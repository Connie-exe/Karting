using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float xLimit = 30;
    public float yLimit = 20;
    private SphereCollider sphereCollider;

    private float colliderTimer = 0.07f;

    private void Start()
    {
        sphereCollider = GetComponent<SphereCollider>();
        sphereCollider.enabled = false;
    }

    virtual public void Update()
    {
        colliderTimer -= Time.deltaTime;
        if (colliderTimer < 0)
        {
            sphereCollider.enabled = true;
        }
        //CheckLimits();
    }

    internal virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall")|| collision.gameObject.CompareTag("PowerUp"))
        {
            Destroy(this.gameObject);
        }
    }

    internal virtual void CheckLimits()
    {
        if (this.transform.position.x > xLimit)
        {
            Destroy(this.gameObject);
        }
        if (this.transform.position.x < -xLimit)
        {
            Destroy(this.gameObject);
        }
        if (this.transform.position.z > yLimit)
        {
            Destroy(this.gameObject);
        }
        if (this.transform.position.z < -yLimit)
        {
            Destroy(this.gameObject);
        }

    }
}
