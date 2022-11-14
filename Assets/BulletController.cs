using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float lifeTime;

    void Start()
    {
        StartCoroutine(DestroyDelay());
    }

    void Update()
    {
        
    }

    IEnumerator DestroyDelay() {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}
