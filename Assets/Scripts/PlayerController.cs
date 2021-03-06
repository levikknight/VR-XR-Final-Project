//  Levi Knight
//  07-30-2021
//  Final Project
//  "Worlds Hardest Game in 3D"

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private LevelController levelController;
    public TextMeshProUGUI[] failsDisplayList;
    private FadeCanvas fadeCanvas = null;
    private PlayQuickSound playQuickSound;
    private PlayAnotherQuickSound playAnotherQuickSound;

    private float forwardInput;
    private float sidewaysInput;
    public float speed = 3.5f;
    private int coinsCollected;
    private int fails;

    private void Awake()
    {
        fadeCanvas = FindObjectOfType<FadeCanvas>();
    }

    void Start()    // Initilization. (Gives access the the LevelController)
    {
        playerRb = GetComponent<Rigidbody>();
        levelController = GameObject.Find("LevelController").GetComponent<LevelController>();
        coinsCollected = 0;
        fails = 0;
        FailsDisplay();

        playQuickSound = GetComponent<PlayQuickSound>();
        playAnotherQuickSound = GetComponent<PlayAnotherQuickSound>();
    }

    public void RestartLevel()      // Does not do a compleate restart but simply resets some of the game objects and variables.
    {
        SendToStart();
        fails = 0;
        FailsDisplay();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Finish"))                             // When the player triggers the Finish marker they either have enough coins or do not have enough
        {
            if (levelController.NextLevel(coinsCollected))          // If they have enough coins NexeLevel will return true, then the values are updated and the player is sent to the spawn of the next level.
            {
                coinsCollected = 0;
                SendToStart();
            } else                                                  // Otherwise nothing happens until the player collects enough coins.
            {
                Debug.Log("You need more coins again.");
            }
        } else if (other.CompareTag("Coin"))                        // If the player triggers a coin the coins count incresses and the coins disapears.
        {
            coinsCollected += 1;
            levelController.CoinsDisplay(coinsCollected);
            Destroy(other.gameObject);
            playAnotherQuickSound.Play();
        } else if (other.CompareTag("Enemy"))                       // When the player collides with an enemy they are sent to the start and fails are incremented
        {
            SendToStart();
            playQuickSound.Play();
            fails += 1;
            FailsDisplay();
        }

    }

    private void SendToStart()      // Send the player to the start of the curent level which is specified in the LevelController class.
    {
        fadeCanvas.QuickFadeIn();
        playerRb.transform.position = new Vector3(levelController.StartXCordinantes, transform.position.y, levelController.StartZCordinantes);
        fadeCanvas.StartFadeOut();
    }

    private void FailsDisplay()     // Updates the Fails UI.
    {
        for (int i = 0; i < failsDisplayList.Length; i++)
        {
            failsDisplayList[i].text = "FAILS: " + fails;
        }
        
    }
}
