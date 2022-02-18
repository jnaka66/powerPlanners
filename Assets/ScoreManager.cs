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


    List<player> playerList;
    public enum Turn {p1 = 0, p2 = 1, p3 = 2, p4 = 3 };
    public Turn turn;
    int temp = 0;
    int turnCount = 0;

    void Awake()
    {
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
            playerList.Add(new player(i, 0, 0, "Player " + i + "\nVP: " + 0 + "\nMoney: " + 0));
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
        temp++;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void endTurn()
    {
        playerList[(int)turn].VP += temp;
        playerList[(int)turn].text = "Player " + playerList[(int)turn].id + "\nVP: " + playerList[(int)turn].VP + "\nMoney: " + playerList[(int)turn].money;
        temp = 0;
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
        turnCount++;
        Debug.Log("TurnCount= "+turnCount);
        if(turnCount>3){
            // Debug.Log("DiceRoll");
            // dice1.roll();
            roll();
        }
    }

    void OnGUI()
    {
        //Debug.Log("GUI");
        for (int i = 0; i < 4; i++)
        {
            if(i == (int)turn)
            {
                GUI.color = Color.yellow;
            }
            GUI.Box(new Rect(i * 120, 0, 100, 50), playerList[i].text);
            GUI.color = Color.white;
        }
        
    }

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
        // Show final dice value in Console
        Debug.Log("Dice1= "+finalSide1);
        Debug.Log("Dice2= "+finalSide2);
        Debug.Log("Total= "+totalRoll);
        Debug.Log("Event= "+eventRoll);
    }
}