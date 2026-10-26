
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [Header("Configuración del salto")]
    public bool isTopPlayer = true;
    public float jumpForce = 7f;

    private Rigidbody2D rb;
    public bool canJump = true;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;

        // Arriba: gravedad hacia abajo.
        // Abajo: gravedad hacia arriba.
        rb.gravityScale = isTopPlayer ? 1.5f : -1.5f;
    }

    public void Jump()
    {
        if (!canJump) return;

        rb.linearVelocity = new Vector2(
            rb.linearVelocity.x,
            isTopPlayer ? jumpForce : -jumpForce
        );

        canJump = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("FLOOR"))
        {
            canJump = true;
        }
    }
}
