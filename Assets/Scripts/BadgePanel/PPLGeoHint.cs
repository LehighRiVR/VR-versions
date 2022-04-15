using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PPLGeoHint : MonoBehaviour
{
    public GameObject BadgeOff;
    
    public Text GeoHint;
   

    void Start()
    {
        BadgeOff.SetActive(false);
        
    }

    public void OnPointerEnter()
    {
        if (tag == "PPL")
        {
            GUIStyle style = new GUIStyle();
            style.richText = true;
            string GUILayout = this.GeoHint.text;
            GeoHint.supportRichText = true;
            GeoHint.text = "<color=yellow>PPL Center</color>\r\n is <size=40><b>110.0 m (W<color=#fbc718>S</color>W)</b></size> distant\r\n from the memorial monument.";
            BadgeOff.SetActive(true);
        }
       
    }

    public void OnPointerExit()
    {
        if (tag == "PPL")
        {
            BadgeOff.SetActive(false);
        }
       
    }

}
