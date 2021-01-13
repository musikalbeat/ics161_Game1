using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class levelStarsProxy
{
    public int levelIndex;
    public int starAmount;
}


public class PlayerManager : MonoBehaviour
{
    // Player Info
    public int currentLevel = 1;
    public Dictionary<int, int> stageProgress = new Dictionary<int, int>();

    // Game Info
    // Screen --> Stage Screen --> Stage Panel --> Content
    public GameObject stageContent;
    private int maxStages = 6;

    private Transform stage;
    private Transform starsContainer;

    // Updates the dictionary of stage levels with star earned during gameplay
    public void UpdateLevel(int level, int starsEarned)
    {
        if (stageProgress.ContainsKey(level))
        {
            stageProgress[level] = starsEarned;
        }
        else
        {
            stageProgress.Add(level, starsEarned);
        }
    }

    // Updates the Level Selection menu out while on the Title scene
    public void UpdateSelection()
    {
        for (int level = 0; level < stageProgress.Count; level++)
        {
            stage = stageContent.transform.GetChild(level);
            starsContainer = stage.transform.GetChild(1);

            if ( stageProgress[level+1] == 0)
            {
                starsContainer.gameObject.SetActive(false);
            }
            else if ( stageProgress[level+1] == 1)
            {
                starsContainer.gameObject.SetActive(true);
                starsContainer.transform.GetChild(0).gameObject.SetActive(true); // Star 2
                starsContainer.transform.GetChild(1).gameObject.SetActive(true); // Star 1
            }
            else if ( stageProgress[level+1] == 2)
            {
                starsContainer.gameObject.SetActive(true);
                starsContainer.transform.GetChild(0).gameObject.SetActive(true);
                starsContainer.transform.GetChild(1).gameObject.SetActive(false);
            }
            else
            {
                starsContainer.gameObject.SetActive(true);
                starsContainer.transform.GetChild(0).gameObject.SetActive(false);
                starsContainer.transform.GetChild(1).gameObject.SetActive(false);
            }
        }
    }
}
