// HANDLE GETTING AND GIVING INFORMATION FROM AND TO THE SAVE FILE

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    // PlayerPref dictionary to store the information that gets saved/loaded
    private class SaveObject
    {
        public int currentLevel;
        public List<int> StarAmounts;
    }

    public PlayerManager pm;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        SaveSystem.Init();
    }

    public void SaveGame()
    {
        // Locate the PlayerManager script
        pm = GameObject.FindGameObjectWithTag("Info").GetComponent<PlayerManager>();

        // Create a new save object to store information into a dictionary
        SaveObject saveObj = new SaveObject
        {
            currentLevel = pm.currentLevel,
            StarAmounts = new List<int>(pm.achievement.Count)
        };

        // Loop through the player inventory and assign the item amounts into the ItemAmounts list.
        foreach (levelStarsProxy proxy in pm.achievement)
        {
            saveObj.StarAmounts.Add(proxy.starAmount);
        }

        // Converts dictionary into JSON file
        string json = JsonUtility.ToJson(saveObj);
        // Save JSON file into a file on your computer
        SaveSystem.Save(json);
    }

    public void LoadGame()
    {
        SaveObject loadedSave = JsonUtility.FromJson<SaveObject>( SaveSystem.Load() );
        Debug.Log("Game loaded...");
        StartCoroutine( LoadingValues(loadedSave) );
    }

    IEnumerator LoadingValues(SaveObject loadedSave)
    {
        while (SceneManager.GetActiveScene().buildIndex != 1)
        {
            Debug.Log("Wait");
            yield return new WaitForSecondsRealtime(0.5f);
        }
        Debug.Log("Load Value");
        
        // Locate the PlayerManager script
        pm = GameObject.FindGameObjectWithTag("Info").GetComponent<PlayerManager>();

        for (int i = 0; i < loadedSave.StarAmounts.Count; i++) 
        {
            pm.achievement[i].starAmount = loadedSave.StarAmounts[i];
        }

        // Make sure that UpdateUI() is public in PlayerManager
        //pm.UpdateLevel();
    }
}
