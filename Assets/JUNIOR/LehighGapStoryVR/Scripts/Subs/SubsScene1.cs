using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubsScene1 : MonoBehaviour
{
    public TutorialManager tutorial;

    public GameObject brownie1;
    public GameObject brownie2;
    public GameObject brownie3;
    public Text subs;
    public GameObject subsBG;
    public GameObject bubble;
    public AudioSource source1;
    public AudioSource source2;
    public bool dialogActive;
    public GameObject arrow;

    public GameObject pic1;
    public GameObject sign;
    private bool brownieOneActive = true;
    private int signSeen = 0;
    private int audioPlayed = 0;
    public GameObject Camera;
    private bool arrowActive = false;
    public Text talkBrownieText;
    public Text infoSignText;
    public Text arrowText;
    public GameObject controlMenu;
    public GameObject checklist;
    private bool signStatus = false;

    void Start()
    {
        sign.SetActive(false);
    }

    IEnumerator TheSequence()
    {
        subs.text = "";
        yield return new WaitForSeconds(0.3f);
        subs.text = "Welcome to the <color=#DEB638>Lehigh Gap</color>, my home.";
        yield return new WaitForSeconds(2.4f);
        subs.text = "My name is <color=#DEB638>Brownie</color>,";
        yield return new WaitForSeconds(1.1f);
        subs.text = "and I’m going to take you on a little trip";
        yield return new WaitForSeconds(1.7f);
        subs.text = "to see and experience the history of my home,";
        yield return new WaitForSeconds(3.0f);
        subs.text = "and have some fun along the way.";
        yield return new WaitForSeconds(2.2f);
        subs.text = "The large house is the <color=#DEB638>Osprey House</color>.";
        pic1.SetActive(true);
        yield return new WaitForSeconds(2.3f);
        subs.text = "This marks the beginning of the <color=#DEB638>LNE trail</color>,";
        yield return new WaitForSeconds(2.5f);
        subs.text = "where you will begin your adventure.";
        yield return new WaitForSeconds(2.85f);
        subs.text = "This house is primarily a green building,";
        yield return new WaitForSeconds(2.8f);
        subs.text = "using solar panels, super-insulation, and a geothermal heating system";
        yield return new WaitForSeconds(4.1f);
        subs.text = "where the heat comes from the earth itself.";
        yield return new WaitForSeconds(2.75f);
        subs.text = "This house became open to the public in May, 2003.";
        yield return new WaitForSeconds(3.7f);
        subs.text = "Currently, the Osprey House serves as a physical space for the <color=#DEB638>Lehigh Gap Nature Center (LGNC)</color> headquarters.";
        yield return new WaitForSeconds(6.55f);
        subs.text = "The <color=#DEB638>LGNC</color> partners with schools to develop";
        yield return new WaitForSeconds(4f);
        subs.text = "experiential nature programs and field trips for students.";
        yield return new WaitForSeconds(3.8f);
        pic1.SetActive(false);
        subsBG.SetActive(false);
        subs.text = "";

        brownie1.SetActive(false);

        audioPlayed++;
        brownieOneActive = false;
        dialogActive = false;
        sign.SetActive(true);
        checklist.SetActive(true);
        controlMenu.SetActive(true);
        //Camera.GetComponent<FirstPersonCam>().enabled =true;
        brownie3.SetActive(true);
        tutorial.Exploring();
        SceneComplete();
    }

    public void SignWasSeen() {
        signSeen++;
        brownie3.SetActive(false);
        sign.SetActive(false);
        SceneComplete();
    }

    public void SceneComplete() {
        if(signSeen >= 1) {
            infoSignText.text = " 1 / 1";
        }
        if(audioPlayed >= 1) {
            talkBrownieText.text = " 1 / 1";
        }
        if(signSeen >= 1 && audioPlayed >= 1 && !arrowActive) {
            if(brownieOneActive)
            {
                brownie1.SetActive(false);
            }
            //brownie2.SetActive(true);
            //Camera.GetComponent<FirstPersonCam>().enabled = false;
            tutorial.GettingHelp();
            //StartCoroutine(BrownieOverHere());
        }
    }

    IEnumerator BrownieOverHere()
    {
        yield return new WaitForSeconds(2f);
        brownie2.SetActive(true);
        source2.Play();
        yield return new WaitForSeconds(1f);
        subs.text = "Once you are ready to move on, press the arrow to <color=#DEB638>follow me</color> along the trail.";
        yield return new WaitForSeconds(3f);
        arrow.SetActive(true);
        arrowText.text = " 1 / 1";
        arrowActive = true;
        yield return new WaitForSeconds(1.8f);

        subsBG.SetActive(true);
        subs.enabled = true;

        subs.text = "<color=#DEB638>Find</color> and <color=#DEB638>click on the green arrow</color> to continue with the tour.";
        yield return new WaitForSeconds(3.0f);
    }

    public void StartTalking() {
        bubble.SetActive(false);
        checklist.SetActive(false);
        controlMenu.SetActive(false);
        sign.SetActive(false);
        dialogActive = true;
        subs.text = "";
        source1.Play();
        StartCoroutine(TheSequence());
    }

    public void SignOpen() {
        signStatus = true;
    }

    public void SignClose() {
        signStatus = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!dialogActive && Input.GetKeyDown(KeyCode.T) && audioPlayed == 0 && !signStatus)
        {
            StartTalking();
        }

        if(PlayerPrefs.GetInt("Subs") == 0)
        {
            subs.enabled = false;
            subsBG.SetActive(false);
        }
        else if(PlayerPrefs.GetInt("Subs") == 1)
        {
            subs.enabled = true;
            if(source1.isPlaying || source2.isPlaying || source1.time != 0 || source2.time != 0) {
                subsBG.SetActive(true);
            }
        }
    }
}
