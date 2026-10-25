
using UnityEngine;
using static UnityEngine.LowLevelPhysics2D.PhysicsShape;

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

        // Sin gravedad al iniciar: los personajes no se alejan.
        rb.gravityScale = -1f;
        rb.freezeRotation = true;

        if (isTopPlayer)
            rb.gravityScale = 1.5f;

        if (!isTopPlayer)
            rb.gravityScale = -1.5f;
    }


    void Update()
    {
        // Solo permite saltar si está apoyado.
        if (canJump && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    public void Jump()
    {
        if (!canJump) return;

        // Impulso alejándose del suelo central.
        rb.linearVelocity = new Vector2(
            rb.linearVelocity.x,
            isTopPlayer ? jumpForce : -jumpForce
        );

        canJump = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        CheckGround(collision);
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        CheckGround(collision);
    }

    void CheckGround(Collision2D collision)
    {
        foreach (ContactPoint2D contact in collision.contacts)
        {
            // La normal indica en qué lado está el suelo.
            if (isTopPlayer && contact.normal.y < -0.5f)
                canJump = true;

            if (!isTopPlayer && contact.normal.y > 0.5f)
                canJump = true;
        }
    }
}
