using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStats : MonoBehaviour
{
    public float health;
    public float flickerTime;
    public float flickerDuration;
    public bool isimmune;
    public float immunityTime;
    public float immunityDuration;
    private SpriteRenderer spriterenderer;

    // Start is called before the first frame update
    void Start()
    {
        flickerDuration = 0.5f;
        flickerTime = flickerDuration;
        isimmune = false;
        immunityDuration = 3f;
        immunityTime = immunityDuration;
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
    void PlayHitReaction()
    {
        isimmune = true;
        immunityTime = 0f;
    }
    public void takeDamage(float damage)
    {
        if (!isimmune)
        {
            PlayHitReaction();
            health = health - damage;
            if (health == 0 || health < 0)
            {
                Destroy(gameObject);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {

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
    }
}
