using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class upgradeTransmissionLine : MonoBehaviour
{
    public createPowerLines powerLines;
    public List<Vector2> P1Lines = new List<Vector2>();
    public List<Vector2> P2Lines = new List<Vector2>();
    public List<Vector2> P3Lines = new List<Vector2>();
    public List<Vector2> P4Lines = new List<Vector2>();
    public List<Button> PowLineButtons = new List<Button>();
    public ScoreManager scoreMan;
    public List<object[]> allPowLineSpots = new List<object[]>();


    bool buildSelected = false;

    void Awake()
    {
        powerLines = GameObject.FindObjectOfType<createPowerLines>();
        scoreMan = GameObject.FindObjectOfType<ScoreManager>();
        P1Lines = powerLines.P1Lines;
        P2Lines = powerLines.P2Lines;
        P3Lines = powerLines.P3Lines;
        P4Lines = powerLines.P4Lines;
        PowLineButtons = powerLines.PowLineButtons;
        allPowLineSpots = powerLines.allPowLineSpots;
    }

    public void spawnButtons()
    {
        if (!buildSelected)
        {
            createButtons();
            //Debug.Log("num" + numOfButtons);
            buildSelected = true;
        }
        else
        {
            deleteButtons();
            buildSelected = false;
        }
    }
    public void deleteButtons()
    {
        GameObject buttontest;
        while (GameObject.Find("LineButton(Clone)") != null)
        {
            buttontest = GameObject.Find("LineButton(Clone)");
            buttontest.gameObject.SetActive(false);
        }
    }
    public void createButtons()//this calls makeButton on all of the bottoms of the hexagons
    {
        if((int)scoreMan.turn==0){
            for(int i=0;i<P1Lines.Count;i++){
                for(int x=0;x<allPowLineSpots.Count;x++){
                    if(P1Lines[i][0] == (float)allPowLineSpots[x][0] && P1Lines[i][1] == (float)allPowLineSpots[x][1]){
                        PowLineButtons[x].gameObject.SetActive(true);
                    }
                }
                    
            }
        }
        if((int)scoreMan.turn==1){
            for(int i=0;i<P2Lines.Count;i++){
                for(int x=0;x<allPowLineSpots.Count;x++){
                    if(P2Lines[i][0] == (float)allPowLineSpots[x][0] && P2Lines[i][1] == (float)allPowLineSpots[x][1]){
                        PowLineButtons[x].gameObject.SetActive(true);
                    }
                }
            }
        }
        if((int)scoreMan.turn==2){
            for(int i=0;i<P3Lines.Count;i++){
                for(int x=0;x<allPowLineSpots.Count;x++){
                    if(P3Lines[i][0] == (float)allPowLineSpots[x][0] && P3Lines[i][1] == (float)allPowLineSpots[x][1]){
                        PowLineButtons[x].gameObject.SetActive(true);
                    }
                }
            }
        }
        if((int)scoreMan.turn==3){
            for(int i=0;i<P4Lines.Count;i++){
                for(int x=0;x<allPowLineSpots.Count;x++){
                    if(P4Lines[i][0] == (float)allPowLineSpots[x][0] && P4Lines[i][1] == (float)allPowLineSpots[x][1]){
                        PowLineButtons[x].gameObject.SetActive(true);
                    }
                }
            }
        }
        
    }
}
