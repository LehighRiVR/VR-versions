using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;


public class PauseManager : MonoBehaviour
{
        
    [Header("Panels")]
    public GameObject mainPanel;
    public GameObject pausePanel;
    public GameObject quitPanel;
    public GameObject optionsPanel;

    [Header("Buttons")]
    public GameObject resumeButton;
    public GameObject optionsButton;
    public GameObject quitButton;
    public GameObject quitGameButton;
    public GameObject quitMainMenuButton;
    public GameObject cancelButton;

    [Header("Toggles")]
    public Toggle onScreenToggle;
    public Toggle offScreenfToggle;
    public Toggle radarToggle;
    public Toggle compassBarfToggle;

    [Header("Contextual UI")]
    public GameObject titleTexts;
    public GameObject mask;
    public Text pauseMenu;
    
    public Camera mainCam;
    public GameObject mainCamObj;

    public float timeScale = 1f;

   
    // Start is called before the first frame update
    void Start()
    {
       
    }
    
    //activating and deactivating buttons 

    public void managingButtonsResume()
    {
        mainPanel.SetActive(false);
        optionsPanel.SetActive(false);
        quitPanel.SetActive(false);
        titleTexts.SetActive(false);
        mask.SetActive(false);
        Time.timeScale = timeScale;
    }

    public void managingButtonsOptions()
    {
        resumeButton.SetActive(false);
        optionsButton.SetActive(true);
        quitButton.SetActive(false);
        optionsPanel.SetActive(true);

    }

    public void managingButtonsQuit()
    {
        resumeButton.SetActive(false);
        optionsButton.SetActive(false);
        quitButton.SetActive(true);
        quitPanel.SetActive(true);

    }

    public void managingButtonsCancel()
    {
        resumeButton.SetActive(true);
        optionsButton.SetActive(true);
        quitButton.SetActive(true);

        optionsPanel.SetActive(false);
        quitPanel.SetActive(false);

        pauseMenu.text = "Pause Menu";
    }

         
    // Update is called once per frame
    void Update()
    {
        // this changes the big titles according to each panel
        if (optionsPanel.activeInHierarchy == true)
        {
            pauseMenu.text = "Options";
        }
        else if (quitPanel.activeInHierarchy == true)
        {
            pauseMenu.text = "Quit?";
        }
        else if (mainPanel.activeInHierarchy == true)
        {
            pauseMenu.text = "Pause Menu";
        }

        // this pauses/unpause the game when BACK button (Two) is hit
        if (OVRInput.GetDown(OVRInput.Button.Two) && mainPanel.activeInHierarchy == false)
        {
            pausePanel.SetActive(true);
            mainPanel.SetActive(true);
            optionsPanel.SetActive(false);
            quitPanel.SetActive(false);
            titleTexts.SetActive(true);
            mask.SetActive(true);
            Time.timeScale = 0;
                       
        }
        else if (OVRInput.GetDown(OVRInput.Button.Two) && mainPanel.activeInHierarchy == true)
        {
            Time.timeScale = timeScale;
            pausePanel.SetActive(false);
            mainPanel.SetActive(false);
            resumeButton.SetActive(true);
            optionsButton.SetActive(true);
            quitButton.SetActive(true);
            optionsPanel.SetActive(false);
            quitPanel.SetActive(false);
            titleTexts.SetActive(false);
            mask.SetActive(false);
        }

        
    }
}

    
 