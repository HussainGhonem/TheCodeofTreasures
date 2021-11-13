//This code is written By Hussain Ghonem BUE ICS Y2 After prep 2020/2021
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainMenu : MonoBehaviour
{
    public GameObject MainMenu, CreditsMenu,GameOverMenu, KeyboardControlMenu;
    // Start is called before the first frame update
    void Start()
    {
        MainMenuButton();
    }
    public void StartButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("VillageHouseLevelScene");
    }
    public void CreditsButton()
    {
        MainMenu.SetActive(false);
        CreditsMenu.SetActive(true);
        KeyboardControlMenu.SetActive(false);
    }
    public void KeyboardControlButton()
    {
        MainMenu.SetActive(false);
        CreditsMenu.SetActive(false);
        KeyboardControlMenu.SetActive(true);
    }
    public void MainMenuButton()
    {
        MainMenu.SetActive(true);
        CreditsMenu.SetActive(false);
        KeyboardControlMenu.SetActive(false);
    }
    public void QuitButton()
    {
        Application.Quit();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
