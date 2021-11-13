//This code is written By Hussain Ghonem BUE ICS Y2 After prep 2020/2021
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArrows : MonoBehaviour
{
    public Vector2 Speed = new Vector2(0f, 0f);
    public float damage;
    public GameObject missionManager;
    // Start is called before the first frame update
    void Start()
    {
        missionManager = GameObject.FindGameObjectWithTag("MissionManager");
        damage = 3;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 currentPosition = new Vector2(transform.position.x, transform.position.y);
        Vector2 newPosition = currentPosition + Speed * Time.deltaTime;
        transform.position = newPosition;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy")||other.CompareTag("Wolf"))
        {
            if (other.CompareTag("Enemy"))
            {
                if (Vector2.Distance(transform.position, other.transform.position) < 1f)
                {
                    other.gameObject.GetComponent<AIStats>().takeDamage(damage);
                    Destroy(gameObject);
                }
            }else if (other.CompareTag("Wolf"))
            {

                missionManager.GetComponent<missionManager>().HuntWolves(); 
                Destroy(other.gameObject);
            }
        }
        else if (!other.CompareTag("Player") && !other.CompareTag("Friends"))
        {
            Destroy(gameObject);
        }
    }
}
