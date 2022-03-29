using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class createPowerPlantButtons : MonoBehaviour
{
    public GameObject prefabButton;
    public RectTransform ParentPanel;
    public HexTileMapGenerator mapGen;
    public GameObject player1PowerPlant;
    public GameObject player2PowerPlant;
    public GameObject player3PowerPlant;
    public GameObject player4PowerPlant;
    public ScoreManager scoreMan;
    //format for each entry is <x,y,playerNum>
    public List<Vector3> builtCoal = new List<Vector3>();
    public List<Vector3> builtNatural = new List<Vector3>();
    public List<Vector3> builtNuclear = new List<Vector3>();
    public List<Vector3> builtSolar = new List<Vector3>();
    public string plantType;
    public string upgradeOrBuild;

    //private List<Vector2> built;
    int width = 10;
    int height = 9;

    int bottomLeftX = -225;
    int bottomLeftY = -195;
    float canvasTileXOffset = 50;
    float canvasTileYOffset = 21.5f;
    float tileXOffset = .89f;
    float tileYOffset = .77f;
    int numOfButtons = 0;


    

    void Awake()
    {
        mapGen = GameObject.FindObjectOfType<HexTileMapGenerator>();
        scoreMan = GameObject.FindObjectOfType<ScoreManager>();
        builtCoal=mapGen.buildCoal;
        builtSolar=mapGen.buildSolar;
        builtNuclear=mapGen.buildNuclear;
        builtNatural=mapGen.buildNatural;
    }

    bool buildSelected = false;

    public void spawnButtons() {
        createButtons();
        /*
        if(!buildSelected) {
            createButtons();
            //Debug.Log("num"+numOfButtons);
            buildSelected = true;
        }
        else {
            deleteButtons();
            buildSelected = false;
        }*/
    }

    public void deleteButtons() {
        while(GameObject.Find("Button(Clone)") != null){
            buttontest = GameObject.Find("Button(Clone)");
            buttontest.gameObject.SetActive(false);
        }
        /*
        for(int i =0; i < numOfButtons; i++) {
            buttontest = GameObject.Find("Button(Clone)");
            buttontest.gameObject.SetActive(false);//I tried implementing Destroy() but wasnt working for some reason
        }
        */
        GameObject coal;
        GameObject solar;
        GameObject natty;  
        GameObject nuke; 

        if(upgradeOrBuild == "Build"){
            solar = GameObject.Find("buildSolarButton");
            coal = GameObject.Find("buildCoalButton");
            natty = GameObject.Find("buildNaturalButton");
            nuke = GameObject.Find("buildNuclearButton");
        }
        else{
            solar = GameObject.Find("upgradeSolarButton");
            coal = GameObject.Find("upgradeCoalButton");
            natty = GameObject.Find("upgradeNaturalButton");
            nuke = GameObject.Find("upgradeNuclearButton");
        }
        
        solar.gameObject.SetActive(false);
        coal.gameObject.SetActive(false);
        natty.gameObject.SetActive(false);
        nuke.gameObject.SetActive(false);

        numOfButtons = 0;
    }

    void createButtons()
    {
        for (int y = 0; y < height *2; y++)
        {
            for (int x = 0; x < width; x++)
            {
                if (y == 0 && x<width-2 && x>1)
                {
                    makeButton(x, y);//bottom
                    makeButton(x, y+2.5f);//top
                    makeButton(x-.5f, y + .5f);//bot left
                    makeButton(x - .5f, y + 2);//top left
                    if (x == 2)//special case on left side
                    {
                        makeButton(x-1, y + 2.5f);
                    }
                    if (x == width - 3)//special case on right side
                    {
                        makeButton(x + .5f, y + .5f);
                        makeButton(x + .5f, y + 2);
                        makeButton(x + 1, y + 2.5f);
                    }
                }

                else if(y == 4  && x < width-1 && x > 0)

                {
                    makeButton(x, y);
                    makeButton(x, y + 2.5f);
                    makeButton(x - .5f, y + .5f);//bot left
                    makeButton(x - .5f, y + 2);//top left
                    if (x == 1)//special case on left side
                    {
                        makeButton(x - 1, y + 2.5f);
                    }
                    if (x == width - 2)//special case on right side
                    {
                        makeButton(x + .5f, y + .5f);
                        makeButton(x + .5f, y + 2);
                        makeButton(x + 1, y + 2.5f);
                    }
                }
                else if(y == 8)


                {
                    makeButton(x, y);
                    makeButton(x, y + 2.5f);
                    makeButton(x - .5f, y + .5f);//bot left
                    makeButton(x - .5f, y + 2);//top left
                    if (x == 1)//special case on left side
                    {
                        makeButton(x - 1, y + 4);
                    }
                    if (x == width - 1)//special case on right side
                    {
                        makeButton(x + .5f, y + .5f);
                        makeButton(x + .5f, y + 2);
                    }
                }

                else if(y == 12 && x < width - 1 && x > 0)
                {
                    makeButton(x, y);
                    makeButton(x, y + 2.5f);
                    makeButton(x - .5f, y + .5f);//bot left
                    makeButton(x - .5f, y + 2);//top left
                    if (x == width - 2)//special case on right side
                    {
                        makeButton(x + .5f, y + .5f);
                        makeButton(x + .5f, y + 2);
                        makeButton(x + 1, y);
                    }
                }
                else if (y == 16 && x < width - 2 && x > 1)

                {
                    makeButton(x, y);
                    makeButton(x, y + 2.5f);
                    makeButton(x - .5f, y + .5f);//bot left
                    makeButton(x - .5f, y + 2);//top left
                    if (x == 2)//special case on left side
                    {
                        makeButton(x - 1, y);
                    }
                    if (x == width - 3)//special case on right side
                    {
                        makeButton(x + .5f, y + .5f);
                        makeButton(x + .5f, y + 2);
                        makeButton(x + 1, y);
                    }
                }

            }
        }
        
    }
    public GameObject buttontest;
    void ButtonClicked(Button tempButton, string buttonNo,float x, float y)
    {
        
        //Debug.Log("turn= ", (int)scoreMan.turn);
        //built.Add(new Vector2(x, y));
        string ownedType = determineOwned(x,y);
        int c= determineCost(determineOwned(x,y),plantType);
        if(scoreMan.buildPlant(plantType,c))
        {
            mapGen.updateBuilt(x,y);
            makePowerPlant((int)scoreMan.turn,x,y,ownedType);
            //Debug.Log("x val " + x);
            //Debug.Log("y val " + y);
        }
        else
        {
            Debug.Log("Not enough money");
        }
        
        

        // tempButton.gameObject.SetActive(false);
        deleteButtons();
        buildSelected = false;
        // buttontest = GameObject.Find("Button(Clone)");
        // buttontest.gameObject.SetActive(false);
        //var ren1 = tempButton.gameObject.GetComponent<Renderer>();
        //ren1.enabled = false;


    }
    void makePowerPlant(int playerTurn,float x ,float y,string ownedType){
        GameObject plant = new GameObject();
        if(playerTurn==0){
            plant = player1PowerPlant;
        }
        if(playerTurn==1){
            plant = player2PowerPlant;
        }
        if(playerTurn==2){
            plant = player3PowerPlant;
        }
        if(playerTurn==3){
            plant = player4PowerPlant;
        }
        if(plantType=="coal"){
            builtCoal.Add(new Vector3(x,y,playerTurn));
        }
        if(plantType=="natural"){
            builtNatural.Add(new Vector3(x,y,playerTurn));
        }
        if(plantType=="nuclear"){
            builtNuclear.Add(new Vector3(x,y,playerTurn));
        }
        if(plantType=="solar"){
            builtSolar.Add(new Vector3(x,y,playerTurn));
        }
        if(ownedType !=""){
            string plantRemove =ownedType+"Plant"+(playerTurn+1)+" "+x+","+y;
            //Debug.Log(plantRemove);
            GameObject plantToDestroy = GameObject.Find(plantRemove);
            GameObject idkwhy = GameObject.Find(plantRemove+"(Clone)");
            GameObject.Destroy(plantToDestroy);
            GameObject.Destroy(idkwhy);
            if(ownedType == "coal"){
                builtCoal.Remove(new Vector3(x,y,playerTurn));
            }
            if(ownedType == "solar"){
                builtSolar.Remove(new Vector3(x,y,playerTurn));
            }
            if(ownedType == "nuclear"){
                builtNuclear.Remove(new Vector3(x,y,playerTurn));
            }
            if(ownedType == "natural"){
                builtNatural.Remove(new Vector3(x,y,playerTurn));
            }
        }
        //Debug.Log(plantType+ " built by "+(int)scoreMan.turn+ " at "+x+","+y);
        GameObject TempGo = Instantiate(plant);
        TempGo.name = plantType+"Plant"+(playerTurn+1)+" "+x+","+y;
        TempGo.transform.position = new Vector2(x * tileXOffset,y * tileYOffset/2 -.5f);
        var ren = TempGo.GetComponent<SpriteRenderer>();
        ren.sortingOrder = 2;
        ren.enabled = true;
        if(upgradeOrBuild == "Build"){
            ScoreManager.instance.AddPoint();
        }
        //hovering section
        TempGo.AddComponent<BoxCollider>();
        TempGo.AddComponent<onHoverScript>();
        var hover = TempGo.GetComponent<onHoverScript>();
        hover.location = new Vector2(x,y);//pass the location
        hover.objType = plantType;//and type
        hover.parent = TempGo;
    }


    void makeButton(float x, float y)
    {
        //determine owned returns the type if owned, "" if unowned
        //plantType is the type trying to build

        //allow owned locations
        bool owned = !(determineOwned(x,y)=="");
        int costButton = determineCost(determineOwned(x,y),plantType);
        if(upgradeOrBuild == "Upgrade"){
            if(owned){
                GameObject goButton = (GameObject)Instantiate(prefabButton);
                //goButton.name = "upgradeButton_" +x+"_"+y;
                goButton.transform.SetParent(ParentPanel, false);
                goButton.transform.localScale = new Vector3(1, 1, 1);

                Button tempButton = goButton.GetComponent<Button>();
                //tempButton.name = "upgradeButton_" +x+"_"+y;
                tempButton.gameObject.SetActive(true);
                string location = (bottomLeftX + x * tileXOffset).ToString() + "," + (bottomLeftY + y * tileYOffset).ToString();

                tempButton.onClick.AddListener(() => ButtonClicked(tempButton, location, x, y));

                RectTransform rectTransform = goButton.GetComponent<RectTransform>();
                Vector2 anchoredPos = new Vector2(bottomLeftX + x * canvasTileXOffset, bottomLeftY + y * canvasTileYOffset);
                rectTransform.anchoredPosition = anchoredPos;

                //hover section
                goButton.AddComponent<BoxCollider>();
                goButton.AddComponent<showCostHover>();
                var hover = goButton.GetComponent<showCostHover>();
                hover.location = new Vector2(x,y);//pass the location
                hover.objType = plantType;//and type
                hover.parent = goButton;

                
                hover.cost = costButton;
            }
        }
        
        else if (!mapGen.getBuilt().Contains(new Vector2(x, y)))
        {
            
            GameObject goButton = (GameObject)Instantiate(prefabButton);
            //goButton.name = "buildButton_" +x+"_"+y;
            goButton.transform.SetParent(ParentPanel, false);
            goButton.transform.localScale = new Vector3(1, 1, 1);

            Button tempButton = goButton.GetComponent<Button>();
            //tempButton.name = "buildButton_" +x+"_"+y;
            tempButton.gameObject.SetActive(true);
            string location = (bottomLeftX + x * tileXOffset).ToString() + "," + (bottomLeftY + y * tileYOffset).ToString();

            tempButton.onClick.AddListener(() => ButtonClicked(tempButton, location, x, y));

            RectTransform rectTransform = goButton.GetComponent<RectTransform>();
            Vector2 anchoredPos = new Vector2(bottomLeftX + x * canvasTileXOffset, bottomLeftY + y * canvasTileYOffset);
            rectTransform.anchoredPosition = anchoredPos;
            //hover 
            goButton.AddComponent<BoxCollider>();
            goButton.AddComponent<showCostHover>();
            var hover = goButton.GetComponent<showCostHover>();
            hover.location = new Vector2(x,y);//pass the location
            hover.objType = plantType;//and type
            hover.parent = goButton;
            hover.cost = costButton;
        }

    }
    int determineCost(string ownedType,string buildType){
        int coalCost = 50;
        int solarCost = 100;
        int naturalCost = 150;
        int nuclearCost=200;
        //build plant
        if(ownedType==""){
            if(buildType=="coal") return coalCost;
            if(buildType=="solar") return solarCost;
            if(buildType=="natural") return naturalCost;
            if(buildType=="nuclear") return nuclearCost;
        }
        //upgrades
        if(ownedType=="coal"){
            if(buildType=="coal") return coalCost-coalCost;
            if(buildType=="solar") return solarCost-coalCost;
            if(buildType=="natural") return naturalCost-coalCost;
            if(buildType=="nuclear") return nuclearCost-coalCost;
        }
        if(ownedType=="solar"){
            if(buildType=="coal") return coalCost-solarCost;
            if(buildType=="solar") return solarCost-solarCost;
            if(buildType=="natural") return naturalCost-solarCost;
            if(buildType=="nuclear") return nuclearCost-solarCost;
        }
        if(ownedType=="natural"){
            if(buildType=="coal") return coalCost-naturalCost;
            if(buildType=="solar") return solarCost-naturalCost;
            if(buildType=="natural") return naturalCost-naturalCost;
            if(buildType=="nuclear") return nuclearCost-naturalCost;
        }
        if(ownedType=="nuclear"){
            if(buildType=="coal") return coalCost-nuclearCost;
            if(buildType=="solar") return solarCost-nuclearCost;
            if(buildType=="natural") return naturalCost-nuclearCost;
            if(buildType=="nuclear") return nuclearCost-nuclearCost;
        }
        
        return 69;
    }
    //dont look below here
    string determineOwned(float x, float y){
        //Debug.Log("checking if "+ (int)scoreMan.turn + "owns"+x+","+y +" type is "+plantType);
        if(plantType == "coal"){
            for(int i=0;i<builtSolar.Count; i++){
                if(builtSolar[i] == new Vector3(x,y,(int)scoreMan.turn)) return "solar";
            }
            for(int i=0;i<builtNuclear.Count; i++){
                if(builtNuclear[i] == new Vector3(x,y,(int)scoreMan.turn)) return "nuclear";
            }
            for(int i=0;i<builtNatural.Count; i++){
                if(builtNatural[i] == new Vector3(x,y,(int)scoreMan.turn)) return "natural";
            }
            return "";
        }
        if(plantType == "solar"){
            for(int i=0;i<builtCoal.Count; i++){
                Debug.Log(builtCoal[i]);
                if(builtCoal[i] == new Vector3(x,y,(int)scoreMan.turn)) return "coal";
            }
            for(int i=0;i<builtNuclear.Count; i++){
                if(builtNuclear[i] == new Vector3(x,y,(int)scoreMan.turn)) return "nuclear";
            }
            for(int i=0;i<builtNatural.Count; i++){
                if(builtNatural[i] == new Vector3(x,y,(int)scoreMan.turn)) return "natural";
            }
            return "";
        }
        if(plantType == "nuclear"){
            for(int i=0;i<builtSolar.Count; i++){
                if(builtSolar[i] == new Vector3(x,y,(int)scoreMan.turn)) return "solar";
            }
            for(int i=0;i<builtCoal.Count; i++){
                if(builtCoal[i] == new Vector3(x,y,(int)scoreMan.turn)) return "coal";
            }
            for(int i=0;i<builtNatural.Count; i++){
                if(builtNatural[i] == new Vector3(x,y,(int)scoreMan.turn)) return "natural";
            }
            return "";
        }
        if(plantType == "natural"){
            for(int i=0;i<builtSolar.Count; i++){
                if(builtSolar[i] == new Vector3(x,y,(int)scoreMan.turn)) return "solar";
            }
            for(int i=0;i<builtNuclear.Count; i++){
                if(builtNuclear[i] == new Vector3(x,y,(int)scoreMan.turn)) return "nuclear";
            }
            for(int i=0;i<builtCoal.Count; i++){
                if(builtCoal[i] == new Vector3(x,y,(int)scoreMan.turn)) return "coal";
            }
            return "";
        }
        return "";
    }
}
