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
    public Renderer mr;
    public float colorCount;
    //public GameObject Parent = GameObject.Find("GreenPlayer");
    //public int x;
    public GameObject Nozzle;
    public GameObject Cube;

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
            changeColor();
        }

    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, spawnBulletHere.position, spawnBulletHere.rotation);
        Rigidbody bulletRB = bullet.GetComponent<Rigidbody>();
        bulletRB.AddForce(spawnBulletHere.forward * bulletSpeed, ForceMode.Impulse);
        fireRate = BaseFireRate;
    }

    void changeColor()
    {
        colorCount++;
        mr = GetComponent<Renderer>();
        if (colorCount % 3 == 0)
         {
            mr.material.color = Color.red;
            Rigidbody Cube = Cube.GetComponent<Renderer>().material.color = Color.red;
            Nozzle.GetComponent<Renderer>().material.color = Color.red;

        }
        else if (colorCount % 3 == 1)
        {
            mr.material.color = Color.green;
            Cube.GetComponent<Renderer>().material.color = Color.green;
            Nozzle.GetComponent<Renderer>().material.color = Color.green;

        }
        else
        {
            mr.material.color = Color.blue;
            Cube.GetComponent<Renderer>().material.color = Color.blue;
            Nozzle.GetComponent<Renderer>().material.color = Color.blue;

        }
    }

    
}