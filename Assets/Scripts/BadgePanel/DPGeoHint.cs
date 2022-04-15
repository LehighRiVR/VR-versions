using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DPGeoHint : MonoBehaviour
{
    public GameObject Badgeoff;
    
    public Text GeoHint;
    
    void Start()
    {
        Badgeoff.SetActive(false);
        
    }


    public void OnPointerEnter()
    {
        if (tag == "DP")
        {
            GUIStyle style = new GUIStyle();
            style.richText = true;
            string GUILayout = this.GeoHint.text;
            GeoHint.supportRichText = true;
            GeoHint.text = "<color=#C3FF0D>Dorney Park</color>\r\n is <size=40><b>5.7 km (W<color=#fbc718>S</color>W)</b></size> distant\r\n from the memorial monument.";
            Badgeoff.SetActive(true);
        }
       
    }

    public void OnPointerExit()
    {
        if (tag == "DP")
        {
            Badgeoff.SetActive(false);
        }
       
    }

}
