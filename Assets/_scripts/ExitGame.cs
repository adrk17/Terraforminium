using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public GameObject saveManager;
    public void Exit()
    {
        saveManager.GetComponent<SavedData>().SaveGame();
        Application.Quit();
    }
}
