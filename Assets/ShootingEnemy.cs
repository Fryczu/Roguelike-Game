using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    public float enemySpeed;
    public float stoppingDistance;
    public float retreatDistance;
    public Transform player;
    
    public float lastFire;
    public float fireDelay;
    public GameObject bulletPrefab;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        lastFire = fireDelay;

    }

    void Update() {
        if(Vector2.Distance(transform.position, player.position) > stoppingDistance) {

            transform.position = Vector2.MoveTowards(transform.position, player.position, enemySpeed * Time.deltaTime);
        
        } else if(Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance) {
            
            transform.position = this.transform.position;
        
        } else if(Vector2.Distance(transform.position, player.position) < retreatDistance) {
            
            transform.position = Vector2.MoveTowards(transform.position, player.position, -enemySpeed * Time.deltaTime);
        
        }

        if(lastFire <= 0) {
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            lastFire = fireDelay;
        } else {
            lastFire -= Time.deltaTime;
        }
    }
}
