using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Shield1 : MonoBehaviour
{
    public float rotationValue;
    public GameObject shieldPrefab;
    public List<Transform> shieldPositions = new List<Transform>();
    public Shield[] shields = new Shield[4];

    private void Start()
    {
        //shields = new List<Shield>();
    }

    public void ActivateShields()
    {
        for(int i = 0; i < 4; i++)
        {
             if (shields[i] == null)
             {
                Shield sh = Instantiate(shieldPrefab, shieldPositions[i]).GetComponent<Shield>();
                shields[i] = sh;
             }
        }
    }

    void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, rotationValue, 0));
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            for (int i = 0; i < 4; i++)
            {
                if (shields[i] != null)
                {
                    shields[i].AutoDestruction();
                }
            }
        }
    }
}
