using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UInteract : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject pauseMenuBoxWorld;
    public GameObject mainCanvas;
    public GameObject mainButton;
    public GameObject text;


    public void AcceptTouchpadClick()
    {
        if (pauseMenu.activeInHierarchy == false)
        {
            pauseMenu.SetActive(true);
        }
        else if (pauseMenu.activeInHierarchy == true)
        {
            pauseMenu.SetActive(false);
        }
        pauseMenuBoxWorld.SetActive(true);

        if (text.activeInHierarchy == true)
        {
            text.SetActive(false);
        }
        else if (text.activeInHierarchy == false)
        {
            text.SetActive(true);
        }

    }


    public void UIButton()
    {
        if (text.activeInHierarchy == true)
        {
            text.SetActive(false);
        }
        else if (text.activeInHierarchy == false)
        {
            text.SetActive(true);
        }

    }


    /*
    public void AcceptTriggerClick()
    {
        if (pauseMenu.activeInHierarchy == false)
        {
            pauseMenu.SetActive(true);
        }
        else if (pauseMenu.activeInHierarchy == true)
        {
            pauseMenu.SetActive(false);
        }
        pauseMenuBoxWorld.SetActive(true);

        if (text.activeInHierarchy == true)
        {
            text.SetActive(false);
        }
        else if (text.activeInHierarchy == false)
        {
            text.SetActive(true);
        }
    }
    */
}



