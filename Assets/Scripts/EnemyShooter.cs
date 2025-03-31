using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : Enemy
{
    public GameObject bullet;
    public float bulletSpeed;
    public float bulletTimer;
    float bulletTimerCurrent;

    public override void Start()
    {
        base.Start();
    }
    void Update()
    {
        Vector3 playerPos = player.transform.position;
        float playerDistance = PlayerDistance();

        transform.rotation = Quaternion.Euler(0, 0, 90);

        if(bulletTimerCurrent < Time.time)
        {
            GameObject temp = Instantiate(bullet, transform.position, transform.rotation);
            temp.GetComponent<Rigidbody2D>().velocity = transform.up * bulletSpeed;
            Destroy(temp, 20);
            bulletTimerCurrent = Time.time + bulletTimer;
        }
    }
}
