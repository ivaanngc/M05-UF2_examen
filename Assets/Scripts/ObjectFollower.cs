using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFollower : MonoBehaviour
{
    public Vector3 offset;
    public Vector3 scale = Vector3.one;
    public float speed;
    public Transform target;

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, Vector3.Scale(target.position + offset, scale), speed * Time.deltaTime);
    }
}
