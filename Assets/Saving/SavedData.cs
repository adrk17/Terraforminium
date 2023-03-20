using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SavedData : MonoBehaviour
{
    public static int loadUpgradeLevel;
    public static float loadTitaniumUpgradeLevel;
    public static int loadOnClickV;
    public List<GameObject> titaniumButtons;
    public List<GameObject> levelUpButtons;
    public List<GameObject> levelSwitchButtons;
    public GameObject clickerButton;
    public List<Sprite> miningUpgradeSprites;
    public Sprite terramars;
    public GameObject backgroundLv3;
    public static List<int> loadHowManySpawnedObjects = new List<int>();
    public GameObject spawnManagerObj;
    public List<int> achievementBools = new List<int>();
    public List<GameObject> achievementObj;
    public GameObject loadGamePanel;

    private float timer;
    private void Start()
    {
        if (PlayerPrefs.HasKey("energy") && PlayerPrefs.HasKey("howMany[0]") && PlayerPrefs.HasKey("currentLevel") && PlayerPrefs.HasKey("mainTimer") && PlayerPrefs.HasKey("achievementBools[0]"))
        {
            loadGamePanel.SetActive(true);
        }
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 60f)
        {
            SaveGame();
            timer = 0f;
        }
        /*
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SaveClicker();
            SaveUpgrades();
            SaveSpawn();
            SaveStats();
            SaveAchievement();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadClicker();
            LoadUpgrades();
            LoadSpawn();
            LoadStats();
            LoadAchievement();
        }
        */
    }

    public void SaveGame()
    {
        SaveClicker();
        SaveUpgrades();
        SaveSpawn();
        SaveStats();
        SaveAchievement();
        print("Saving");
    }
    public void LoadGame()
    {
        LoadClicker();
        LoadUpgrades();
        LoadSpawn();
        LoadStats();
        LoadAchievement();
        print("Loading");
    }
    public void DeleteSave()
    {
        PlayerPrefs.DeleteAll();
        print("save deleted");
    }
    void SaveSpawn()
    {
        PlayerPrefs.SetInt("howMany[0]", Spawn.howManySpawnedObjects[0]);
        PlayerPrefs.SetInt("howMany[1]", Spawn.howManySpawnedObjects[1]);
        PlayerPrefs.SetInt("howMany[2]", Spawn.howManySpawnedObjects[2]);
        PlayerPrefs.SetInt("howMany[3]", Spawn.howManySpawnedObjects[3]);
        PlayerPrefs.SetInt("howMany[4]", Spawn.howManySpawnedObjects[4]);
        PlayerPrefs.SetInt("howMany[5]", Spawn.howManySpawnedObjects[5]);
        PlayerPrefs.SetInt("howMany[6]", Spawn.howManySpawnedObjects[6]);
        PlayerPrefs.SetInt("howMany[7]", Spawn.howManySpawnedObjects[7]);
        PlayerPrefs.SetInt("howMany[8]", Spawn.howManySpawnedObjects[8]);
    }
    void SaveUpgrades()
    {
        PlayerPrefs.SetInt("currentLevel", Upgrades.levelTracker);
        PlayerPrefs.SetFloat("energyPerSec", Upgrades.addEnergyPerSecond);
        PlayerPrefs.SetFloat("titaniumPerSec", Upgrades.addTitanium);
    }
    void SaveClicker()
    {
        PlayerPrefs.SetFloat("energy", Clicker.currentEnergy);
        PlayerPrefs.SetFloat("titanium", Clicker.currentTitanium);
        PlayerPrefs.SetInt("totalC", Clicker.totalClicks);
        PlayerPrefs.SetInt("onClickV", Clicker.onClickValue);
    }
    void SaveStats()
    {
        PlayerPrefs.SetFloat("mainTimer", Stats.timer);
    }

    void SaveAchievement()
    {
        PlayerPrefs.SetInt("achievementBools[0]",Achievement.activatedACSP.GetHashCode());
        PlayerPrefs.SetInt("achievementBools[1]", Achievement.activatedEB.GetHashCode());
        PlayerPrefs.SetInt("achievementBools[2]", Achievement.activatedEMT.GetHashCode());
        PlayerPrefs.SetInt("achievementBools[3]", Achievement.activatedH1.GetHashCode());
        PlayerPrefs.SetInt("achievementBools[4]", Achievement.activatedLv1.GetHashCode());
        PlayerPrefs.SetInt("achievementBools[5]", Achievement.activatedLv2.GetHashCode());
        PlayerPrefs.SetInt("achievementBools[6]", Achievement.activatedX1000C.GetHashCode());
        PlayerPrefs.SetInt("achievementBools[7]", Achievement.activatedXEnergy.GetHashCode());
        PlayerPrefs.SetInt("achievementBools[8]", Achievement.activatedXTitanium.GetHashCode());
    }
    void LoadClicker()
    {
        loadTitaniumUpgradeLevel = Mathf.Log(PlayerPrefs.GetInt("onClickV"), 2f);
        loadOnClickV = PlayerPrefs.GetInt("onClickV");
        Clicker.currentEnergy = PlayerPrefs.GetFloat("energy");
        Clicker.currentTitanium = PlayerPrefs.GetFloat("titanium");
        Clicker.onClickValue = loadOnClickV;
        Clicker.totalClicks = PlayerPrefs.GetInt("totalC");
        TitaniumButton();
    }
    private void LoadUpgrades()
    {
        loadUpgradeLevel = PlayerPrefs.GetInt("currentLevel");
        Upgrades.levelTracker = PlayerPrefs.GetInt("currentLevel");
        Upgrades.addEnergyPerSecond = PlayerPrefs.GetFloat("energyPerSec");
        Upgrades.addTitanium = PlayerPrefs.GetFloat("titaniumPerSec");
        LevelButton();
    }
    void LoadSpawn()
    {
        loadHowManySpawnedObjects.Add(PlayerPrefs.GetInt("howMany[0]"));
        loadHowManySpawnedObjects.Add(PlayerPrefs.GetInt("howMany[1]"));
        loadHowManySpawnedObjects.Add(PlayerPrefs.GetInt("howMany[2]"));
        loadHowManySpawnedObjects.Add(PlayerPrefs.GetInt("howMany[3]"));
        loadHowManySpawnedObjects.Add(PlayerPrefs.GetInt("howMany[4]"));
        loadHowManySpawnedObjects.Add(PlayerPrefs.GetInt("howMany[5]"));
        loadHowManySpawnedObjects.Add(PlayerPrefs.GetInt("howMany[6]"));
        loadHowManySpawnedObjects.Add(PlayerPrefs.GetInt("howMany[7]"));
        loadHowManySpawnedObjects.Add(PlayerPrefs.GetInt("howMany[8]"));
       
        SpawnLoop();
    }
    void LoadStats()
    {
        Stats.timer = PlayerPrefs.GetFloat("mainTimer");
    }
    void LoadAchievement()
    {
        achievementBools.Add(PlayerPrefs.GetInt("achievementBools[0]"));
        achievementBools.Add(PlayerPrefs.GetInt("achievementBools[1]"));
        achievementBools.Add(PlayerPrefs.GetInt("achievementBools[2]"));
        achievementBools.Add(PlayerPrefs.GetInt("achievementBools[3]"));
        achievementBools.Add(PlayerPrefs.GetInt("achievementBools[4]"));
        achievementBools.Add(PlayerPrefs.GetInt("achievementBools[5]"));
        achievementBools.Add(PlayerPrefs.GetInt("achievementBools[6]"));
        achievementBools.Add(PlayerPrefs.GetInt("achievementBools[7]"));
        achievementBools.Add(PlayerPrefs.GetInt("achievementBools[8]"));

        if(achievementBools[0] == 1)
        {
            Achievement.activatedACSP = true;
            achievementObj[0].SetActive(true);
        }
        if(achievementBools[1] == 1)
        {
            Achievement.activatedEB = true;
            achievementObj[1].SetActive(true);
        }
        if (achievementBools[2] == 1)
        {
            Achievement.activatedEMT = true;
            achievementObj[2].SetActive(true);
        }
        if (achievementBools[3] == 1)
        {
            Achievement.activatedH1 = true;
            achievementObj[3].SetActive(true);
        }
        if (achievementBools[4] == 1)
        {
            Achievement.activatedLv1 = true;
            achievementObj[4].SetActive(true);
        }
        if (achievementBools[5] == 1)
        {
            Achievement.activatedLv2 = true;
            achievementObj[5].SetActive(true);
        }
        if (achievementBools[6] == 1)
        {
            Achievement.activatedX1000C = true;
            achievementObj[6].SetActive(true);
        }
        if (achievementBools[7] == 1)
        {
            Achievement.activatedXEnergy = true;
            achievementObj[7].SetActive(true);
        }
        if (achievementBools[8] == 1)
        {
            Achievement.activatedXTitanium = true;
            achievementObj[8].SetActive(true);
        }
    }
    private void TitaniumButton()
    {
        if(loadTitaniumUpgradeLevel > 0)
        {
            titaniumButtons[0].SetActive(false);
        }
        if(loadTitaniumUpgradeLevel >= 1)
        {
            titaniumButtons[1].SetActive(true);
            clickerButton.GetComponent<Image>().sprite = miningUpgradeSprites[0];
        }
        if(loadTitaniumUpgradeLevel >= 2)
        {
            titaniumButtons[1].SetActive(false);
            titaniumButtons[2].SetActive(true);
            clickerButton.GetComponent<Image>().sprite = miningUpgradeSprites[1];
        }
        if(loadTitaniumUpgradeLevel >= 3)
        {
            titaniumButtons[2].GetComponentInChildren<Button>().interactable = false;
            levelUpButtons[0].GetComponentInChildren<Button>().interactable = true;
            clickerButton.GetComponent<Image>().sprite = miningUpgradeSprites[2];
        }
        if(loadTitaniumUpgradeLevel > 3)
        {
            titaniumButtons[3].SetActive(false);
        }
        if(loadTitaniumUpgradeLevel >= 4)
        {
            titaniumButtons[4].SetActive(true);
            clickerButton.GetComponent<Image>().sprite = miningUpgradeSprites[3];
        }
        if(loadTitaniumUpgradeLevel >= 5)
        {
            titaniumButtons[4].SetActive(false);
            titaniumButtons[5].SetActive(true);
            clickerButton.GetComponent<Image>().sprite = miningUpgradeSprites[4];
        }
        if(loadTitaniumUpgradeLevel >= 6)
        {
            titaniumButtons[5].GetComponentInChildren<Button>().interactable = false;
            levelUpButtons[1].GetComponentInChildren<Button>().interactable = true;
            clickerButton.GetComponent<Image>().sprite = miningUpgradeSprites[5];
        }
        if (loadTitaniumUpgradeLevel > 6)
        {
            titaniumButtons[6].SetActive(false);
        }
        if (loadTitaniumUpgradeLevel >= 7)
        {
            titaniumButtons[7].SetActive(true);
            clickerButton.GetComponent<Image>().sprite = miningUpgradeSprites[6];
        }
        if (loadTitaniumUpgradeLevel >= 8)
        {
            titaniumButtons[7].SetActive(false);
            titaniumButtons[8].SetActive(true);
            clickerButton.GetComponent<Image>().sprite = miningUpgradeSprites[7];
        }
        if (loadTitaniumUpgradeLevel >= 9)
        {
            titaniumButtons[8].GetComponentInChildren<Button>().interactable = false;
            clickerButton.GetComponent<Image>().sprite = miningUpgradeSprites[8];
        }
    }

    void LevelButton()
    {
        if(loadUpgradeLevel >= 1)
        {
            levelUpButtons[0].GetComponentInChildren<Button>().interactable = false;
            levelSwitchButtons[0].SetActive(true);
        }
        if(loadUpgradeLevel >= 2)
        {
            levelUpButtons[1].GetComponentInChildren<Button>().interactable = false;
            levelSwitchButtons[1].SetActive(true);
            backgroundLv3.GetComponentInChildren<Image>().sprite = terramars;
        }
    }

    void SpawnLoop()
    {
        for(int i = 0; i < loadHowManySpawnedObjects.Count; i++)
        {
            for (int a = 0; a < loadHowManySpawnedObjects[i]; a++)
            {
                spawnManagerObj.GetComponent<Spawn>().SpawnEnergyBuidling(i);
            }
        }
    }
}
