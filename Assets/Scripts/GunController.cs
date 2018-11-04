using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {

    public bool isFiring;
    public float fireRate;
    public float timeToDespawn;

    private float shotCounter;

    public BulletController bullet;
    public float bulletSpeed;

    public Transform firePoint;
	
	// Update is called once per frame
	void Update () {
        if(isFiring) {
            shotCounter -= Time.deltaTime;
            if(shotCounter <= 0) {
                shotCounter = fireRate;
                BulletController newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as BulletController;
                newBullet.bulletSpeed = bulletSpeed;
                Destroy(newBullet.gameObject, timeToDespawn);
            }
        } else {
            shotCounter = 0;
        }
	}
}
