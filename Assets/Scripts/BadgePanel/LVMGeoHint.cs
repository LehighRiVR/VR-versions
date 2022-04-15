using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LVMGeoHint : MonoBehaviour
{
    public GameObject Badgeoff;
    
    public Text GeoHint;
    

    void Start()
    {
        Badgeoff.SetActive(false);
       ;
    }

      


    public void OnPointerEnter()
    {
        if (tag == "LVM")
        {
            GUIStyle style = new GUIStyle();
            style.richText = true;
            string GUILayout = this.GeoHint.text;
            GeoHint.supportRichText = true;
            GeoHint.text = "<color=#0DD244>Lehigh Valley Mall</color>\r\n is <size=40><b>3.2 km (<color=#e81c23>NN</color>W)</b></size> distant\r\n from the memorial monument.";
            Badgeoff.SetActive(true);
        }
       
    }

    public void OnPointerExit()
    {
        if (tag == "LVM")
        {
            Badgeoff.SetActive(false);
        }
       
    }

}
