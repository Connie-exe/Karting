using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject missilePrefab;


    public float bulletForce = 20f;

    public static Ammo ammo;

    public static int ammunition;

    public static Controller_Shooting _ShootingPlayer;

    private bool started = false;

    private bool canShoot = false;

    private bool hasPU = false;

    public Controller_Shield1 shieldController;

    IEnumerator CountdownThenStartRaceRoutine()
    {
        yield return new WaitForSeconds(3f);
        StartRace();
    }

    private void StartRace()
    {
        canShoot = true;
    }


    private void Awake()
    {
        if (_ShootingPlayer == null)
        {
            _ShootingPlayer = this.gameObject.GetComponent<Controller_Shooting>();

        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        if (_ShootingPlayer == null)
        {
            _ShootingPlayer = this.gameObject.GetComponent<Controller_Shooting>();

            //DontDestroyOnLoad(_Player);
        }
        firePoint.position = firePoint.position + Vector3.forward;
        //Restart._Restart.OnRestart += Reset;
        started = true;
        //ammo = Ammo.Shield;
        //ammunition = 2;
        StartCoroutine(CountdownThenStartRaceRoutine());
    }

    private void OnEnable()
    {
        //if(started)
            //Restart._Restart.OnRestart += Reset;
    }

    //public void Respawn()
    //{
    //    ammo = Ammo.Bumeran;
    //    ammunition = 1;
    //}

    private void Reset()
    {
        ammo = Ammo.Normal;
        ammunition = 1;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
            CheckAmmo();
        }
    }

    private void CheckAmmo()
    {
        if (ammunition <= 0)
        {
            ammo = Ammo.None;
            hasPU = false;
        }
    }

    private void Shoot()
    {
        if (canShoot)
        {
            if (ammunition > 0)
            {
                if (ammo == Ammo.Normal)
                {
                    GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                    Rigidbody rb = bullet.GetComponent<Rigidbody>();
                    rb.AddForce(firePoint.forward * bulletForce, ForceMode.Impulse);
                    ammunition--;
                }
                else if (ammo == Ammo.Missile)
                {
                    GameObject missile = Instantiate(missilePrefab, firePoint.position, firePoint.rotation);
                    Rigidbody rb = missile.GetComponent<Rigidbody>();
                    rb.AddForce(firePoint.forward * (bulletForce / 2), ForceMode.Impulse);
                    ammunition--;
                }
                else if (ammo == Ammo.Shield)
                {
                    shieldController.ActivateShields();
                    ammunition--;
                }
            }
        }
    }

    private void OnDisable()
    {
        //Restart._Restart.OnRestart -= Reset;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!hasPU)
        
            if (collision.gameObject.CompareTag("ShieldPU"))
            {
                Destroy(collision.gameObject);
                if (!hasPU)
                {
                    ammo = Ammo.Shield;
                    ammunition = 1;
                    hasPU = true;
                }
                
            }
            if (collision.gameObject.CompareTag("MissilePU"))
            {
                Destroy(collision.gameObject);
            if (!hasPU)
            {
                ammo = Ammo.Missile;
                ammunition = 1;
                hasPU = true;
            }
                
            }
            if (collision.gameObject.CompareTag("CannonPU"))
            {
                Destroy(collision.gameObject);
                if (!hasPU)
                {
                ammo = Ammo.Normal;
                ammunition = 2;
                hasPU = true;
            }
                
            }
        }
    
}

public enum Ammo
{
    None,
    Normal,
    Shield,
    Missile
}
