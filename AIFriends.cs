//This code is written By Hussain Ghonem BUE ICS Y2 After prep 2020/2021
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIFriends : MonoBehaviour
{
    private Transform target;
    public bool followHussain;
    public float Speed;
    Vector2 movement;
    public Rigidbody2D rb;
    public Animator anim;
    public int damage;
    public bool Triggered;
    public bool MeleeAttacking;
    public bool RangeAttacking;
    public char attackingType; //A for archer, M for melee
    public float retreatDistance;
    public float stopDistance;
    private float waitTime;
    public float StartWaitTime;
    public GameObject Hussain;
    public GameObject arrow;

    // Start is called before the first frame update
    void Start()
    {
        followHussain = false;
        Hussain = GameObject.FindWithTag("Player");
        waitTime = StartWaitTime;
        MeleeAttacking = false;
        RangeAttacking = false;
        Triggered = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Triggered = false;
            MeleeAttacking = false;
            RangeAttacking = false;
            if (attackingType == 'M')
            {
                anim.SetBool("MeleeAttacking", MeleeAttacking);
            }
            else if (attackingType == 'A')
            {
                anim.SetBool("RangeAttacking", RangeAttacking);
            }
        }
        if (Triggered)
        {
            if (attackingType == 'M')
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, Speed * Time.deltaTime);
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, Speed * Time.deltaTime);
                if (Vector2.Distance(transform.position, target.position) < 1f)
                {
                    MeleeAttacking = true;
                    anim.SetBool("MeleeAttacking", MeleeAttacking);
                    senddamage();
                }
                else if (Vector2.Distance(transform.position, target.position) > 1f)
                {
                    MeleeAttacking = false;
                    anim.SetBool("MeleeAttacking", MeleeAttacking);
                    transform.position = Vector2.MoveTowards(transform.position, target.position, Speed * Time.deltaTime);
                }
                rb.MovePosition(temp);
                changeAnim(temp - transform.position);
            }

            if (attackingType == 'A')
            {
                StartWaitTime = 3f;
                if (Vector2.Distance(transform.position, target.position) > stopDistance)
                {
                    transform.position = Vector2.MoveTowards(transform.position, target.position, Speed * Time.deltaTime);
                    Vector3 temp = Vector3.MoveTowards(transform.position, target.position, Speed * Time.deltaTime);
                    rb.MovePosition(temp);
                    changeAnim(temp - transform.position);
                }
                else if (Vector2.Distance(transform.position, target.position) > retreatDistance && Vector2.Distance(transform.position, target.position) < stopDistance)
                {
                    if (waitTime <= 0)
                    {
                        RangeAttacking = true;
                        anim.SetBool("RangeAttacking", RangeAttacking);
                        Instantiate(arrow, transform.position, Quaternion.identity);
                        waitTime = StartWaitTime;
                    }
                    else
                    {
                        waitTime -= Time.deltaTime;
                    }
                    transform.position = this.transform.position;
                    Vector3 temp = this.transform.position;
                    rb.MovePosition(temp);
                    changeAnim(temp - transform.position);
                }
                else if (Vector2.Distance(transform.position, target.position) < retreatDistance)
                {
                    transform.position = Vector2.MoveTowards(transform.position, target.position, -Speed * Time.deltaTime);
                    Vector3 temp = Vector3.MoveTowards(transform.position, target.position, -Speed * Time.deltaTime);
                    rb.MovePosition(temp);
                    changeAnim(temp - transform.position);
                }

            }
        }else if (!Triggered)
        {
            if (Hussain.GetComponent<playermovement>().callFriends)
            {
                transform.position = Vector2.MoveTowards(transform.position, Hussain.transform.position, Speed * Time.deltaTime);
                Vector3 temp = Vector3.MoveTowards(transform.position, Hussain.transform.position, Speed * Time.deltaTime);
                rb.MovePosition(temp);
                changeAnim(temp - transform.position);
            }
        }
    }

    void senddamage()
    {
        if (MeleeAttacking)
        {
            if (target.tag == "Enemy")
            {
                target.GetComponent<AIStats>().takeDamage(damage);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!Triggered)
        {
            if (other.tag == "Enemy" || other.tag == "Arrow" )
            {
                Triggered = true;
                if (other.tag == "Enemy")
                {
                    target = other.transform;
                }
            }
        }
    }

    private void SetAnimFloat(Vector2 setVector)
    {
        anim.SetFloat("Horizontal", setVector.x);
        anim.SetFloat("Vertical", setVector.y);
    }

    private void changeAnim(Vector2 direction)
    {
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if (direction.x > 0)
            {
                SetAnimFloat(Vector2.right);
                anim.SetFloat("Speed", 1);
            }
            else if (direction.x < 0)
            {
                SetAnimFloat(Vector2.left);
                anim.SetFloat("Speed", 1);
            }
        }
        else if (Mathf.Abs(direction.x) < Mathf.Abs(direction.y))
        {
            if (direction.y > 0)
            {
                SetAnimFloat(Vector2.up);
                anim.SetFloat("Speed", 1);
            }
            else if (direction.y < 0)
            {
                SetAnimFloat(Vector2.down);
                anim.SetFloat("Speed", 1);
            }
        }
        else if (Mathf.Abs(direction.x) == Mathf.Abs(direction.y))
        {
            anim.SetFloat("Speed", 0);
        }
    }
}
