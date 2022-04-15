using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubsScene6 : MonoBehaviour
{
    public Text subs;
    public Text talkBrownieText;
    public Text arrowText;
    public AudioSource source;
    public bool dialogActive;
    public GameObject arrow;
    // public GameObject brownie2D;
    public GameObject tree1;
    public GameObject deadtree1;
    public GameObject tree2;
    public GameObject deadtree2;
    public GameObject tree3;
    public GameObject deadtree3;
    public GameObject tree4;
    public GameObject deadtree4;
    public GameObject tree5;
    public GameObject deadtree5;
    //public UniStorm.WeatherType rain; //JUNIOR commented this out on April 14 2022 to start the VR porting process
    public GameObject controlMenu;
    public GameObject checklist;
    private int audioPlayed = 0;
    public GameObject bubble;
    public GameObject figure;
    public GameObject subsBG;

    IEnumerator TheSequence()
    {
        // UniStorm.UniStormManager.Instance.ChangeWeatherWithTransition(rain); //JUNIOR commented this out on April 14 2022 to start the VR porting process
        yield return new WaitForSeconds(1.5f);
        source.Play();
        // brownie2D.SetActive(false);
        subs.text = "";
        yield return new WaitForSeconds(0.48f);
        subs.text = "The <color=#DEB638>zinc extraction</color> process produced high levels of <color=#DEB638>liquid waste</color> and <color=#DEB638>sulfur dioxide</color>.";
        yield return new WaitForSeconds(5.91f);
        subs.text = "The sulfur dioxide travelled into the earth and produced <color=#DEB638>acid rain</color>.";
        yield return new WaitForSeconds(4.855f);
        subs.text = "Other <color=#DEB638>pollutants</color> that were produced from this plant included";
        yield return new WaitForSeconds(2.8f);
        subs.text = "heavy metals such as zinc, cadmium, and lead.";
        yield return new WaitForSeconds(3.77f);
        subs.text = "These heavy metals contaminated water and air";
        yield return new WaitForSeconds(3.257f);
        subs.text = "which affected that habitat of the plant and animal life living in the gap.";
        yield return new WaitForSeconds(4.887f);
        subs.text = "The acid rain caused by the pollution also leached away the nutrients in the soil that plants needed to grow.";
        yield return new WaitForSeconds(5.685f);
        subs.text = "As plants withered away, so did the animals";
        yield return new WaitForSeconds(2.97f);
        subs.text = "since their food sources were disappearing as well.";
        yield return new WaitForSeconds(4.0f);
        checklist.SetActive(true);
        controlMenu.SetActive(true);
        subsBG.SetActive(true);
        subs.enabled = true;
        subs.text = "<color=#DEB638>Find</color> and <color=#DEB638>click on the green arrow</color> to continue with the tour.";
        audioPlayed++;
        talkBrownieText.text = " 1 / 1";
        arrow.SetActive(true);
        arrowText.text = " 1 / 1";
    }

    IEnumerator TreeSequence()
    {
        yield return new WaitForSeconds(35.0f);
        tree1.SetActive(false);
        deadtree1.SetActive(true);
        tree5.SetActive(false);
        deadtree5.SetActive(true);
        tree2.SetActive(false);
        deadtree2.SetActive(true);
        tree4.SetActive(false);
        deadtree4.SetActive(true);
        tree3.SetActive(false);
        deadtree3.SetActive(true);

    }

    public void StartTalking() {
        bubble.SetActive(false);
        figure.SetActive(false);
        checklist.SetActive(false);
        controlMenu.SetActive(false);
        dialogActive = true;
        subs.text = "";
        StartCoroutine(TheSequence());
        StartCoroutine(TreeSequence());
    }

    // Update is called once per frame
    void Update()
    {
        if (!dialogActive && Input.GetKeyDown(KeyCode.T) && audioPlayed == 0)
        {
            StartTalking();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            tree1.SetActive(false);
            deadtree1.SetActive(true);
            tree2.SetActive(false);
            deadtree2.SetActive(true);
            tree3.SetActive(false);
            deadtree3.SetActive(true);
            tree4.SetActive(false);
            deadtree4.SetActive(true);
            tree5.SetActive(false);
            deadtree5.SetActive(true);

        }

        if(PlayerPrefs.GetInt("Subs") == 0){
            subs.enabled = false;
            subsBG.SetActive(false);
        }
        else if(PlayerPrefs.GetInt("Subs") == 1){
            subs.enabled = true;
            if(source.isPlaying || source.time != 0) {
                subsBG.SetActive(true);
            }
        }
    }
}
