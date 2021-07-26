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
    public TextMeshProUGUI levelDisplay;
    public TextMeshProUGUI coinsDisplay;
    public TextMeshProUGUI winDisplay;

    private int level;
    private int levelTotalCoins;
    private int testReturn;
    private float startXCordinantes;
    private float startZCordinantes;

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
        levelDisplay.text = "LEVEL: " + Level;
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
            winDisplay.text = "YOU WIN!";
        }
    }

    private void LevelDisplay() // Updates the UI for the level.
    {
        levelDisplay.text = "LEVEL: " + Level;
    }

    public void CoinsDisplay(int coinsCollected)    // Updates the UI when coins collected.
    {
        if (levelTotalCoins > 0)                    // If coins are required to compleat the level, let the user know.
        {
            coinsDisplay.text = "COINS: " + coinsCollected + "/" + levelTotalCoins;
        } else                                      // If coins are not required, display nothing.
        {
            coinsDisplay.text = "";
        }

    }
}
