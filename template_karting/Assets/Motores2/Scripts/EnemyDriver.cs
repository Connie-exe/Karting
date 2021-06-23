using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KartGame.KartSystems;
using System;

public class EnemyDriver : ArcadeKart
{
    public GameObject player;

    public float acceleration=0,turnAngle=0;

    public override void GatherInputs()
    {
        // reset input
        Input = Vector2.zero;

        // gather nonzero input from our sources
        for (int i = 0; i < m_Inputs.Length; i++)
        {
            var inputSource = m_Inputs[i];
            Vector2 current = inputSource.GenerateInput();
            if (current.sqrMagnitude > 0)
            {
                Input = current;
            }
        }
        CheckDistance();
        CheckAngle();

        Input = new Vector2(CheckAngle(),CheckDistance());

    }

    private float CheckAngle()
    {
        if (player != null)
        {
            Vector3 vectorAngle = -(this.transform.localPosition - player.transform.localPosition);
            turnAngle=Vector3.Angle(this.transform.position, vectorAngle);
            Vector2 normalizeAngle = new Vector2(turnAngle, turnAngle).normalized;
            turnAngle = normalizeAngle.y;
        }
        return turnAngle;
    }

    private float CheckDistance()
    {
        float distance = (this.transform.position - player.transform.position).magnitude;
        if (distance > 2)
        {
            acceleration = 0;
        }
        else
        {
            acceleration = 1;
        }
        return acceleration;
    }
}
