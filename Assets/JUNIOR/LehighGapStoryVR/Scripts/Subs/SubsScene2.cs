using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubsScene2 : MonoBehaviour
{
    public GameObject brownie1;
    public GameObject brownie2;
    public Text subs;
    public GameObject bubble;
    public AudioSource source1;
    public AudioSource source2;
    public bool dialogActive;
    public GameObject arrow;
    private bool brownieOneActive = true;
    private int audioPlayed = 0;
    public GameObject Camera;
    public GameObject tempCam;
    private int rocks = 0;
    private bool arrowActive = false;
    public Text talkBrownieText;
    public Text rocksText;
    public Text arrowText;
    public GameObject controlMenu;
    public GameObject checklist;
    public GameObject subsBG;

    public void Start()
    {        
        Camera.SetActive(false);
        tempCam.SetActive(true);
    }



    IEnumerator TheSequence()
    {
        subs.text = "";
        yield return new WaitForSeconds(0.3f);
        subs.text = "Oh look!";
        yield return new WaitForSeconds(1.2f);
        subs.text = "What's that <color=#DEB638>shiny rock</color> over there?";
        yield return new WaitForSeconds(2.4f);
        subs.text = "Looks like a piece of <color=#DEB638>zinc</color>.";
        yield return new WaitForSeconds(2.1f);
        subs.text = "Zinc is a <color=#DEB638>metal</color> that occurs naturally,";
        yield return new WaitForSeconds(2.5f);
        subs.text = "but most zinc finds its way into the environment";
        yield return new WaitForSeconds(3.1f);
        subs.text = "because of <color=#DEB638>human activities</color>.";
        yield return new WaitForSeconds(1.9f);
        subs.text = "These include mining, smelting metals";
        yield return new WaitForSeconds(2.9f);
        subs.text = "such as zinc, lead, and cadmium,";
        yield return new WaitForSeconds(2.5f);
        subs.text = "steel production, or simple zinc transportation.";
        yield return new WaitForSeconds(3.8f);
        subs.text = "Zinc from the nearby <color=#DEB638>New Jersey Zinc Company</color>";
        yield return new WaitForSeconds(2.9f);
        subs.text = "was used to make <color=#DEB638>batteries</color> and <color=#DEB638>other materials</color> as well.";
        yield return new WaitForSeconds(3.6f);
        subs.text = "When you look around, you will find pieces of coal, zinc, ore, and other important stuff <color=#DEB638>on the ground</color>.";
        yield return new WaitForSeconds(7.1f);
        subs.text = "Pick them up to learn more about them and add them to your collection."; //JUNIOR: I recommend removing this. I can edit the audio if Dr. Bodzin approves
        yield return new WaitForSeconds(3.4f);
        subs.text = "<color=#DEB638>Click</color> on the coal <color=#DEB638>to pick it up</color> and <color=#DEB638>interact</color> with it.";
        yield return new WaitForSeconds(3.0f);
        subsBG.SetActive(false);
        subs.text = "";

        brownie1.SetActive(false);
        audioPlayed++;
        brownieOneActive = false;
        checklist.SetActive(true);
        controlMenu.SetActive(true);
        dialogActive = false;
        
        Camera.SetActive(true);
        Camera.GetComponent<FirstPersonCam>().enabled =true;
        tempCam.SetActive(false);
        SceneComplete();
    }

    public void RockSeen() {
        rocks++;
        SceneComplete();
    }

    public void SceneComplete() {
        if(audioPlayed >= 1) {
            talkBrownieText.text = " 1 / 1";
        }
        if(rocks == 1) {
            rocksText.text = " 1 / 4";
        }
        if(rocks == 2) {
            rocksText.text = " 2 / 4";
        }
        if(rocks == 3) {
            rocksText.text = " 3 / 4";
        }
        if(rocks == 4) {
            rocksText.text = " 4 / 4";
        }
        if(rocks >= 4 && audioPlayed >= 1 && !arrowActive) {
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
        dialogActive = true;
        subs.text = "";
        source1.Play();
        StartCoroutine(TheSequence());
    }

    // Update is called once per frame
    void Update()
    {
        if (!dialogActive && Input.GetKeyDown(KeyCode.T) && audioPlayed == 0)
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
