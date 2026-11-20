using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed = 2f;
    public float travelTime = 2f; 
    public bool startRight = true;

    Rigidbody2D rb;
    float dir;
    float timer;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        dir = startRight ? 1f : -1f;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + Vector2.right * dir * speed * Time.fixedDeltaTime);

        timer += Time.fixedDeltaTime;
        if (timer >= travelTime) { timer = 0f; dir = -dir; }
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.collider.CompareTag("Player") && c.GetContact(0).normal.y < -0.5f)
            c.transform.SetParent(transform);
    }

    void OnCollisionExit2D(Collision2D c)
    {
        if (c.collider.CompareTag("Player"))
            c.transform.SetParent(null);
    }
}