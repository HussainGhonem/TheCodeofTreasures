//This code is written By Hussain Ghonem & Kareem Hatem BUE ICS Y2 After prep 2020/2021
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missionManager : MonoBehaviour
{
    public int strawberies;
    public int gold;
    public int wolves;
    public int currentmission;

    public bool didChatwithTrader;
    public bool didChatwithKareem;
    public bool didChatwithSuaad;
    public bool didChatwithMomen;
    public bool didChatwithMarwan;
    public bool didChatwithJasmine;
    public bool didChatwithNuraddin;
    public bool didChatwithConvoyMaster;
    public bool didChatwithMaziar;
    public bool didChatwithMarduk;
    public bool didChatwithZainaddin;
    public bool didChatwithIbrahim;
    // Start is called before the first frame update
    void Start()
    {
        strawberies = 0;
        gold = 0;
        wolves = 0;

        currentmission = 0;

        didChatwithConvoyMaster = false;
        didChatwithKareem = false;
        didChatwithTrader = false;
        didChatwithNuraddin = false;
        didChatwithSuaad = false;
        didChatwithJasmine = false;
        didChatwithMarwan = false;
        didChatwithMomen = false;
        didChatwithMaziar = false;
        didChatwithIbrahim = false;
        didChatwithMarduk = false;
        didChatwithZainaddin = false;
    }

    // Update is called once per frame
    void Update()
    {
        Visitthemarket();
        if (didChatwithSuaad && currentmission >= 3)
        {
            giveGold();
        }
    }
    //Missions
    //Visit the market
    public void talkwithSuaad()
    {
        didChatwithSuaad = true;
        if (didChatwithSuaad && currentmission == 0)
        {
            currentmission = 1;
        }
    }
    public void talkwithKareem()
    {
        didChatwithKareem = true;
    }
    public void talkwithTrader()
    {
        didChatwithTrader = true;
    }
    public void Visitthemarket()
    {
        if (didChatwithTrader && didChatwithKareem && currentmission == 1)
        {
            currentmission = 2;
        }
    }
    //Gather Strawberries
    public void talkwithMarwan()
    {
        didChatwithMarwan = true;
        if (didChatwithTrader && currentmission == 2)
        {
            currentmission = 3;
        }
    }
    public void CollectStrawberry()
    {
        if (currentmission == 3)
        {
            if (strawberies < 20)
            {
                strawberies++;
                gold += 5;
            } else if (strawberies >= 20)
            {
                currentmission = 4;
            }
        }
    }
    //Hunt Wolves
    public void talkwithMomen()
    {
        didChatwithMomen = true;
        if (didChatwithMomen && currentmission == 4)
        {
            currentmission = 5;
        }
    }
    public void HuntWolves()
    {
        if (currentmission == 5 && wolves < 4)
        {
            wolves++;
            gold += 50;
        } else if (wolves >= 4)
        {
            currentmission = 6;
        }
    }
    // Give gold to Suaad
    public void giveGold()
    {
        if (currentmission >= 6)
        {
            if (gold >= 300)
            {
                gold -= 50;
                currentmission = 7;
            }
        }
    }
    //Get in the covoy
    public void talkwithconvoyMaster()
    {
        didChatwithConvoyMaster = true;
    }
    public void getinConvoy()
    {
        if (didChatwithConvoyMaster && currentmission == 7)
        {
            currentmission = 8;
        }
    }
    //Interrogate Maziar
    public void talkwithMaziar()
    {
        didChatwithMaziar = true;
        if (currentmission == 8)
        {
            currentmission = 9;
        }
    }
    //Talk with Jasmine
    public void talkwithJasmine()
    {
        didChatwithJasmine = true;
        if (didChatwithJasmine && currentmission == 9)
        {
            currentmission = 10;
        }
    }
    //Talk with Nurraddin
    public void talkwithNuraddin()
    {
        didChatwithNuraddin = true;
        if (didChatwithNuraddin && currentmission == 10)
        {
            currentmission = 11;
        }
    }
    //Talk with Marduk
    public void talkwithMarduk()
    {
        didChatwithMarduk = true;
        if (didChatwithNuraddin && currentmission == 11)
        {
            currentmission = 12;
        }
    }
    //Talk with Ibrahim
    public void talkwithIbrahim()
    {
        didChatwithIbrahim = true;
        if (didChatwithNuraddin && currentmission == 12)
        {
            currentmission = 13;
        }
    }
    //Talk with Zainaddin
    public void talkwithZainaddin()
    {
        didChatwithZainaddin = true;
        if (didChatwithNuraddin && currentmission == 13)
        {
            currentmission = 14;
        }
    }
}
