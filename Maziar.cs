using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maziar : MonoBehaviour
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
            missionManager.GetComponent<missionManager>().talkwithMaziar();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
