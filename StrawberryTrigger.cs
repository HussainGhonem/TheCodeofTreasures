//This code is written By Kareem Hatem BUE ICS Y2 After prep 2020/2021
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrawberryTrigger : MonoBehaviour
{
    private SpriteRenderer sr;
    public Sprite HarvestedStrawberry;
    public GameObject missionManager;
    private bool harvested;
    // Start is called before the first frame update
    void Start()
    {
        missionManager = GameObject.FindGameObjectWithTag("MissionManager");
        harvested = false;
        sr = GetComponent<SpriteRenderer>();
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!harvested)
            {
                sr.sprite = HarvestedStrawberry;
                missionManager.GetComponent<missionManager>().CollectStrawberry();
                harvested = true;
            }
        }
    }
    void Update()
    {
        
    }
}
