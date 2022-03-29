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

    public GameObject Coal;
    public GameObject Natural;
    public GameObject Solar;
    public GameObject Nuclear;
    int width = 10;
    int height = 9;

    int bottomLeftX = -225;
    int bottomLeftY = -195;
    float canvasTileXOffset = 50;
    float canvasTileYOffset = 21.5f;
    float tileXOffset = .89f;
    float tileYOffset = .77f;
    int numOfButtons = 0;
    
    public List<object[]> allPowLineSpots = new List<object[]>();
    public List<Button> PowLineButtons = new List<Button>();
    List<Vector3> coalPlants = new List<Vector3>();
    List<Vector3> NaturalPlants = new List<Vector3>();
    List<Vector3> NuclearPlants = new List<Vector3>();
    List<Vector3> SolarPlants = new List<Vector3>();
    List<Vector2> P1Coal = new List<Vector2>();
    List<Vector2> P2Coal = new List<Vector2>();
    List<Vector2> P3Coal = new List<Vector2>();
    List<Vector2> P4Coal = new List<Vector2>();
    List<Vector2> P1Natural = new List<Vector2>();
    List<Vector2> P2Natural = new List<Vector2>();
    List<Vector2> P3Natural = new List<Vector2>();
    List<Vector2> P4Natural = new List<Vector2>();
    List<Vector2> P1Nuclear = new List<Vector2>();
    List<Vector2> P2Nuclear = new List<Vector2>();
    List<Vector2> P3Nuclear = new List<Vector2>();
    List<Vector2> P4Nuclear = new List<Vector2>();
    List<Vector2> P1Solar = new List<Vector2>();
    List<Vector2> P2Solar = new List<Vector2>();
    List<Vector2> P3Solar = new List<Vector2>();
    List<Vector2> P4Solar = new List<Vector2>();

    public List<Quaternion> P1Lines = new List<Quaternion>();
    public List<Quaternion> P2Lines = new List<Quaternion>();
    public List<Quaternion> P3Lines = new List<Quaternion>();
    public List<Quaternion> P4Lines = new List<Quaternion>();
    List<Vector2> towns = new List<Vector2>();

    List<List<Quaternion>> P1Paths = new List<List<Quaternion>>();
    List<List<Quaternion>> P2Paths = new List<List<Quaternion>>();
    List<List<Quaternion>> P3Paths = new List<List<Quaternion>>();
    List<List<Quaternion>> P4Paths = new List<List<Quaternion>>();

    List<Vector2> P1reachedTowns = new List<Vector2>();
    List<Vector2> P2reachedTowns = new List<Vector2>();
    List<Vector2> P3reachedTowns = new List<Vector2>();
    List<Vector2> P4reachedTowns = new List<Vector2>();
    List<Vector2> P1LinesPos = new List<Vector2>();
    List<Vector2> P2LinesPos = new List<Vector2>();
    List<Vector2> P3LinesPos = new List<Vector2>();
    List<Vector2> P4LinesPos = new List<Vector2>();
    List<GameObject> P1sprites = new List<GameObject>();
    List<GameObject> P2sprites = new List<GameObject>();
    List<GameObject> P3sprites = new List<GameObject>();
    List<GameObject> P4sprites = new List<GameObject>();
    // void Start()
    // {
    //     createButtons();
    // }
    public GameObject buttontest;

    void Awake()
    {
        coalPlants = Coal.GetComponent<createPowerPlantButtons>().builtCoal;
        NaturalPlants = Coal.GetComponent<createPowerPlantButtons>().builtNatural;
        NuclearPlants = Coal.GetComponent<createPowerPlantButtons>().builtNuclear;
        SolarPlants = Coal.GetComponent<createPowerPlantButtons>().builtSolar;
        mapGen = GameObject.FindObjectOfType<HexTileMapGenerator>();
        scoreMan = GameObject.FindObjectOfType<ScoreManager>();
        towns = mapGen.GetComponent<HexTileMapGenerator>().builtTowns;
        generatePositions();
        generateInactiveButtons();

    }

    bool buildSelected = false;
   /* private void Update()
    {
        Debug.Log("helloooo");
    }*/
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
        while (GameObject.Find("LineButton(Clone)") != null)
        {
            buttontest = GameObject.Find("LineButton(Clone)");
            buttontest.gameObject.SetActive(false);
        }
    }
    bool checkforIntersection(float x, float y, float vertexX, float vertexY)
    {
        bool check = false;
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

        if (new Vector2(botCorner1X, botCorner1Y) == new Vector2(vertexX, vertexY))
        {
            return true;
        }
        if (new Vector2(botCorner2X, botCorner2Y) == new Vector2(vertexX, vertexY))
        {
            return true;
        }
        if (new Vector2(bottomX, bottomY) == new Vector2(vertexX, vertexY))
        {
            return true;
        }
        if (new Vector2(topCorner1X, topCorner1Y) == new Vector2(vertexX, vertexY))
        {
            return true;
        }
        if (new Vector2(topCorner2X, topCorner2Y) == new Vector2(vertexX, vertexY))
        {
            return true;
        }
        if (new Vector2(topX, topY) == new Vector2(vertexX, vertexY))
        {
            return true;
        }
        return false;
    }

    void generatePositions()
    {
        for (int y = 0; y < height * 2; y++)
        {
            for (int x = 0; x < width; x++)
            {

                if (y == 0 && x < width - 2 && x > 1)
                {
                    allPowLineSpots.Add(new object[] { (float)x + 0.25f, (float)y + 0.25f, new Quaternion(0.5f, 1.0f, 0.0f, 0.0f) , new int[] { 0, 0, 0, 0 }, 0});//bottom
                    allPowLineSpots.Add(new object[] { (float)x + 0.25f, (float)y + 2.25f, new Quaternion(1.65f, 1.0f, 0.0f, 0.0f), new int[] { 0, 0, 0, 0 }, 0 });//top
                    allPowLineSpots.Add(new object[] { (float)x - 0.25f, (float)y + 0.25f, new Quaternion(1.65f, 1.0f, 0.0f, 0.0f), new int[] { 0, 0, 0, 0 }, 0 });//bot left
                    allPowLineSpots.Add(new object[] { (float)x - 0.25f, (float)y + 2.25f, new Quaternion(0.5f, 1.0f, 0.0f, 0.0f), new int[] { 0, 0, 0, 0 }, 0 });//top left
                    allPowLineSpots.Add(new object[] { (float)x + .5f, (float)y + 1.25f, new Quaternion(0.0f, 0.0f, 0.0f, 0.0f), new int[] { 0, 0, 0, 0 }, 0 });
                    if (x == 2)//special case on left side
                    {
                        allPowLineSpots.Add(new object[] { (float)x - 0.5f, (float)y + 1.2f, new Quaternion(0.0f, 1.0f, 0.0f, 0.0f), new int[] { 0, 0, 0, 0 }, 0 });
                        allPowLineSpots.Add(new object[] { (float)x - 0.75f, (float)y + 2.25f, new Quaternion(1.65f, 1.0f, 0.0f, 0.0f), new int[] { 0, 0, 0, 0 }, 0 });
                    }
                    if (x == width - 3)//special case on right side
                    {

                        allPowLineSpots.Add(new object[] { (float)x + 0.75f, (float)y + 2.25f, new Quaternion(0.5f, 1.0f, 0.0f, 0.0f), new int[] { 0, 0, 0, 0 }, 0 });
                        allPowLineSpots.Add(new object[] { (float)x + 1, (float)y + 3.25f, new Quaternion(0.0f, 1.0f, 0.0f, 0.0f), new int[] { 0, 0, 0, 0 }, 0 });
                    }

                }

                if (y == 4 && x < width - 1 && x > 0)
                {
                    allPowLineSpots.Add(new object[] { (float)x + 0.25f, (float)y + 0.25f, new Quaternion(0.5f, 1.0f, 0.0f, 0.0f), new int[] {0,0,0,0},0 });//bottom
                    allPowLineSpots.Add(new object[] { (float)x + 0.25f, (float)y + 2.25f, new Quaternion(1.65f, 1.0f, 0.0f, 0.0f), new int[] { 0, 0, 0, 0 }, 0 });//top
                    allPowLineSpots.Add(new object[] { (float)x - 0.25f, (float)y + 0.25f, new Quaternion(1.65f, 1.0f, 0.0f, 0.0f), new int[] { 0, 0, 0, 0 }, 0 });//bot left
                    allPowLineSpots.Add(new object[] { (float)x - 0.25f, (float)y + 2.25f, new Quaternion(0.5f, 1.0f, 0.0f, 0.0f), new int[] { 0, 0, 0, 0 }, 0 });//top left
                    allPowLineSpots.Add(new object[] { (float)x + .5f, (float)y + 1.25f, new Quaternion(0.0f, 0.0f, 0.0f, 0.0f), new int[] { 0, 0, 0, 0 }, 0 });
                    allPowLineSpots.Add(new object[] { (float)x, (float)y - 0.75f, new Quaternion(0.0f, 0.0f, 0.0f, 0.0f), new int[] { 0, 0, 0, 0 }, 0 });
                    if (x == 1)//special case on left side
                    {
                        allPowLineSpots.Add(new object[] { (float)x - 0.75f, (float)y + 2.25f, new Quaternion(1.65f, 1.0f, 0.0f, 0.0f), new int[] { 0, 0, 0, 0 }, 0 });
                        allPowLineSpots.Add(new object[] { (float)x - 0.5f, (float)y + 1.25f, new Quaternion(0.0f, 1.0f, 0.0f, 0.0f), new int[] { 0, 0, 0, 0 }, 0 });
                    }
                    if (x == width - 2)//special case on right side
                    {
                        allPowLineSpots.Add(new object[] { (float)x + 0.75f, (float)y + 2.25f, new Quaternion(0.5f, 1.0f, 0.0f, 0.0f), new int[] { 0, 0, 0, 0 }, 0 });

                    }

                }
                if (y == 8)
                {
                    allPowLineSpots.Add(new object[] { (float)x + 0.25f, (float)y + 0.25f, new Quaternion(0.5f, 1.0f, 0.0f, 0.0f) , new int[] { 0, 0, 0, 0 }, 0});//bottom
                    allPowLineSpots.Add(new object[] { (float)x + 0.25f, (float)y + 2.25f, new Quaternion(1.65f, 1.0f, 0.0f, 0.0f), new int[] { 0, 0, 0, 0 }, 0 });//top
                    allPowLineSpots.Add(new object[] { (float)x - 0.25f, (float)y + 0.25f, new Quaternion(1.65f, 1.0f, 0.0f, 0.0f), new int[] { 0, 0, 0, 0 }, 0 });//bot left
                    allPowLineSpots.Add(new object[] { (float)x - 0.25f, (float)y + 2.25f, new Quaternion(0.5f, 1.0f, 0.0f, 0.0f), new int[] { 0, 0, 0, 0 }, 0 });//top left
                    allPowLineSpots.Add(new object[] { (float)x + .5f, (float)y + 1.25f, new Quaternion(0.0f, 0.0f, 0.0f, 0.0f), new int[] { 0, 0, 0, 0 }, 0 });
                    allPowLineSpots.Add(new object[] { (float)x, (float)y - 0.75f, new Quaternion(0.0f, 0.0f, 0.0f, 0.0f), new int[] { 0, 0, 0, 0 }, 0 });
                    if (x == 1)//special case on left side
                    {
                        allPowLineSpots.Add(new object[] { (float)x - 1.5f, (float)y + 1.25f, new Quaternion(0.0f, 1.0f, 0.0f, 0.0f), new int[] { 0, 0, 0, 0 }, 0 });
                        allPowLineSpots.Add(new object[] { (float)x - 0.75f, (float)y + 4.2f, new Quaternion(0.5f, 1.0f, 0.0f, 0.0f), new int[] { 0, 0, 0, 0 }, 0 });
                        allPowLineSpots.Add(new object[] { (float)x - 1.0f, (float)y - 0.75f, new Quaternion(0.0f, 1.0f, 0.0f, 0.0f), new int[] { 0, 0, 0, 0 }, 0 });
                    }


                }
                if (y == 12 && x < width - 1 && x > 0)
                {
                    allPowLineSpots.Add(new object[] { (float)x + 0.25f, (float)y + 0.25f, new Quaternion(0.5f, 1.0f, 0.0f, 0.0f) , new int[] { 0, 0, 0, 0 }, 0});//bottom
                    allPowLineSpots.Add(new object[] { (float)x + 0.25f, (float)y + 2.25f, new Quaternion(1.65f, 1.0f, 0.0f, 0.0f), new int[] { 0, 0, 0, 0 }, 0 });//top
                    allPowLineSpots.Add(new object[] { (float)x - 0.25f, (float)y + 0.25f, new Quaternion(1.65f, 1.0f, 0.0f, 0.0f), new int[] { 0, 0, 0, 0 }, 0 });//bot left
                    allPowLineSpots.Add(new object[] { (float)x - 0.25f, (float)y + 2.25f, new Quaternion(0.5f, 1.0f, 0.0f, 0.0f), new int[] { 0, 0, 0, 0 }, 0 });//top left
                    allPowLineSpots.Add(new object[] { (float)x + .5f, (float)y + 1.25f, new Quaternion(0.0f, 0.0f, 0.0f, 0.0f), new int[] { 0, 0, 0, 0 }, 0 });
                    allPowLineSpots.Add(new object[] { (float)x, (float)y - 0.75f, new Quaternion(0.0f, 0.0f, 0.0f, 0.0f), new int[] { 0, 0, 0, 0 }, 0 });

                    if (x == 1)
                    {
                        allPowLineSpots.Add(new object[] { (float)x - 1.0f, (float)y - 0.75f, new Quaternion(0.0f, 1.0f, 0.0f, 0.0f) , new int[] { 0, 0, 0, 0 }, 0});
                        allPowLineSpots.Add(new object[] { (float)x - 0.5f, (float)y + 1.25f, new Quaternion(0.0f, 1.0f, 0.0f, 0.0f), new int[] { 0, 0, 0, 0 }, 0 });
                    }

                    if (x == width - 2)
                    {
                        allPowLineSpots.Add(new object[] { (float)x + 1.0f, (float)y - 0.75f, new Quaternion(0.0f, 1.0f, 0.0f, 0.0f) , new int[] { 0, 0, 0, 0 }, 0});
                        allPowLineSpots.Add(new object[] { (float)x - 1.0f, (float)y - 0.75f, new Quaternion(0.0f, 1.0f, 0.0f, 0.0f), new int[] { 0, 0, 0, 0 }, 0 });
                        allPowLineSpots.Add(new object[] { (float)x + 0.75f, (float)y + 0.25f, new Quaternion(1.65f, 1.0f, 0.0f, 0.0f), new int[] { 0, 0, 0, 0 }, 0 });
                    }

                }

                if (y == 16 && x < width - 2 && x > 1)
                {
                    allPowLineSpots.Add(new object[] { (float)x + 0.25f, (float)y + 0.25f, new Quaternion(0.5f, 1.0f, 0.0f, 0.0f) , new int[] { 0, 0, 0, 0 }, 0});//bottom
                    allPowLineSpots.Add(new object[] { (float)x + 0.25f, (float)y + 2.25f, new Quaternion(1.65f, 1.0f, 0.0f, 0.0f), new int[] { 0, 0, 0, 0 }, 0 });//top
                    allPowLineSpots.Add(new object[] { (float)x - 0.25f, (float)y + 0.25f, new Quaternion(1.65f, 1.0f, 0.0f, 0.0f), new int[] { 0, 0, 0, 0 }, 0 });//bot left
                    allPowLineSpots.Add(new object[] { (float)x - 0.25f, (float)y + 2.25f, new Quaternion(0.5f, 1.0f, 0.0f, 0.0f), new int[] { 0, 0, 0, 0 }, 0 });//top left
                    allPowLineSpots.Add(new object[] { (float)x + .5f, (float)y + 1.25f, new Quaternion(0.0f, 0.0f, 0.0f, 0.0f), new int[] { 0, 0, 0, 0 }, 0 });
                    allPowLineSpots.Add(new object[] { (float)x + 1.0f, (float)y - 0.75f, new Quaternion(0.0f, 0.0f, 0.0f, 0.0f), new int[] { 0, 0, 0, 0 }, 0 });
                    if (x == 2)//special case on left side
                    {
                        allPowLineSpots.Add(new object[] { (float)x - 0.5f, (float)y + 1.25f, new Quaternion(0.0f, 1.0f, 0.0f, 0.0f), new int[] { 0, 0, 0, 0 }, 0 });
                        allPowLineSpots.Add(new object[] { (float)x - 0.75f, (float)y + 0.25f, new Quaternion(1.65f, 1.0f, 0.0f, 0.0f), new int[] { 0, 0, 0, 0 }, 0 });
                        allPowLineSpots.Add(new object[] { (float)x, (float)y - 0.75f, new Quaternion(0.0f, 1.0f, 0.0f, 0.0f), new int[] { 0, 0, 0, 0 }, 0 });
                        allPowLineSpots.Add(new object[] { (float)x - 1.0f, (float)y - 0.75f, new Quaternion(0.0f, 1.0f, 0.0f, 0.0f), new int[] { 0, 0, 0, 0 }, 0 });
                    }

                    if (x == width - 3)
                    {
                        allPowLineSpots.Add(new object[] { (float)x + 0.75f, (float)y + 0.25f, new Quaternion(1.65f, 1.0f, 0.0f, 0.0f), new int[] { 0, 0, 0, 0 }, 0 });
                    }


                }

            }
        }
    }

    bool checkLegalLinePlacement(int turn, float x, float y)
    {
        for(int j = 0; j < allPowLineSpots.Count; j++)
        {
            float xCoord = (float)allPowLineSpots[j][0];
            float yCoord = (float)allPowLineSpots[j][1];

            if(x == xCoord && y == yCoord)
            {
                if ((int)allPowLineSpots[j][4] < 8)
                {
                    int[] playerLines = (int[])allPowLineSpots[j][3];
                    if (turn == 0)
                    {
                        if (playerLines[0] < 4)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    if (turn == 1)
                    {
                        if (playerLines[1] < 4)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    if (turn == 2)
                    {
                        if (playerLines[2] < 4)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    if (turn == 3)
                    {
                        if (playerLines[3] < 4)
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
    void createButtons()//this calls makeButton on all of the bottoms of the hexagons
    {
        coalPlants = Coal.GetComponent<createPowerPlantButtons>().builtCoal;
        NaturalPlants = Coal.GetComponent<createPowerPlantButtons>().builtNatural;
        NuclearPlants = Coal.GetComponent<createPowerPlantButtons>().builtNuclear;
        SolarPlants = Coal.GetComponent<createPowerPlantButtons>().builtSolar;

        int turn = 0;
        for (int i = 0; i < coalPlants.Count; i++)
        {
            turn = (int)coalPlants[i][2];
            if (turn == 0)
            {
                if (!P1Coal.Contains(new Vector2((float)coalPlants[i][0], (float)coalPlants[i][1])))
                {
                    P1Coal.Add(new Vector2((float)coalPlants[i][0], (float)coalPlants[i][1]));
                }
            }
            if (turn == 1)
            {
                if (!P2Coal.Contains(new Vector2((float)coalPlants[i][0], (float)coalPlants[i][1])))
                {
                    P2Coal.Add(new Vector2((float)coalPlants[i][0], (float)coalPlants[i][1]));
                }
            }
            if (turn == 2)
            {
                if (!P3Coal.Contains(new Vector2((float)coalPlants[i][0], (float)coalPlants[i][1])))
                {
                    P3Coal.Add(new Vector2((float)coalPlants[i][0], (float)coalPlants[i][1]));
                }
            }
            if (turn == 3)
            {
                if (!P4Coal.Contains(new Vector2((float)coalPlants[i][0], (float)coalPlants[i][1])))
                {
                    P4Coal.Add(new Vector2((float)coalPlants[i][0], (float)coalPlants[i][1]));
                }
            }

            //makeButton(coalPlants[i][0]-0.25f, coalPlants[i][1] + 0.25f, new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
            for (int j = 0; j < allPowLineSpots.Count; j++)
            {
                float xCoord = (float)allPowLineSpots[j][0];
                float yCoord = (float)allPowLineSpots[j][1];
                if (turn == (int)scoreMan.turn)
                {
                    float topLeftX = coalPlants[i][0] - 0.25f;
                    float topLeftY = coalPlants[i][1] + 0.25f;
                    float topRightX = coalPlants[i][0] + 0.25f;
                    float topRightY = coalPlants[i][1] + 0.25f;
                    float bottomX = coalPlants[i][0];
                    float bottomY = coalPlants[i][1] - 0.75f;
                    float topX = coalPlants[i][0];
                    float topY = coalPlants[i][1] + 0.75f;
                    float botLeftX = coalPlants[i][0] - 0.25f;
                    float botLeftY = coalPlants[i][1] - 0.25f;
                    float botRightX = coalPlants[i][0] + 0.25f;
                    float botRightY = coalPlants[i][1] - 0.25f;
                    /*if (i == 0)
                    {
                        Debug.Log("plant x " + coalPlants[i][0]);
                        Debug.Log("plant y " + coalPlants[i][1]);
                        Debug.Log("top left x " + topLeftX);
                        Debug.Log("top left y " + topLeftY);
                        Debug.Log("x coord " + xCoord);
                        Debug.Log("y coord " + yCoord);
                    }*/

                    if (topLeftX == xCoord && topLeftY == yCoord)
                    {
                        if(checkLegalLinePlacement(turn, xCoord, yCoord) == false)
                        {
                            PowLineButtons[j].gameObject.SetActive(false);
                        }
                        else
                        {
                            PowLineButtons[j].gameObject.SetActive(true);
                        }
                        
                    }

                    if (topRightX == xCoord && topRightY == yCoord)
                    {
                        if (checkLegalLinePlacement(turn, xCoord, yCoord) == false)
                        {
                            PowLineButtons[j].gameObject.SetActive(false);
                        }
                        else
                        {
                            PowLineButtons[j].gameObject.SetActive(true);
                        }
                    }

                    if (bottomX == xCoord && (Mathf.Abs(yCoord - bottomY) >= 0) && (Mathf.Abs(yCoord - bottomY) <= 0.2f))
                    {
                        if (checkLegalLinePlacement(turn, xCoord, yCoord) == false)
                        {
                            PowLineButtons[j].gameObject.SetActive(false);
                        }
                        else
                        {
                            PowLineButtons[j].gameObject.SetActive(true);
                        }
                    }

                    if (topX == xCoord && ((yCoord - topY) >= 0) && ((yCoord - topY) <= 0.2f))
                    {
                        if (checkLegalLinePlacement(turn, xCoord, yCoord) == false)
                        {
                            PowLineButtons[j].gameObject.SetActive(false);
                        }
                        else
                        {
                            PowLineButtons[j].gameObject.SetActive(true);
                        }
                    }

                    if (botLeftX == xCoord && botLeftY == yCoord)
                    {
                        if (checkLegalLinePlacement(turn, xCoord, yCoord) == false)
                        {
                            PowLineButtons[j].gameObject.SetActive(false);
                        }
                        else
                        {
                            PowLineButtons[j].gameObject.SetActive(true);
                        }
                    }

                    if (botRightX == xCoord && botRightY == yCoord)
                    {
                        if (checkLegalLinePlacement(turn, xCoord, yCoord) == false)
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

        for (int i = 0; i < SolarPlants.Count; i++)
        {
            turn = (int)SolarPlants[i][2];
            if (turn == 0)
            {
                if (!P1Solar.Contains(new Vector2((float)SolarPlants[i][0], (float)SolarPlants[i][1])))
                {
                    P1Solar.Add(new Vector2((float)SolarPlants[i][0], (float)SolarPlants[i][1]));
                }
            }
            if (turn == 1)
            {
                if (!P2Solar.Contains(new Vector2((float)SolarPlants[i][0], (float)SolarPlants[i][1])))
                {
                    P2Solar.Add(new Vector2((float)SolarPlants[i][0], (float)SolarPlants[i][1]));
                }
            }
            if (turn == 2)
            {
                if (!P3Solar.Contains(new Vector2((float)SolarPlants[i][0], (float)SolarPlants[i][1])))
                {
                    P3Solar.Add(new Vector2((float)SolarPlants[i][0], (float)SolarPlants[i][1]));
                }
            }
            if (turn == 3)
            {
                if (!P4Solar.Contains(new Vector2((float)SolarPlants[i][0], (float)SolarPlants[i][1])))
                {
                    P4Solar.Add(new Vector2((float)SolarPlants[i][0], (float)SolarPlants[i][1]));
                }
            }
            //makeButton(coalPlants[i][0]-0.25f, coalPlants[i][1] + 0.25f, new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
            for (int j = 0; j < allPowLineSpots.Count; j++)
            {
                float xCoord = (float)allPowLineSpots[j][0];
                float yCoord = (float)allPowLineSpots[j][1];
                if (turn == (int)scoreMan.turn)
                {
                    float topLeftX = SolarPlants[i][0] - 0.25f;
                    float topLeftY = SolarPlants[i][1] + 0.25f;
                    float topRightX = SolarPlants[i][0] + 0.25f;
                    float topRightY = SolarPlants[i][1] + 0.25f;
                    float bottomX = SolarPlants[i][0];
                    float bottomY = SolarPlants[i][1] - 0.75f;
                    float topX = SolarPlants[i][0];
                    float topY = SolarPlants[i][1] + 0.75f;
                    float botLeftX = SolarPlants[i][0] - 0.25f;
                    float botLeftY = SolarPlants[i][1] - 0.25f;
                    float botRightX = SolarPlants[i][0] + 0.25f;
                    float botRightY = SolarPlants[i][1] - 0.25f;
                    /*if (i == 0)
                    {
                        Debug.Log("plant x " + SolarPlants[i][0]);
                        Debug.Log("plant y " + SolarPlants[i][1]);
                        Debug.Log("top  x " + topX);
                        Debug.Log("top  y " + topY);
                        //Debug.Log("x coord " + xCoord);
                        //Debug.Log("y coord " + yCoord);
                    }*/



                    if (topLeftX == xCoord && topLeftY == yCoord)
                    {
                        if (checkLegalLinePlacement(turn, xCoord, yCoord) == false)
                        {
                            PowLineButtons[j].gameObject.SetActive(false);
                        }
                        else
                        {
                            PowLineButtons[j].gameObject.SetActive(true);
                        }

                    }

                    if (topRightX == xCoord && topRightY == yCoord)
                    {
                        if (checkLegalLinePlacement(turn, xCoord, yCoord) == false)
                        {
                            PowLineButtons[j].gameObject.SetActive(false);
                        }
                        else
                        {
                            PowLineButtons[j].gameObject.SetActive(true);
                        }
                    }

                    if (bottomX == xCoord && (Mathf.Abs(yCoord - bottomY) >= 0) && (Mathf.Abs(yCoord - bottomY) <= 0.2f))
                    {
                        if (checkLegalLinePlacement(turn, xCoord, yCoord) == false)
                        {
                            PowLineButtons[j].gameObject.SetActive(false);
                        }
                        else
                        {
                            PowLineButtons[j].gameObject.SetActive(true);
                        }
                    }

                    if (topX == xCoord && ((yCoord - topY) >= 0) && ((yCoord - topY) <= 0.2f))
                    {

                        if (checkLegalLinePlacement(turn, xCoord, yCoord) == false)
                        {
                            PowLineButtons[j].gameObject.SetActive(false);
                        }
                        else
                        {
                            PowLineButtons[j].gameObject.SetActive(true);
                        }
                    }

                    if (botLeftX == xCoord && botLeftY == yCoord)
                    {
                        if (checkLegalLinePlacement(turn, xCoord, yCoord) == false)
                        {
                            PowLineButtons[j].gameObject.SetActive(false);
                        }
                        else
                        {
                            PowLineButtons[j].gameObject.SetActive(true);
                        }
                    }

                    if (botRightX == xCoord && botRightY == yCoord)
                    {
                        if (checkLegalLinePlacement(turn, xCoord, yCoord) == false)
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

        for (int i = 0; i < NaturalPlants.Count; i++)
        {
            turn = (int)NaturalPlants[i][2];
            if (turn == 0)
            {
                if (!P1Natural.Contains(new Vector2((float)NaturalPlants[i][0], (float)NaturalPlants[i][1])))
                {
                    P1Natural.Add(new Vector2((float)NaturalPlants[i][0], (float)NaturalPlants[i][1]));
                }
            }
            if (turn == 1)
            {
                if (!P2Natural.Contains(new Vector2((float)NaturalPlants[i][0], (float)NaturalPlants[i][1])))
                {
                    P2Natural.Add(new Vector2((float)NaturalPlants[i][0], (float)NaturalPlants[i][1]));
                }
            }
            if (turn == 2)
            {
                if (!P3Natural.Contains(new Vector2((float)NaturalPlants[i][0], (float)NaturalPlants[i][1])))
                {
                    P3Natural.Add(new Vector2((float)NaturalPlants[i][0], (float)NaturalPlants[i][1]));
                }
            }
            if (turn == 3)
            {
                if (!P4Natural.Contains(new Vector2((float)NaturalPlants[i][0], (float)NaturalPlants[i][1])))
                {
                    P4Natural.Add(new Vector2((float)NaturalPlants[i][0], (float)NaturalPlants[i][1]));
                }
            }
            //makeButton(coalPlants[i][0]-0.25f, coalPlants[i][1] + 0.25f, new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
            for (int j = 0; j < allPowLineSpots.Count; j++)
            {
                float xCoord = (float)allPowLineSpots[j][0];
                float yCoord = (float)allPowLineSpots[j][1];
                if (turn == (int)scoreMan.turn)
                {
                    float topLeftX = NaturalPlants[i][0] - 0.25f;
                    float topLeftY = NaturalPlants[i][1] + 0.25f;
                    float topRightX = NaturalPlants[i][0] + 0.25f;
                    float topRightY = NaturalPlants[i][1] + 0.25f;
                    float bottomX = NaturalPlants[i][0];
                    float bottomY = NaturalPlants[i][1] - 0.75f;
                    float topX = NaturalPlants[i][0];
                    float topY = NaturalPlants[i][1] + 0.75f;
                    float botLeftX = NaturalPlants[i][0] - 0.25f;
                    float botLeftY = NaturalPlants[i][1] - 0.25f;
                    float botRightX = NaturalPlants[i][0] + 0.25f;
                    float botRightY = NaturalPlants[i][1] - 0.25f;
                    /*if (i == 0)
                    {
                        Debug.Log("plant x " + coalPlants[i][0]);
                        Debug.Log("plant y " + coalPlants[i][1]);
                        Debug.Log("top left x " + topLeftX);
                        Debug.Log("top left y " + topLeftY);
                        Debug.Log("x coord " + xCoord);
                        Debug.Log("y coord " + yCoord);
                    }*/

                    if (topLeftX == xCoord && topLeftY == yCoord)
                    {
                        if (checkLegalLinePlacement(turn, xCoord, yCoord) == false)
                        {
                            PowLineButtons[j].gameObject.SetActive(false);
                        }
                        else
                        {
                            PowLineButtons[j].gameObject.SetActive(true);
                        }

                    }

                    if (topRightX == xCoord && topRightY == yCoord)
                    {
                        if (checkLegalLinePlacement(turn, xCoord, yCoord) == false)
                        {
                            PowLineButtons[j].gameObject.SetActive(false);
                        }
                        else
                        {
                            PowLineButtons[j].gameObject.SetActive(true);
                        }
                    }

                    if (bottomX == xCoord && (Mathf.Abs(yCoord - bottomY) >= 0) && (Mathf.Abs(yCoord - bottomY) <= 0.2f))
                    {
                        if (checkLegalLinePlacement(turn, xCoord, yCoord) == false)
                        {
                            PowLineButtons[j].gameObject.SetActive(false);
                        }
                        else
                        {
                            PowLineButtons[j].gameObject.SetActive(true);
                        }
                    }

                    if (topX == xCoord && ((yCoord - topY) >= 0) && ((yCoord - topY) <= 0.2f))
                    {

                        if (checkLegalLinePlacement(turn, xCoord, yCoord) == false)
                        {
                            PowLineButtons[j].gameObject.SetActive(false);
                        }
                        else
                        {
                            PowLineButtons[j].gameObject.SetActive(true);
                        }
                    }

                    if (botLeftX == xCoord && botLeftY == yCoord)
                    {
                        if (checkLegalLinePlacement(turn, xCoord, yCoord) == false)
                        {
                            PowLineButtons[j].gameObject.SetActive(false);
                        }
                        else
                        {
                            PowLineButtons[j].gameObject.SetActive(true);
                        }
                    }

                    if (botRightX == xCoord && botRightY == yCoord)
                    {
                        if (checkLegalLinePlacement(turn, xCoord, yCoord) == false)
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

        for (int i = 0; i < NuclearPlants.Count; i++)
        {
            turn = (int)NuclearPlants[i][2];
            if (turn == 0)
            {
                if (!P1Nuclear.Contains(new Vector2((float)NuclearPlants[i][0], (float)NuclearPlants[i][1])))
                {
                    P1Nuclear.Add(new Vector2((float)NuclearPlants[i][0], (float)NuclearPlants[i][1]));
                }
            }
            if (turn == 1)
            {
                if (!P2Nuclear.Contains(new Vector2((float)NuclearPlants[i][0], (float)NuclearPlants[i][1])))
                {
                    P2Nuclear.Add(new Vector2((float)NuclearPlants[i][0], (float)NuclearPlants[i][1]));
                }
            }
            if (turn == 2)
            {
                if (!P3Nuclear.Contains(new Vector2((float)NuclearPlants[i][0], (float)NuclearPlants[i][1])))
                {
                    P3Nuclear.Add(new Vector2((float)NuclearPlants[i][0], (float)NuclearPlants[i][1]));
                }
            }
            if (turn == 3)
            {
                if (!P4Nuclear.Contains(new Vector2((float)NuclearPlants[i][0], (float)NuclearPlants[i][1])))
                {
                    P4Nuclear.Add(new Vector2((float)NuclearPlants[i][0], (float)NuclearPlants[i][1]));
                }
            }
            //makeButton(coalPlants[i][0]-0.25f, coalPlants[i][1] + 0.25f, new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
            for (int j = 0; j < allPowLineSpots.Count; j++)
            {
                float xCoord = (float)allPowLineSpots[j][0];
                float yCoord = (float)allPowLineSpots[j][1];
                if (turn == (int)scoreMan.turn)
                {
                    float topLeftX = NuclearPlants[i][0] - 0.25f;
                    float topLeftY = NuclearPlants[i][1] + 0.25f;
                    float topRightX = NuclearPlants[i][0] + 0.25f;
                    float topRightY = NuclearPlants[i][1] + 0.25f;
                    float bottomX = NuclearPlants[i][0];
                    float bottomY = NuclearPlants[i][1] - 0.75f;
                    float topX = NuclearPlants[i][0];
                    float topY = NuclearPlants[i][1] + 0.75f;
                    float botLeftX = NuclearPlants[i][0] - 0.25f;
                    float botLeftY = NuclearPlants[i][1] - 0.25f;
                    float botRightX = NuclearPlants[i][0] + 0.25f;
                    float botRightY = NuclearPlants[i][1] - 0.25f;
                    /*if (i == 0)
                    {
                        Debug.Log("plant x " + coalPlants[i][0]);
                        Debug.Log("plant y " + coalPlants[i][1]);
                        Debug.Log("top left x " + topLeftX);
                        Debug.Log("top left y " + topLeftY);
                        Debug.Log("x coord " + xCoord);
                        Debug.Log("y coord " + yCoord);
                    }*/

                    if (topLeftX == xCoord && topLeftY == yCoord)
                    {
                        if (checkLegalLinePlacement(turn, xCoord, yCoord) == false)
                        {
                            PowLineButtons[j].gameObject.SetActive(false);
                        }
                        else
                        {
                            PowLineButtons[j].gameObject.SetActive(true);
                        }

                    }

                    if (topRightX == xCoord && topRightY == yCoord)
                    {
                        if (checkLegalLinePlacement(turn, xCoord, yCoord) == false)
                        {
                            PowLineButtons[j].gameObject.SetActive(false);
                        }
                        else
                        {
                            PowLineButtons[j].gameObject.SetActive(true);
                        }
                    }

                    if (bottomX == xCoord && (Mathf.Abs(yCoord - bottomY) >= 0) && (Mathf.Abs(yCoord - bottomY) <= 0.2f))
                    {
                        if (checkLegalLinePlacement(turn, xCoord, yCoord) == false)
                        {
                            PowLineButtons[j].gameObject.SetActive(false);
                        }
                        else
                        {
                            PowLineButtons[j].gameObject.SetActive(true);
                        }
                    }

                    if (topX == xCoord && ((yCoord - topY) >= 0) && ((yCoord - topY) <= 0.2f))
                    {

                        if (checkLegalLinePlacement(turn, xCoord, yCoord) == false)
                        {
                            PowLineButtons[j].gameObject.SetActive(false);
                        }
                        else
                        {
                            PowLineButtons[j].gameObject.SetActive(true);
                        }
                    }

                    if (botLeftX == xCoord && botLeftY == yCoord)
                    {
                        if (checkLegalLinePlacement(turn, xCoord, yCoord) == false)
                        {
                            PowLineButtons[j].gameObject.SetActive(false);
                        }
                        else
                        {
                            PowLineButtons[j].gameObject.SetActive(true);
                        }
                    }

                    if (botRightX == xCoord && botRightY == yCoord)
                    {
                        if (checkLegalLinePlacement(turn, xCoord, yCoord) == false)
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
        createLinesOffOtherLines();
        /*for (int i = 0; i < PowLineButtons.Count; i++)
        {
            PowLineButtons[i].gameObject.SetActive(true);
        }*/
    }
    void createLinesOffOtherLines()
    {
        int playerturn = (int)scoreMan.turn;

        if(playerturn == 0)
        {
            
            for (int i = 0; i < P1Lines.Count; i++)
            {
                for (int j = 0; j < allPowLineSpots.Count; j++)
                {
                    float xCoord = (float)allPowLineSpots[j][0];
                    float yCoord = (float)allPowLineSpots[j][1];

                    float topX = (float)P1Lines[i][0] + 0.25f;
                    float topY = (float)P1Lines[i][1] + 1.0f;

                    float bot1X = (float)P1Lines[i][0] - 0.25f;
                    float bot1Y = (float)P1Lines[i][1] - 1.0f;

                    float topL1X = (float)P1Lines[i][0] - 0.5f;
                    float topL1Y = (float)P1Lines[i][1];

                    float topRX = (float)P1Lines[i][0] + 0.5f;
                    float topRY = (float)P1Lines[i][1];

                    float topL2X = (float)P1Lines[i][0] - 0.25f;
                    float topL2Y = (float)P1Lines[i][1] + 1.0f;

                    float bot2X = (float)P1Lines[i][0] + 0.25f;
                    float bot2Y = (float)P1Lines[i][1] - 1.0f;

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
    void ButtonClicked(Button tempButton, string buttonNo, float x, float y, Quaternion rotation)
    {
        //Debug.Log("Button clicked = " + buttonNo);

        if (scoreMan.buildLine())
        {
            bool check = false;
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
            Debug.Log(P1Paths.Count);
        }
        else
        {
            Debug.Log("Not enough money");
        }

        // tempButton.gameObject.SetActive(false);
        deleteButtons();
        buildSelected = false;
        // buttontest = GameObject.Find("Button(Clone)");
        // buttontest.gameObject.SetActive(false);
        //var ren1 = tempButton.gameObject.GetComponent<Renderer>();
        //ren1.enabled = false;

    }
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
                    if(((int[])allPowLineSpots[i][3])[0] >1){
                        GameObject dest = GameObject.Find("orangeLine "+x+","+y);
                        GameObject.Destroy(dest.GetComponent<BoxCollider>());
                        //GameObject.Destroy(dest);
                        dest = GameObject.Find("powerLine "+x+","+y+" statsText");
                        GameObject.Destroy(dest);
                        dest = GameObject.Find("powerLine "+x+","+y+" statsBackground");
                        GameObject.Destroy(dest);
                    }
                    
                }
                if (playerTurn == 1)
                {
                    int[] currP2Lines = (int[])allPowLineSpots[i][3];
                    currP2Lines[playerTurn] += 1;
                    allPowLineSpots[i][3] = (int[])currP2Lines.Clone();
                    if(((int[])allPowLineSpots[i][3])[1] >1){
                        GameObject dest = GameObject.Find("yellowblackpattern "+x+","+y);
                        GameObject.Destroy(dest.GetComponent<BoxCollider>());
                        dest = GameObject.Find("powerLine "+x+","+y+" statsText");
                        GameObject.Destroy(dest);
                        dest = GameObject.Find("powerLine "+x+","+y+" statsBackground");
                        GameObject.Destroy(dest);
                    }
                }
                if (playerTurn == 2)
                {
                    int[] currP3Lines = (int[])allPowLineSpots[i][3];
                    currP3Lines[playerTurn] += 1;
                    allPowLineSpots[i][3] = (int[])currP3Lines.Clone();
                    if(((int[])allPowLineSpots[i][3])[2] >1){
                        GameObject dest = GameObject.Find("whiteLine "+x+","+y);
                        GameObject.Destroy(dest.GetComponent<BoxCollider>());
                        dest = GameObject.Find("powerLine "+x+","+y+" statsText");
                        GameObject.Destroy(dest);
                        dest = GameObject.Find("powerLine "+x+","+y+" statsBackground");
                        GameObject.Destroy(dest);
                    }
                }
                if (playerTurn == 3)
                {
                    int[] currP4Lines = (int[])allPowLineSpots[i][3];
                    currP4Lines[playerTurn] += 1;
                    allPowLineSpots[i][3] = (int[])currP4Lines.Clone();
                    if(((int[])allPowLineSpots[i][3])[3] >1){
                        GameObject dest = GameObject.Find("redLine "+x+","+y);
                        GameObject.Destroy(dest.GetComponent<BoxCollider>());
                        dest = GameObject.Find("powerLine "+x+","+y+" statsText");
                        GameObject.Destroy(dest);
                        dest = GameObject.Find("powerLine "+x+","+y+" statsBackground");
                        GameObject.Destroy(dest);
                    }
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
            storePlayerPowLines(playerTurn, x, y);
            GameObject TempGo = Instantiate(powLine);
            TempGo.name = powLine.name +" "+x+","+y;
            TempGo.transform.position = new Vector2(x * tileXOffset, y * tileYOffset / 2 - .5f);
            TempGo.transform.rotation = rotation;

            var ren = TempGo.GetComponent<SpriteRenderer>();
            ren.sortingOrder = 1;
            ren.enabled = true;
            
            if (playerTurn == 0)
            {
                P1LinesPos.Add(new Vector2(x, y));
            }
            if (playerTurn == 1)
            {
                P2LinesPos.Add(new Vector2(x, y));
            }
            if (playerTurn == 2)
            {
                P3LinesPos.Add(new Vector2(x, y));
            }
            if (playerTurn == 3)
            {
                P4LinesPos.Add(new Vector2(x, y));
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
                            int index = -1;
                            if (P1LinesPos.FindIndex(0, P1LinesPos.Count, pos => pos[0] == (float)allPowLineSpots[i][0] && pos[1] == (float)allPowLineSpots[i][1]) > -1)
                            {
                                index = P1LinesPos.FindIndex(0, P1LinesPos.Count, pos => pos[0] == (float)allPowLineSpots[i][0] && pos[1] == (float)allPowLineSpots[i][1]);
                                P1LinesPos.RemoveAt(index);
                                Destroy(P1sprites[index]);
                                P1sprites.RemoveAt(index);
                            }
                            else if (P2LinesPos.FindIndex(0, P2LinesPos.Count, pos => pos[0] == (float)allPowLineSpots[i][0] && pos[1] == (float)allPowLineSpots[i][1]) > -1)
                            {
                                index = P2LinesPos.FindIndex(0, P2LinesPos.Count, pos => pos[0] == (float)allPowLineSpots[i][0] && pos[1] == (float)allPowLineSpots[i][1]);
                                P2LinesPos.RemoveAt(index);
                                Destroy(P2sprites[index]);
                                P2sprites.RemoveAt(index);
                            }
                            else if (P3LinesPos.FindIndex(0, P3LinesPos.Count, pos => pos[0] == (float)allPowLineSpots[i][0] && pos[1] == (float)allPowLineSpots[i][1]) > -1)
                            {
                                index = P3LinesPos.FindIndex(0, P3LinesPos.Count, pos => pos[0] == (float)allPowLineSpots[i][0] && pos[1] == (float)allPowLineSpots[i][1]);
                                P3LinesPos.RemoveAt(index);
                                Destroy(P3sprites[index]);
                                P3sprites.RemoveAt(index);
                            }
                            else if (P4LinesPos.FindIndex(0, P4LinesPos.Count, pos => pos[0] == (float)allPowLineSpots[i][0] && pos[1] == (float)allPowLineSpots[i][1]) > -1)
                            {
                                index = P4LinesPos.FindIndex(0, P4LinesPos.Count, pos => pos[0] == (float)allPowLineSpots[i][0] && pos[1] == (float)allPowLineSpots[i][1]);
                                P4LinesPos.RemoveAt(index);
                                Destroy(P4sprites[index]);
                                P4sprites.RemoveAt(index);
                            }
                            if (index != -1)
                            {
                                mapGen.removeBuilt((float)allPowLineSpots[i][0], (float)allPowLineSpots[i][1]);
                                int[] playerTurn = (int[])allPowLineSpots[i][3];
                                playerTurn[(int)scoreMan.turn] -= 1;
                                allPowLineSpots[i][3] = playerTurn;
                                allPowLineSpots[i][4] = (int)allPowLineSpots[i][4] - 1;
                                //Debug.Log("destroy");
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
    }
}