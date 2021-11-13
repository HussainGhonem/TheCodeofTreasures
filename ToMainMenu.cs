using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToMainMenu : MonoBehaviour
{
    public GameObject health, gold, mission, missionManager;

    // Start is called before the first frame update
    void Start()
    {
        gold = GameObject.FindGameObjectWithTag("GoldUI");
        health = GameObject.FindGameObjectWithTag("HealthUI");
        mission = GameObject.FindGameObjectWithTag("MissionUI");
        missionManager = GameObject.FindGameObjectWithTag("MissionManager");
    }
    public void MainMenuButton()
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

    // Update is called once per frame
    void Update()
    {
    }

}
