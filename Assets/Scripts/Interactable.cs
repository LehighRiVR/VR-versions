using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public GameObject questionCanvas;
    public GameObject b21;
    public GameObject ppl;
    public GameObject pauseMenu;
    public GameObject text;

    
    public void OpenPauseMenu()
    {
        if (pauseMenu.activeInHierarchy == false)
        {
            pauseMenu.SetActive(true);
        }
        else if (pauseMenu.activeInHierarchy == true)
        {
            pauseMenu.SetActive(false);
        }        
    }


    public void ButtonClick()
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
       
    

    public void B21Selected()
    {
        if (b21.activeInHierarchy == false)
        {
            questionCanvas.SetActive(true);
            b21.SetActive(true);
        }
        else if (b21.activeInHierarchy == true)
        {
            b21.SetActive(false);
        }
    }

    public void PPLSelected()
    {
        if (ppl.activeInHierarchy == false)
        {
            questionCanvas.SetActive(true);
            ppl.SetActive(true);
        }
        else if (ppl.activeInHierarchy == true)
        {
            ppl.SetActive(false);
        }
    }

}
 