using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller_Hud : MonoBehaviour
{
    public Text powerUpText;

    private Ammo ammo;

    void Update()
    {
        if (Controller_Shooting.ammo == Ammo.None)
        {
            powerUpText.text = "Gun: None - Ammo: - ";
        }
        else if (Controller_Shooting.ammo == Ammo.Normal)
        {
            powerUpText.text = "Gun: Normal Cannon - Ammo:" + Controller_Shooting.ammunition.ToString();
        }
        else if (Controller_Shooting.ammo == Ammo.Shield)
        {
            powerUpText.text = "Gun: Shield - Ammo:"+ Controller_Shooting.ammunition.ToString();
        }
        else if (Controller_Shooting.ammo == Ammo.Missile)
        {
            powerUpText.text = "Gun: Missile - Ammo:" + Controller_Shooting.ammunition.ToString();
        }
    }
}
