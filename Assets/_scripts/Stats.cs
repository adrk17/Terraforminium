using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Stats : MonoBehaviour
{
    // text boxes where thhe statisitcs are displayed
    public GameObject totalClicksTxtBox;
    public GameObject totalTimeTxtBox;
    public static float timer = 0; // main timer
    private float minutes;
    private float hours;
    
    private void Update()
    {
        Timer();
        TotalClicks();
    }
    public void Timer() // main game timer, it takes the seconds and displays them in hours:minutes:seconds order
    {
        timer += Time.deltaTime;
        minutes = timer / 60f; // converts seconds into minutes
        hours = minutes / 60f;
        //rounded down values of seconds, minutes and hours
        float fullMinutes = Mathf.Floor(minutes);
        float finalHours = Mathf.Floor(hours);
        float finalMinutes = Mathf.Floor(minutes - (finalHours * 60f)); // shows only whole numbers, rounds down
        float finalSeconds = Mathf.Floor(timer - (fullMinutes * 60f)); // substracts whole minutes from whole seconds making the number drop down to 0 when a minute passes
        totalTimeTxtBox.GetComponent<TextMeshProUGUI>().text =finalHours.ToString() + "h " + finalMinutes.ToString() + "m " + finalSeconds.ToString() + "s";
    }
    //Displays the total clicks number in a text box
    private void TotalClicks()
    {
        totalClicksTxtBox.GetComponent<TextMeshProUGUI>().text ="Total clicks: " + Clicker.totalClicks.ToString();
    }
}
