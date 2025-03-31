using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : LifeContainer
{
    [Header("Player Settings")]
    public float movementSpeed;
    public float fixedSpeed;
    public float maxRotation;
    Vector3 lastPos;
    Rigidbody2D rb;
    public GameObject bala;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        GameManager.Instance.player = this;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        #region MOVEMENT

        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        horizontal += 1.25f;
        transform.position += new Vector3(horizontal * fixedSpeed, vertical * movementSpeed) * Time.deltaTime;

        #endregion MOVEMENT


        #region VISUALS

        Vector2 speed = rb.velocity;
        speed.y += vertical;

        if(speed.y > 0)
        {
            transform.localEulerAngles = new Vector3(0, 0, Mathf.Lerp(0, maxRotation, speed.y));
        }
        else
        {
            transform.localEulerAngles = new Vector3(0, 0, Mathf.Lerp(0, -maxRotation, -speed.y));
        }

        #endregion VISUALS

        lastPos = transform.position;

        if (Input.GetButtonDown("Fire"))
        {
            GameObject objeto = Instantiate(bala, transform.position, transform.rotation = Quaternion.Euler(0, 0, -90));
            objeto.GetComponent<Rigidbody2D>().velocity = transform.up * 25;
            Destroy(objeto, 2);
        }
    }
}
