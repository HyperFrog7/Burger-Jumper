using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Rigidbody2D))]
public class MovingPlatform : MonoBehaviour
{
    [SerializeField, Min(0f)] float speed = 2f;
    [SerializeField, Min(0.01f)] float travelTime = 2f;
    [SerializeField] bool startRight = true;
    [SerializeField] string riderTag = "Player";
    [SerializeField, Range(0.1f, 1f)] float minTopNormal = 0.5f;

    Rigidbody2D rb;
    Vector2 origin;
    float elapsed;

    readonly Dictionary<Transform, Transform> riders = new Dictionary<Transform, Transform>();

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.interpolation = RigidbodyInterpolation2D.Interpolate;
        origin = rb.position;
    }

    void FixedUpdate()
    {
        elapsed = Mathf.Repeat(elapsed + Time.fixedDeltaTime, travelTime * 2f);
        float offset = Mathf.PingPong(elapsed * speed, speed * travelTime);
        float sign = startRight ? 1f : -1f;
        rb.MovePosition(origin + Vector2.right * (sign * offset));
    }

    void OnCollisionEnter2D(Collision2D c) => TryBoard(c);
    void OnCollisionStay2D(Collision2D c) => TryBoard(c);

    void OnCollisionExit2D(Collision2D c)
    {
        Transform rider = GetRider(c);
        if (rider == null || !riders.TryGetValue(rider, out Transform previous)) return;

        riders.Remove(rider);
        if (rider.parent == transform)
            rider.SetParent(previous, true);
    }

    void TryBoard(Collision2D c)
    {
        if (c.collider == null || !c.collider.CompareTag(riderTag)) return;

        Transform rider = GetRider(c);
        if (rider == null || rider.parent == transform || !IsOnTop(c)) return;

        riders[rider] = rider.parent;
        rider.SetParent(transform, true);
    }

    bool IsOnTop(Collision2D c)
    {
        for (int i = 0; i < c.contactCount; i++)
            if (c.GetContact(i).normal.y <= -minTopNormal) return true;
        return false;
    }

    static Transform GetRider(Collision2D c)
    {
        if (c.rigidbody != null) return c.rigidbody.transform;
        return c.collider != null ? c.collider.transform : null;
    }
}