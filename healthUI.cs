using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class healthUI : MonoBehaviour
{
    public float health;
    public GameObject Player;
    public Text healthText;
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        health = Player.GetComponent<PlayerStats>().health;
        healthText.text = health.ToString();
    }
}
