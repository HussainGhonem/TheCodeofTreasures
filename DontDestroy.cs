//This code is written By Kareem Hatem BUE ICS Y2 After prep 2020/2021
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DontDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
    }
}
