using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : LifeContainer
{
    public float playerDistanceMin;
    protected Player player;

    public override void Start()
    {
        base.Start();
        player = GameManager.Instance.player;
    }

    protected float PlayerDistance()
    {
        return Vector3.Distance(player.transform.position, transform.position);
    }
}
