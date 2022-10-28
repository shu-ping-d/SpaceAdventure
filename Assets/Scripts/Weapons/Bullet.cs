using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime;
    public float moveSpeed;
    private Rigidbody2D rb;
    InGameUIController exp;
    // Start is called before the first frame update
    void Awake()
    {
        exp = GetComponent<InGameUIController>();
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject , lifeTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            exp.addEXP(100);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
    public void SetVelocity(Vector2 dir)
    {
        rb.velocity = dir.normalized * moveSpeed * Time.deltaTime;
    }
}
