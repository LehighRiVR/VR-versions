using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FiltroGeoHint : MonoBehaviour
{
    public GameObject Badgeoff;
    
    public Text GeoHint;
    
    void Start()
    {
        Badgeoff.SetActive(false);
    }
    
   
    public void OnPointerEnter()
    {
        if (tag == "Filtro")
        {
            GUIStyle style = new GUIStyle();
            style.richText = true;
            string GUILayout = this.GeoHint.text;
            GeoHint.supportRichText = true;
            GeoHint.text = "<color=#00A9F4>Water Filtration Plant</color>\r\n is <size=40><b>1.3 km (<color=#fbc718>S</color>W)</b></size> distant\r\n from the memorial monument.";
            Badgeoff.SetActive(true);
        }
       
    }

    public void OnPointerExit()
    {
        if (tag == "Filtro")
        {
            Badgeoff.SetActive(false);
        }
       
    }

}
