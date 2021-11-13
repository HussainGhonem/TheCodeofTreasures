//This code is written By Hussain Ghonem BUE ICS Y2 After prep 2020/2021
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;


public class Chat : MonoBehaviour
{
    public GameObject dialogBox;
    public KeyCode Interact;
    public bool dialogActive;
    // Start is called before the first frame update
    void Start()
    {
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            dialogActive = true;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            dialogActive = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(Interact) && dialogActive) 
        {
            if (dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);
            }
            else
            {
                dialogBox.SetActive(true);
            }
        }
    }
}

