using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 20f;

    private void Start()
    {
        gameObject.GetComponent<Rigidbody>().velocity = transform.forward * speed;
        transform.parent = null;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}