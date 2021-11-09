using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class hexButtonGenerator : MonoBehaviour
{
    public GameObject prefabButton;
    public RectTransform ParentPanel;
    public GameObject powerPlant;
    int width = 10;
    int height = 9;

    int bottomLeftX = -225;
    int bottomLeftY = -195;
    float canvasTileXOffset = 50;
    float canvasTileYOffset = 21.5f;
    float tileXOffset = .89f;
    float tileYOffset = .77f;

    void Start()
    {
        createButtons();
    }

    void createButtons()
    {
        for (int y = 0; y < height *2; y++)
        {
            for (int x = 0; x < width; x++)
            {
                if (y % 4 == 0)//even rows
                {
                    if ((y == 0 || y ==16)&& x<width-2 && x>1)
                    {
                        makeButton(x, y);
                    }
                    if ((y == 4 || y == 12) && x < width - 1 && x > 0)
                    {
                        makeButton(x, y);
                    }
                    if (y == 8)
                    {
                        makeButton(x, y);
                    }
                }
            }
        }
        
    }
    void ButtonClicked(Button tempButton, string buttonNo,int x, int y)
    {
        Debug.Log("Button clicked = " + buttonNo);

        GameObject TempGo = Instantiate(powerPlant);
        TempGo.transform.position = new Vector2(x * tileXOffset,y * tileYOffset/2 -.5f);
        var ren = TempGo.GetComponent<SpriteRenderer>();
        ren.enabled = true;

        tempButton.gameObject.SetActive(false);
        //var ren1 = tempButton.gameObject.GetComponent<Renderer>();
        //ren1.enabled = false;

    }
    void makeButton(int x, int y)
    {
        GameObject goButton = (GameObject)Instantiate(prefabButton);
        goButton.transform.SetParent(ParentPanel, false);
        goButton.transform.localScale = new Vector3(1, 1, 1);

        Button tempButton = goButton.GetComponent<Button>();
        tempButton.gameObject.SetActive(true);
        string location = (bottomLeftX + x * tileXOffset).ToString() +","+ (bottomLeftY + y * tileYOffset).ToString();

        tempButton.onClick.AddListener(() => ButtonClicked(tempButton,location, x ,y));

        RectTransform rectTransform = goButton.GetComponent<RectTransform>();
        Vector2 anchoredPos = new Vector2(bottomLeftX + x * canvasTileXOffset, bottomLeftY + y * canvasTileYOffset);
        rectTransform.anchoredPosition = anchoredPos;
    }
}
