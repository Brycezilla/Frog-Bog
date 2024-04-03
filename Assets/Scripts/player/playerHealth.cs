using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    AudioManager audioManager;
    public Canvas GameOverUI;
    public int maxHealth;
    public int health;
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    public void playerHit(int damage)
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        health -= damage;
        audioManager.PlaySFX(audioManager.hit);
        if(health <= 0) {
            health = 0;
            gameObject.SetActive(false);
            GameOverUI.enabled = true;
            //audioManager.PlaySFX(audioManager.failure); 
        }
    }
    
}