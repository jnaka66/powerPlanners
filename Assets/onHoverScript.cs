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
    public GameObject parent;
    public int production=0;

    void Start(){
        txt = new GameObject("statsText");//the text for the stats
        txt.transform.SetParent(parent.GetComponent<Transform>());
        //set the position to be close to the original object
        float x = location[0];
        float y = location[1];
        Transform Transform = txt.GetComponent<Transform>();
        Vector2 Pos = new Vector2(x * tileXOffset+1,y * tileYOffset/2 -.5f);
        Transform.position = Pos;

        //set the text
        txt.AddComponent<TextMesh>();
        var txtmsh = txt.GetComponent<TextMesh>();
        if(objType=="City" || objType=="Town"){
            txtmsh.text = objType;
            txtmsh.text += "\nDemand: "+demand;
            txtmsh.text += "\nDelivered: "+delivered;
            txtmsh.text += "\nHappiness: "+happiness;
        }
        if(objType=="coal"){
            production=100;
            txtmsh.text = "Coal Plant";
            txtmsh.text += "\nProd: 100MW";
            txtmsh.text += "\nDelivered: "+delivered;
        }
        if(objType=="nuclear"){
            production=300;
            txtmsh.text = "Nuclear Plant";
            txtmsh.text += "\nProd: 300MW";
            txtmsh.text += "\nDelivered: "+delivered;
        }
        if(objType=="natural"){
            production=150;
            txtmsh.text = "Natural Gas";
            txtmsh.text += "\nProd: 150MW";
            txtmsh.text += "\nDelivered: "+delivered;
        }
        if(objType=="solar"){
            production=200;
            txtmsh.text = "Solar Plant";
            txtmsh.text += "\nProd: 200MW";
            txtmsh.text += "\nDelivered: "+delivered;
        }
        txtmsh.color = Color.red;
        txtmsh.anchor = TextAnchor.MiddleCenter;
        Vector2 scale = new Vector2(.2f,.2f);//large fonsize and small scale makes it look much better
        txtmsh.fontSize = 100;
        Transform.localScale = scale;
        gameObject.transform.SetParent(this.transform);
        txt.SetActive(false);
        MeshRenderer ren = txt.GetComponent<MeshRenderer>();
        ren.sortingOrder = 3;//put on top
        
        //make the background for the text
        GameObject background = new GameObject("statsBackground");
        background.transform.SetParent(parent.GetComponent<Transform>());
        Transform = background.GetComponent<Transform>();
        Transform.position = Pos;
        scale = new Vector2(12f,10f);
        Transform.localScale = scale;
        renderer = background.AddComponent<SpriteRenderer>();
        renderer.sortingOrder = 2;
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