//This code is written By Kareem Hatem BUE ICS Y2 After prep 2020/2021
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToVillage : MonoBehaviour
{
    public KeyCode Interact;
    public KeyCode Leave;
    public GameObject dialogBox;
    public Text dialogText;
    public string dialog;
    private int currentMission;
    public bool dialogActive;
    // Start is called before the first frame update
    void Start()
    {
        currentMission = 0;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            currentMission = other.gameObject.GetComponent<PlayerStats>().currentmission;
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
        if (Input.GetKey(Interact) && dialogActive)
        {
            if (dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);
            }
            else
            {
                dialogBox.SetActive(true);
                dialogText.text = dialog;
            }
        }
        if (Input.GetKey(Leave) && currentMission >= 0 && dialogActive)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("VillageLevelScene");
        }
    }
}
