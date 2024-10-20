using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    [SerializeField] ParticleSystem movementParticle;

    [Range(0, 10)]

    [SerializeField] int occurAfterVelocity;

    [Range (0,0.2f)]
    [SerializeField] float dustFormationPeriod;

    [SerializeField] Rigidbody2D playerRb;

    float counter;

    private void Update()
    {
        counter += Time.deltaTime;

        if (counter > dustFormationPeriod)
        {
            movementParticle.Play();
            counter = 0;
        }
        /*if(Mathf.Abs(playerRb.velocity.x) > occurAfterVelocity)
        {
            Debug.Log("2");
            if (counter > dustFormationPeriod)
            {
                Debug.Log("3");
                movementParticle.Play();
                counter = 0;
            }
        }*/
    }
}
