using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Controller_Enemy : MonoBehaviour
{
    //public float enemySpeed;

    private bool powerUp;

    internal GameObject player;
    internal NavMeshAgent agent;

    //public float patrolDistance = 5;

    internal Vector3 destination;
    //public float destinationTime = 4;

    private bool canMove = false;

    IEnumerator CountdownThenStartRaceRoutine()
    {
        yield return new WaitForSeconds(3f);
        StartRace();
    }

    private void StartRace()
    {
        canMove = true;
    }

    void Start()
    {
        destination = new Vector3(UnityEngine.Random.Range(-10, 12), 1, UnityEngine.Random.Range(-12, 9));
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player");
        StartCoroutine(CountdownThenStartRaceRoutine());
    }

    public void Reset()
    {
        Destroy(this.gameObject);
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            if (player != null)
            {
                agent.SetDestination(player.transform.position);
            }
        }

    }

    void Update()
    {
        if (powerUp)
        {
            ShootPlayer();
        }
        else
        {
            GeneratePowerUp();
            //SearchPU();
        }
    }

    private void GeneratePowerUp()
    {
        //throw new NotImplementedException();
    }

    private void SearchPU()
    {
        //Buscar power up.
    }

    void ShootPlayer()
    {
        if (player != null)
        {
            //Diferenciar los diferentes powerUps y dispararlos.
            //Instantiate(enemyProjectile, transform.position, Quaternion.identity);
            
        }
    }


    internal virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
        //if (collision.gameObject.CompareTag("CannonBall"))
        //{
        //    Destroy(this.gameObject);
        //}
        //if (collision.gameObject.CompareTag("Bumeran"))
        //{
        //    Destroy(this.gameObject);
        //}

    }

}

