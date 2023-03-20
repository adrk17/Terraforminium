using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour
{
    public List<int> titaniumUpgradePrice; // list of titanium upgrade prices in titanium
    public List<int> titaniumUpgradePriceE; // list of titanium upgrade prices in energy
    public List<GameObject> titaniumPanels; // list of price panels that dissapear if the player has the requaired amount of money to buy an upgrade
    public static float addTitanium = 0f; // last titanium upgrade, it gives a certain amount of titanium per second, default is 0/sec

    public List<int> energyUpgradePrice; // list of energy upgrade prices
    public List<int> energyUpgrade; // list of energy upgrade values. They are used to increase player's energy per second.
    public List<GameObject> energyPanels; 
    public static float addEnergyPerSecond = 0f; // gives a certain amount of energy per sec, default is 0/sec

    private float timerPerSecond; // timer that updates once per second

    public List<int> levelUpPrice;
    public List<int> levelUpPriceE;
    public List<GameObject> levelUpPanels;
    public static int levelTracker;
    private void Start()
    {
        // Creates all the lists
        titaniumUpgradePrice.Add(100);
        titaniumUpgradePrice.Add(260);
        titaniumUpgradePrice.Add(700);
        titaniumUpgradePrice.Add(1800);
        titaniumUpgradePrice.Add(4600);
        titaniumUpgradePrice.Add(12000);
        titaniumUpgradePrice.Add(31000);
        titaniumUpgradePrice.Add(80000);
        titaniumUpgradePrice.Add(210000);

        titaniumUpgradePriceE.Add(0);
        titaniumUpgradePriceE.Add(0);
        titaniumUpgradePriceE.Add(0);
        titaniumUpgradePriceE.Add(1000);
        titaniumUpgradePriceE.Add(5000);
        titaniumUpgradePriceE.Add(10000);
        titaniumUpgradePriceE.Add(40000);
        titaniumUpgradePriceE.Add(100000);
        titaniumUpgradePriceE.Add(400000);

        energyUpgradePrice.Add(100);
        energyUpgradePrice.Add(180);
        energyUpgradePrice.Add(300);
        energyUpgradePrice.Add(600);
        energyUpgradePrice.Add(1400);
        energyUpgradePrice.Add(3800);
        energyUpgradePrice.Add(9000);
        energyUpgradePrice.Add(20000);
        energyUpgradePrice.Add(50000);

        energyUpgrade.Add(1);
        energyUpgrade.Add(3);
        energyUpgrade.Add(7);
        energyUpgrade.Add(18);
        energyUpgrade.Add(46);
        energyUpgrade.Add(120);
        energyUpgrade.Add(310);
        energyUpgrade.Add(800);
        energyUpgrade.Add(2100);

        levelUpPrice.Add(1000);
        levelUpPrice.Add(20000);

        levelUpPriceE.Add(3000);
        levelUpPriceE.Add(40000);
        levelTracker = 0;
    }

    // titanium upgrade main code, it checks if the player has the required amount of resources to buy the upgrade, then it multiplys onclickValue by 2 and removes a the resources from inventory
    public void TitaniumX2(int index)
    {
        if (Clicker.currentTitanium >= titaniumUpgradePrice[index] && Clicker.currentEnergy >= titaniumUpgradePriceE[index])
        {
            Clicker.onClickValue *= 2;
            Clicker.currentTitanium -= titaniumUpgradePrice[index];
            Clicker.currentEnergy -= titaniumUpgradePriceE[index];
        }
    }

    // Last titanium upgrade gives a number of titanium per second
    public void TitaniumPerSecond()
    {
        addTitanium = 250f;
    }

    //Main energy upgrade code. It ckecks if the player has the money to buy it, then it adds energy per second and removes the price from player's inventory
    public void EnergyPerSecond(int index)
    {
       if(Clicker.currentTitanium >= energyUpgradePrice[index])
        {
            addEnergyPerSecond += energyUpgrade[index];
            Clicker.currentTitanium -= energyUpgradePrice[index];
        }
    }


    public void LevelUp(int index)
    {
        if (Clicker.currentTitanium >= levelUpPrice[index] && Clicker.currentEnergy >= levelUpPriceE[index])
        {
            Clicker.currentEnergy -= levelUpPriceE[index];
            Clicker.currentTitanium -= levelUpPrice[index];
            levelTracker++;
        }

    }
    // PanelChecks check if the player has enough resources to buy an upgrade and manage the price panels.
    public void PanelCheck()
    {
        for (int i = 0; i < titaniumPanels.Count; i++)
        { 
            if(Clicker.currentTitanium >= titaniumUpgradePrice[i] && Clicker.currentEnergy >= titaniumUpgradePriceE[i])
            {
                titaniumPanels[i].SetActive(false);
            }
            else
            {
                titaniumPanels[i].SetActive(true);
            }
        }
    }

    public void PanelCheckEnergy()
    {
        for (int i = 0; i < energyPanels.Count; i++)
        {
            if (Clicker.currentTitanium >= energyUpgradePrice[i])
            {
                energyPanels[i].SetActive(false);
            }
            else
            {
                energyPanels[i].SetActive(true);
            }
        }
    }

    public void PanelCheckLevelUp()
    {
        for (int i = 0; i < levelUpPanels.Count; i++)
        {
            if (Clicker.currentTitanium >= levelUpPrice[i] && Clicker.currentEnergy >= levelUpPriceE[i])
            {
                levelUpPanels[i].SetActive(false);
            }
            else
            {
                levelUpPanels[i].SetActive(true);
            }
        }
    }
    // timer that resets itself after some time, adding a certain amount of resources in the process
    public void Timers()
    {
        timerPerSecond += Time.deltaTime;
        float refreshRate = 0.05f;
        if (timerPerSecond >= 1f * refreshRate)
        {
            Clicker.currentEnergy += (addEnergyPerSecond * refreshRate);
            Clicker.currentTitanium += addTitanium * refreshRate;
            timerPerSecond = 0f;
        }
    }
    private void Update()
    {
        PanelCheck();
        PanelCheckEnergy();
        PanelCheckLevelUp();
        Timers();
    }
}
