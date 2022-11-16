using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject basicEnemy;
    //[SerializeField] private GameObject shootingEnemy;
    [SerializeField] private float basicEnemyInterval = 3.5f;
    //[SerializeField] private float shootingEnemyInterval = 5f;

    void Start()
    {
        StartCoroutine(spawnEnemy(basicEnemyInterval, basicEnemy));
        //StartCoroutine(spawnEnemy(shootingEnemyInterval, shootingEnemy));
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-5f, 5), Random.Range(-5f, 5f), 0), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}
