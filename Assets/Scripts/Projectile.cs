using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    bool shotProjectile;
    float projectileTimer;
    public float shotDelay = 4.0f;

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }
    
    public void Launch(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force);
        projectileTimer = shotDelay;
        shotProjectile = true;
    }
    
    void Update()
    {
        if (shotProjectile)
        {
            projectileTimer -= Time.deltaTime;
            if (projectileTimer < 0){
                Destroy(gameObject);
            }
        }
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        EnemyController e = other.collider.GetComponent<EnemyController>();
        if (e != null)
        {
            e.Fix();
        }
    
        Destroy(gameObject);
    }
}