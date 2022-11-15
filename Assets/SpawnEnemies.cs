using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject basicEnemySpawn;
    public GameObject shootingEnemySpawn;
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Enemies spawned!");
        Instantiate(basicEnemySpawn);
        Instantiate(shootingEnemySpawn);
    }
}
