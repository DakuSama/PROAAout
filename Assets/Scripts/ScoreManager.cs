using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreManager : MonoBehaviour
{
    int score = 0;

    public TMP_Text scoreText;

    public PickupSpawner pickupSpawner;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Pickup")
        {
            score++;
            //Handheld.Vibrate();
            GameManager.instance.currentScore++;
            AudioManager.instance.PlaySFX("Pickup");
            pickupSpawner.DownCountPickup();
            scoreText.text = "Current Score : " + score.ToString();
            Destroy(collision.gameObject);
        }
    }
}
