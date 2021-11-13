//This code is written By Hussain Ghonem BUE ICS Y2 After prep 2020/2021
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    public GameObject health, gold, mission, missionManager;
    public float movespeed = 5f;
    public Rigidbody2D rb;
    public Animator anim;
    public KeyCode shoot;
    public KeyCode slash;
    public KeyCode call;
    public KeyCode MainMenu;
    public bool callFriends;
    Vector2 movement;
    public bool MeleeAttacking;
    public bool RangeAttacking;
    public float damage;
    public GameObject arrow;
    private float waitTime;
    public Transform target;
    public float StartWaitTime;
    // Start is called before the first frame update
    void Start()
    {
        gold = GameObject.FindGameObjectWithTag("GoldUI");
        health = GameObject.FindGameObjectWithTag("HealthUI");
        mission = GameObject.FindGameObjectWithTag("MissionUI");
        missionManager = GameObject.FindGameObjectWithTag("MissionManager");
        MeleeAttacking = false;
        callFriends = false;
        RangeAttacking = false;
    }


    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
        anim.SetFloat("Speed", movement.sqrMagnitude);
        float s = anim.GetFloat("Speed");
        if (s <= 0.1)
        {
            MeleeAttacking = false;
            RangeAttacking = false;
            anim.SetBool("RangeAttacking", RangeAttacking);
            anim.SetBool("MeleeAttacking", MeleeAttacking);
        }
        if (Input.GetKeyDown(shoot))
        {
            MeleeAttacking = false;
            RangeAttacking = true;
            anim.SetBool("RangeAttacking", RangeAttacking);
            anim.SetBool("MeleeAttacking", MeleeAttacking);
            Shoot();
        }
        if (Input.GetKeyDown(MainMenu))
        {
            gold.SetActive(false);
            health.SetActive(false);
            mission.SetActive(false);
            missionManager.GetComponent<missionManager>().currentmission = 0;
            missionManager.GetComponent<missionManager>().gold = 0;
            missionManager.GetComponent<missionManager>().wolves = 0;
            missionManager.GetComponent<missionManager>().strawberies = 0;
            UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
        }
        if (Input.GetKeyDown(call))
        {
            if (!callFriends)
            {
                callFriends = true;
            }else if (callFriends)
            {
                callFriends = false;
            }
        }
        if (Input.GetKeyDown(slash))
        {
            MeleeAttacking = true;
            RangeAttacking = false;
            anim.SetBool("RangeAttacking", RangeAttacking);
            anim.SetBool("MeleeAttacking", MeleeAttacking);
            Slash();
        }
    }

    private void Shoot()
    {
        Vector2 shootingDirection = new Vector2(movement.x, movement.y);
        shootingDirection.Normalize();
        GameObject arrowshot = Instantiate(arrow, transform.position, Quaternion.identity);
        arrowshot.GetComponent<PlayerArrows>().Speed = shootingDirection*5f;
        arrowshot.transform.Rotate(0f, 0f, Mathf.Atan2(-shootingDirection.x, shootingDirection.y) * Mathf.Rad2Deg);
        Destroy(arrowshot, 2f);
    }
    private void Slash()
    {
        if (MeleeAttacking)
        {
            if(Vector2.Distance(transform.position, target.position) < 1.5f)
            {
                if (MeleeAttacking)
                {
                    if (target != null)
                    {
                        if (target.tag == "Enemy")
                        {
                            target.GetComponent<AIStats>().takeDamage(damage);
                        }
                    }
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            target = other.transform;
        }
    }
        void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * movespeed * Time.fixedDeltaTime);
    }
}
