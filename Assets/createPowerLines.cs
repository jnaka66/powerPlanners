using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class createPowerLines : MonoBehaviour
{
    public GameObject prefabButton;
    public RectTransform ParentPanel;
    
    public ScoreManager scoreMan;
    public HexTileMapGenerator mapGen;
    public GameObject player1PowerLine;
    public GameObject player2PowerLine;
    public GameObject player3PowerLine;
    public GameObject player4PowerLine;
    
    int width = 10;
    int height = 9;

    int bottomLeftX = -225;
    int bottomLeftY = -195;
    float canvasTileXOffset = 50;
    float canvasTileYOffset = 21.5f;
    float tileXOffset = .89f;
    float tileYOffset = .77f;
    int numOfButtons = 0;

    // void Start()
    // {
    //     createButtons();
    // }

    void Awake()
    {
        mapGen = GameObject.FindObjectOfType<HexTileMapGenerator>();
        scoreMan = GameObject.FindObjectOfType<ScoreManager>();
    }

    bool buildSelected = false;

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
        for (int i = 0; i < numOfButtons; i++)
        {
            buttontest = GameObject.Find("LineButton(Clone)");
            buttontest.gameObject.SetActive(false);
        }
        numOfButtons = 0;
    }

    void createButtons()//this calls makeButton on all of the bottoms of the hexagons
    {
        for (int y = 0; y < height * 2; y++)
        {
            for (int x = 0; x < width; x++)
            {

                if (y == 0 && x < width - 2 && x > 1)
                {
                    makeButton(x+0.25f, y+0.25f, new Quaternion(0.5f, 1.0f, 0.0f, 0.0f));//bottom
                    makeButton(x + 0.25f, y + 2.25f, new Quaternion(1.65f, 1.0f, 0.0f, 0.0f));//top
                    makeButton(x - 0.25f, y + 0.25f,new Quaternion(1.65f, 1.0f, 0.0f, 0.0f));//bot left
                    makeButton(x - 0.25f, y + 2.25f, new Quaternion(0.5f, 1.0f, 0.0f, 0.0f));//top left
                    makeButton(x + .5f, y + 1.25f, new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                    if (x == 2)//special case on left side
                    {
                        makeButton(x-0.5f , y+1.2f, new Quaternion(0.0f, 1.0f, 0.0f, 0.0f));
                        makeButton(x - 0.75f, y + 2.25f, new Quaternion(1.65f, 1.0f, 0.0f, 0.0f));
                    }
                    if (x == width - 3)//special case on right side
                    {
                       
                        makeButton(x + 0.75f, y + 2.25f, new Quaternion(0.5f, 1.0f, 0.0f, 0.0f));
                        makeButton(x + 1, y + 3.25f, new Quaternion(0.0f, 1.0f, 0.0f, 0.0f));
                    }

                }

                if (y == 4 && x < width - 1 && x > 0)
                {
                    makeButton(x + 0.25f, y + 0.25f, new Quaternion(0.5f, 1.0f, 0.0f, 0.0f));//bottom
                    makeButton(x + 0.25f, y + 2.25f, new Quaternion(1.65f, 1.0f, 0.0f, 0.0f));//top
                    makeButton(x - 0.25f, y + 0.25f, new Quaternion(1.65f, 1.0f, 0.0f, 0.0f));//bot left
                    makeButton(x - 0.25f, y + 2.25f, new Quaternion(0.5f, 1.0f, 0.0f, 0.0f));//top left
                    makeButton(x + .5f, y + 1.25f, new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                    makeButton(x, y - 0.75f, new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                    if (x == 1)//special case on left side
                    {
                        makeButton(x - 0.75f, y + 2.25f, new Quaternion(1.65f, 1.0f, 0.0f, 0.0f));
                        makeButton(x-0.5f,y+1.25f, new Quaternion(0.0f, 1.0f, 0.0f, 0.0f));
                    }
                    if (x == width - 2)//special case on right side
                    {
                        makeButton(x + 0.75f, y + 2.25f, new Quaternion(0.5f, 1.0f, 0.0f, 0.0f));
                        
                    }

                }
                if (y == 8)
                {
                    makeButton(x + 0.25f, y + 0.25f, new Quaternion(0.5f, 1.0f, 0.0f, 0.0f));//bottom
                    makeButton(x + 0.25f, y + 2.25f, new Quaternion(1.65f, 1.0f, 0.0f, 0.0f));//top
                    makeButton(x - 0.25f, y + 0.25f, new Quaternion(1.65f, 1.0f, 0.0f, 0.0f));//bot left
                    makeButton(x - 0.25f, y + 2.25f, new Quaternion(0.5f, 1.0f, 0.0f, 0.0f));//top left
                    makeButton(x + .5f, y + 1.25f, new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                    makeButton(x, y - 0.6f, new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                    if (x == 1)//special case on left side
                    {
                        makeButton(x-1.5f, y+1.25f, new Quaternion(0.0f, 1.0f, 0.0f, 0.0f));
                        makeButton(x - 0.75f, y + 4.2f, new Quaternion(0.5f, 1.0f, 0.0f, 0.0f));
                        //makeButton(x, y - 0.6f);
                        makeButton(x - 1.0f, y - 0.6f, new Quaternion(0.0f, 1.0f, 0.0f, 0.0f));
                    }


                }
                if (y == 12 && x < width - 1 && x > 0)
                {
                    makeButton(x + 0.25f, y + 0.25f, new Quaternion(0.5f, 1.0f, 0.0f, 0.0f));//bottom
                    makeButton(x + 0.25f, y + 2.25f, new Quaternion(1.65f, 1.0f, 0.0f, 0.0f));//top
                    makeButton(x - 0.25f, y + 0.25f, new Quaternion(1.65f, 1.0f, 0.0f, 0.0f));//bot left
                    makeButton(x - 0.25f, y + 2.25f, new Quaternion(0.5f, 1.0f, 0.0f, 0.0f));//top left
                    makeButton(x + .5f, y + 1.25f, new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                    makeButton(x, y - 0.6f, new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));

                    if (x == 1)
                    {
                        makeButton(x - 1.0f, y - 0.6f, new Quaternion(0.0f, 1.0f, 0.0f, 0.0f));
                        makeButton(x-0.5f, y+1.25f, new Quaternion(0.0f, 1.0f, 0.0f, 0.0f));
                    }

                    if(x == width - 2)
                    {
                        makeButton(x+1.0f,y-0.6f, new Quaternion(0.0f, 1.0f, 0.0f, 0.0f));
                        makeButton(x - 1.0f, y - 0.6f, new Quaternion(0.0f, 1.0f, 0.0f, 0.0f));
                        makeButton(x +0.75f, y+0.25f, new Quaternion(1.65f, 1.0f, 0.0f, 0.0f));
                    }

                }

                if (y == 16 && x < width - 2 && x > 1)
                {
                    makeButton(x + 0.25f, y + 0.25f, new Quaternion(0.5f, 1.0f, 0.0f, 0.0f));//bottom
                    makeButton(x + 0.25f, y + 2.25f, new Quaternion(1.65f, 1.0f, 0.0f, 0.0f));//top
                    makeButton(x - 0.25f, y + 0.25f, new Quaternion(1.65f, 1.0f, 0.0f, 0.0f));//bot left
                    makeButton(x - 0.25f, y + 2.25f, new Quaternion(0.5f, 1.0f, 0.0f, 0.0f));//top left
                    makeButton(x + .5f, y + 1.25f, new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                    makeButton(x+1.0f, y-0.6f,new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                    if (x == 2)//special case on left side
                    {
                        makeButton(x - 0.5f, y + 1.25f, new Quaternion(0.0f, 1.0f, 0.0f, 0.0f));
                        makeButton(x - 0.75f, y+0.25f, new Quaternion(1.65f, 1.0f, 0.0f, 0.0f));
                        makeButton(x, y-0.6f, new Quaternion(0.0f, 1.0f, 0.0f, 0.0f));
                        makeButton(x - 1.0f, y - 0.6f, new Quaternion(0.0f, 1.0f, 0.0f, 0.0f));
                    }

                    if(x == width - 3)
                    {
                        makeButton(x + 0.75f, y+0.25f, new Quaternion(1.65f, 1.0f, 0.0f, 0.0f));
                    }


                }

            }
        }

        //for (int x = 0; x < width; x++)
        //{
        //    for (int y = 0; y < height; y++)
        //    {

        //        if (y % 2 == 0)//even rows
        //        {
        //            if ((y == 0 || y == 8) && x > 1 && x < 8)
        //            {
        //                makeButton(x * tileXOffset + 0.45f, y * tileYOffset);
        //                makeButton(x * tileXOffset + 0.2f, y * tileYOffset + 0.4f);
        //                makeButton(x * tileXOffset + 0.2f, y * tileYOffset - 0.4f);

        //                /*GameObject obj = Instantiate(prefab);
        //                obj.transform.position = new Vector2(x * tileXOffset + 0.45f, y * tileYOffset);

        //                GameObject obj1 = Instantiate(prefab);
        //                obj1.transform.position = new Vector2(x * tileXOffset + 0.2f, y * tileYOffset + 0.4f);
        //                obj1.transform.rotation = new Quaternion(1.65f, 1.0f, 0.0f, 0.0f);

        //                GameObject obj2 = Instantiate(prefab);
        //                obj2.transform.position = new Vector2(x * tileXOffset + 0.2f, y * tileYOffset - 0.4f);
        //                obj2.transform.rotation = new Quaternion(0.5f, 1.0f, 0.0f, 0.0f);*/



        //            }
        //            if ((y == 2 || y == 6) && x > 0 && x < 9)
        //            {
        //                makeButton(x * tileXOffset + 0.45f, y * tileYOffset);
        //                makeButton(x * tileXOffset + 0.2f, y * tileYOffset + 0.4f);
        //                makeButton(x * tileXOffset + 0.2f, y * tileYOffset - 0.4f);
        //                /*GameObject obj = Instantiate(prefab);
        //                obj.transform.position = new Vector2(x * tileXOffset + 0.45f, y * tileYOffset);

        //                GameObject obj1 = Instantiate(prefab);
        //                obj1.transform.position = new Vector2(x * tileXOffset + 0.2f, y * tileYOffset + 0.4f);
        //                obj1.transform.rotation = new Quaternion(1.65f, 1.0f, 0.0f, 0.0f);

        //                GameObject obj2 = Instantiate(prefab);
        //                obj2.transform.position = new Vector2(x * tileXOffset + 0.2f, y * tileYOffset - 0.4f);
        //                obj2.transform.rotation = new Quaternion(0.5f, 1.0f, 0.0f, 0.0f);*/

        //            }
        //            if (y == 4)
        //            {
        //                makeButton(x * tileXOffset + 0.45f, y * tileYOffset);
        //                makeButton(x * tileXOffset + 0.2f, y * tileYOffset + 0.4f);
        //                makeButton(x * tileXOffset + 0.2f, y * tileYOffset - 0.4f);
        //                /*GameObject obj = Instantiate(prefab);
        //                obj.transform.position = new Vector2(x * tileXOffset + 0.45f, y * tileYOffset);

        //                GameObject obj1 = Instantiate(prefab);
        //                obj1.transform.position = new Vector2(x * tileXOffset + 0.2f, y * tileYOffset + 0.4f);
        //                obj1.transform.rotation = new Quaternion(1.65f, 1.0f, 0.0f, 0.0f);

        //                GameObject obj2 = Instantiate(prefab);
        //                obj2.transform.position = new Vector2(x * tileXOffset + 0.2f, y * tileYOffset - 0.4f);
        //                obj2.transform.rotation = new Quaternion(0.5f, 1.0f, 0.0f, 0.0f);*/

        //            }

        //        }
        //        else
        //        {
        //            if ((y == 1 || y == 7) && x > 0 & x < 8)
        //            {
        //                makeButton(x * tileXOffset + 0.45f + 0.45f, y * tileYOffset);
        //                makeButton(x * tileXOffset + 0.2f + 0.45f, y * tileYOffset + 0.4f);
        //                makeButton(x * tileXOffset + 0.2f + 0.45f, y * tileYOffset - 0.4f);

        //                /*GameObject obj = Instantiate(prefab);
        //                obj.transform.position = new Vector2(x * tileXOffset + 0.45f + 0.45f, y * tileYOffset);

        //                GameObject obj1 = Instantiate(prefab);
        //                obj1.transform.position = new Vector2(x * tileXOffset + 0.2f + 0.45f, y * tileYOffset + 0.4f);
        //                obj1.transform.rotation = new Quaternion(1.65f, 1.0f, 0.0f, 0.0f);

        //                GameObject obj2 = Instantiate(prefab);
        //                obj2.transform.position = new Vector2(x * tileXOffset + 0.2f + 0.45f, y * tileYOffset - 0.4f);
        //                obj2.transform.rotation = new Quaternion(0.5f, 1.0f, 0.0f, 0.0f);*/

        //            }
        //            if ((y == 3 || y == 5) && x < 9)
        //            {
        //                makeButton(x * tileXOffset + 0.45f + 0.45f, y * tileYOffset);
        //                makeButton(x * tileXOffset + 0.2f + 0.45f, y * tileYOffset + 0.4f);
        //                makeButton(x * tileXOffset + 0.2f + 0.45f, y * tileYOffset - 0.4f);
        //                /* GameObject obj = Instantiate(prefab);
        //                 obj.transform.position = new Vector2(x * tileXOffset + 0.45f + 0.45f, y * tileYOffset);

        //                 GameObject obj1 = Instantiate(prefab);
        //                 obj1.transform.position = new Vector2(x * tileXOffset + 0.2f + 0.45f, y * tileYOffset + 0.4f);
        //                 obj1.transform.rotation = new Quaternion(1.65f, 1.0f, 0.0f, 0.0f);

        //                 GameObject obj2 = Instantiate(prefab);
        //                 obj2.transform.position = new Vector2(x * tileXOffset + 0.2f + 0.45f, y * tileYOffset - 0.4f);
        //                 obj2.transform.rotation = new Quaternion(0.5f, 1.0f, 0.0f, 0.0f);*/

        //            }
        //        }

        //    }
        //}

    }
    public GameObject buttontest;
    

    void ButtonClicked(Button tempButton, string buttonNo, float x, float y, Quaternion rotation)
    {
        //Debug.Log("Button clicked = " + buttonNo);

        makePowerLine((int)scoreMan.turn, x, y,rotation);

        // tempButton.gameObject.SetActive(false);
        deleteButtons();
        buildSelected = false;
        // buttontest = GameObject.Find("Button(Clone)");
        // buttontest.gameObject.SetActive(false);
        //var ren1 = tempButton.gameObject.GetComponent<Renderer>();
        //ren1.enabled = false;

    }

    void makePowerLine(int playerTurn, float x, float y, Quaternion rotation)
    {
        GameObject powLine = new GameObject();
        if (playerTurn == 0)
        {
            powLine = player1PowerLine;
        }
        if (playerTurn == 1)
        {
            powLine = player2PowerLine;
        }
        if (playerTurn == 2)
        {
<<<<<<< Updated upstream
            powLine = player3PowerLine;
=======
            if (playerTurn == 0)
            {
                powLine = player1PowerLine;
            }
            if (playerTurn == 1)
            {
                powLine = player2PowerLine;
            }
            if (playerTurn == 2)
            {
                powLine = player3PowerLine;
            }
            if (playerTurn == 3)
            {
                powLine = player4PowerLine;
            }

            GameObject TempGo = Instantiate(powLine);
            TempGo.name = "PLine"+playerTurn;
            TempGo.transform.position = new Vector2(x * tileXOffset, y * tileYOffset / 2 - .5f);
            // GameObject dispLine = new GameObject();
            // dispLine.name = "test"+playerTurn;
            TempGo.transform.rotation = rotation;

            var ren = TempGo.GetComponent<SpriteRenderer>();
            ren.sortingOrder = 1;
            ren.enabled = true;

            if (playerTurn == 0)
            {
                P1Lines.Add(new Vector2(x, y));
            }
            if (playerTurn == 1)
            {
                P2Lines.Add(new Vector2(x, y));
            }
            if (playerTurn == 2)
            {
                P3Lines.Add(new Vector2(x, y));
            }
            if (playerTurn == 3)
            {
                P4Lines.Add(new Vector2(x, y));
            }

            updateNumPowLines(playerTurn, x, y);

            GameObject dispLine = new GameObject();
            dispLine.AddComponent<BoxCollider>();
            dispLine.AddComponent<onHoverScript>();
            var hover= dispLine.GetComponent<onHoverScript>();
            hover.location = new Vector2(x,y);//pass the location
            hover.objType = "powline";//and type
            hover.parent = dispLine;
>>>>>>> Stashed changes
        }
        if (playerTurn == 3)
        {
            powLine = player4PowerLine;
        }
        GameObject TempGo = Instantiate(powLine);

        TempGo.transform.position = new Vector2(x * tileXOffset, y * tileYOffset / 2 - .5f);
        TempGo.transform.rotation = rotation;
        var ren = TempGo.GetComponent<SpriteRenderer>();
        ren.enabled = true;

    }
    void makeButton(float x, float y, Quaternion rotation)//this makes buttons to build factories on all of the hex above it
    {
        //make bottom button
        GameObject goButton = (GameObject)Instantiate(prefabButton);
        goButton.transform.SetParent(ParentPanel, false);
        goButton.transform.localScale = new Vector3(1, 1, 1);

        Button tempButton = goButton.GetComponent<Button>();
        tempButton.gameObject.SetActive(true);
        string location = (bottomLeftX + x * tileXOffset).ToString() + "," + (bottomLeftY + y * tileYOffset).ToString();

        tempButton.onClick.AddListener(() => ButtonClicked(tempButton, location, x, y, rotation));

        RectTransform rectTransform = goButton.GetComponent<RectTransform>();
        Vector2 anchoredPos = new Vector2(bottomLeftX + x * canvasTileXOffset, bottomLeftY + y * canvasTileYOffset);
        rectTransform.anchoredPosition = anchoredPos;

        numOfButtons++;
    }
}
