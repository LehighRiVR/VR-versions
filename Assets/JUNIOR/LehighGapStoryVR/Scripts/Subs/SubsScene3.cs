using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubsScene3 : MonoBehaviour
{
    public GameObject brownie1;
    public GameObject brownie2;
    public Text subs;
    public GameObject bubble;
    public AudioSource source1;
    public AudioSource source2;
    public bool dialogActive;
    public GameObject arrow;

    public GameObject pic1;
    public GameObject pic2;

    public GameObject sign;
    private bool brownieOneActive = true;
    private int signSeen = 0;
    private int audioPlayed = 0;
    public GameObject Camera;
    public bool arrowActive = false;
    public Text talkBrownieText;
    public Text infoSignText;
    public Text arrowText;
    public GameObject controlMenu;
    public GameObject checklist;
    private bool signStatus = false;
    public GameObject subsBG;

    IEnumerator TheSequence()
    {
        subs.text = "";
        yield return new WaitForSeconds(1);
        subs.text = "See that <color=#DEB638>broken bridge</color>?";
        yield return new WaitForSeconds(2);
        subs.text = "It used to be a railway bridge that was built between 1911 and 1912.";
        pic1.SetActive(true);
        yield return new WaitForSeconds(5.3f);
        subs.text = "It was built for the <color=#DEB638>Lehigh and New England Railroad</color>,";
        yield return new WaitForSeconds(3.0f);
        subs.text = "also known as the <color=#DEB638>LNE road</color>,";
        yield return new WaitForSeconds(1.9f);
        subs.text = "to carry zinc and coal through the Lehigh Gap.";
        yield return new WaitForSeconds(3.4f);
        pic1.SetActive(false);
        subs.text = "One fun fact is that on July 24, 1912";
        yield return new WaitForSeconds(4);
        subs.text = "the first train carrying railroad and company officials went over the 106-foot bridge.";
        yield return new WaitForSeconds(6.5f);
        subs.text = "However, it never reached its actual destination because the train jumped the newly laid track!";
        yield return new WaitForSeconds(6.2f);
        pic2.SetActive(true);
        subs.text = "About 10 days later, a second train crossed the bridge and made a successful run.";
        yield return new WaitForSeconds(5.5f);
        pic2.SetActive(false);
        subs.text = "The bridge was abandoned in 1961 due to the main zinc factory being temporarily shut down.";
        yield return new WaitForSeconds(6.6f);
        subs.text = "The bridge was officially removed in 1967.";
        yield return new WaitForSeconds(3f);
        subsBG.SetActive(false);
        subs.text = "";

        brownie1.SetActive(false);
        audioPlayed++;
        brownieOneActive = false;
        dialogActive = false;
        sign.SetActive(true);
        checklist.SetActive(true);
        controlMenu.SetActive(true);
        Camera.GetComponent<FirstPersonCam>().enabled =true;
        SceneComplete();
    }

    public void SignWasSeen() {
        signSeen++;
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
            brownie2.SetActive(true);
            StartCoroutine(BrownieOverHere());
        }
    }

    IEnumerator BrownieOverHere()
    {
        source2.Play();
        yield return new WaitForSeconds(1.6f);
        subs.text = "When you are done looking around, <color=#DEB638>come with me</color> over here!";
        yield return new WaitForSeconds(2f);
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
        // Camera.GetComponent<FirstPersonCam>().enabled = false;
    }

    public void SignClose() {
        signStatus = false;
        // Camera.GetComponent<FirstPersonCam>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!dialogActive && Input.GetKeyDown(KeyCode.T) && audioPlayed == 0 && !signStatus)
        {
            StartTalking();
        }

        if(PlayerPrefs.GetInt("Subs") == 0){
            subs.enabled = false;
            subsBG.SetActive(false);
        }
        else if(PlayerPrefs.GetInt("Subs") == 1){
            subs.enabled = true;
            if(source1.isPlaying || source2.isPlaying || source1.time != 0 || source2.time != 0) {
                subsBG.SetActive(true);
            }
        }
    }
}
