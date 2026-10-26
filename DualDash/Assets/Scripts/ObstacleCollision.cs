
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.EndGame();
            }
        }
    }
}
