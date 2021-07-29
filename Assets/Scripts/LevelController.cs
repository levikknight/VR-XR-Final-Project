//  Levi Knight
//  07-09-2021
//  MidTerm Project
//  "Worlds Hardest Game in 3D"

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelController : MonoBehaviour
{
    public static LevelController instance = null;      //This class is a Singleton
    public TextMeshProUGUI[] levelDisplayList;
    public TextMeshProUGUI[] coinsDisplayList;
    public TextMeshProUGUI[] winDisplayList;

    private int level;
    private int levelTotalCoins;
    private int testReturn;
    private float startXCordinantes;
    private float startZCordinantes;
    private bool coinsOverride;

            // These Dicts handle all the information need for each level. (How many coins there are as well as the start position for the player.)
    private IDictionary<int, int> gameCoins = new Dictionary<int, int>(){ { 1, 0 }, { 2, 9 }, { 3, 4 } };
    private IDictionary<int, float> gameStartXCords = new Dictionary<int, float>()  { { 1, -14.5f }, { 2, -14.5f }, { 3, 0.0f } };
    private IDictionary<int, float> gameStartZCords = new Dictionary<int, float>()  { { 1, 0.0f }, { 2, 30.0f }, { 3, 60.0f } };

            // Level information can be accessed by other classes but should only be changed by methods in this LevelController.
    public int Level
    {
        get => level;
    }

    public int LevelTotalCoins
    {
        get => levelTotalCoins;
    }

    public float StartXCordinantes
    {
        get => startXCordinantes;
    }

    public float StartZCordinantes
    {
        get => startZCordinantes;
    }

    void Start()    // Simple Initilization.
    {
        level = 0;
        NextLevel();
        coinsOverride = false;
    }

    void Awake()    // Enforces Singleton behavior.
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    public void NextLevel()     // Called when the end of the level is reached. 
    {
        level += 1;

        if (gameCoins.TryGetValue(level, out testReturn))    // If there are more levels remaining update values and UI.
        {
            levelTotalCoins = gameCoins[Level];
            startXCordinantes = gameStartXCords[Level];
            startZCordinantes = gameStartZCords[Level];
            LevelDisplay();
            CoinsDisplay(0);
        } else                                          // Else display a victory message.
        {
            WinDisplay();
        }
    }

    public void ResetLevel()    // Returns the Player to level one.  **TODO: Totally reset the world. Respawn all enemies and coins.
    {
        level = 0;
        LevelDisplay();
        coinsOverride = true;
        CoinsDisplay(gameCoins[level]);
    }

    private void LevelDisplay() // Updates all level UI for the level.
    {
        for(int i = 0; i < levelDisplayList.Length; i++)
        {
            levelDisplayList[i].text = "LEVEL: " + Level;
        }
    }

    public void CoinsDisplay(int coinsCollected)    // Updates all level UI when coins collected.
    {
        if (levelTotalCoins > 0 && !coinsOverride)          // If coins are required to compleat the level and coins over ride is not on, let the user know.
        {
            for (int i = 0; i < coinsDisplayList.Length; i++)
            {
                coinsDisplayList[i].text = "COINS: " + coinsCollected + "/" + levelTotalCoins;
            }
        } else                                      // If coins are not required, display nothing.
        {
            for (int i = 0; i < coinsDisplayList.Length; i++)
            {
                coinsDisplayList[i].text = "COINS: not required";
            }
        }

    }

    public void WinDisplay()    // Updates al level UI when the player wins.
    {
        for (int i = 0; i < winDisplayList.Length; i++)
        {
            winDisplayList[i].text = "YOU WIN!!!";
        }
    }
}
