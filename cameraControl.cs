//This code is written By Hussain Ghonem BUE ICS Y2 After prep 2020/2021
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControl : MonoBehaviour
{
    public Transform target;
    public float cameraspeed;
    public float minX, maxX, minY, maxY;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void FixedUpdate()
    {
        if (target != null)
        {
            Vector2 newcamposition = Vector2.Lerp(transform.position, target.position, Time.deltaTime * cameraspeed);

            float ClampX = Mathf.Clamp(newcamposition.x, minX, maxX);
            float ClampY = Mathf.Clamp(newcamposition.y, minY, maxY);
            transform.position = new Vector3(ClampX, ClampY, -10F);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
