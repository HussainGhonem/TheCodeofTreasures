using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
public class goldUI : MonoBehaviour
{
    public int gold;
    public GameObject missionManager;
    public Text goldText;
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        missionManager = GameObject.FindGameObjectWithTag("MissionManager");
        gold = missionManager.GetComponent<missionManager>().gold;    
        goldText.text = gold.ToString();        
    }
}
