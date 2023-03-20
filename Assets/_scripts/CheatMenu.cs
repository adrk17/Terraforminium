using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheatMenu : MonoBehaviour
{
    public static bool cheatMode = false; // checks if the cheat menu has been enabled, false on default
    // Cheat menu's input fields when the player writes the amount of titanium/energy he wants to have
    public GameObject titaniumInputField;
    public GameObject energyInputField;
    // ckecks if titanium/energy input fields are activated
    public bool activeT = false;
    public bool activeE = false;


    private void Update()
    {
        DeveloperMode();
        GiveTitaniumOrEnergy();
    }

    // This method enables and disables cheat mode, it is connected to a checkmark in manager
    public void CheatModeOnOff(bool active)
    {
        cheatMode = active;
    }

    // Cheat menu's main code
    private void DeveloperMode()
    {
        if (cheatMode) // checks if cheat menu is checked in game
        {
            if (Input.GetKeyDown(KeyCode.T) && !activeT && !activeE) // it activates only if you press T and none of  the input fields are active
            {
                Cursor.lockState = CursorLockMode.Locked; // locks the cursor just to prevent bugs
                titaniumInputField.SetActive(true);
                titaniumInputField.GetComponent<InputField>().ActivateInputField();
                activeT = true;
            }
            else if(Input.GetKeyDown(KeyCode.T) && activeT) // It hides the input field if it is active
            {
                Cursor.lockState = CursorLockMode.None;
                titaniumInputField.SetActive(false);
                activeT = false;
            }


            if (Input.GetKeyDown(KeyCode.E) && !activeE && !activeT)
            {
                Cursor.lockState = CursorLockMode.Locked;
                energyInputField.SetActive(true);
                energyInputField.GetComponent<InputField>().ActivateInputField();
                activeE = true;
            }
            else if (Input.GetKeyDown(KeyCode.E) && activeE)
            {
                Cursor.lockState = CursorLockMode.None;
                energyInputField.SetActive(false);
                activeE = false;
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                PlayerPrefs.DeleteAll();
                print("save deleted");
            }
        }
    }

    // The code htat gives the player the resources 
    public void GiveTitaniumOrEnergy()
    {
        if(activeT && Input.GetKeyDown(KeyCode.Return)) // it gets the value from input field and uses it to add a certain amount of resources to the player's inventory
        {
            int amount;
            int.TryParse(titaniumInputField.GetComponentInChildren<Text>().text, out amount); // the text from input field is converted into an int
            Clicker.currentTitanium += amount;
            Cursor.lockState = CursorLockMode.None;
            titaniumInputField.SetActive(false);
            activeT = false;
        }

        if (activeE && Input.GetKeyDown(KeyCode.Return))
        {
            int amount;
            int.TryParse(energyInputField.GetComponentInChildren<Text>().text, out amount);
            Clicker.currentEnergy += amount;
            Cursor.lockState = CursorLockMode.None;
            energyInputField.SetActive(false);
            activeE = false;
        }
    }

}
