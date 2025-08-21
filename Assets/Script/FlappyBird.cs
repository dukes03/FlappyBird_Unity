using UnityEngine;

public class FlappyBird : MonoBehaviour
{
    [SerializeField] private float mass= 100;
    [SerializeField] private float gravity = 10;
    [SerializeField] private float velocityFly = 7.5f;
    private Rigidbody2D rigidbody2D;
    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        Physics2D.gravity = Vector2.down * gravity;
        rigidbody2D.mass = mass;
    }
    public void Fly()
    {
    rigidbody2D.linearVelocityY = velocityFly;
      // rigidbody2D.AddForceY ( velocityFly);
    }
}
