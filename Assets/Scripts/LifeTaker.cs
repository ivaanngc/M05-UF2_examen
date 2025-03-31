using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTaker : MonoBehaviour
{
    [Header("Damage Settings")]
    public int damage;
    public bool skipInvencible = false;
    public string tagTarget;
    public bool destroyOnAttack;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(string.IsNullOrWhiteSpace(tagTarget) || collision.CompareTag(tagTarget))
        {
            if (damage > 0)
            {
                collision.GetComponent<LifeContainer>().Damage(damage, skipInvencible);
            }
            if(destroyOnAttack)
            {
                Destroy(gameObject);
            }
        }
    }
}
