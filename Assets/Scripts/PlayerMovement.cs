using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator), typeof(SpriteRenderer))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 5f;
    public float jumpForce = 500f;

    [Header("Respawn")]
    public float fallLimit = -10f;

    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer sr;
    Vector3 startPos;
    bool isGrounded;

        void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
            sr = GetComponent<SpriteRenderer>();
            startPos = transform.position;
            GetComponent<Collider2D>().sharedMaterial = new PhysicsMaterial2D { friction = 0f, bounciness = 0f };
        }

    void Update()
    {
        Jump();
        UpdateAnimator();
        CheckFall();
    }

    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(x * speed, rb.linearVelocity.y);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    void UpdateAnimator()
    {
        Vector2 v = rb.linearVelocity;
        anim.SetFloat("Speed", Mathf.Abs(v.x));
        anim.SetFloat("YVelocity", v.y);
        anim.SetBool("IsGrounded", isGrounded);
        if (Mathf.Abs(v.x) > 0.1f) sr.flipX = v.x < 0;
    }

    void CheckFall()
    {
        if (transform.position.y >= fallLimit) return;
        transform.position = startPos;
        rb.linearVelocity = Vector2.zero;
    }

    void OnCollisionStay2D(Collision2D col)
    {
        foreach (ContactPoint2D contact in col.contacts)
            if (contact.normal.y > 0.5f) isGrounded = true;
    }

    void OnCollisionExit2D(Collision2D col) => isGrounded = false;
}