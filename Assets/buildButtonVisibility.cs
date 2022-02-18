using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buildButtonVisibility : MonoBehaviour
{
    public bool showing=false;
    public GameObject buildCoalButton;
    public GameObject buildSolarButton;
    public GameObject buildNaturalButton;
    public GameObject buildNuclearButton;



    public void toggle(){
        showing = buildCoalButton.activeSelf;
        if(showing){
            while(GameObject.Find("Button(Clone)") != null){
                GameObject buttontest = GameObject.Find("Button(Clone)");
                buttontest.gameObject.SetActive(false);
            }
            buildCoalButton.SetActive(false);
            buildSolarButton.SetActive(false);
            buildNaturalButton.SetActive(false);
            buildNuclearButton.SetActive(false);
        }//penis
        else if(!showing){
            buildCoalButton.SetActive(true);
            buildSolarButton.SetActive(true);
            buildNaturalButton.SetActive(true);
            buildNuclearButton.SetActive(true);
        }
    }
}
