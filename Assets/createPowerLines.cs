using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class createPowerLines : MonoBehaviour
{
    public GameObject prefabButton;
    public RectTransform ParentPanel;
    public GameObject powLine;
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

    bool buildSelected = false;

    public void spawnButtons()
    {
        if (!buildSelected)
        {
            createButtons();
            Debug.Log("num" + numOfButtons);
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
                    makeButton(x+0.25f, y+0.1f);//bottom
                    makeButton(x + 0.25f, y + 2.25f);//top
                    makeButton(x - 0.25f, y + 0.1f);//bot left
                    makeButton(x - 0.25f, y + 2.25f);//top left
                    makeButton(x + .5f, y + 1.25f);
                    if (x == 2)//special case on left side
                    {
                        makeButton(x - 0.75f, y + 2.25f);
                    }
                    if (x == width - 3)//special case on right side
                    {
                       
                        makeButton(x + 0.75f, y + 2.25f);
                        makeButton(x + 1, y + 3.25f);
                    }

                }

                if (y == 4 && x < width - 1 && x > 0)
                {
                    makeButton(x + 0.25f, y + 0.1f);//bottom
                    makeButton(x + 0.25f, y + 2.25f);//top
                    makeButton(x - 0.25f, y + 0.1f);//bot left
                    makeButton(x - 0.25f, y + 2.25f);//top left
                    makeButton(x + .5f, y + 1.25f);
                    if (x == 1)//special case on left side
                    {
                        makeButton(x - 1, y + 2.5f);
                    }
                    if (x == width - 2)//special case on right side
                    {
                        makeButton(x + 0.75f, y + 2.25f);
                        makeButton(x + 1, y + 3.25f);
                    }

                }
                if (y == 8)
                {
                    makeButton(x + 0.25f, y + 0.1f);//bottom
                    makeButton(x + 0.25f, y + 2.25f);//top
                    makeButton(x - 0.25f, y + 0.1f);//bot left
                    makeButton(x - 0.25f, y + 2.25f);//top left
                    makeButton(x + .5f, y + 1.25f);
                    if (x == 1)//special case on left side
                    {
                        makeButton(x - 1, y + 4);
                    }

                }
                if (y == 12 && x < width - 1 && x > 0)
                {
                    makeButton(x + 0.25f, y + 0.1f);//bottom
                    makeButton(x + 0.25f, y + 2.25f);//top
                    makeButton(x - 0.25f, y + 0.1f);//bot left
                    makeButton(x - 0.25f, y + 2.25f);//top left
                    makeButton(x + .5f, y + 1.25f);

                }
                
                if (y == 16 && x < width - 2 && x > 1)
                {
                    makeButton(x + 0.25f, y + 0.1f);//bottom
                    makeButton(x + 0.25f, y + 2.25f);//top
                    makeButton(x - 0.25f, y + 0.1f);//bot left
                    makeButton(x - 0.25f, y + 2.25f);//top left
                    makeButton(x + .5f, y + 1.25f);
                    if (x == 2)//special case on left side
                    {
                        makeButton(x - 1, y);
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
    void ButtonClicked(Button tempButton, string buttonNo, float x, float y)
    {
        Debug.Log("Button clicked = " + buttonNo);

        GameObject TempGo = Instantiate(powLine);
        TempGo.transform.position = new Vector2(x * tileXOffset, y * tileYOffset / 2 - .5f);
        var ren = TempGo.GetComponent<SpriteRenderer>();
        ren.enabled = true;

        // tempButton.gameObject.SetActive(false);
        deleteButtons();
        buildSelected = false;
        // buttontest = GameObject.Find("Button(Clone)");
        // buttontest.gameObject.SetActive(false);
        //var ren1 = tempButton.gameObject.GetComponent<Renderer>();
        //ren1.enabled = false;

    }
    void makeButton(float x, float y)//this makes buttons to build factories on all of the hex above it
    {
        //make bottom button
        GameObject goButton = (GameObject)Instantiate(prefabButton);
        goButton.transform.SetParent(ParentPanel, false);
        goButton.transform.localScale = new Vector3(1, 1, 1);

        Button tempButton = goButton.GetComponent<Button>();
        tempButton.gameObject.SetActive(true);
        string location = (bottomLeftX + x * tileXOffset).ToString() + "," + (bottomLeftY + y * tileYOffset).ToString();

        tempButton.onClick.AddListener(() => ButtonClicked(tempButton, location, x, y));

        RectTransform rectTransform = goButton.GetComponent<RectTransform>();
        Vector2 anchoredPos = new Vector2(bottomLeftX + x * canvasTileXOffset, bottomLeftY + y * canvasTileYOffset);
        rectTransform.anchoredPosition = anchoredPos;

        numOfButtons++;
    }
}
