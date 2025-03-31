using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollower : Enemy
{
    public float speed;
    public override void Start()
    {
        base.Start();
    }
    private void Update()
    {
        Vector3 playerPos = player.transform.position;
        float playerDistance = PlayerDistance();
    }
}
