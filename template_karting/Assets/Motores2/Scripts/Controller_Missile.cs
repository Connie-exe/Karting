using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Missile : MonoBehaviour
{
    public GameObject target;
    public float missileSpeed;
    private Rigidbody rb;
    public float lifeSpan;
    private float lifeCounter;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        target = GameObject.Find("Enemy");
    }

    private void Update()
    {
        lifeCounter += Time.deltaTime;
        if (lifeCounter > lifeSpan)
        {
            Destroy(this.gameObject);
        }
    }

    void FixedUpdate()
    {

        if (target != null)
        {
            /*rb.transform.LookAt(Vector3.zero);*/

            rb.AddForce(/*this.transform.forward*/(target.transform.position - transform.position*0.5f) * missileSpeed * Time.deltaTime, ForceMode.Force);
        }
    }
}
