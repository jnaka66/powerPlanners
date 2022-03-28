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
    public Quaternion rotation;
    public List<object[]> allPowLineSpots;

    void Start(){
        if(objType=="powerLine"){
            //get info about spot
            float x = location[0];
            float y = location[1];
            createPowerLines cpl = GameObject.FindObjectOfType<createPowerLines>();
            allPowLineSpots = cpl.allPowLineSpots;
            object[] spot;
            for(int i=0;i<allPowLineSpots.Count;i++){
                if((float)allPowLineSpots[i][0]==x && (float)allPowLineSpots[i][1]==y){
                    spot = allPowLineSpots[i];
                    Debug.Log(spot[4]);
                    break;
                }
            }
            txt = new GameObject("powerLine "+ location[0]+","+location[1]+" "+"statsText");//the text for the stats
            
            Transform Transform = txt.GetComponent<Transform>();
            Vector2 Pos = new Vector2(x * tileXOffset+1,y * tileYOffset/2 -.5f);
            Vector2 txtPos = Pos+new Vector2(0,0.7f);
            Transform.position = txtPos;
            //set the text
            txt.AddComponent<TextMesh>();
            var txtmsh = txt.GetComponent<TextMesh>();
            txtmsh.richText = true;
            txtmsh.text =  "<color=#E0E300>1. Player 1-tier 1-50MW\n</color>";
            /*
            txtmsh.text += "2. Player 1-tier 1-50MW\n";
            txtmsh.text += "3. Player 1-tier 1-50MW\n";
            txtmsh.text += "4. Player 1-tier 1-50MW\n";
            txtmsh.text += "5. Player 2-tier 2-100MW\n";
            txtmsh.text += "6. Player 2-tier 1-50MW\n";
            txtmsh.text += "7. Player 3-tier 1-50MW\n";
            txtmsh.text += "8.";
            txtmsh.color = Color.red;
            */
            txtmsh.anchor = TextAnchor.UpperCenter;
            Vector2 scale = new Vector2(.017f,.017f);//large fonsize and small scale makes it look much better
            txtmsh.fontSize = 100;
            Transform.localScale = scale;
            gameObject.transform.SetParent(this.transform);
            txt.SetActive(false);
            MeshRenderer ren = txt.GetComponent<MeshRenderer>();
            ren.sortingOrder = 3;//put on top
            GameObject background = new GameObject("powerLine "+ location[0]+","+location[1]+" "+"statsBackground");
            Transform = background.GetComponent<Transform>();
            Transform.position = Pos;
            scale = new Vector2(2f,2f);
            Transform.localScale = scale;
            renderer = background.AddComponent<SpriteRenderer>();
            renderer.sortingOrder = 2;
            Sprite[] sprit = Resources.LoadAll<Sprite>("Square");
            renderer.sprite = sprit[0];
            renderer.enabled = false;
        }
        else{
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
                txtmsh.text = "Coal Plant";
                txtmsh.text += "\nProd: 100MW";
                txtmsh.text += "\nDelivered: "+delivered;
            }
            if(objType=="nuclear"){
                txtmsh.text = "Nuclear Plant";
                txtmsh.text += "\nProd: 300MW";
                txtmsh.text += "\nDelivered: "+delivered;
            }
            if(objType=="natural"){
                txtmsh.text = "Natural Gas";
                txtmsh.text += "\nProd: 150MW";
                txtmsh.text += "\nDelivered: "+delivered;
            }
            if(objType=="solar"){
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