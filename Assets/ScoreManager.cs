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
    }

    // Start is called before the first frame update
    void Start()
    {
        player1Text.text = "Player 1\nVP: " + p1VP.ToString() + "\nMoney: " + p1Money.ToString();
        player2Text.text = "Player 2\nVP: " + p2VP.ToString() + "\nMoney: " + p2Money.ToString();
        player3Text.text = "Player 3\nVP: " + p3VP.ToString() + "\nMoney: " + p3Money.ToString();
        player4Text.text = "Player 4\nVP: " + p4VP.ToString() + "\nMoney: " + p4Money.ToString();
    }

    public void AddPoint()
    {
        p1VP += 1;
        player1Text.text = "Player 1\nVP: " + p1VP.ToString() + "\nMoney: " + p1Money.ToString();
    }
}
