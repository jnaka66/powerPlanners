using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ScoreManager : MonoBehaviour
{   
    struct player
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

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            playerList.Add(new player(i, 0, 0, "Player " + i + "\nVP: " + 0 + "\nMoney: " + 0));
        }
    }

    void AddPoint()
    {
        player p = playerList[(int)turn];
        p.VP += 1;
        p.text = "Player " + p.id + "\nVP: " + p.VP + "\nMoney: " + p.money;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnGUI()
    {
        for (int i = 0; i < 3; i++)
        {
            GUI.Box(new Rect(0, 0, 100, 100), playerList[i].text);
        }
        
    }
}
