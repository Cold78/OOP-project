using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxController : PlayerController
{
    public float dashSpeed;
    public float dashTime;
    public ParticleSystem dirtSplatter;



    public override void PLayerSkills()
    {
        if( Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Dash());
        }
    }

    IEnumerator Dash()
    {
        float startTime = Time.time;

        while(Time.time < startTime + dashTime)
        {
            characterController.Move(movementDirection * dashSpeed * Time.deltaTime);
            playerAnim.SetFloat("Speed_f", 1.0f);
            dirtSplatter.Play();
            yield return null;
        }
    }
}
