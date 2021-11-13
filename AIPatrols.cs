//This code is written By Hussain Ghonem BUE ICS Y2 After prep 2020/2021
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPatrols : MonoBehaviour
{
    public Transform []nodes;
    public float Speed;
    private int randomnode;
    Vector2 movement;
    public Rigidbody2D rb;
    public Animator anim;
    private float waitTime;
    public float StartWaitTime;

    // Start is called before the first frame update
    void Start()
    {
        waitTime = StartWaitTime;
        randomnode = Random.Range(0, nodes.Length);
    }
    private void OnCollisionEnter2D()
    {
        randomnode = Random.Range(0, nodes.Length);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, nodes[randomnode].position, Speed * Time.deltaTime);
        Vector3 temp = Vector3.MoveTowards(transform.position, nodes[randomnode].position, Speed * Time.deltaTime);
        rb.MovePosition(temp);
        changeAnim(temp - transform.position);
        if (Vector2.Distance(transform.position, nodes[randomnode].position) < 0.5f)
        {
            if (waitTime <= 0)
            {
                randomnode = Random.Range(0, nodes.Length);
                waitTime = StartWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
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
        else if(Mathf.Abs(direction.x) == Mathf.Abs(direction.y))
        {
            anim.SetFloat("Speed", 0);
        }
    }
}
