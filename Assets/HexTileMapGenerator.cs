
using UnityEngine;
//testing
public class HexTileMapGenerator : MonoBehaviour
{
    public GameObject prefab;
    public GameObject HexTilePrefab;
    int width = 10;
    int height = 9;
    
    float tileXOffset = .89f;
    float tileYOffset = .77f;
    public int idx = 0;
    // Start is called before the first frame update
    void Start()
    {
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

                        //GameObject obj = Instantiate(prefab);
                        //obj.transform.position = new Vector2(x * tileXOffset + 0.45f, y * tileYOffset);
                        //
                        //GameObject obj1 = Instantiate(prefab);
                        //obj1.transform.position = new Vector2(x * tileXOffset+0.2f, y * tileYOffset+0.4f);
                        //obj1.transform.rotation = new Quaternion(1.65f, 1.0f, 0.0f, 0.0f);
                        //
                        //GameObject obj2 = Instantiate(prefab);
                        //obj2.transform.position = new Vector2(x * tileXOffset + 0.2f, y * tileYOffset - 0.4f);
                        //obj2.transform.rotation = new Quaternion(0.5f, 1.0f, 0.0f, 0.0f);



                    }
                    if ((y == 2 || y== 6)&& x > 0 && x < 9)
                    {

                        GameObject TempGo = Instantiate(HexTilePrefab);
                        TempGo.transform.position = new Vector2(x * tileXOffset, y * tileYOffset);
                        SetColor(TempGo);
                        SetTileInfo(TempGo, x, y);
                        SetText(TempGo, x, y, nums);

                        //GameObject obj = Instantiate(prefab);
                        //obj.transform.position = new Vector2(x * tileXOffset + 0.45f, y * tileYOffset);
                        //
                        //GameObject obj1 = Instantiate(prefab);
                        //obj1.transform.position = new Vector2(x * tileXOffset + 0.2f, y * tileYOffset + 0.4f);
                        //obj1.transform.rotation = new Quaternion(1.65f, 1.0f, 0.0f, 0.0f);
                        //
                        //GameObject obj2 = Instantiate(prefab);
                        //obj2.transform.position = new Vector2(x * tileXOffset + 0.2f, y * tileYOffset - 0.4f);
                        //obj2.transform.rotation = new Quaternion(0.5f, 1.0f, 0.0f, 0.0f);
  
                    }
                    if (y == 4)
                    {

                        GameObject TempGo = Instantiate(HexTilePrefab);
                        TempGo.transform.position = new Vector2(x * tileXOffset, y * tileYOffset);
                        SetColor(TempGo);
                        SetTileInfo(TempGo, x, y);
                        SetText(TempGo, x, y, nums);

                        //GameObject obj = Instantiate(prefab);
                        //obj.transform.position = new Vector2(x * tileXOffset + 0.45f, y * tileYOffset);
                        //
                        //GameObject obj1 = Instantiate(prefab);
                        //obj1.transform.position = new Vector2(x * tileXOffset + 0.2f, y * tileYOffset + 0.4f);
                        //obj1.transform.rotation = new Quaternion(1.65f, 1.0f, 0.0f, 0.0f);
                        //
                        //GameObject obj2 = Instantiate(prefab);
                        //obj2.transform.position = new Vector2(x * tileXOffset + 0.2f, y * tileYOffset - 0.4f);
                        //obj2.transform.rotation = new Quaternion(0.5f, 1.0f, 0.0f, 0.0f);

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

                        //GameObject obj = Instantiate(prefab);
                        //obj.transform.position = new Vector2(x * tileXOffset + 0.45f +0.45f, y * tileYOffset);
                        //
                        //GameObject obj1 = Instantiate(prefab);
                        //obj1.transform.position = new Vector2(x * tileXOffset + 0.2f+0.45f, y * tileYOffset + 0.4f);
                        //obj1.transform.rotation = new Quaternion(1.65f, 1.0f, 0.0f, 0.0f);
                        //
                        //GameObject obj2 = Instantiate(prefab);
                        //obj2.transform.position = new Vector2(x * tileXOffset + 0.2f+0.45f, y * tileYOffset - 0.4f);
                        //obj2.transform.rotation = new Quaternion(0.5f, 1.0f, 0.0f, 0.0f);

                    }
                    if ((y == 3 || y == 5) && x < 9)
                    {
                        GameObject TempGo = Instantiate(HexTilePrefab);
                        TempGo.transform.position = new Vector2(x * tileXOffset+tileXOffset/2, y * tileYOffset);
                        SetColor(TempGo);
                        SetTileInfo(TempGo, x, y);
                        SetText(TempGo, x, y, nums);

                        /*GameObject obj = Instantiate(prefab);
                        obj.transform.position = new Vector2(x * tileXOffset + 0.45f+0.45f, y * tileYOffset);

                        GameObject obj1 = Instantiate(prefab);
                        obj1.transform.position = new Vector2(x * tileXOffset + 0.2f+0.45f, y * tileYOffset + 0.4f);
                        obj1.transform.rotation = new Quaternion(1.65f, 1.0f, 0.0f, 0.0f);

                        GameObject obj2 = Instantiate(prefab);
                        obj2.transform.position = new Vector2(x * tileXOffset + 0.2f+0.45f, y * tileYOffset - 0.4f);
                        obj2.transform.rotation = new Quaternion(0.5f, 1.0f, 0.0f, 0.0f);*/


                    }
                }
                
            }
        }
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
        Debug.Log(idx.ToString());
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
        if(idx % 17 == 0)
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

}
