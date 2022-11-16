using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePoint;
    public float fireForce;
    public int currentClip, maxClipSize = 10, currentAmmo, maxAmmoSize = 100;
    
    public void Start() 
    {
        currentAmmo = maxAmmoSize;
        currentClip = maxClipSize;
    }

    public void Fire()
    {
        if(currentClip > 0)
        {
            GameObject projectile = Instantiate(bullet, firePoint.position, firePoint.rotation);
            projectile.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);    
            currentClip--;
        }

    }

    public void Reload()
    {
        int reloadAmount = maxClipSize - currentClip; //how many bullets to refill clip

        if(currentAmmo >= reloadAmount)
        {
            currentClip += reloadAmount;
            currentAmmo -= reloadAmount;
        }
        
    }

    public void AddAmmo(int ammoAmount)
    {
        currentAmmo += ammoAmount;

        if(currentAmmo > maxAmmoSize)
        {
            currentAmmo = maxAmmoSize;   
        }
    }
}
