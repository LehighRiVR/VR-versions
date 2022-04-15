using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubsScene5 : MonoBehaviour
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

    public GameObject sign1;
    public GameObject sign2;
    private bool brownieOneActive = true;
    private int signSeen1 = 0;
    private int signSeen2 = 0;
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
        yield return new WaitForSeconds(0.5f);
        subs.text = "The New Jersey Zinc Company opened its <color=#DEB638>Palmerton plant</color> to produce";
        pic1.SetActive(true);
        yield return new WaitForSeconds(3.5f);
        subs.text = "metallic zinc, zinc oxide, spelter, and spiegeleisen from materials mined";
        yield return new WaitForSeconds(5.1f);
        subs.text = "in <color=#DEB638>Sussex County</color>, New Jersey and <color=#DEB638>Friedensville</color>, Pennsylvania.";
        yield return new WaitForSeconds(3.7f);
        subs.text = "The plant included over 31 buildings on 200 acres of land.";
        yield return new WaitForSeconds(4.7f);
        //pic1.SetActive(false);
        subs.text = "The zinc they produced was sold to other companies to make various products,";
        yield return new WaitForSeconds(4.2f);
        subs.text = "including <color=#DEB638>tires</color>, <color=#DEB638>paint</color>, and <color=#DEB638>high-quality brass</color>.";
        yield return new WaitForSeconds(3.7f);
        pic1.SetActive(false);
        subs.text = "It was transported using the railways that each of these companies owned.";
        yield return new WaitForSeconds(4.0f);        
        subs.text = "The plant went out of business in 1980.";
        yield return new WaitForSeconds(3.8f);
        subs.text = "The company <color=#DEB638>designed and built</color> the entire town of Palmerton beginning in 1898.";
        pic2.SetActive(true);
        yield return new WaitForSeconds(6.23f);
        subs.text = "<color=#DEB638>Palmerton</color> was named after the company’s president, <color=#DEB638>Stephen S. Palmer</color>.";
        yield return new WaitForSeconds(5.5f);
        //pic2.SetActive(false);
        subs.text = "Some of the things the company provided in the town were";
        yield return new WaitForSeconds(2.35f);
        subs.text = "a hospital, schools, a library, a water system, a community center, park, streets, sewer system, and employee housing.";
        yield return new WaitForSeconds(8.86f);
        subs.text = "Palmerton was built to support the workers and their families’ daily needs,";
        yield return new WaitForSeconds(5.03f);
        subs.text = "such as access to education.";
        yield return new WaitForSeconds(2.8f);
        subs.text = "The company provided employment for many people in Palmerton for almost a century.";
        yield return new WaitForSeconds(6.2f);
        pic2.SetActive(false);
        subs.text = "One fun fact about Palmerton is that <color=#DEB638>the first public bath</color> was built here.";
        yield return new WaitForSeconds(4.9f);
        subsBG.SetActive(false);
        subs.text = "";

        brownie1.SetActive(false);
        audioPlayed++;
        brownieOneActive = false;
        dialogActive = false;
        sign1.SetActive(true);
        sign2.SetActive(true);
        checklist.SetActive(true);
        controlMenu.SetActive(true);
        Camera.GetComponent<FirstPersonCam>().enabled =true;
        SceneComplete();
    }

    public void SignWasSeen1() {
        signSeen1++;
        SceneComplete();
    }

    public void SignWasSeen2() {
        signSeen2++;
        SceneComplete();
    }

    public void SceneComplete() {
        if(signSeen1 >= 1 && signSeen2 == 0) {
            infoSignText.text = " 1 / 2";
        }
        if(signSeen1 == 0 && signSeen2 >= 1) {
            infoSignText.text = " 1 / 2";
        }
        if(signSeen1 >= 1 && signSeen2 >= 1) {
            infoSignText.text = " 2 / 2";
        }
        if(audioPlayed >= 1) {
            talkBrownieText.text = " 1 / 1";
        }
        if(signSeen1 >= 1 && signSeen2 >= 1 && audioPlayed >= 1 && !arrowActive) {
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
        sign1.SetActive(false);
        sign2.SetActive(false);
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
