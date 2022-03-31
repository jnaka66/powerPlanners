using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ScoreManager : MonoBehaviour
{   
    public class player
    {
        public int id;
        public int VP;
        public int money;
        public string text;

        public player(int i, int vp, int m, string t)
        {
            this.id = i;
            this.VP = vp;
            this.money = m;
            this.text = t;
        }
    }

    public static ScoreManager instance;
    public createPowerLines cpl;

    //dice stuff
    // Dice dice1;
    // Dice dice2;
    // EventDice eventDice;
    private Sprite[] diceSides; // Array of dice sides sprites to load from Resources folder
    private Sprite[] diceSidesEvent;
    private SpriteRenderer rend1; // Reference to sprite renderer to change sprites
    private SpriteRenderer rend2; // Reference to sprite renderer to change sprites
    private SpriteRenderer rendEvent;
    public GameObject diceFace1;
    public GameObject diceFace2;
    public GameObject diceFaceEvent;
    float tileXOffset = .89f;
    float tileYOffset = .77f;

    //private GUIStyle currentStyle = null;
    float boxHeight = 55;
    float boxWidth = 100;
    float ogscreenw = 708;
    float ogscreenh = 342;
    float scoredist = 120;
    List<Texture2D> colorList;

    public List<player> playerList;
    public enum Turn {p1 = 0, p2 = 1, p3 = 2, p4 = 3 };
    public Turn turn;
    int temp = 0;
    int turnCount = 0;
    public const int defaultEarnings = 50;

    //build class
    public HexTileMapGenerator mapGen0;
    public createPowerLines cpl0;
    public ScoreManager scoreMan0;
    //format for each entry is <x,y,playerNum>
    public List<Vector3> builtCoal0;
    public List<Vector3> builtNatural0;
    public List<Vector3> builtNuclear0;
    public List<Vector3> builtSolar0;

    void Awake()
    {
        mapGen0 = GameObject.FindObjectOfType<HexTileMapGenerator>();
        cpl0 = GameObject.FindObjectOfType<createPowerLines>();
        scoreMan0 = GameObject.FindObjectOfType<ScoreManager>();
        builtCoal0=mapGen0.buildCoal;
        builtSolar0=mapGen0.buildSolar;
        builtNuclear0=mapGen0.buildNuclear;
        builtNatural0=mapGen0.buildNatural;
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else if(instance != null)
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        turn = Turn.p1;
        playerList = new List<player>();
        for (int i = 1; i < 5; i++)
        {
            if (i == 1)
            {
                playerList.Add(new player(i, 0, defaultEarnings*2, "Player " + i + "\nVP: " + 0 + "\nMoney: " + defaultEarnings*2));
            }
            else
            {
                playerList.Add(new player(i, 0, defaultEarnings, "Player " + i + "\nVP: " + 0 + "\nMoney: " + defaultEarnings));
            }
        }
        diceSides = Resources.LoadAll<Sprite>("DiceSides/");
        diceSidesEvent = Resources.LoadAll<Sprite>("EventDiceSides/");
        rend1 = GetComponent<SpriteRenderer>();
        rend2 = GetComponent<SpriteRenderer>();
        rendEvent = GetComponent<SpriteRenderer>();
        GameObject tempFace1 = Instantiate(diceFace1);
        GameObject tempFace2 = Instantiate(diceFace2);
        GameObject tempFaceEvent = Instantiate(diceFaceEvent);
        tempFace1.transform.position = new Vector2(-1 * tileXOffset,1.0f * tileYOffset/2 -.5f);
        tempFace2.transform.position = new Vector2(-1.6f * tileXOffset,1.0f * tileYOffset/2 -.5f);
        tempFaceEvent.transform.position = new Vector2(-2.2f * tileXOffset,1.0f * tileYOffset/2 -.5f);
        rend1 = tempFace1.GetComponent<SpriteRenderer>();
        rend2 = tempFace2.GetComponent<SpriteRenderer>();
        rendEvent = tempFaceEvent.GetComponent<SpriteRenderer>();
    }

    public void AddPoint()
    {
        //Debug.Log("Add point");
        //temp++;
        playerList[(int)turn].VP += 1;
    }

    public bool buildPlant(string plantType,int cost)
    {
        if (plantType == "coal" && playerList[(int)turn].money >= cost)
        {
            playerList[(int)turn].money -= cost;
            return true;
        }
        if (plantType == "natural" && playerList[(int)turn].money >= cost)
        {
            playerList[(int)turn].money -= cost;
            return true;
        }
        if (plantType == "nuclear" && playerList[(int)turn].money >= cost)
        {
            playerList[(int)turn].money -= cost;
            return true;
        }
        if (plantType == "solar" && playerList[(int)turn].money >= cost)
        {
            playerList[(int)turn].money -= cost;
            return true;
        }
        return false;
    }

    public bool buildLine()
    {
        if (playerList[(int)turn].money >= 25)
        {
            playerList[(int)turn].money -= 25;
            return true;
        }
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        playerList[(int)turn].text = "Player " + playerList[(int)turn].id + "\nVP: " + playerList[(int)turn].VP + "\nMoney: " + playerList[(int)turn].money;
    }

    public void endTurn()
    {
        //playerList[(int)turn].VP += temp;
        //playerList[(int)turn].text = "Player " + playerList[(int)turn].id + "\nVP: " + playerList[(int)turn].VP + "\nMoney: " + playerList[(int)turn].money;
        //temp = 0;
        switch ((int)turn)
        {
            case 0:
                turn = Turn.p2;
                //Debug.Log(playerList[0].text);
                break;
            case 1:
                turn = Turn.p3;
                //Debug.Log("P3");
                break;
            case 2:
                turn = Turn.p4;
                //Debug.Log("P4");
                break;
            default:
                turn = Turn.p1;
                //Debug.Log("P1");
                break;
        }

        playerList[(int)turn].money += defaultEarnings;
        turnCount++;
        //Debug.Log("TurnCount= "+turnCount);
        if(turnCount>3){
            // Debug.Log("DiceRoll");
            // dice1.roll();
            roll();
        }
        if(turnCount % 11 == 1 && turnCount>1) {
            Debug.Log("Time for a new town!");
            mapGen0.makeTown();
        }
        // GameObject TempGo = Instantiate(city);
        // // TempGo.AddComponent<BoxCollider>();
        // // TempGo.transform.position = new Vector2(x * tileXOffset,y * tileYOffset/2 -.5f);
        // // var ren = TempGo.GetComponent<SpriteRenderer>();
        // TempGo.AddComponent<onHoverScript>();
        // var hover = TempGo.GetComponent<onHoverScript>();//add the hover script to the city
        // hover.location = new Vector2(x,y);//pass the location
        // hover.objType = "Town";//and type
        // hover.demand = Random.Range(50,125);//set the town's demand
        // if (hover.delivered > 150) {
        //     Debug.Log("Time to make this a city!");
        // }
    }

    void OnGUI()
    {
        //Debug.Log("GUI");
        //InitStyles();
        for (int i = 0; i < 4; i++)
        {
            if(i == (int)turn)
            {
                GUI.color = Color.yellow;
            }
            if(i == 0)
            {
                GUI.backgroundColor = new Color(1.0f, 0.5f, 0.0f, 1.0f);
                //currentStyle.normal.background = MakeTex(boxWidth, boxHeight, new Color(1.0f, 0.5f, 0.0f, 1.0f));
            }
            else if (i == 1)
            {
                GUI.backgroundColor = Color.black;
                //currentStyle.normal.background = MakeTex(boxWidth, boxHeight, Color.black);
            }
            else if(i == 2)
            {
                GUI.backgroundColor = Color.white;
                //currentStyle.normal.background = MakeTex(boxWidth, boxHeight, Color.white);
            }
            else
            {
                GUI.backgroundColor = Color.red;
                //currentStyle.normal.background = MakeTex(boxWidth, boxHeight, Color.red);
            }
            GUI.Button(new Rect(i * (scoredist/ogscreenw) * Screen.width, 0, (boxWidth/ogscreenw) * Screen.width, (boxHeight/ogscreenh) * Screen.height), playerList[i].text); //, currentStyle);
            //Debug.Log("screen width = " + Screen.width);
            //Debug.Log("screen height = " + Screen.height);
            GUI.color = Color.white;
        }
        
    }
    /*
    private void InitStyles()
    {
        if (currentStyle == null)
        {
            currentStyle = new GUIStyle(GUI.skin.box);
        }
    }

    private Texture2D MakeTex(int width, int height, Color col)
    {
        Color[] pix = new Color[width * height];
        for (int i = 0; i < pix.Length; ++i)
        {
            pix[i] = col;
        }
        Texture2D result = new Texture2D(width, height);
        result.SetPixels(pix);
        result.Apply();
        return result;
    }
    */
    // If you left click over the dice then RollTheDice coroutine is started
    public void roll()
    {
        StartCoroutine("RollTheDice");
    }

    private IEnumerator RollTheDice()
    {
        // Variable to contain random dice side number.
        // It needs to be assigned. Let it be 0 initially
        // Debug.Log("DiceRoll");
        int randomDiceSide1 = 0;
        int randomDiceSide2 = 0;
        int randomDiceSideEvent = 0;

        // Final side or value that dice reads in the end of coroutine
        int finalSide1 = 0;
        int finalSide2 = 0;
        int finalSideEvent = 0;

        //when totalRoll is 0, roll has not finished yet
        int totalRoll = 0;
        string eventRoll = "n/a";

        // Loop to switch dice sides ramdomly
        // before final side appears. 20 itterations here.
        for (int i = 0; i <= 20; i++)
        {
            // Pick up random value from 0 to 5 (All inclusive)
            randomDiceSide1 = Random.Range(0, 5);
            randomDiceSide2 = Random.Range(0, 5);
            randomDiceSideEvent = Random.Range(0, 5);

            // Set sprite to upper face of dice from array according to random value
            // rend.sprite = diceSides[randomDiceSide];
            // rend.enabled = false;
            rend1.sprite = diceSides[randomDiceSide1];
            rend1.enabled = true;
            rend2.sprite = diceSides[randomDiceSide2];
            rend2.enabled = true;
            rendEvent.sprite = diceSidesEvent[randomDiceSideEvent];
            rendEvent.enabled = true;
            // rend.enabled = true;

            // Pause before next itteration
            yield return new WaitForSeconds(0.05f);
        }

        // Assigning final side so you can use this value later in your game
        // for player movement for example
        finalSide1 = randomDiceSide1 + 1;
        finalSide2 = randomDiceSide2 + 1;

        totalRoll = finalSide1 + finalSide2;

        switch(randomDiceSideEvent) {
            case 0:
                eventRoll="cloudy";
                break;
            case 1:
                eventRoll="cloudy";
                break;
            case 2:
                eventRoll="moderate";
                break;
            case 3:
                eventRoll="severe";
                break;
            case 4:
                eventRoll="sunny";
                break;
            case 5:
                eventRoll="sunny";
                break;
            default:
                eventRoll="bruh";
                break;
        }

        cpl0.wreckLines(totalRoll, eventRoll);
        // Show final dice value in Console
        
        // Debug.Log("Dice1= "+finalSide1);
        // Debug.Log("Dice2= "+finalSide2);
        // Debug.Log("Total= "+totalRoll);
        // Debug.Log("Event= "+eventRoll);
    }
}