using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class showCostHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
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
    public int cost=0;
    public GameObject parent;

    void Start(){
        txt = new GameObject("costText");//the text for the stats
        txt.transform.SetParent(parent.GetComponent<RectTransform>());
        //set the position to be close to the original object
        float x = location[0];
        float y = location[1];
        Transform Transform = txt.GetComponent<Transform>();
        Vector2 Pos = new Vector2(x * tileXOffset-1,y * tileYOffset/2 -.5f);
        Transform.position = Pos;

        //set the text
        txt.AddComponent<TextMesh>();
        var txtmsh = txt.GetComponent<TextMesh>();
        txtmsh.text = "Cost: "+cost;
        txtmsh.color = Color.red;
        txtmsh.anchor = TextAnchor.MiddleCenter;
        Vector2 scale = new Vector2(.03f,.03f);//large fonsize and small scale makes it look much better
        txtmsh.fontSize = 100;
        Transform.localScale = scale;
        gameObject.transform.SetParent(this.transform);
        txt.SetActive(false);
        MeshRenderer ren = txt.GetComponent<MeshRenderer>();
        ren.sortingLayerName = "info";
        ren.sortingOrder = 5;//put on top
        
        //make the background for the text
        GameObject background = new GameObject("costBackground");
        background.transform.SetParent(parent.GetComponent<Transform>());
        Transform = background.GetComponent<Transform>();
        Transform.position = Pos;
        scale = new Vector2(1.2f,.4f);
        Transform.localScale = scale;
        renderer = background.AddComponent<SpriteRenderer>();
        renderer.sortingOrder = 4;
        Sprite[] sprit = Resources.LoadAll<Sprite>("Square");
        renderer.sprite = sprit[0];
        renderer.sortingLayerName = "info";
        renderer.enabled = false;

    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        txt.SetActive(true);
        //background.SetActive(true);
        renderer.enabled = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        txt.SetActive(false);
        //background.SetActive(false);
        renderer.enabled = false;
    }
}
