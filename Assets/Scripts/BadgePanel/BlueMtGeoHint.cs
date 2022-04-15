using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BlueMtGeoHint : MonoBehaviour
{
    public GameObject Badgeoff;
    
    public Text GeoHint;
  

    void Start()
    {
        Badgeoff.SetActive(false);
        
    }


    

    public void OnPointerEnter()
    {
        if (tag == "BlueMt")
        {
            GUIStyle style = new GUIStyle();
            style.richText = true;
            string GUILayout = this.GeoHint.text;
            GeoHint.supportRichText = true;
            GeoHint.text = "<color=#8CFFFD>Blue Mountain Resort</color>\r\n is <size=40><b>23.5 km (<color=#e81c23>NN</color>W)</b></size> distant\r\n from the memorial monument.";
            Badgeoff.SetActive(true);
        }
       
    }

    public void OnPointerExit()
    {
        if (tag == "BlueMt")
        {
            Badgeoff.SetActive(false);
        }
       
    }

}
