using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms;
using System.Runtime.CompilerServices;

public class Clicker : MonoBehaviour
{
    public GameObject number; //number object that spawns nearby the main button
    public GameObject parentObject; // parent object of number object
    // Spawn points of the number object
    public GameObject sp1;
    public GameObject sp2;

    // Text boxes where currentTitanium and currentEnergy displays
    public GameObject titaniumDisplay;
    public GameObject energyDisplay;
    public static int onClickValue = 1; //The amount of titanium the player gets when he clicks 1 time.
    public static float currentTitanium = 0f;
    public static float currentEnergy = 0f;
    public static int totalClicks = 0;
    public static bool cheatMode = false;

    //Main button method. Updates currentTitanium and totalClicks, displays number objects.
    public void Click()
    {
        currentTitanium += onClickValue;
        totalClicks += 1;
        StartCoroutine(DisplayNumber(1f));
    }

    // Displays number object in random position between sp1 and sp2. It displays the number for some time and then destroys the object
    public IEnumerator DisplayNumber(float sec)
    {
        float x = Random.Range(sp1.transform.position.x, sp2.transform.position.x);
        float y = Random.Range(sp1.transform.position.y, sp2.transform.position.y);
        GameObject displayedNumber = Instantiate(number, new Vector2(x, y), Quaternion.identity);
        displayedNumber.GetComponent<TextMeshProUGUI>().text = "+" + onClickValue;
        displayedNumber.transform.parent = parentObject.transform;
        yield return new WaitForSeconds(sec);
        Destroy(displayedNumber);
    }
    // Displays currentTitanium value in a text box
    public void DisplayTitanium()
    {
        titaniumDisplay.GetComponent<TextMeshProUGUI>().text = Mathf.Floor(currentTitanium).ToString();
    }
    // Displays currentEnergy value in a text box
    public void DisplayEnergy()
    {
        energyDisplay.GetComponent<TextMeshProUGUI>().text = Mathf.Floor(currentEnergy).ToString();
    }
    public void Update()
    {
        DisplayTitanium();
        DisplayEnergy();
    }
}

