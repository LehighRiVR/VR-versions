using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DamGeoHint : MonoBehaviour
{
    public GameObject Badgeoff;
    
    public Text GeoHint;
    

    void Start()
    {
        Badgeoff.SetActive(false);
       
    }



    public void OnPointerEnter()
    {
        if (tag == "Dam")
        {
            GUIStyle style = new GUIStyle();
            style.richText = true;
            string GUILayout = this.GeoHint.text;
            GeoHint.supportRichText = true;
            GeoHint.text = "<color=#FAC091>Hamilton Street Dam</color>\r\n is <size=40><b>1.6 km (E<color=#e81c23>N</color>E)</b></size> distant\r\n from the memorial monument.";
            Badgeoff.SetActive(true);
        }
       
    }

    public void OnPointerExit()
    {
        if (tag == "Dam")
        {
            Badgeoff.SetActive(false);
        }
       
    }

}
