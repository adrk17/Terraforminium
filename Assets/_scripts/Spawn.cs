using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Spawn : MonoBehaviour
{
    // A list with all building prefabs that are later on spawned
    public List<GameObject> energyPrefabs;
    // a list of all the lists of spawning points for each category of spawned objects
    public List<List<GameObject>> spawnPoints = new List<List<GameObject>>();
    // Lists for each object category
    public List<GameObject> sp0;
    public List<GameObject> sp1;
    public List<GameObject> sp2;
    public List<GameObject> sp3;
    public List<GameObject> sp4;
    public List<GameObject> sp5;
    public List<GameObject> sp6;
    public List<GameObject> sp7;
    public List<GameObject> sp8;

    // a list of all the lists of spawned objects
    public List<List<GameObject>> spawnedEnergyPrefabs = new List<List<GameObject>>();
    // Lists for each spawned object category
    public List<GameObject> so0;
    public List<GameObject> so1;
    public List<GameObject> so2;
    public List<GameObject> so3;
    public List<GameObject> so4;
    public List<GameObject> so5;
    public List<GameObject> so6;
    public List<GameObject> so7;
    public List<GameObject> so8;
    private GameObject empty; // empty object that is added to a list of spawned obejcts if the list runs out of spawnpoints
    public static List<int> howManySpawnedObjects = new List<int>(); // a list that keeps track of spawned objects
    public List<GameObject> textboxes;

    public GameObject parentLv1; // parent obejcts that attach spwaned objects to a level
    public GameObject parentLv2;
    public GameObject parentLv3;
    // Start is called before the first frame update
    void Start()
    {
        // Creates all the needed lists
        spawnPoints.Add(sp0);
        spawnPoints.Add(sp1);
        spawnPoints.Add(sp2);
        spawnPoints.Add(sp3);
        spawnPoints.Add(sp4);
        spawnPoints.Add(sp5);
        spawnPoints.Add(sp6);
        spawnPoints.Add(sp7);
        spawnPoints.Add(sp8);

        spawnedEnergyPrefabs.Add(so0);
        spawnedEnergyPrefabs.Add(so1);
        spawnedEnergyPrefabs.Add(so2);
        spawnedEnergyPrefabs.Add(so3);
        spawnedEnergyPrefabs.Add(so4);
        spawnedEnergyPrefabs.Add(so5);
        spawnedEnergyPrefabs.Add(so6);
        spawnedEnergyPrefabs.Add(so7);
        spawnedEnergyPrefabs.Add(so8);

        howManySpawnedObjects.Add(0);
        howManySpawnedObjects.Add(0);
        howManySpawnedObjects.Add(0);
        howManySpawnedObjects.Add(0);
        howManySpawnedObjects.Add(0);
        howManySpawnedObjects.Add(0);
        howManySpawnedObjects.Add(0);
        howManySpawnedObjects.Add(0);
        howManySpawnedObjects.Add(0);
    }

    // Update is called once per frame
    void Update()
    {
        SpawndedObjects();
        ShowXBuildings();
    }
   
    // Main code that spawnes buildings, it is attached to building buttons, that pass an index that indicates which type of building needs to be spawned
    public void SpawnEnergyBuidling(int index)
    {
        if (spawnPoints[index].Count != 0) // ckecks if the list of spawnPoints have some spawnpoints left to spawn a new object
        {
            int num = spawnPoints[index].Count; // Counts the spawnpoints
            GameObject sp = spawnPoints[index][num - 1]; // Takes the last sp in the list
            GameObject spawnedObject = Instantiate(energyPrefabs[index], new Vector3(sp.transform.position.x, sp.transform.position.y, -0.05f), sp.transform.rotation); // Spawns an object of type "index" i a position of sp
            spawnPoints[index].RemoveAt(num-1); // Removes the last spawnpoint in the list. Every building is spawned in different spawn point after it eventually run out of spawnpoints
            spawnedEnergyPrefabs[index].Add(spawnedObject); // It adds the spawned object to the spawned obejct list
            if (index >= 0 && index <= 2) // it sets parent of the spawned object according to the index. 
            {
                spawnedObject.transform.parent = parentLv1.transform;
            }
            else if (index >= 3 && index <= 5)
            {
                spawnedObject.transform.parent = parentLv2.transform;
            }
            else if (index >= 6 && index <= 8)
            {
                spawnedObject.transform.parent = parentLv3.transform;
            }
        }
        // If there is not spawnpoints left in a list it adds an empty obejct to the list of spawned points
        else
        {
            spawnedEnergyPrefabs[index].Add(empty);
        }
    }
    public void LoadSpawnBuildings()
    {

    }
    public void SpawndedObjects() // counts the spawned objects
    {
        for (int a = 0; a < spawnedEnergyPrefabs.Count; a++)
        {
            howManySpawnedObjects[a] = spawnedEnergyPrefabs[a].Count;
            if(a == spawnedEnergyPrefabs.Count)
            {
                a = 0;
            }
        }
    }
    // if there are more spawned objects than 5 then the number of spawned buildings is displayed in a text box
    public void ShowXBuildings()
    {
        for (int a = 0; a < howManySpawnedObjects.Count; a++)
        {
            if(howManySpawnedObjects[a] >= 5)
            {
                textboxes[a].SetActive(true);
                textboxes[a].GetComponent<TextMeshProUGUI>().text = "x" + howManySpawnedObjects[a]; 
            }
        }
    }
}
