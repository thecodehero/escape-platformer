using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class LevelSelectController : MonoBehaviour
{
    public GameObject mainMenu;

    public GameObject level1Button;
    public GameObject level2Button;
    public GameObject level3Button;
    public GameObject level4Button;

    public GameObject collectiblesText;
    public GameObject deathsText;
    public GameObject timeText;

    public InputAction backAction;

    public String selectedLevel;

    private void Start() {
        backAction.performed += _ => back();
    }

    void OnEnable()
    {   
        backAction.Enable();

        //Check which levels are unlocked
        if(PlayerPrefs.GetString("Level1") == "complete") {
            level2Button.GetComponent<Toggle>().interactable = true;
        }
        else {
            level2Button.GetComponent<Toggle>().interactable = false;
        }
        if(PlayerPrefs.GetString("Level2") == "complete") {
            level3Button.GetComponent<Toggle>().interactable = true;
        }
        else {
            level3Button.GetComponent<Toggle>().interactable = false;
        }
        if(PlayerPrefs.GetString("Level3") == "complete") {
            level4Button.GetComponent<Toggle>().interactable = true;
        }
        else {
            level4Button.GetComponent<Toggle>().interactable = false;
        }
        
        showLevel("Level1");
    }

    //Shows stats and readies play function for selected level (specified in editor)
    public void showLevel(String level) {
        int total = 0;
        selectedLevel = level;
        if(level == "Level1") {
            total = 9;
        }
        else if(level == "Level2") {
            total = 11;
        }
        else if(level == "Level3") {
            total = 5;
        }
        else if(level == "Level4") {
            total = 6;
        }
        collectiblesText.GetComponent<TMPro.TextMeshProUGUI>().text  = $"x {PlayerPrefs.GetInt($"{level}Collectibles")} / {total}";
        deathsText.GetComponent<TMPro.TextMeshProUGUI>().text  = $"x {PlayerPrefs.GetInt($"{level}Deaths")}";
        timeText.GetComponent<TMPro.TextMeshProUGUI>().text  = PlayerPrefs.GetString($"{level}Time");
    }

    private void OnDisable() {
        backAction.Disable();
    }

    public void playLevel(String difficulty)
    {   
        String sceneName = selectedLevel;
        sceneName += difficulty;
        SceneManager.LoadScene(sceneName);
    }

    public void back()
    {
        //To main menu
        this.gameObject.SetActive(false);
        mainMenu.SetActive(true);

        //Select first button on main menu for keyboard navigation
        mainMenu.GetComponentInChildren<Button>().Select();
    }
}
