using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.TryGetComponent<BasicEnemy>(out BasicEnemy enemyComponent))
        {
            enemyComponent.TakeDamage(1);
        }
        Destroy(gameObject);    
    }
}
