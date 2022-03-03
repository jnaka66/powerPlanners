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
    SpriteRenderer renderer;
    public Vector2 location;
    public string objType;
    public int demand=0;
    public int happiness=0;
    public int delivered=0;

    void Start(){
        txt = new GameObject("statsText");
        float x = location[0];
        float y = location[1];
        Transform Transform = txt.GetComponent<Transform>();
        Vector2 Pos = new Vector2(x * tileXOffset+1,y * tileYOffset/2 -.5f);
        Transform.position = Pos;
        txt.AddComponent<TextMesh>();
        var txtmsh = txt.GetComponent<TextMesh>();
        txtmsh.text = objType;
        if(objType=="City" || objType=="Town"){
            txtmsh.text += "\nDemand: "+demand;
            txtmsh.text += "\nDelivered: "+delivered;
            txtmsh.text += "\nHappiness: "+happiness;
        }
        txtmsh.color = Color.red;
        txtmsh.anchor = TextAnchor.MiddleCenter;
        Vector2 scale = new Vector2(.03f,.03f);
        txtmsh.fontSize = 100;
        Transform.localScale = scale;
        gameObject.transform.SetParent(this.transform);
        txt.SetActive(false);
        MeshRenderer ren = txt.GetComponent<MeshRenderer>();
        ren.sortingOrder = 2;
        
        GameObject background = new GameObject("statsBackground");
        Transform = background.GetComponent<Transform>();
        Transform.position = Pos;
        scale = new Vector2(1.8f,1.33f);
        Transform.localScale = scale;
        renderer = background.AddComponent<SpriteRenderer>();
        renderer.sortingOrder = 1;
        Sprite[] sprit = Resources.LoadAll<Sprite>("Square");
        renderer.sprite = sprit[0];
        renderer.enabled = false;

    }
    void OnMouseOver()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        txt.SetActive(true);
        //background.SetActive(true);
        renderer.enabled = true;
    }

    void OnMouseExit()
    {
        //The mouse is no longer hovering over the GameObject so output this message each frame
        txt.SetActive(false);
        //background.SetActive(false);
        renderer.enabled = false;
    }
}