using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nuraddin : MonoBehaviour
{
    public GameObject missionManager;
    // Start is called before the first frame update
    void Start()
    {
        missionManager = GameObject.FindGameObjectWithTag("MissionManager");
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            missionManager.GetComponent<missionManager>().talkwithNuraddin();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
