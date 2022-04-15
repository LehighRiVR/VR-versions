using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public SubsScene1 subscene1;

    public GameObject GameTitle;

    public Camera cam;

    public GameObject Game_UI;
    public GameObject Tutorial_UI;
          
    public GameObject CornerCards;

    public GameObject lookingTITLE;
    public GameObject exploringTITLE;
    public GameObject movingTITLE;
    public GameObject gettingTITLE;

    public GameObject lookingDESCRIPTION;
    public GameObject exploringDESCRIPTION;
    public GameObject movingDESCRIPTION;

    public GameObject lookingTASK;
    public GameObject exploringTASK;
    public GameObject movingTASK;
    public GameObject gettingTASK;



    // Start is called before the first frame update
    void Start()
    {
        CornerCards.SetActive(false);
        Game_UI.SetActive(false);
        
        Tutorial_UI.SetActive(true);
        GameTitle.SetActive(false);

        StartCoroutine(LookingTutorial());

    }
    
    IEnumerator LookingTutorial()
    {
        cam.GetComponent<FirstPersonCam>().enabled = false;

        yield return new WaitForSeconds(1f);
        GameTitle.SetActive(true);
        

        yield return new WaitForSeconds(2f);
        lookingTITLE.SetActive(true);
        GameTitle.SetActive(false);

        yield return new WaitForSeconds(2.5f);
        lookingTITLE.SetActive(false);        
        lookingDESCRIPTION.SetActive(true);

        yield return new WaitForSeconds(7f);
        lookingTASK.SetActive(true);
        lookingDESCRIPTION.SetActive(false);
        
        yield return new WaitForSeconds(6f);
        lookingTASK.SetActive(false);
        Game_UI.SetActive(true);

        cam.GetComponent<FirstPersonCam>().enabled = true;

        yield return null;
    }

    public void Exploring()
    {        
        StartCoroutine(ExploringTutorial());
    }

    IEnumerator ExploringTutorial()
    {
        cam.GetComponent<FirstPersonCam>().enabled = false;
        Game_UI.SetActive(false);

        exploringTITLE.SetActive(true);

        yield return new WaitForSeconds(2.5f);
        exploringTITLE.SetActive(false);
        exploringDESCRIPTION.SetActive(true);
        
        yield return new WaitForSeconds(7f);
        exploringTASK.SetActive(true);
        exploringDESCRIPTION.SetActive(false);

        yield return new WaitForSeconds(6f);
        exploringTASK.SetActive(false);
        Game_UI.SetActive(true);

        cam.GetComponent<FirstPersonCam>().enabled = true;        

        yield return null;
    }

    public void GettingHelp()
    {
        cam.GetComponent<FirstPersonCam>().enabled = false;
        StartCoroutine(GettingTutorial());        
    }

    IEnumerator GettingTutorial()
    {
        cam.GetComponent<FirstPersonCam>().enabled = false;
        Game_UI.SetActive(false);
                
        gettingTITLE.SetActive(true);

        yield return new WaitForSeconds(3f);
        gettingTITLE.SetActive(false);
        gettingTASK.SetActive(true);

        yield return new WaitForSeconds(6f);
        gettingTASK.SetActive(false);

        StartCoroutine(MovingTutorial());

        yield return null;
    }

    IEnumerator MovingTutorial()
    {
        cam.GetComponent<FirstPersonCam>().enabled = false;
                
        movingTITLE.SetActive(true);              

        yield return new WaitForSeconds(3f);
        movingTITLE.SetActive(false);
        movingDESCRIPTION.SetActive(true);

        yield return new WaitForSeconds(4f);
        movingTASK.SetActive(true);
        movingDESCRIPTION.SetActive(false);

        yield return new WaitForSeconds(6f);
        Game_UI.SetActive(true);
        movingTASK.SetActive(false);

        CornerCards.SetActive(true);

        subscene1.StartCoroutine("BrownieOverHere");

        cam.GetComponent<FirstPersonCam>().enabled = true;              

        yield return null;
    }  

}
