using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievement : MonoBehaviour
{
    private float timer; // timer used in achievements

    public Transform parent; // parent object that helps organizing the achievment scroll view

    public GameObject averageClickPerSecPrefab; // achievement prefab that is spawned when player meets the achievement requirements
    public static bool activatedACSP = false; // bool that checks if the achievement prefab has been spawned

    public GameObject x1000ClicksPrefab;
    public static bool activatedX1000C = false;

    public GameObject hour1Prefab;
    public static bool activatedH1 = false;

    public GameObject lv1UpPrefab;
    public static bool activatedLv1;
    public GameObject lv2UpPrefab;
    public static bool activatedLv2;

    public GameObject xTitaniumPrefab;
    public GameObject xEnergyPrefab;
    public static bool activatedXTitanium = false;
    public static bool activatedXEnergy = false;

    public GameObject everyMiningToolPrefab;
    public static bool activatedEMT = false;
    public GameObject everyBuidlingPrefab;
    public static bool activatedEB = false;

    // achievemnt prefabs in the scroll view, that are set to true when player meets the requirements
    public GameObject averageClickPerSecScrollView;
    public GameObject x1000ClicksScrollView;
    public GameObject hour1ScrollView;
    public GameObject lv1UpScrollView;
    public GameObject lv2UpScrollView;
    public GameObject xTitaniumScrollView;
    public GameObject xEnergyScrollView;
    public GameObject everyMiningScrollView;
    public GameObject everyBuidlingScrollView;

    public Sound soundScript; 
    

    // Update is called once per frame
    void Update()
    {
        // It runs methods only if the achievement has not been activated before
        if (!activatedACSP)
        {
            AverageClicksPerSecAchievement();
        }
        if (!activatedX1000C)
        {
            X1000ClicksAchievement();
        }
        if (!activatedH1)
        {
            Hour1Achievement();
        }
        if (!activatedXTitanium)
        {
            XTitaniumAchievement();
        }
        if (!activatedXEnergy)
        {
            XEnergyAchievement();
        }
    }

    // Each 10th secnonds it checks the players average clicks per second
    public void AverageClicksPerSecAchievement()
    {
        timer += Time.deltaTime;
        if(timer >= 10f)
        {
          float average = Clicker.totalClicks / Stats.timer;
            if(average >= 2f)
            {
                Instantiate(averageClickPerSecPrefab, parent);
                soundScript.ButtonSound(7);
                averageClickPerSecScrollView.SetActive(true);
                activatedACSP = true;
            }
            timer = 0f;
        }
    }

    // Checks if the player has clicked the main button a 1000 times
    public void X1000ClicksAchievement()
    {
        if(Clicker.totalClicks >= 1000)
        {
            Instantiate(x1000ClicksPrefab, parent);
            soundScript.ButtonSound(7);
            x1000ClicksScrollView.SetActive(true);
            activatedX1000C = true;
        }
    }

    // It activates after 1 hour in game
    public void Hour1Achievement()
    {
        if(Stats.timer >= 3600f)
        {
            Instantiate(hour1Prefab, parent);
            soundScript.ButtonSound(7);
            hour1ScrollView.SetActive(true);
            activatedH1 = true;
        }
    }

    // It activates when player levels up
    public void Lv1UpAchievement()
    {
        if (!activatedLv1)
        {
            Instantiate(lv1UpPrefab, parent);
            soundScript.ButtonSound(7);
            lv1UpScrollView.SetActive(true);
        }
    }

    public void Lv2UpAchievement()
    {
        if (!activatedLv2)
        {
            Instantiate(lv2UpPrefab, parent);
            soundScript.ButtonSound(7);
            lv2UpScrollView.SetActive(true);
        }
    }
    
    // It activates when player has a certain amount of titanium/energy in inventory
    public void XTitaniumAchievement()
    {
        if(Clicker.currentTitanium >= 10000)
        {
            Instantiate(xTitaniumPrefab, parent);
            soundScript.ButtonSound(7);
            xTitaniumScrollView.SetActive(true);
            activatedXTitanium = true;
        }
    }

    public void XEnergyAchievement()
    {
        if (Clicker.currentEnergy >= 100000)
        {
            Instantiate(xEnergyPrefab, parent);
            soundScript.ButtonSound(7);
            xEnergyScrollView.SetActive(true);
            activatedXEnergy = true;
        }
    }

    // It activates when the player buys the last mining upgrade
    public void EveryMiningToolAchievement()
    {
        if (!activatedEMT)
        {
            Instantiate(everyMiningToolPrefab, parent);
            soundScript.ButtonSound(7);
            everyMiningScrollView.SetActive(true);
        }
    }

    // It activates when player buys the last building 
    public void EveryBuildingAchievement()
    {
        if (!activatedEB)
        {
            Instantiate(everyBuidlingPrefab, parent);
            soundScript.ButtonSound(7);
            everyBuidlingScrollView.SetActive(true);
            activatedEB = true;
        }
    }
}
