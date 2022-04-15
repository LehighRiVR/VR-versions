using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WWGeoHint : MonoBehaviour
{
    public GameObject Badgeoff;
    
    public Text GeoHint;
    

    void Start()
    {
        Badgeoff.SetActive(false);
       
    }



    public void OnPointerEnter()
    {
        if (tag == "WW")
        {
            GUIStyle style = new GUIStyle();
            style.richText = true;
            string GUILayout = this.GeoHint.text;
            GeoHint.supportRichText = true;
            GeoHint.text = "<color=#AE55D4>Wastewater Treatment Plant</color>\r\n is <size=40><b>1.5 km (E<color=#fbc718>S</color>E)</b></size> distant\r\n from the memorial monument.";
            Badgeoff.SetActive(true);
        }
       
    }

    public void OnPointerExit()
    {
        if (tag == "WW")
        {
            Badgeoff.SetActive(false);
        }
       
    }

}
