using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FishGeoHint : MonoBehaviour
{
    public GameObject Badgeoff;
    
    public Text GeoHint;
   
    void Start()
    {
        Badgeoff.SetActive(false);
        
    }


    public void OnPointerEnter()
    {
        if (tag == "Fish")
        {
            GUIStyle style = new GUIStyle();
            style.richText = true;
            string GUILayout = this.GeoHint.text;
            GeoHint.supportRichText = true;
            GeoHint.text = "<color=#FFAEC8>Li'l-Le-Hi Fish Hatchery</color>\r\n is <size=40><b>5.5 km (<color=#fbc718>S</color>W)</b></size> distant\r\n from the memorial monument.";
            Badgeoff.SetActive(true);
        }
       
    }

    public void OnPointerExit()
    {
        if (tag == "Fish")
        {
            Badgeoff.SetActive(false);
        }
       
    }

}
