using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class B21GeoHint : MonoBehaviour
{
    public GameObject Badgeoff;
    
    public Text GeoHint;
    

    void Start()
    {
        Badgeoff.SetActive(false);
      
    }




    public void OnPointerEnter()
    {
        if (tag == "B21")
        {
            GUIStyle style = new GUIStyle();
            style.richText = true;
            string GUILayout = this.GeoHint.text;
            GeoHint.supportRichText = true;
            GeoHint.text = "<color=#FF7F26>Building 21 High School</color>\r\n is <size=40><b>490.0 m (<color=#fbc718>S</color>E)</b></size> distant\r\n from the memorial monument.";
            Badgeoff.SetActive(true);
                       
        }
       
    }

    public void OnPointerExit()
    {
        if (tag == "B21")
        {
            Badgeoff.SetActive(false);
        }
       
    }

}
