using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

[RequireComponent(typeof(Enemy))]
public class Gold : MonoBehaviour
{
    [SerializeField] int startingGold = 150;
    int currentGold;
    int totalKillCount;
    [SerializeField] TextMeshProUGUI displayGold;
    [SerializeField] TextMeshProUGUI displayKills;
    public int CurrentGold { get { return currentGold;  } }


    private void Awake()
    {
        currentGold = startingGold;
        totalKillCount = 0;
        UpdateGoldDisplay();
    }


    public void AddGold(int amount)
    {
        currentGold += Mathf.Abs(amount);
        totalKillCount++;
        UpdateGoldDisplay();
    }

    public void RemoveGold(int amount)
    {
        currentGold -= Mathf.Abs(amount);
        UpdateGoldDisplay();
        if (currentGold < 0)
        {
            ReloadScene();
        }

    }

    void UpdateGoldDisplay()
    {
        displayGold.text = "Gold: " + currentGold;
        displayKills.text = "Kills: " + totalKillCount;
    }

    void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);

    }
}
