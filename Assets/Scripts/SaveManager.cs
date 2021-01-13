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
        if (GameObject.FindGameObjectWithTag("Info") == null)
        {
            DontDestroyOnLoad(this.gameObject);
        }
        SaveSystem.Init();
        // Locate the PlayerManager script
        pm = GameObject.FindGameObjectWithTag("Info").GetComponent<PlayerManager>();
    }

    public void SaveGame()
    {
        // Create a new save object to store information into a dictionary
        SaveObject saveObj = new SaveObject
        {
            currentLevel = pm.currentLevel,
            StarAmounts = new List<int>(pm.stageProgress.Count)
        };

        foreach (KeyValuePair<int,int> pair in pm.stageProgress)
        {
            saveObj.StarAmounts.Add(pair.Value);
        }

        Debug.Log("Saving...");
        // Converts dictionary into JSON file
        string json = JsonUtility.ToJson(saveObj);
        // Save JSON file into a file on your computer
        SaveSystem.Save(json);
    }

    public void LoadGame()
    {
        SaveObject loadedSave = JsonUtility.FromJson<SaveObject>( SaveSystem.Load() );
        Debug.Log("Loading...");
        StartCoroutine( LoadingValues(loadedSave) );
    }

    IEnumerator LoadingValues(SaveObject loadedSave)
    {
        while (SceneManager.GetActiveScene().buildIndex != 0)
        {
            Debug.Log("Wait");
            yield return new WaitForSecondsRealtime(0.5f);
        }
        Debug.Log("Load Value");
        
        // Locate the PlayerManager script
        pm = GameObject.FindGameObjectWithTag("Info").GetComponent<PlayerManager>();

        pm.currentLevel = loadedSave.currentLevel;

        for (int i = 0; i < loadedSave.StarAmounts.Count; i++) 
        {
            if (pm.stageProgress.ContainsKey(i+1) == true)
            {
                pm.stageProgress[i+1] = loadedSave.StarAmounts[i];
            }
            else
            {
                pm.stageProgress.Add(i+1, loadedSave.StarAmounts[i]);
            }
        }

        // Make sure that UpdateUI() is public in PlayerManager
        pm.UpdateSelection();
    }
}
