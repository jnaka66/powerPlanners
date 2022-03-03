
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class HexTileMapGenerator : MonoBehaviour
{
    public GameObject HexTilePrefab;
    public GameObject city;
    public List<Vector2> built = new List<Vector2>();
    List<Vector2> buildCoords = new List<Vector2>();
    public List<Vector3> buildCoal = new List<Vector3>();
    public List<Vector3> buildNatural = new List<Vector3>();
    public List<Vector3> buildNuclear = new List<Vector3>();
    public List<Vector3> buildSolar = new List<Vector3>();

    int width = 10;
    int height = 9;

    float tileXOffset = .89f;
    float tileYOffset = .77f;
    float canvasTileXOffset = 50;
    float canvasTileYOffset = 21.5f;

    public int idx = 0;
    List<int> randomList = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        initCoordinates();
        CreateHexTileMap();
        
    }

    // Update is called once per frame
    void CreateHexTileMap()
    {
        string[] nums = new string[] { "2","2","2","2",
                                       "3","3","3","3","3",
                                       "4","4","4","4","4","4",
                                       "5","5","5","5","5","5","5",
                                       "6","6","6","6","6","6","6","6",
                                       "7","7","7","7","7","7","7","7","7","7",
                                       "8","8","8","8","8","8","8","8",
                                       "9","9","9","9","9","9","9",
                                       "10","10","10","10","10","10",
                                       "11","11","11","11","11",
                                       "12","12","12","12"
        };
        Shuffle(nums);
        //water tiles rng
        var a = new System.Random(); // replace from new Random(DateTime.Now.Ticks.GetHashCode());
                                // Since similar code is done in default constructor internally
        //List<int> randomList = new List<int>();
        int MyNumber = 0;
        for (int i = 0; i < 6; i++){
            MyNumber = a.Next(0, 69);
            while(randomList.Contains(MyNumber))
                MyNumber = a.Next(0, 69);
            randomList.Add(MyNumber);
            //Debug.Log("water "+ MyNumber);
        }
        
        for (int x = 0; x < width; x++)
        {
            for(int y = 0; y < height; y++)
            {
                
                if (y % 2 == 0)//even rows
                {
                    if((y==0 || y==8)&& x>1 && x < 8)
                    {
                        GameObject TempGo = Instantiate(HexTilePrefab);
                        TempGo.transform.position = new Vector2(x * tileXOffset, y * tileYOffset);
                        SetColor(TempGo);
                        SetTileInfo(TempGo, x, y);
                        SetText(TempGo, x, y,nums);

                        
                    }
                    if ((y == 2 || y== 6)&& x > 0 && x < 9)
                    {
                        GameObject TempGo = Instantiate(HexTilePrefab);
                        TempGo.transform.position = new Vector2(x * tileXOffset, y * tileYOffset);
                        SetColor(TempGo);
                        SetTileInfo(TempGo, x, y);
                        SetText(TempGo, x, y, nums);
                    }
                    if (y == 4)
                    {
                        GameObject TempGo = Instantiate(HexTilePrefab);
                        TempGo.transform.position = new Vector2(x * tileXOffset, y * tileYOffset);
                        SetColor(TempGo);
                        SetTileInfo(TempGo, x, y);
                        SetText(TempGo, x, y, nums);
                    }

                }
                else
                {
                    if ((y == 1 || y == 7) && x > 0 & x < 8)
                    {
                        GameObject TempGo = Instantiate(HexTilePrefab);
                        TempGo.transform.position = new Vector2(x * tileXOffset+tileXOffset/2, y * tileYOffset);
                        SetColor(TempGo);
                        SetTileInfo(TempGo, x, y);
                        SetText(TempGo, x, y, nums);
                    }
                    if ((y == 3 || y == 5) && x < 9)
                    {
                        GameObject TempGo = Instantiate(HexTilePrefab);
                        TempGo.transform.position = new Vector2(x * tileXOffset+tileXOffset/2, y * tileYOffset);
                        SetColor(TempGo);
                        SetTileInfo(TempGo, x, y);
                        SetText(TempGo, x, y, nums);
                    }
                }
                
            }
        }
        //now make random cities
        for (int i = 0; i < 6; i++){//6 cities x
            MyNumber = a.Next(0, buildCoords.Count);
            //Debug.Log(MyNumber);
            Vector2 buildAt = buildCoords[MyNumber];
            built.Add(buildAt);
            float x = buildAt[0];
            float y = buildAt[1];
            GameObject TempGo = Instantiate(city);
            TempGo.AddComponent<BoxCollider>();
            TempGo.AddComponent<onHoverScript>();
            var hover = TempGo.GetComponent<onHoverScript>();
            hover.location = new Vector2(x,y);
            TempGo.transform.position = new Vector2(x * tileXOffset,y * tileYOffset/2 -.5f);
            var ren = TempGo.GetComponent<SpriteRenderer>();
            TempGo.AddComponent<BoxCollider>();
            TempGo.AddComponent<onHoverScript>();
            var hover = TempGo.GetComponent<onHoverScript>();
            hover.location = new Vector2(x,y);
            hover.objType = "Town";
            hover.demand = Random.Range(50,125);
            ren.enabled = true;
        }
        /*
        List<int> xCoordRandomList = new List<int>();
        List<int> yCoordRandomList = new List<int>();
        for (int i = 0; i < 6; i++){//6 cities x
            MyNumber = a.Next(0, width);
            while(xCoordRandomList.Contains(MyNumber))
                MyNumber = a.Next(0, width);
            xCoordRandomList.Add(MyNumber);
            //Debug.Log("water "+ MyNumber);
        }
        for (int i = 0; i < 6; i++){//6 cities y
            MyNumber = a.Next(0, height);
            while(yCoordRandomList.Contains(MyNumber))
                MyNumber = a.Next(0, height);
            yCoordRandomList.Add(MyNumber);
            //Debug.Log("water "+ MyNumber);
        }
        //now place cities
        for (int i = 0; i < 6; i++){
            int x=xCoordRandomList[i];
            int y=yCoordRandomList[i];
            built.Add(new Vector2(x, y));

            GameObject TempGo = Instantiate(city);
            TempGo.transform.position = new Vector2(x * tileXOffset,y * tileYOffset/2 -.5f);
            var ren = TempGo.GetComponent<SpriteRenderer>();
            ren.enabled = true;
        }*/
    }
    void SetTileInfo(GameObject go, int x, int y)
    {
        go.transform.parent = transform;
        go.name = x.ToString() + "," + y.ToString();
        
    }
    void SetText(GameObject go, int x, int y, string[] nums)
    {
        
        GameObject childObj = new GameObject();
        childObj.transform.parent = go.transform;
        childObj.name = "Text Holder";

        //Create TextMesh and modify its properties
        TextMesh textMesh = childObj.AddComponent<TextMesh>();
        //Debug.Log(idx.ToString());
        
        
        textMesh.text = nums[idx];
        
        
        idx++;
        textMesh.characterSize = .2f;

        //Set postion of the TextMesh with offset
        textMesh.anchor = TextAnchor.MiddleCenter;
        textMesh.alignment = TextAlignment.Center;
        textMesh.color = Color.red;
        if (y % 2 == 0)
        {
            textMesh.transform.position = new Vector2(x * tileXOffset, y * tileYOffset);
        }
        else
        {
            textMesh.transform.position = new Vector2(x * tileXOffset + tileXOffset / 2, y * tileYOffset);
        }
           
    }
    void SetColor(GameObject go)
    {
        int r = Random.Range(0, 3);
        var render = go.GetComponent<Renderer>();
        //randomList.Contains(MyNumber)
        if(randomList.Contains(idx))
        {
            render.material.SetColor("_Color", Color.blue);
        }
        else if (r == 0)
        {
            render.material.SetColor("_Color", Color.green);
        }
        else if (r == 1)
        {
            render.material.SetColor("_Color", Color.gray);
        }
        else if (r == 2)
        {
            render.material.SetColor("_Color", Color.yellow);
        }

    }
    public void Shuffle(string[] nums)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            int rnd = Random.Range(0, nums.Length);
            string temp = nums[rnd];
            nums[rnd] = nums[i];
            nums[i] = temp;
        }
    }
    public void updateBuilt(float x, float y)
    {
        built.Add(new Vector2(x, y));        
    }
    public List<Vector2> getBuilt()
    {
        return built;      
    }
    //this is really bad but i didnt have a differnt way of doing it
    //this is getting the coordinates of all of the building placement options
    //built.Add(new Vector2(x, y));
    public void initCoordinates(){
        for (int y = 0; y < height *2; y++)
        {
            for (int x = 0; x < width; x++)
            {
                if (y == 0 && x<width-2 && x>1)
                {
                    buildCoords.Add(new Vector2(x, y));//bottom
                    buildCoords.Add(new Vector2(x, y+2.5f));//top
                    buildCoords.Add(new Vector2(x-.5f, y + .5f));//bot left
                    buildCoords.Add(new Vector2(x - .5f, y + 2));//top left
                    if (x == 2)//special case on left side
                    {
                        buildCoords.Add(new Vector2(x-1, y + 2.5f));
                    }
                    if (x == width - 3)//special case on right side
                    {
                        buildCoords.Add(new Vector2(x + .5f, y + .5f));
                        buildCoords.Add(new Vector2(x + .5f, y + 2));
                        buildCoords.Add(new Vector2(x + 1, y + 2.5f));
                    }
                }

                else if(y == 4  && x < width-1 && x > 0)

                {
                    buildCoords.Add(new Vector2(x, y));
                    buildCoords.Add(new Vector2(x, y + 2.5f));
                    buildCoords.Add(new Vector2(x - .5f, y + .5f));//bot left
                    buildCoords.Add(new Vector2(x - .5f, y + 2));//top left
                    if (x == 1)//special case on left side
                    {
                        buildCoords.Add(new Vector2(x - 1, y + 2.5f));
                    }
                    if (x == width - 2)//special case on right side
                    {
                        buildCoords.Add(new Vector2(x + .5f, y + .5f));
                        buildCoords.Add(new Vector2(x + .5f, y + 2));
                        buildCoords.Add(new Vector2(x + 1, y + 2.5f));
                    }
                }
                else if(y == 8)


                {
                    buildCoords.Add(new Vector2(x, y));
                    buildCoords.Add(new Vector2(x, y + 2.5f));
                    buildCoords.Add(new Vector2(x - .5f, y + .5f));//bot left
                    buildCoords.Add(new Vector2(x - .5f, y + 2));//top left
                    if (x == 1)//special case on left side
                    {
                        buildCoords.Add(new Vector2(x - 1, y + 4));
                    }
                    if (x == width - 1)//special case on right side
                    {
                        buildCoords.Add(new Vector2(x + .5f, y + .5f));
                        buildCoords.Add(new Vector2(x + .5f, y + 2));
                    }
                }

                else if(y == 12 && x < width - 1 && x > 0)
                {
                    buildCoords.Add(new Vector2(x, y));
                    buildCoords.Add(new Vector2(x, y + 2.5f));
                    buildCoords.Add(new Vector2(x - .5f, y + .5f));//bot left
                    buildCoords.Add(new Vector2(x - .5f, y + 2));//top left
                    if (x == width - 2)//special case on right side
                    {
                        buildCoords.Add(new Vector2(x + .5f, y + .5f));
                        buildCoords.Add(new Vector2(x + .5f, y + 2));
                        buildCoords.Add(new Vector2(x + 1, y));
                    }
                }
                else if (y == 16 && x < width - 2 && x > 1)

                {
                    buildCoords.Add(new Vector2(x, y));
                    buildCoords.Add(new Vector2(x, y + 2.5f));
                    buildCoords.Add(new Vector2(x - .5f, y + .5f));//bot left
                    buildCoords.Add(new Vector2(x - .5f, y + 2));//top left
                    if (x == 2)//special case on left side
                    {
                        buildCoords.Add(new Vector2(x - 1, y));
                    }
                    if (x == width - 3)//special case on right side
                    {
                        buildCoords.Add(new Vector2(x + .5f, y + .5f));
                        buildCoords.Add(new Vector2(x + .5f, y + 2));
                        buildCoords.Add(new Vector2(x + 1, y));
                    }
                }
            }
        }
    }
    
}
