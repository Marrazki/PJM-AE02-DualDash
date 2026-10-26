
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    [Header("Movimiento")]
    public float speed = 6f;

    void Update()
    {
        // El obstáculo se mueve hacia la izquierda.
        transform.position += Vector3.left * speed * Time.deltaTime;

        // Destruirlo cuando salga de la pantalla.
        if (transform.position.x < -12f)
        {
            Destroy(gameObject);
        }
    }
}
