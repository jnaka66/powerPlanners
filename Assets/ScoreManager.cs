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

    List<player> playerList;
    enum Turn {p1 = 0, p2 = 1, p3 = 2, p4 = 3 };
    Turn turn = Turn.p1;
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
        playerList = new List<player>();
        for (int i = 1; i < 5; i++)
        {
            playerList.Add(new player(i, 0, 0, "Player " + i + "\nVP: " + 0 + "\nMoney: " + 0));
        }
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
