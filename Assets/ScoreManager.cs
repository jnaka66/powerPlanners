using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public TextMeshProUGUI player1Text;
    public TextMeshProUGUI player2Text;
    public TextMeshProUGUI player3Text;
    public TextMeshProUGUI player4Text;

    int p1VP = 0;
    int p1Money = 0;
    int p2VP = 0;
    int p2Money = 0;
    int p3VP = 0;
    int p3Money = 0;
    int p4VP = 0;
    int p4Money = 0;

    private void Awake()
    {
        instance = this;



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
    List<player> playerList;
    public enum Turn {p1 = 0, p2 = 1, p3 = 2, p4 = 3 };
    public Turn turn;
    int temp = 0;

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
<<<<<<< Updated upstream
        player1Text.text = "Player 1\nVP: " + p1VP.ToString() + "\nMoney: " + p1Money.ToString();
        player2Text.text = "Player 2\nVP: " + p2VP.ToString() + "\nMoney: " + p2Money.ToString();
        player3Text.text = "Player 3\nVP: " + p3VP.ToString() + "\nMoney: " + p3Money.ToString();
        player4Text.text = "Player 4\nVP: " + p4VP.ToString() + "\nMoney: " + p4Money.ToString();
=======
        turn = Turn.p1;
>>>>>>> Stashed changes
        playerList = new List<player>();
        for (int i = 1; i < 5; i++)
        {
            playerList.Add(new player(i, 0, 0, "Player " + i + "\nVP: " + 0 + "\nMoney: " + 0));
        }

    }

    public void AddPoint()
    {

        p1VP += 1;
        player1Text.text = "Player 1\nVP: " + p1VP.ToString() + "\nMoney: " + p1Money.ToString();

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
}
