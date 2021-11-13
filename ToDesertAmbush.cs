using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToDesertAmbush : MonoBehaviour
{
    public KeyCode Interact;
    public KeyCode Leave;
    public GameObject dialogBox;
    public Text dialogText;
    private int currentMission;
    public string dialog;
    public bool dialogActive;
    public GameObject missionManager;
    // Start is called before the first frame update
    void Start()
    {
        currentMission = 0;
        missionManager = GameObject.FindGameObjectWithTag("MissionManager");
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
        if (Input.GetKey(Leave) && currentMission >= 7 && dialogActive)
        {
            missionManager.GetComponent<missionManager>().getinConvoy();
            UnityEngine.SceneManagement.SceneManager.LoadScene("DesertAmbushLevel");
        }
    }
}
