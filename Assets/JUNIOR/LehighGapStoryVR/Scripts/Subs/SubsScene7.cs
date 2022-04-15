using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubsScene7 : MonoBehaviour
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
    public GameObject pic3;
    public GameObject pic4;
    public GameObject pic5;

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
        yield return new WaitForSeconds(0.45f);
        subs.text = "The New Jersey Zinc Company’s smelting operation shut down in the <color=#DEB638>1980s</color>,";
        yield return new WaitForSeconds(4.7f);
        subs.text = "but the <color=#DEB638>environmental damage</color> had already been done.";
        pic1.SetActive(true);
        yield return new WaitForSeconds(3.7f);
        subs.text = "The <color=#DEB638>United States Environmental Protection Agency</color>, also known as the <color=#DEB638>EPA</color>,";
        yield return new WaitForSeconds(5.0f);
        subs.text = "quarantined the impacted area and declared it a <color=#DEB638>Superfund site</color> in 1983.";
        yield return new WaitForSeconds(6.54f);
        pic1.SetActive(false);
        subs.text = "The years of <color=#DEB638>acid rain</color> created an environment where plants were unable to grow";
        yield return new WaitForSeconds(4.4f);
        subs.text = "and us animals were unable to survive.";
        yield return new WaitForSeconds(3.6f);
        subs.text = "The mountain became a “moonscape” and remained so until 2003.";
        yield return new WaitForSeconds(5.7f);
        pic2.SetActive(true);
        subs.text = "In 2002, the land was so toxic that little or no life,";
        yield return new WaitForSeconds(4.8f);
        subs.text = "including bacteria and fungi, could survive.";
        yield return new WaitForSeconds(3.7f);
        pic2.SetActive(false);
        subs.text = "My grandparents had to migrate somewhere else.";
        yield return new WaitForSeconds(3.9f);
        subs.text = "Since 2003, many different <color=#DEB638>warm-season grasses</color> were planted along the trail <color=#DEB638>to revegetate</color> the area.";
        pic3.SetActive(true);
        yield return new WaitForSeconds(7.3f);
        subs.text = "The established grasses continue to grow,";
        yield return new WaitForSeconds(2.9f);
        subs.text = "restore the ecological growth of the mountain,";
        yield return new WaitForSeconds(2.45f);
        subs.text = "and recapture the natural beauty of the Lehigh Gap.";
        pic3.SetActive(false);
        yield return new WaitForSeconds(3.3f);
        subs.text = "Most grew successfully on the barren mountainside.";
        yield return new WaitForSeconds(3.2f);
        subs.text = "In the beginning of 2006, the steep, barren upper slopes of the ridge were seeded with crop dusters.";
        pic4.SetActive(true);
        yield return new WaitForSeconds(6.7f);
        subs.text = "However, this is still an <color=#DEB638>ongoing process</color>.";
        pic4.SetActive(false);
        yield return new WaitForSeconds(3.2f);
        subs.text = "The damage done to the environment will not be fully healed for many more years.";
        yield return new WaitForSeconds(4.9f);
        subs.text = "Today, the Gap features an amazing diversity of <color=#DEB638>habitats</color>,";
        pic5.SetActive(true);
        yield return new WaitForSeconds(3.75f);
        subs.text = "including forest, scrub, grassland, pond, and river.";
        yield return new WaitForSeconds(4.65f);
        subs.text = "My parents and I moved here recently.";
        yield return new WaitForSeconds(2.36f);
        subs.text = "A number of other rare species of animals";
        yield return new WaitForSeconds(2.89f);
        subs.text = "such as <color=#DEB638>Blue Grosbeak</color>, and <color=#DEB638>wild bleeding heart</color> now call the Lehigh Gap home as well.";
        pic5.SetActive(false);
        yield return new WaitForSeconds(6f);
        subsBG.SetActive(false);
        subs.text = "";

        brownie1.SetActive(false);
        audioPlayed++;
        brownieOneActive = false;
        dialogActive = false;
        Camera.GetComponent<FirstPersonCam>().enabled =true;
        sign1.SetActive(true);
        sign2.SetActive(true);
        checklist.SetActive(true);
        controlMenu.SetActive(true);
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
        arrow.SetActive(true);
        activateTEST();
        arrowText.text = " 1 / 1";
        arrowActive = true;
        yield return new WaitForSeconds(1.5f);
        subsBG.SetActive(true);
        subs.enabled = true;
        subs.text = "<color=#DEB638>Find</color> and <color=#DEB638>click on the green arrow</color> to help us understand your thoughts about this virtual field trip of the Lehigh Gap.";
        subs.resizeTextForBestFit = true;
        yield return new WaitForSeconds(3.0f);
    }

    public GameObject brownieTEST;

    public MeshRenderer arrowTEST;

    public Canvas canvasTEST;

    public void activateTEST()
    {
        brownieTEST.SetActive(true);
        arrowTEST.enabled = true;
        canvasTEST.enabled = true;
        arrow.GetComponent<SphereCollider>().enabled = true;
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
