using System.Collections;
using UnityEngine;

public class EventDice : MonoBehaviour {

    // Array of dice sides sprites to load from Resources folder
    // private Sprite[] diceSides1;
    // private Sprite[] diceSides2;
    private Sprite[] diceSidesEvent;

    // Reference to sprite renderer to change sprites
    // private SpriteRenderer rend1;
    // private SpriteRenderer rend2;
    private SpriteRenderer rendEvent;

	// Use this for initialization
	private void Start () {

        // Assign Renderer component
        // rend1 = GetComponent<SpriteRenderer>();
        // rend2 = GetComponent<SpriteRenderer>();
        rendEvent = GetComponent<SpriteRenderer>();


        // Load dice sides sprites to array from DiceSides subfolder of Resources folder
        // diceSides1 = Resources.LoadAll<Sprite>("DiceSides/");
        // diceSides2 = Resources.LoadAll<Sprite>("DiceSides/");
        diceSidesEvent = Resources.LoadAll<Sprite>("EventDiceSides/");
	}
	
    // If you left click over the dice then RollTheDice coroutine is started
    private void OnMouseDown()
    {
        StartCoroutine("RollTheDice");
    }

    // Coroutine that rolls the dice
    private IEnumerator RollTheDice()
    {
        // Variable to contain random dice side number.
        // It needs to be assigned. Let it be 0 initially
        // int randomDiceSide1 = 0;
        // int randomDiceSide2 = 0;
        int randomDiceSideEvent = 0;

        // Final side or value that dice reads in the end of coroutine
        // int finalSide1 = 0;
        // int finalSide2 = 0;
        int finalSideEvent = 0;

        // Loop to switch dice sides ramdomly
        // before final side appears. 20 itterations here.
        for (int i = 0; i <= 20; i++)
        {
            // Pick up random value from 0 to 5 (All inclusive)
            // randomDiceSide1 = Random.Range(0, 5);
            // randomDiceSide2 = Random.Range(0, 5);
            randomDiceSideEvent = Random.Range(0, 5);

            // Set sprite to upper face of dice from array according to random value
            // rend1.sprite = diceSides1[randomDiceSide1];
            // rend2.sprite = diceSides2[randomDiceSide2];
            rendEvent.sprite = diceSidesEvent[randomDiceSideEvent];

            // Pause before next itteration
            yield return new WaitForSeconds(0.05f);
        }

        // Assigning final side so you can use this value later in your game
        // for player movement for example
        // finalSide1 = randomDiceSide1 + 1;
        // finalSide2 = randomDiceSide2 + 1;
        finalSideEvent = randomDiceSideEvent + 1;

        // Show final dice value in Console
        // Debug.Log("Dice1= "+finalSide1);
        // Debug.Log("Dice2= "+finalSide2);
        Debug.Log("DiceEvent= "+finalSideEvent);
    }
}
