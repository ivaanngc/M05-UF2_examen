using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeContainer : LifeTaker
{
    [Header("Life Settings")]
    public bool invencible = false;
    public int life;
    public int maxLife;
    public int damagePoints;
    public int killPoints;
    public enum OnDie { Destroy, Teleport, RestartScene, Nothing }
    public OnDie onDie;
    public Vector3 teleport;

    protected SpriteRenderer sr;
    public Color damageA = new Color(1, 1, 1, 0.5f);
    public Color damageB = new Color(1, 1, 1, 0.25f);
    Color original;
    public virtual void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        if (sr)
        {
            original = sr.color;
        }
    }
    public void Damage(int damage = 1, bool skipInvencible = false)
    {
        if(!invencible || skipInvencible)
        {
            StartCoroutine(Damage_Corutine());
            life -= damage;
            GameManager.Instance.points += damagePoints;
            if (life <= 0)
            {
                Kill();
            }
        }
    }

    IEnumerator Damage_Corutine()
    {
        invencible = true;


        if (sr)
        {
            sr.color = damageA;
        }
        yield return new WaitForSeconds(0.5f);
        if (sr)
        {
            sr.color = damageB;
        }
        yield return new WaitForSeconds(0.5f);

        if (sr)
        {
            sr.color = damageA;
        }
        yield return new WaitForSeconds(0.5f);
        if (sr)
        {
            sr.color = damageB;
        }
        yield return new WaitForSeconds(0.5f);


        if (sr)
        {
            sr.color = original;
        }
        invencible = false;
    }
    public void Kill()
    {
        GameManager.Instance.points += killPoints;
        switch (onDie)
        {
            case OnDie.Destroy:
                Destroy(gameObject);
                break;
            case OnDie.Teleport:
                life = maxLife;
                transform.position = teleport;
                break;
            case OnDie.RestartScene:
                UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
                break;
            case OnDie.Nothing:
                break;
        }
    }
}
