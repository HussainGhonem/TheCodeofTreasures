using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionUI : MonoBehaviour
{
    public int mission;
    public GameObject missionManager;
    public Text missionText;
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        missionManager = GameObject.FindGameObjectWithTag("MissionManager");
        mission = missionManager.GetComponent<missionManager>().currentmission;
        switch (mission)
        {
            case 0:
                missionText.text = "Talk with Suaad";
                break;
            case 1:
                missionText.text = "Visit the market";
                break;
            case 2:
                missionText.text = "Talk with Marwan";
                break;
            case 3:
                missionText.text = "Gather Strawberries";
                break;
            case 4:
                missionText.text = "Talk with Momen";
                break;
            case 5:
                missionText.text = "Hunt wolves";
                break;
            case 6:
                missionText.text = "Give gold to Suaad";
                break;
            case 7:
                missionText.text = "Start your journey to Kermanshah";
                break;
            case 8:
                missionText.text = "Interrogate Maziar";
                break;
            case 9:
                missionText.text = "Talk with Jasmine";
                break;
            case 10:
                missionText.text = "Talk with Nurraddin";
                break;
            case 11:
                missionText.text = "Defeat Marduk";
                break;
            case 12:
                missionText.text = "Talk with Ibrahim";
                break;
            case 13:
                missionText.text = "Talk with Zainaddin";
                break;
        }
    }
}
