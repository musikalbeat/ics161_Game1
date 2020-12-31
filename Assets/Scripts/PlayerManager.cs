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
    public int currentLevel = 0;
    public List<levelStarsProxy> achievement = new List<levelStarsProxy>();

    // Game Info
    public GameObject stageContent;
    private int maxStages = 6;
    private Transform stage;
    private Transform starsContainer;

    // Start is called before the first frame update
    void Awake()
    {
        for (int i = 0; i < maxStages; i++)
        {
            achievement.Add(new levelStarsProxy { levelIndex = i, starAmount = 0 });
        }
    }

    public void UpdateLevel(int level, int starsEarned)
    {
        stage = stageContent.transform.GetChild(level-1);
        starsContainer = stage.transform.GetChild(1);
        
        if ( starsEarned == 0)
        {
            starsContainer.gameObject.SetActive(false);
        }
        else if ( starsEarned == 1)
        {
            starsContainer.gameObject.SetActive(true);
            starsContainer.transform.GetChild(0).gameObject.SetActive(false);
            starsContainer.transform.GetChild(0).gameObject.SetActive(false);
        }
        else if ( starsEarned == 2)
        {
            starsContainer.gameObject.SetActive(true);
            starsContainer.transform.GetChild(0).gameObject.SetActive(true);
            starsContainer.transform.GetChild(0).gameObject.SetActive(false);
        }
        else
        {
            starsContainer.gameObject.SetActive(true);
            starsContainer.transform.GetChild(0).gameObject.SetActive(true);
            starsContainer.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

}
