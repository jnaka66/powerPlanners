using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class onHoverScript : MonoBehaviour
{
    GameObject txt;
    int bottomLeftX = -225;
    int bottomLeftY = -195;
    float canvasTileXOffset = 50;
    float canvasTileYOffset = 21.5f;
    float tileXOffset = .89f;
    float tileYOffset = .77f;
    public Vector2 location;

    void Start(){
        txt = new GameObject("statsText1");
        float x = location[0];
        float y = location[1];
        Transform Transform = txt.GetComponent<Transform>();
        Vector2 Pos = new Vector2(x * tileXOffset,y * tileYOffset/2 -.5f);
        Transform.position = Pos;

        txt.AddComponent<TextMesh>();
        var txtmsh = txt.GetComponent<TextMesh>();
        txtmsh.text = "test!!!!";
        txtmsh.color = Color.red;
        
        
        
        
        gameObject.transform.SetParent(this.transform);
        Text myText = gameObject.AddComponent<Text>();
        myText.text = "Ta-dah!";
/*
        
*/
        txt.SetActive(false);
        
    }
    void OnMouseOver()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        txt.SetActive(true);
        Debug.Log("Mouse is over GameObject.");
    }

    void OnMouseExit()
    {
        //The mouse is no longer hovering over the GameObject so output this message each frame
        txt.SetActive(false);
        Debug.Log("Mouse is no longer on GameObject.");
    }
}