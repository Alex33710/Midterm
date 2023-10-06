using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public Transform spawnBulletHere;
    public GameObject bulletPrefab;
    public float bulletSpeed;
    public float fireRate = 10;
    private float BaseFireRate;
    public GameObject RedPlayer, GreenPlayer, BluePlayer;
    public float colorCount;
    

    void Start()
    {
        BaseFireRate = fireRate;
        colorCount = 0;
    }

    void Update()
    {
        fireRate -= Time.deltaTime;
        if (fireRate<=0)
        {
            Shoot();
        }
        if (Input.GetButtonDown("Fire1"))
        {
            ChangeColor();
        }

    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, spawnBulletHere.position, spawnBulletHere.rotation);
        Rigidbody bulletRB = bullet.GetComponent<Rigidbody>();
        bulletRB.AddForce(spawnBulletHere.forward * bulletSpeed, ForceMode.Impulse);
        fireRate = BaseFireRate;
    }

    void ChangeColor()
    {
        colorCount++;
        if (colorCount % 3 == 0)
         {
           RedPlayer.SetActive(true);
           GreenPlayer.SetActive(false);
           BluePlayer.SetActive(false);
        }
        else if (colorCount % 3 == 1)
        {
            RedPlayer.SetActive(false);
            GreenPlayer.SetActive(true);
            BluePlayer.SetActive(false);
        }
        else 
        {
            RedPlayer.SetActive(false);
            GreenPlayer.SetActive(false);
            BluePlayer.SetActive(true);
        }
    }

    
}
