//This code is written By Hussain Ghonem BUE ICS Y2 After prep 2020/2021
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject missionManager;
    public int currentmission;
    public float health;  
    public float flickerTime;
    public float flickerDuration;
    public bool isimmune;
    public float immunityTime;
    public float immunityDuration;
    public KeyCode endgame;
    public GameObject gameover;
    public GameObject victory;
    private SpriteRenderer spriterenderer;

    // Missions number : 1- Talk to Karim and Trader 2-Collect strawberries 3- hunt wolves 4- give soad gold
    void Start()
    {      
        health = 45;

        flickerDuration = 0.5f;
        flickerTime = flickerDuration;
        isimmune = false;
        immunityDuration = 3f;

        spriterenderer = gameObject.GetComponent<SpriteRenderer>();
    }
    void spriteflicker()
    {
        if (flickerTime < flickerDuration)
        {
            flickerTime = flickerTime * Time.deltaTime;
        }
        else if (flickerTime >= flickerDuration)
        {
            spriterenderer.enabled = !(spriterenderer.enabled);
            flickerTime = 0;
        }
    }  
        
    public void takeDamage(float damage)
    {
        if (!isimmune)
        {
            PlayHitReaction();
            health = health - damage;
            if (health == 0 || health < 0)
            {
                gameover.SetActive(true);
                Destroy(this.gameObject);
            }
        }
    }
    public void victroyscene()
    {
        victory.SetActive(true);
        Destroy(this.gameObject);
    }
    void PlayHitReaction()
    {
        isimmune = true;
        immunityTime = 0f;
    }    
    // Update is called once per frame
    void Update()
    {
        if (currentmission >= 14 && (Input.GetKeyDown(endgame)))
        {
            victroyscene();
        }            
            missionManager = GameObject.FindGameObjectWithTag("MissionManager");
        if (isimmune)
        {
            if (immunityTime < immunityDuration)
            {
                spriteflicker();
                immunityTime = immunityTime + Time.deltaTime;
                spriterenderer.enabled = true;
            }
            else if (immunityTime >= immunityDuration)
            {
                isimmune = false;
            }
        }
       currentmission = missionManager.GetComponent<missionManager>().currentmission;
    }
}
