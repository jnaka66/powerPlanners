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

<<<<<<< Updated upstream
        numOfButtons++;
=======
                    if (bot2X == xCoord && bot2Y == yCoord)
                    {
                        if (checkLegalLinePlacement(playerturn, xCoord, yCoord) == false)
                        {
                            PowLineButtons[j].gameObject.SetActive(false);
                        }
                        else
                        {
                            PowLineButtons[j].gameObject.SetActive(true);
                        }
                    }


                    if (topL2X == xCoord && topL2Y == yCoord)
                    {
                        if (checkLegalLinePlacement(playerturn, xCoord, yCoord) == false)
                        {
                            PowLineButtons[j].gameObject.SetActive(false);
                        }
                        else
                        {
                            PowLineButtons[j].gameObject.SetActive(true);
                        }

                    }
                }
            }
        }

        if (playerturn == 1)
        {

            for (int i = 0; i < P2Lines.Count; i++)
            {
                for (int j = 0; j < allPowLineSpots.Count; j++)
                {
                    float xCoord = (float)allPowLineSpots[j][0];
                    float yCoord = (float)allPowLineSpots[j][1];

                    float topX = (float)P2Lines[i][0] + 0.25f;
                    float topY = (float)P2Lines[i][1] + 1.0f;

                    float bot1X = (float)P2Lines[i][0] - 0.25f;
                    float bot1Y = (float)P2Lines[i][1] - 1.0f;

                    float topL1X = (float)P2Lines[i][0] - 0.5f;
                    float topL1Y = (float)P2Lines[i][1];

                    float topRX = (float)P2Lines[i][0] + 0.5f;
                    float topRY = (float)P2Lines[i][1];

                    float topL2X = (float)P2Lines[i][0] - 0.25f;
                    float topL2Y = (float)P2Lines[i][1] + 1.0f;

                    float bot2X = (float)P2Lines[i][0] + 0.25f;
                    float bot2Y = (float)P2Lines[i][1] - 1.0f;

                    if (topX == xCoord && topY == yCoord)
                    {
                        if (checkLegalLinePlacement(playerturn, xCoord, yCoord) == false)
                        {
                            PowLineButtons[j].gameObject.SetActive(false);
                        }
                        else
                        {
                            PowLineButtons[j].gameObject.SetActive(true);
                        }

                    }

                    if (topL1X == xCoord && topL1Y == yCoord)
                    {
                        if (checkLegalLinePlacement(playerturn, xCoord, yCoord) == false)
                        {
                            PowLineButtons[j].gameObject.SetActive(false);
                        }
                        else
                        {
                            PowLineButtons[j].gameObject.SetActive(true);
                        }

                    }


                    if (topRX == xCoord && topRY == yCoord)
                    {
                        if (checkLegalLinePlacement(playerturn, xCoord, yCoord) == false)
                        {
                            PowLineButtons[j].gameObject.SetActive(false);
                        }
                        else
                        {
                            PowLineButtons[j].gameObject.SetActive(true);
                        }
                    }

                    if (bot1X == xCoord && bot1Y == yCoord)
                    {
                        if (checkLegalLinePlacement(playerturn, xCoord, yCoord) == false)
                        {
                            PowLineButtons[j].gameObject.SetActive(false);
                        }
                        else
                        {
                            PowLineButtons[j].gameObject.SetActive(true);
                        }
                    }

                    if (bot2X == xCoord && bot2Y == yCoord)
                    {
                        if (checkLegalLinePlacement(playerturn, xCoord, yCoord) == false)
                        {
                            PowLineButtons[j].gameObject.SetActive(false);
                        }
                        else
                        {
                            PowLineButtons[j].gameObject.SetActive(true);
                        }
                    }


                    if (topL2X == xCoord && topL2Y == yCoord)
                    {
                        if (checkLegalLinePlacement(playerturn, xCoord, yCoord) == false)
                        {
                            PowLineButtons[j].gameObject.SetActive(false);
                        }
                        else
                        {
                            PowLineButtons[j].gameObject.SetActive(true);
                        }

                    }
                }
            }
        }

        if (playerturn == 2)
        {

            for (int i = 0; i < P3Lines.Count; i++)
            {
                for (int j = 0; j < allPowLineSpots.Count; j++)
                {
                    float xCoord = (float)allPowLineSpots[j][0];
                    float yCoord = (float)allPowLineSpots[j][1];

                    float topX = (float)P3Lines[i][0] + 0.25f;
                    float topY = (float)P3Lines[i][1] + 1.0f;

                    float bot1X = (float)P3Lines[i][0] - 0.25f;
                    float bot1Y = (float)P3Lines[i][1] - 1.0f;

                    float topL1X = (float)P3Lines[i][0] - 0.5f;
                    float topL1Y = (float)P3Lines[i][1];

                    float topRX = (float)P3Lines[i][0] + 0.5f;
                    float topRY = (float)P3Lines[i][1];

                    float topL2X = (float)P3Lines[i][0] - 0.25f;
                    float topL2Y = (float)P3Lines[i][1] + 1.0f;

                    float bot2X = (float)P3Lines[i][0] + 0.25f;
                    float bot2Y = (float)P3Lines[i][1] - 1.0f;

                    if (topX == xCoord && topY == yCoord)
                    {
                        if (checkLegalLinePlacement(playerturn, xCoord, yCoord) == false)
                        {
                            PowLineButtons[j].gameObject.SetActive(false);
                        }
                        else
                        {
                            PowLineButtons[j].gameObject.SetActive(true);
                        }

                    }

                    if (topL1X == xCoord && topL1Y == yCoord)
                    {
                        if (checkLegalLinePlacement(playerturn, xCoord, yCoord) == false)
                        {
                            PowLineButtons[j].gameObject.SetActive(false);
                        }
                        else
                        {
                            PowLineButtons[j].gameObject.SetActive(true);
                        }

                    }


                    if (topRX == xCoord && topRY == yCoord)
                    {
                        if (checkLegalLinePlacement(playerturn, xCoord, yCoord) == false)
                        {
                            PowLineButtons[j].gameObject.SetActive(false);
                        }
                        else
                        {
                            PowLineButtons[j].gameObject.SetActive(true);
                        }
                    }

                    if (bot1X == xCoord && bot1Y == yCoord)
                    {
                        if (checkLegalLinePlacement(playerturn, xCoord, yCoord) == false)
                        {
                            PowLineButtons[j].gameObject.SetActive(false);
                        }
                        else
                        {
                            PowLineButtons[j].gameObject.SetActive(true);
                        }
                    }

                    if (bot2X == xCoord && bot2Y == yCoord)
                    {
                        if (checkLegalLinePlacement(playerturn, xCoord, yCoord) == false)
                        {
                            PowLineButtons[j].gameObject.SetActive(false);
                        }
                        else
                        {
                            PowLineButtons[j].gameObject.SetActive(true);
                        }
                    }


                    if (topL2X == xCoord && topL2Y == yCoord)
                    {
                        if (checkLegalLinePlacement(playerturn, xCoord, yCoord) == false)
                        {
                            PowLineButtons[j].gameObject.SetActive(false);
                        }
                        else
                        {
                            PowLineButtons[j].gameObject.SetActive(true);
                        }

                    }
                }
            }
        }

        if (playerturn == 3)
        {

            for (int i = 0; i < P4Lines.Count; i++)
            {
                for (int j = 0; j < allPowLineSpots.Count; j++)
                {
                    float xCoord = (float)allPowLineSpots[j][0];
                    float yCoord = (float)allPowLineSpots[j][1];

                    float topX = (float)P4Lines[i][0] + 0.25f;
                    float topY = (float)P4Lines[i][1] + 1.0f;

                    float bot1X = (float)P4Lines[i][0] - 0.25f;
                    float bot1Y = (float)P4Lines[i][1] - 1.0f;

                    float topL1X = (float)P4Lines[i][0] - 0.5f;
                    float topL1Y = (float)P4Lines[i][1];

                    float topRX = (float)P4Lines[i][0] + 0.5f;
                    float topRY = (float)P4Lines[i][1];

                    float topL2X = (float)P4Lines[i][0] - 0.25f;
                    float topL2Y = (float)P4Lines[i][1] + 1.0f;

                    float bot2X = (float)P4Lines[i][0] + 0.25f;
                    float bot2Y = (float)P4Lines[i][1] - 1.0f;

                    if (topX == xCoord && topY == yCoord)
                    {
                        if (checkLegalLinePlacement(playerturn, xCoord, yCoord) == false)
                        {
                            PowLineButtons[j].gameObject.SetActive(false);
                        }
                        else
                        {
                            PowLineButtons[j].gameObject.SetActive(true);
                        }

                    }

                    if (topL1X == xCoord && topL1Y == yCoord)
                    {
                        if (checkLegalLinePlacement(playerturn, xCoord, yCoord) == false)
                        {
                            PowLineButtons[j].gameObject.SetActive(false);
                        }
                        else
                        {
                            PowLineButtons[j].gameObject.SetActive(true);
                        }

                    }


                    if (topRX == xCoord && topRY == yCoord)
                    {
                        if (checkLegalLinePlacement(playerturn, xCoord, yCoord) == false)
                        {
                            PowLineButtons[j].gameObject.SetActive(false);
                        }
                        else
                        {
                            PowLineButtons[j].gameObject.SetActive(true);
                        }
                    }

                    if (bot1X == xCoord && bot1Y == yCoord)
                    {
                        if (checkLegalLinePlacement(playerturn, xCoord, yCoord) == false)
                        {
                            PowLineButtons[j].gameObject.SetActive(false);
                        }
                        else
                        {
                            PowLineButtons[j].gameObject.SetActive(true);
                        }
                    }

                    if (bot2X == xCoord && bot2Y == yCoord)
                    {
                        if (checkLegalLinePlacement(playerturn, xCoord, yCoord) == false)
                        {
                            PowLineButtons[j].gameObject.SetActive(false);
                        }
                        else
                        {
                            PowLineButtons[j].gameObject.SetActive(true);
                        }
                    }


                    if (topL2X == xCoord && topL2Y == yCoord)
                    {
                        if (checkLegalLinePlacement(playerturn, xCoord, yCoord) == false)
                        {
                            PowLineButtons[j].gameObject.SetActive(false);
                        }
                        else
                        {
                            PowLineButtons[j].gameObject.SetActive(true);
                        }

                    }
                }
            }
        }
    }
    void generateInactiveButtons()
    {
        for (int i = 0; i < allPowLineSpots.Count; i++)
        {
            makeButton((float)allPowLineSpots[i][0], (float)allPowLineSpots[i][1], (Quaternion)allPowLineSpots[i][2]);
        }
    }
    
    
    bool checkForTowns(int turn, float x, float y)
    {
        float botCorner1X = x + 0.25f;
        float botCorner1Y = y - 0.25f;

        float botCorner2X = x - 0.25f;
        float botCorner2Y = y - 0.25f;

        float bottomX = x;
        float bottomY = y - 0.75f;

        float topCorner1X = x - 0.25f;
        float topCorner1Y = y + 0.25f;
              
        float topCorner2X = x + 0.25f;
        float topCorner2Y = y + 0.25f;

        float topX = x;
        float topY = y + 0.75f;

        if(turn == 0)
        {
            
            if(towns.Contains(new Vector2(botCorner1X,botCorner1Y)))
            {
                P1reachedTowns.Add(new Vector2(botCorner1X, botCorner1Y));
                return true;
            }
            if (towns.Contains(new Vector2(botCorner2X, botCorner2Y)))
            {
                P1reachedTowns.Add(new Vector2(botCorner2X, botCorner2Y));
                return true;
            }
            if (towns.Contains(new Vector2(bottomX, bottomY)))
            {
                P1reachedTowns.Add(new Vector2(bottomX, bottomY));
                return true;
            }
            if (towns.Contains(new Vector2(topCorner1X, topCorner1Y)))
            {
                P1reachedTowns.Add(new Vector2(topCorner1X, topCorner1Y));
                return true;
            }
            if (towns.Contains(new Vector2(topCorner2X, topCorner2Y)))
            {
                P1reachedTowns.Add(new Vector2(topCorner2X, topCorner2Y));
                return true;
            }
            if (towns.Contains(new Vector2(topX, topY)))
            {
                P1reachedTowns.Add(new Vector2(topX, topY));
                return true;
            }
        }
        if (turn == 1)
        {

            if (towns.Contains(new Vector2(botCorner1X, botCorner1Y)))
            {
                P2reachedTowns.Add(new Vector2(botCorner1X, botCorner1Y));
                return true;
            }
            if (towns.Contains(new Vector2(botCorner2X, botCorner2Y)))
            {
                P2reachedTowns.Add(new Vector2(botCorner2X, botCorner2Y));
                return true;
            }
            if (towns.Contains(new Vector2(bottomX, bottomY)))
            {
                P2reachedTowns.Add(new Vector2(bottomX, bottomY));
                return true;
            }
            if (towns.Contains(new Vector2(topCorner1X, topCorner1Y)))
            {
                P2reachedTowns.Add(new Vector2(topCorner1X, topCorner1Y));
                return true;
            }
            if (towns.Contains(new Vector2(topCorner2X, topCorner2Y)))
            {
                P2reachedTowns.Add(new Vector2(topCorner2X, topCorner2Y));
                return true;
            }
            if (towns.Contains(new Vector2(topX, topY)))
            {
                P2reachedTowns.Add(new Vector2(topX, topY));
                return true;
            }
        }
        if (turn == 2)
        {

            if (towns.Contains(new Vector2(botCorner1X, botCorner1Y)))
            {
                P3reachedTowns.Add(new Vector2(botCorner1X, botCorner1Y));
                return true;
            }
            if (towns.Contains(new Vector2(botCorner2X, botCorner2Y)))
            {
                P3reachedTowns.Add(new Vector2(botCorner2X, botCorner2Y));
                return true;
            }
            if (towns.Contains(new Vector2(bottomX, bottomY)))
            {
                P3reachedTowns.Add(new Vector2(bottomX, bottomY));
                return true;
            }
            if (towns.Contains(new Vector2(topCorner1X, topCorner1Y)))
            {
                P3reachedTowns.Add(new Vector2(topCorner1X, topCorner1Y));
                return true;
            }
            if (towns.Contains(new Vector2(topCorner2X, topCorner2Y)))
            {
                P3reachedTowns.Add(new Vector2(topCorner2X, topCorner2Y));
                return true;
            }
            if (towns.Contains(new Vector2(topX, topY)))
            {
                P3reachedTowns.Add(new Vector2(topX, topY));
                return true;

            }
        }
        if (turn == 3)
        {

            if (towns.Contains(new Vector2(botCorner1X, botCorner1Y)))
            {
                P4reachedTowns.Add(new Vector2(botCorner1X, botCorner1Y));
                return true;
            }
            if (towns.Contains(new Vector2(botCorner2X, botCorner2Y)))
            {
                P4reachedTowns.Add(new Vector2(botCorner2X, botCorner2Y));
                return true;
            }
            if (towns.Contains(new Vector2(bottomX, bottomY)))
            {
                P4reachedTowns.Add(new Vector2(bottomX, bottomY));
                return true;
            }
            if (towns.Contains(new Vector2(topCorner1X, topCorner1Y)))
            {
                P4reachedTowns.Add(new Vector2(topCorner1X, topCorner1Y));
                return true;
            }
            if (towns.Contains(new Vector2(topCorner2X, topCorner2Y)))
            {
                P4reachedTowns.Add(new Vector2(topCorner2X, topCorner2Y));
                return true;
            }
            if (towns.Contains(new Vector2(topX, topY)))
            {
                P4reachedTowns.Add(new Vector2(topX, topY));
                return true;
            }
        }

        return false;
    }

    List<Quaternion> determinePath(int turn, float x, float y, List<Quaternion> lineList)
    {
        List<Quaternion> temp = new List<Quaternion>();
        int startIndex = 0;
        for(int i = 0; i<lineList.Count; i++)
        {
            if((float)lineList[i][0] == x && (float)lineList[i][1] == y)
            {
                startIndex = i;
                break;
            }
        }

        int prev = startIndex+1;
        for(int i = startIndex; i >= 0; i--)
        {
            if(i == startIndex)
            {
                temp.Add(lineList[i]);
                if ((int)lineList[i][2] == 1)
                {
                    break;
                }
            }
            else
            {
                if ((int)lineList[i][2] == ((int)lineList[prev][2] - 1))
                {
                    temp.Add(lineList[i]);
                    if ((int)lineList[i][2] == 1)
                    {
                        break;
                    }
                }
            }

            prev--;
        }

        /*for(int j = 0; j < temp.Count; j++)
        {
            Debug.Log(temp[j][2]);
        }*/
        
        return temp;
    }
    // upgrades player turn transmission line lineIdx at location x,y 
    bool addLevel(int turn, float x, float y,int lineIdx){
        int maxLevel = 3;
        for(int i=0;i<allPowLineSpots.Count;i++){
            if((float)allPowLineSpots[i][0]==x && (float)allPowLineSpots[i][1]==y){//get the location
                //Debug.Log(((List< List<int> >)allPowLineSpots[i][5]).Count);
                if(((List< List<int> >)allPowLineSpots[i][5]).Count==0){//generate levels if not made yet
                    List< List<int> > emptyLevels = new List< List<int> >();
                    //make levels 4x4 since 4 players, max 4 lines
                    for(int p=0;p<4;p++){
                        emptyLevels.Add(new List<int>());
                        for(int q=0;q<4;q++){
                            emptyLevels[p].Add(0);
                        }
                    }
                    allPowLineSpots[i][5] = emptyLevels;
                }
                //find which to upgrade, currently just finds lowest index that can upgrade
                int numPowLines = ((int[])allPowLineSpots[i][3])[turn];
                for(int t=0;t<numPowLines;t++){
                    List< List<int> > levels = (List< List<int> >)allPowLineSpots[i][5];
                    if(levels[turn][t] <2){
                        levels[turn][t]++;
                        allPowLineSpots[i][5] = levels;
                        Debug.Log("Upgraded player " + (turn+1) +" line "+ (t+1) +" to level "+ (levels[turn][t]+1));
                        return true;
                    }
                }
                Debug.Log("Could not find line to upgrade at location");
                
                return false;
                
                

            }
        }
        return false;
    }
    void ButtonClicked(Button tempButton, string buttonNo, float x, float y, Quaternion rotation)
    {
        //Debug.Log("Button clicked = " + buttonNo);
        if (scoreMan.buildLine())//checks if player has enough money
        {
            bool check = false;
            upgrade = upgradePowerLines.upgrade;
            if(upgrade){
                int lineIdx = 0;
                bool ok = addLevel((int)scoreMan.turn, x, y,lineIdx);
                if(!ok){
                    scoreMan.playerList[(int)scoreMan.turn].money += 25;
                }
            }
            else{//regular build
                mapGen.updateBuilt(x,y);
                makePowerLine((int)scoreMan.turn, x, y, rotation);
                check = checkForTowns((int)scoreMan.turn, x, y);

                if(check == true)
                {
                    if((int)scoreMan.turn == 0)
                    {
                        List<Quaternion> temp = determinePath((int)scoreMan.turn, x, y, P1Lines);
                        P1Paths.Add(temp);
                    }
                    if ((int)scoreMan.turn == 1)
                    {
                        List<Quaternion> temp = determinePath((int)scoreMan.turn, x, y, P2Lines);
                        P2Paths.Add(temp);
                    }
                    if ((int)scoreMan.turn == 2)
                    {
                        List<Quaternion> temp = determinePath((int)scoreMan.turn, x, y, P3Lines);
                        P3Paths.Add(temp);
                    }
                    if ((int)scoreMan.turn == 3)
                    {
                        List<Quaternion> temp = determinePath((int)scoreMan.turn, x, y, P4Lines);
                        P4Paths.Add(temp);
                    }

                }
            //Debug.Log("x val " + x);
            //Debug.Log("y val " + y);
            }
            
        }
        else
        {
            Debug.Log("Not enough money");
        }

        // tempButton.gameObject.SetActive(false);
        deleteButtons();
        buildSelected = false;
        

    }

    // bool PowerLineTerrainLevel(int playerTurn, float x, float y)
    // {
    //     GameObject temp = new GameObject();
    //     if (SetColor(temp) == Color.green)
    //     {
    //         //deleted so code can still run
    //     }
    //     else if (SetColor(temp) = Color.blue)
    //     {

    //     }
    //     else if (SetColor(temp) == Color.gray)
    //     {

    //     }
    //     else if (SetColor(temp) = Color.yellow)
    //     {
            
    //     }
    // }
    bool checkMaxPowerLines(int playerTurn, float x, float y)
    {
        for (int i = 0; i < allPowLineSpots.Count; i++)
        {
            if (x == (float)allPowLineSpots[i][0] && y == (float)allPowLineSpots[i][1])
            {
                if((int)allPowLineSpots[i][4] < 8)
                {
                    if(playerTurn == 0)
                    {
                        int[] currP1Lines = (int[])allPowLineSpots[i][3];
                        if ( currP1Lines[playerTurn] < 4)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    if (playerTurn == 1)
                    {
                        int[] currP2Lines = (int[])allPowLineSpots[i][3];
                        if (currP2Lines[playerTurn] < 4)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    if (playerTurn == 2)
                    {
                        int[] currP3Lines = (int[])allPowLineSpots[i][3];
                        if (currP3Lines[playerTurn] < 4)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    if (playerTurn == 3)
                    {
                        int[] currP4Lines = (int[])allPowLineSpots[i][3];
                        if (currP4Lines[playerTurn] < 4)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    return false;
                }
            }
        }
        return false;
    }
    void updateNumPowLines(int playerTurn, float x, float y)
    {
        for (int i = 0; i < allPowLineSpots.Count; i++)
        {
            if (x == (float)allPowLineSpots[i][0] && y == (float)allPowLineSpots[i][1])
            {
                if (playerTurn == 0)
                {
                    int[] currP1Lines = (int[])allPowLineSpots[i][3];
                    currP1Lines[playerTurn] += 1;
                    allPowLineSpots[i][3] = (int[])currP1Lines.Clone();
                    
                }
                if (playerTurn == 1)
                {
                    int[] currP2Lines = (int[])allPowLineSpots[i][3];
                    currP2Lines[playerTurn] += 1;
                    allPowLineSpots[i][3] = (int[])currP2Lines.Clone();
                }
                if (playerTurn == 2)
                {
                    int[] currP3Lines = (int[])allPowLineSpots[i][3];
                    currP3Lines[playerTurn] += 1;
                    allPowLineSpots[i][3] = (int[])currP3Lines.Clone();
                }
                if (playerTurn == 3)
                {
                    int[] currP4Lines = (int[])allPowLineSpots[i][3];
                    currP4Lines[playerTurn] += 1;
                    allPowLineSpots[i][3] = (int[])currP4Lines.Clone();
                }

                int temp = (int)allPowLineSpots[i][4];
                temp += 1;
                allPowLineSpots[i][4] = temp;
                //Debug.Log("total " + allPowLineSpots[i][4]);
            }
        }
       
    }

    void storePlayerPowLines(int turn, float x, float y)
    {
        int placeVal = 0;

        //adjacent vertices (to find towns and plants)
        float botCorner1X = x + 0.25f;
        float botCorner1Y = y - 0.25f;

        float botCorner2X = x - 0.25f;
        float botCorner2Y = y - 0.25f;

        float bottomX = x;
        float bottomY = y - 0.75f;

        float topCorner1X = x - 0.25f;
        float topCorner1Y = y + 0.25f;

        float topCorner2X = x + 0.25f;
        float topCorner2Y = y + 0.25f;

        float topX = x;
        float topY = y + 0.75f;

        if (turn == 0)
        {
            if (P1Coal.Contains(new Vector2(botCorner1X, botCorner1Y)) || P1Solar.Contains(new Vector2(botCorner1X, botCorner1Y)) || P1Natural.Contains(new Vector2(botCorner1X, botCorner1Y)) || P1Nuclear.Contains(new Vector2(botCorner1X, botCorner1Y)))
            {
                placeVal = 1;
                P1Lines.Add(new Quaternion(x, y, placeVal, 1));
                //Debug.Log(placeVal);
            }
            else if (P1Coal.Contains(new Vector2(botCorner2X, botCorner2Y)) || P1Solar.Contains(new Vector2(botCorner2X, botCorner2Y)) || P1Natural.Contains(new Vector2(botCorner2X, botCorner2Y)) || P1Nuclear.Contains(new Vector2(botCorner2X, botCorner2Y)))
            {
                placeVal = 1;
                P1Lines.Add(new Quaternion(x, y, placeVal, 1));
                //Debug.Log(placeVal);
            }
            else if (P1Coal.Contains(new Vector2(bottomX, bottomY)) || P1Solar.Contains(new Vector2(bottomX, bottomY)) || P1Natural.Contains(new Vector2(bottomX, bottomY)) || P1Nuclear.Contains(new Vector2(bottomX, bottomY)))
            {
                placeVal = 1;
                P1Lines.Add(new Quaternion(x, y, placeVal, 1));
                //Debug.Log(placeVal);
            }
            else if (P1Coal.Contains(new Vector2(topCorner1X, topCorner1Y)) || P1Solar.Contains(new Vector2(topCorner1X, topCorner1Y)) || P1Natural.Contains(new Vector2(topCorner1X, topCorner1Y)) || P1Nuclear.Contains(new Vector2(topCorner1X, topCorner1Y)))
            {
                placeVal = 1;
                P1Lines.Add(new Quaternion(x, y, placeVal, 1));
                //Debug.Log(placeVal);
            }
            else if (P1Coal.Contains(new Vector2(topCorner2X, topCorner2Y)) || P1Solar.Contains(new Vector2(topCorner2X, topCorner2Y)) || P1Natural.Contains(new Vector2(topCorner2X, topCorner2Y)) || P1Nuclear.Contains(new Vector2(topCorner2X, topCorner2Y)))
            {
                placeVal = 1;
                P1Lines.Add(new Quaternion(x, y, placeVal, 1));
                //Debug.Log(placeVal);
            }
            else if (P1Coal.Contains(new Vector2(topX, topY)) || P1Solar.Contains(new Vector2(topX, topY)) || P1Natural.Contains(new Vector2(topX, topY)) || P1Nuclear.Contains(new Vector2(topX, topY)))
            {
                placeVal = 1;
                P1Lines.Add(new Quaternion(x, y, placeVal, 1));
                //Debug.Log(placeVal);
            }

            else
            {
                for(int i = 0; i < P1Lines.Count; i++)
                {
                    float xCoord = (float)P1Lines[i][0];
                    float yCoord = (float)P1Lines[i][1];
                    int currPlace = (int)P1Lines[i][2];

                    //adjacent edges
                    float adjtopX = xCoord + 0.25f;
                    float adjtopY = yCoord + 1.0f;

                    float bot1X = xCoord - 0.25f;
                    float bot1Y = yCoord - 1.0f;

                    float topL1X = xCoord - 0.5f;
                    float topL1Y = yCoord;

                    float topRX = xCoord + 0.5f;
                    float topRY = yCoord;

                    float topL2X = xCoord - 0.25f;
                    float topL2Y = yCoord + 1.0f;

                    float bot2X = xCoord + 0.25f;
                    float bot2Y = yCoord - 1.0f;
                    if (x == xCoord && y == yCoord)
                    {
                        P1Lines.Add(new Quaternion(x, y, currPlace, 1));
                        //Debug.Log(currPlace);
                        break;
                    }
                    else
                    {
                        if (adjtopX == x && adjtopY == y)
                        {
                            P1Lines.Add(new Quaternion(x, y, currPlace + 1, 1));
                            //Debug.Log(currPlace+1);
                            break;
                        }

                        if (topL1X == x && topL1Y == y)
                        {
                            P1Lines.Add(new Quaternion(x, y, currPlace + 1, 1));
                            //Debug.Log(currPlace + 1);
                            break;
                        }


                        if (topRX == x && topRY == y)
                        {
                            P1Lines.Add(new Quaternion(x, y, currPlace + 1, 1));
                            //Debug.Log(currPlace + 1);
                            break;
                        }

                        if (bot1X == x && bot1Y == y)
                        {
                            P1Lines.Add(new Quaternion(x, y, currPlace + 1, 1));
                            //Debug.Log(currPlace + 1);
                            break;
                        }

                        if (bot2X == x && bot2Y == y)
                        {
                            P1Lines.Add(new Quaternion(x, y, currPlace + 1, 1));
                            //Debug.Log(currPlace + 1);
                            break;
                        }


                        if (topL2X == x && topL2Y == y)
                        {
                            P1Lines.Add(new Quaternion(x, y, currPlace + 1, 1));
                            //Debug.Log(currPlace + 1);
                            break;
                        }
                    }

                }
            }
        }
        if (turn == 1)
        {
            if (P2Coal.Contains(new Vector2(botCorner1X, botCorner1Y)) || P2Solar.Contains(new Vector2(botCorner1X, botCorner1Y)) || P2Natural.Contains(new Vector2(botCorner1X, botCorner1Y)) || P2Nuclear.Contains(new Vector2(botCorner1X, botCorner1Y)))
            {
                placeVal = 1;
                P2Lines.Add(new Quaternion(x, y, placeVal, 1));
                //Debug.Log(placeVal);
            }
            else if (P2Coal.Contains(new Vector2(botCorner2X, botCorner2Y)) || P2Solar.Contains(new Vector2(botCorner2X, botCorner2Y)) || P2Natural.Contains(new Vector2(botCorner2X, botCorner2Y)) || P2Nuclear.Contains(new Vector2(botCorner2X, botCorner2Y)))
            {
                placeVal = 1;
                P2Lines.Add(new Quaternion(x, y, placeVal, 1));
                //Debug.Log(placeVal);
            }
            else if (P2Coal.Contains(new Vector2(bottomX, bottomY)) || P2Solar.Contains(new Vector2(bottomX, bottomY)) || P2Natural.Contains(new Vector2(bottomX, bottomY)) || P2Nuclear.Contains(new Vector2(bottomX, bottomY)))
            {
                placeVal = 1;
                P2Lines.Add(new Quaternion(x, y, placeVal, 1));
                //Debug.Log(placeVal);
            }
            else if (P2Coal.Contains(new Vector2(topCorner1X, topCorner1Y)) || P2Solar.Contains(new Vector2(topCorner1X, topCorner1Y)) || P2Natural.Contains(new Vector2(topCorner1X, topCorner1Y)) || P2Nuclear.Contains(new Vector2(topCorner1X, topCorner1Y)))
            {
                placeVal = 1;
                P2Lines.Add(new Quaternion(x, y, placeVal, 1));
                //Debug.Log(placeVal);
            }
            else if (P2Coal.Contains(new Vector2(topCorner2X, topCorner2Y)) || P2Solar.Contains(new Vector2(topCorner2X, topCorner2Y)) || P2Natural.Contains(new Vector2(topCorner2X, topCorner2Y)) || P2Nuclear.Contains(new Vector2(topCorner2X, topCorner2Y)))
            {
                placeVal = 1;
                P2Lines.Add(new Quaternion(x, y, placeVal, 1));
                //Debug.Log(placeVal);
            }
            else if (P2Coal.Contains(new Vector2(topX, topY)) || P2Solar.Contains(new Vector2(topX, topY)) || P2Natural.Contains(new Vector2(topX, topY)) || P2Nuclear.Contains(new Vector2(topX, topY)))
            {
                placeVal = 1;
                P2Lines.Add(new Quaternion(x, y, placeVal, 1));
                //Debug.Log(placeVal);
            }

            else
            {
                for (int i = 0; i < P2Lines.Count; i++)
                {
                    float xCoord = (float)P2Lines[i][0];
                    float yCoord = (float)P2Lines[i][1];
                    int currPlace = (int)P2Lines[i][2];

                    //adjacent edges
                    float adjtopX = xCoord + 0.25f;
                    float adjtopY = yCoord + 1.0f;

                    float bot1X = xCoord - 0.25f;
                    float bot1Y = yCoord - 1.0f;

                    float topL1X = xCoord - 0.5f;
                    float topL1Y = yCoord;

                    float topRX = xCoord + 0.5f;
                    float topRY = yCoord;

                    float topL2X = xCoord - 0.25f;
                    float topL2Y = yCoord + 1.0f;

                    float bot2X = xCoord + 0.25f;
                    float bot2Y = yCoord - 1.0f;
                    if (x == xCoord && y == yCoord)
                    {
                        P2Lines.Add(new Quaternion(x, y, currPlace, 1));
                        //Debug.Log(currPlace);
                        break;
                    }
                    else
                    {
                        if (adjtopX == x && adjtopY == y)
                        {
                            P2Lines.Add(new Quaternion(x, y, currPlace + 1, 1));
                            //Debug.Log(currPlace+1);
                            break;
                        }

                        if (topL1X == x && topL1Y == y)
                        {
                            P2Lines.Add(new Quaternion(x, y, currPlace + 1, 1));
                            //Debug.Log(currPlace + 1);
                            break;
                        }


                        if (topRX == x && topRY == y)
                        {
                            P2Lines.Add(new Quaternion(x, y, currPlace + 1, 1));
                            //Debug.Log(currPlace + 1);
                            break;
                        }

                        if (bot1X == x && bot1Y == y)
                        {
                            P2Lines.Add(new Quaternion(x, y, currPlace + 1, 1));
                            //Debug.Log(currPlace + 1);
                            break;
                        }

                        if (bot2X == x && bot2Y == y)
                        {
                            P2Lines.Add(new Quaternion(x, y, currPlace + 1, 1));
                            //Debug.Log(currPlace + 1);
                            break;
                        }


                        if (topL2X == x && topL2Y == y)
                        {
                            P2Lines.Add(new Quaternion(x, y, currPlace + 1, 1));
                            //Debug.Log(currPlace + 1);
                            break;
                        }
                    }

                }
            }
        }
        if (turn == 2)
        {
            if (P3Coal.Contains(new Vector2(botCorner1X, botCorner1Y)) || P3Solar.Contains(new Vector2(botCorner1X, botCorner1Y)) || P3Natural.Contains(new Vector2(botCorner1X, botCorner1Y)) || P3Nuclear.Contains(new Vector2(botCorner1X, botCorner1Y)))
            {
                placeVal = 1;
                P3Lines.Add(new Quaternion(x, y, placeVal, 1));
                //Debug.Log(placeVal);
            }
            else if (P3Coal.Contains(new Vector2(botCorner2X, botCorner2Y)) || P3Solar.Contains(new Vector2(botCorner2X, botCorner2Y)) || P3Natural.Contains(new Vector2(botCorner2X, botCorner2Y)) || P3Nuclear.Contains(new Vector2(botCorner2X, botCorner2Y)))
            {
                placeVal = 1;
                P3Lines.Add(new Quaternion(x, y, placeVal, 1));
                //Debug.Log(placeVal);
            }
            else if (P3Coal.Contains(new Vector2(bottomX, bottomY)) || P3Solar.Contains(new Vector2(bottomX, bottomY)) || P3Natural.Contains(new Vector2(bottomX, bottomY)) || P3Nuclear.Contains(new Vector2(bottomX, bottomY)))
            {
                placeVal = 1;
                P3Lines.Add(new Quaternion(x, y, placeVal, 1));
                //Debug.Log(placeVal);
            }
            else if (P3Coal.Contains(new Vector2(topCorner1X, topCorner1Y)) || P3Solar.Contains(new Vector2(topCorner1X, topCorner1Y)) || P3Natural.Contains(new Vector2(topCorner1X, topCorner1Y)) || P3Nuclear.Contains(new Vector2(topCorner1X, topCorner1Y)))
            {
                placeVal = 1;
                P3Lines.Add(new Quaternion(x, y, placeVal, 1));
                //Debug.Log(placeVal);
            }
            else if (P3Coal.Contains(new Vector2(topCorner2X, topCorner2Y)) || P3Solar.Contains(new Vector2(topCorner2X, topCorner2Y)) || P3Natural.Contains(new Vector2(topCorner2X, topCorner2Y)) || P3Nuclear.Contains(new Vector2(topCorner2X, topCorner2Y)))
            {
                placeVal = 1;
                P3Lines.Add(new Quaternion(x, y, placeVal, 1));
                //Debug.Log(placeVal);
            }
            else if (P3Coal.Contains(new Vector2(topX, topY)) || P3Solar.Contains(new Vector2(topX, topY)) || P3Natural.Contains(new Vector2(topX, topY)) || P3Nuclear.Contains(new Vector2(topX, topY)))
            {
                placeVal = 1;
                P3Lines.Add(new Quaternion(x, y, placeVal, 1));
                //Debug.Log(placeVal);
            }

            else
            {
                for (int i = 0; i < P3Lines.Count; i++)
                {
                    float xCoord = (float)P3Lines[i][0];
                    float yCoord = (float)P3Lines[i][1];
                    int currPlace = (int)P3Lines[i][2];

                    //adjacent edges
                    float adjtopX = xCoord + 0.25f;
                    float adjtopY = yCoord + 1.0f;

                    float bot1X = xCoord - 0.25f;
                    float bot1Y = yCoord - 1.0f;

                    float topL1X = xCoord - 0.5f;
                    float topL1Y = yCoord;

                    float topRX = xCoord + 0.5f;
                    float topRY = yCoord;

                    float topL2X = xCoord - 0.25f;
                    float topL2Y = yCoord + 1.0f;

                    float bot2X = xCoord + 0.25f;
                    float bot2Y = yCoord - 1.0f;
                    if (x == xCoord && y == yCoord)
                    {
                        P3Lines.Add(new Quaternion(x, y, currPlace, 1));
                        //Debug.Log(currPlace);
                        break;
                    }
                    else
                    {
                        if (adjtopX == x && adjtopY == y)
                        {
                            P3Lines.Add(new Quaternion(x, y, currPlace + 1, 1));
                            //Debug.Log(currPlace+1);
                            break;
                        }

                        if (topL1X == x && topL1Y == y)
                        {
                            P3Lines.Add(new Quaternion(x, y, currPlace + 1, 1));
                            //Debug.Log(currPlace + 1);
                            break;
                        }


                        if (topRX == x && topRY == y)
                        {
                            P3Lines.Add(new Quaternion(x, y, currPlace + 1, 1));
                            //Debug.Log(currPlace + 1);
                            break;
                        }

                        if (bot1X == x && bot1Y == y)
                        {
                            P3Lines.Add(new Quaternion(x, y, currPlace + 1, 1));
                            //Debug.Log(currPlace + 1);
                            break;
                        }

                        if (bot2X == x && bot2Y == y)
                        {
                            P3Lines.Add(new Quaternion(x, y, currPlace + 1, 1));
                            //Debug.Log(currPlace + 1);
                            break;
                        }


                        if (topL2X == x && topL2Y == y)
                        {
                            P3Lines.Add(new Quaternion(x, y, currPlace + 1, 1));
                            //Debug.Log(currPlace + 1);
                            break;
                        }
                    }

                }
            }
        }
        if (turn == 3)
        {
            if (P4Coal.Contains(new Vector2(botCorner1X, botCorner1Y)) || P4Solar.Contains(new Vector2(botCorner1X, botCorner1Y)) || P4Natural.Contains(new Vector2(botCorner1X, botCorner1Y)) || P4Nuclear.Contains(new Vector2(botCorner1X, botCorner1Y)))
            {
                placeVal = 1;
                P4Lines.Add(new Quaternion(x, y, placeVal, 1));
                //Debug.Log(placeVal);
            }
            else if (P4Coal.Contains(new Vector2(botCorner2X, botCorner2Y)) || P4Solar.Contains(new Vector2(botCorner2X, botCorner2Y)) || P4Natural.Contains(new Vector2(botCorner2X, botCorner2Y)) || P4Nuclear.Contains(new Vector2(botCorner2X, botCorner2Y)))
            {
                placeVal = 1;
                P4Lines.Add(new Quaternion(x, y, placeVal, 1));
                //Debug.Log(placeVal);
            }
            else if (P4Coal.Contains(new Vector2(bottomX, bottomY)) || P4Solar.Contains(new Vector2(bottomX, bottomY)) || P4Natural.Contains(new Vector2(bottomX, bottomY)) || P4Nuclear.Contains(new Vector2(bottomX, bottomY)))
            {
                placeVal = 1;
                P4Lines.Add(new Quaternion(x, y, placeVal, 1));
                //Debug.Log(placeVal);
            }
            else if (P4Coal.Contains(new Vector2(topCorner1X, topCorner1Y)) || P4Solar.Contains(new Vector2(topCorner1X, topCorner1Y)) || P4Natural.Contains(new Vector2(topCorner1X, topCorner1Y)) || P4Nuclear.Contains(new Vector2(topCorner1X, topCorner1Y)))
            {
                placeVal = 1;
                P4Lines.Add(new Quaternion(x, y, placeVal, 1));
                //Debug.Log(placeVal);
            }
            else if (P4Coal.Contains(new Vector2(topCorner2X, topCorner2Y)) || P4Solar.Contains(new Vector2(topCorner2X, topCorner2Y)) || P4Natural.Contains(new Vector2(topCorner2X, topCorner2Y)) || P4Nuclear.Contains(new Vector2(topCorner2X, topCorner2Y)))
            {
                placeVal = 1;
                P4Lines.Add(new Quaternion(x, y, placeVal, 1));
                //Debug.Log(placeVal);
            }
            else if (P4Coal.Contains(new Vector2(topX, topY)) || P4Solar.Contains(new Vector2(topX, topY)) || P4Natural.Contains(new Vector2(topX, topY)) || P4Nuclear.Contains(new Vector2(topX, topY)))
            {
                placeVal = 1;
                P4Lines.Add(new Quaternion(x, y, placeVal, 1));
                //Debug.Log(placeVal);
            }

            else
            {
                for (int i = 0; i < P4Lines.Count; i++)
                {
                    float xCoord = (float)P4Lines[i][0];
                    float yCoord = (float)P4Lines[i][1];
                    int currPlace = (int)P4Lines[i][2];

                    //adjacent edges
                    float adjtopX = xCoord + 0.25f;
                    float adjtopY = yCoord + 1.0f;

                    float bot1X = xCoord - 0.25f;
                    float bot1Y = yCoord - 1.0f;

                    float topL1X = xCoord - 0.5f;
                    float topL1Y = yCoord;

                    float topRX = xCoord + 0.5f;
                    float topRY = yCoord;

                    float topL2X = xCoord - 0.25f;
                    float topL2Y = yCoord + 1.0f;

                    float bot2X = xCoord + 0.25f;
                    float bot2Y = yCoord - 1.0f;
                    if (x == xCoord && y == yCoord)
                    {
                        P4Lines.Add(new Quaternion(x, y, currPlace, 1));
                        //Debug.Log(currPlace);
                        break;
                    }
                    else
                    {
                        if (adjtopX == x && adjtopY == y)
                        {
                            P4Lines.Add(new Quaternion(x, y, currPlace + 1, 1));
                            //Debug.Log(currPlace+1);
                            break;
                        }

                        if (topL1X == x && topL1Y == y)
                        {
                            P4Lines.Add(new Quaternion(x, y, currPlace + 1, 1));
                            //Debug.Log(currPlace + 1);
                            break;
                        }


                        if (topRX == x && topRY == y)
                        {
                            P4Lines.Add(new Quaternion(x, y, currPlace + 1, 1));
                            //Debug.Log(currPlace + 1);
                            break;
                        }

                        if (bot1X == x && bot1Y == y)
                        {
                            P4Lines.Add(new Quaternion(x, y, currPlace + 1, 1));
                            //Debug.Log(currPlace + 1);
                            break;
                        }

                        if (bot2X == x && bot2Y == y)
                        {
                            P4Lines.Add(new Quaternion(x, y, currPlace + 1, 1));
                            //Debug.Log(currPlace + 1);
                            break;
                        }


                        if (topL2X == x && topL2Y == y)
                        {
                            P4Lines.Add(new Quaternion(x, y, currPlace + 1, 1));
                            //Debug.Log(currPlace + 1);
                            break;
                        }
                    }

                }
            }
        }
    }
    void makePowerLine(int playerTurn, float x, float y, Quaternion rotation)
    {
        GameObject powLine = new GameObject();
        bool check = checkMaxPowerLines(playerTurn, x, y);
        if(check == true)
        {
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
            updateNumPowLines(playerTurn, x, y);
            GameObject TempGo = Instantiate(powLine);
            TempGo.name = powLine.name +" "+x+","+y;

            TempGo.transform.position = new Vector2(x * tileXOffset, y * tileYOffset / 2 - .5f);
            TempGo.transform.rotation = rotation;

            var ren = TempGo.GetComponent<SpriteRenderer>();
            ren.sortingOrder = 1;
            ren.enabled = true;
            storePlayerPowLines(playerTurn, x, y);
            if (playerTurn == 0)
            {
                P1LinesPos.Add(new Vector2(x, y));
                P1sprites.Add(TempGo);
            }
            if (playerTurn == 1)
            {
                P2LinesPos.Add(new Vector2(x, y));
                P2sprites.Add(TempGo);
            }
            if (playerTurn == 2)
            {
                P3LinesPos.Add(new Vector2(x, y));
                P3sprites.Add(TempGo);
            }
            if (playerTurn == 3)
            {
                P4LinesPos.Add(new Vector2(x, y));
                P4sprites.Add(TempGo);
            }

            TempGo.AddComponent<BoxCollider>();
            TempGo.AddComponent<onHoverScript>();
            var hover = TempGo.GetComponent<onHoverScript>();
            hover.location = new Vector2(x,y);//pass the location
            hover.objType = "powerLine";//and type
            hover.parent = TempGo;
            hover.rotation = rotation;


            
        }

    }
    void makeButton(float x, float y, Quaternion rotation)//this makes buttons to build factories on all of the hex above it
    {
        if (!mapGen.getBuilt().Contains(new Vector2(x, y)))
        {
            //make bottom button
            GameObject goButton = (GameObject)Instantiate(prefabButton);
            goButton.transform.SetParent(ParentPanel, false);
            goButton.transform.localScale = new Vector3(1, 1, 1);

            Button tempButton = goButton.GetComponent<Button>();
            tempButton.gameObject.SetActive(false);
            string location = (bottomLeftX + x * tileXOffset).ToString() + "," + (bottomLeftY + y * tileYOffset).ToString();

            tempButton.onClick.AddListener(() => ButtonClicked(tempButton, location, x, y, rotation));

            RectTransform rectTransform = goButton.GetComponent<RectTransform>();
            Vector2 anchoredPos = new Vector2(bottomLeftX + x * canvasTileXOffset, bottomLeftY + y * canvasTileYOffset);
            rectTransform.anchoredPosition = anchoredPos;

            PowLineButtons.Add(tempButton);
            
            //numOfButtons++;
        }

    }

    public void wreckLines(int roll, string eventRoll)
    {
        List<Vector2> tilepos = mapGen.getTileCoord(roll);
        //int coun = 0;
        if (eventRoll != "sunny") {
            foreach (Vector2 pos in tilepos)
            {
                for (int i = 0; i < allPowLineSpots.Count; i++)
                {
                    if (eventRoll == "cloudy")
                    {
                        //Debug.Log("cloudy");
                    }
                    else if (Vector2.Distance(pos, new Vector2((float)allPowLineSpots[i][0] * tileXOffset, (float)allPowLineSpots[i][1] * tileYOffset / 2 - .5f)) < 0.58843) // (pos[0] - (float)allPowLineSpots[i][0] < .89f / 2 && pos[1] - (float)allPowLineSpots[i][1] < .77f / 2)
                    {
                        int r = Random.Range(0, 100);
                        bool destroy = false;
                        if (eventRoll == "severe" && r < 75) //currently set up so that each power line has a chance of staying up in severe weather
                        {
                            destroy = true;
                        }
                        else if(eventRoll == "moderate" && r < 25)
                        {
                            destroy = true;
                        }
                        if(destroy){
                            List<int> playersDestroyed = new List<int>();

                            int index = -1;
                            if (P1LinesPos.FindIndex(0, P1LinesPos.Count, pos => pos[0] == (float)allPowLineSpots[i][0] && pos[1] == (float)allPowLineSpots[i][1]) > -1)
                            {
                                index = P1LinesPos.FindIndex(0, P1LinesPos.Count, pos => pos[0] == (float)allPowLineSpots[i][0] && pos[1] == (float)allPowLineSpots[i][1]);
                                P1LinesPos.RemoveAt(index);
                                DestroyImmediate(P1sprites[index]);
                                P1sprites.RemoveAt(index);
                                playersDestroyed.Add(1);
                                Debug.Log("destroyed p1 at "+(float)allPowLineSpots[i][0]+","+(float)allPowLineSpots[i][1]);    
                            }
                            else if (P2LinesPos.FindIndex(0, P2LinesPos.Count, pos => pos[0] == (float)allPowLineSpots[i][0] && pos[1] == (float)allPowLineSpots[i][1]) > -1)
                            {
                                index = P2LinesPos.FindIndex(0, P2LinesPos.Count, pos => pos[0] == (float)allPowLineSpots[i][0] && pos[1] == (float)allPowLineSpots[i][1]);
                                P2LinesPos.RemoveAt(index);
                                DestroyImmediate(P2sprites[index]);
                                P2sprites.RemoveAt(index);
                                playersDestroyed.Add(2);
                                Debug.Log("destroyed p2 at "+(float)allPowLineSpots[i][0]+","+(float)allPowLineSpots[i][1]);
                            }
                            else if (P3LinesPos.FindIndex(0, P3LinesPos.Count, pos => pos[0] == (float)allPowLineSpots[i][0] && pos[1] == (float)allPowLineSpots[i][1]) > -1)
                            {
                                index = P3LinesPos.FindIndex(0, P3LinesPos.Count, pos => pos[0] == (float)allPowLineSpots[i][0] && pos[1] == (float)allPowLineSpots[i][1]);
                                P3LinesPos.RemoveAt(index);
                                DestroyImmediate(P3sprites[index]);
                                P3sprites.RemoveAt(index);
                                playersDestroyed.Add(3);
                                Debug.Log("destroyed p3 at "+(float)allPowLineSpots[i][0]+","+(float)allPowLineSpots[i][1]);
                            }
                            else if (P4LinesPos.FindIndex(0, P4LinesPos.Count, pos => pos[0] == (float)allPowLineSpots[i][0] && pos[1] == (float)allPowLineSpots[i][1]) > -1)
                            {
                                index = P4LinesPos.FindIndex(0, P4LinesPos.Count, pos => pos[0] == (float)allPowLineSpots[i][0] && pos[1] == (float)allPowLineSpots[i][1]);
                                P4LinesPos.RemoveAt(index);
                                DestroyImmediate(P4sprites[index]);
                                P4sprites.RemoveAt(index);
                                playersDestroyed.Add(4);    
                                Debug.Log("destroyed p4 at "+(float)allPowLineSpots[i][0]+","+(float)allPowLineSpots[i][1]);
                            }
                            if (index != -1)
                            {
                                mapGen.removeBuilt((float)allPowLineSpots[i][0], (float)allPowLineSpots[i][1]);
                                int[] playerTurn = (int[])allPowLineSpots[i][3];

                                for(int p=0;p<playersDestroyed.Count;p++){
                                    playerTurn[playersDestroyed[p]-1] -=1;
                                }
                                //playerTurn[(int)scoreMan.turn] -= 1;
                                allPowLineSpots[i][3] = playerTurn;
                                allPowLineSpots[i][4] = (int)allPowLineSpots[i][4] - 1;
                                //newHoverAfterDestroy((float)allPowLineSpots[i][0],(float)allPowLineSpots[i][1]);  
                                Debug.Log((float)allPowLineSpots[i][0]+","+(float)allPowLineSpots[i][1]+" "+playerTurn[0]+" "+playerTurn[1]+" "+playerTurn[2]+" "+playerTurn[3]);
                            }
                        }
                        //Debug.Log(allPowLineSpots[i][0].ToString() + " " + allPowLineSpots[i][1].ToString());
                        //Debug.Log(pos.ToString());
                        //Debug.Log(Vector2.Distance(pos, new Vector2((float)allPowLineSpots[i][0], (float)allPowLineSpots[i][1])));
                        //Debug.DrawLine(pos, new Vector2((float)allPowLineSpots[i][0] * tileXOffset, (float)allPowLineSpots[i][1] * tileYOffset / 2 - .5f), Color.white, 30.0f, false);
                        //coun++;
                    }
                    //Debug.DrawLine(new Vector2(0,0), new Vector2((float)allPowLineSpots[i][0]* tileXOffset, (float)allPowLineSpots[i][1] * tileYOffset / 2 - .5f), Color.white, 30.0f, false);
                    //x* tileXOffset, y *tileYOffset / 2 - .5f
                }
                //Debug.Log(coun);
                //coun = 0;
            }
        }
>>>>>>> Stashed changes
    }
}
