//This code is written By Hussain Ghonem BUE ICS Y2 After prep 2020/2021
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArrows : MonoBehaviour
{
    public float Speed;
    private Transform Victim;
    private Vector2 Target;
    private float waitTime;
    private float StartWaitTime;
    public float damage;
    // Start is called before the first frame update
    void Start()
    {
        damage = 3;
        StartWaitTime = 2f;
        waitTime = StartWaitTime;
        Victim = GameObject.FindGameObjectWithTag("Friends").transform;
        Target = new Vector2(Victim.position.x, Victim.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (waitTime <= 0)
        {
            Destroy(gameObject);
            waitTime = StartWaitTime;
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, Target, Speed * Time.deltaTime);
            waitTime -= Time.deltaTime;
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Friends") || other.CompareTag("Player"))
        {
            if (other.CompareTag("Friends"))
            {
                if (Vector2.Distance(transform.position, other.transform.position) < 1f)
                {
                    other.gameObject.GetComponent<AIStats>().takeDamage(damage);
                    Destroy(gameObject);
                }
            }
            else if (other.CompareTag("Player"))
            {
                if (Vector2.Distance(transform.position, other.transform.position) < 1f)
                {
                    other.gameObject.GetComponent<PlayerStats>().takeDamage(damage);
                    Destroy(gameObject, 3f);
                }
            }
        }
        else if (other.CompareTag("Enemy")) {

        }
        else
        {
            Destroy(this.gameObject);
        }
    }

}
