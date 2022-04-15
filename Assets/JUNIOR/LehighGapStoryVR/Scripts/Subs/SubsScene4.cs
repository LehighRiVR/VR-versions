using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubsScene4 : MonoBehaviour
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
    private bool arrowActive = false;
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
        yield return new WaitForSeconds(0.75f);
        subs.text = "Over the last 150 years";
        yield return new WaitForSeconds(2.7f);
        subs.text = "my ancestors watched many companies and tourists use my home";
        yield return new WaitForSeconds(3.45f);
        subs.text = "as an important <color=#DEB638>transportation corridor</color>.";
        yield return new WaitForSeconds(3.06f);
        subs.text = "Notice the <color=#DEB638>railways</color> and <color=#DEB638>canals</color>?";
        yield return new WaitForSeconds(2.65f);
        subs.text = "In years past, each company had its own railroad tracks for coal and zinc.";
        pic1.SetActive(true);
        yield return new WaitForSeconds(5.8f);
        subs.text = "Before the construction of the bridge and the railroads,";
        yield return new WaitForSeconds(2.6f);
        subs.text = "the main mode of transportation was the <color=#DEB638>Lehigh river</color> and a series of canals.";
        pic1.SetActive(false);
        pic2.SetActive(true);
        yield return new WaitForSeconds(5.6f);
        subs.text = "This is how small boats transported coal from the <color=#DEB638>Pocono Mountains</color>";
        yield return new WaitForSeconds(4.42f);
        subs.text = "to factories in the <color=#DEB638>Lehigh Valley</color> and beyond.";
        yield return new WaitForSeconds(3.5f);
        subs.text = "My ancestors used to watch these boats carry these shiny stones up and down the river.";
        yield return new WaitForSeconds(6.17f);
        pic2.SetActive(false);
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
        yield return new WaitForSeconds(1.0f);
        subs.text = "When you are ready, <color=#DEB638>follow me</color>.";
        yield return new WaitForSeconds(1.7f);
        arrow.SetActive(true);
        arrowText.text = " 1 / 1";
        arrowActive = true;
        yield return new WaitForSeconds(0.5f);
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
