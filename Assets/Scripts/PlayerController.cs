//  Levi Knight
//  07-09-2021
//  MidTerm Project
//  "Worlds Hardest Game in 3D"

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private LevelController levelController;
    public TextMeshProUGUI failsUI;

    private float forwardInput;
    private float sidewaysInput;
    public float speed = 3.5f;
    private int coinsCollected;
    private int fails;


    void Start()    // Initilization. (Gives access the the LevelController)
    {
        playerRb = GetComponent<Rigidbody>();
        levelController = GameObject.Find("LevelController").GetComponent<LevelController>();
        coinsCollected = 0;
        fails = 0;
    }

    //void Update()   // Player movement controll.
    //{
    //
    //}

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Enemy"))   // When the player collides with an enemy they are sent to the start and fails are incremented
    //    {
    //        SendToStart();
    //        fails += 1;
    //        FailsDisplay();
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Finish"))     // When the player triggers the Finish marker they either have enough coins or do not have enough
        {
            if (coinsCollected == levelController.LevelTotalCoins)  // If they have enough coins they NextLevel method is called, the values are updated and the player is sent to the spawn of the next level.
            {
                Debug.Log("Finished with level" + levelController.Level);
                levelController.NextLevel();
                coinsCollected = 0;
                SendToStart();
            } else                                                  // Otherwise nothing happens until the player collects enough coins.
            {
                Debug.Log("You need more coins.");
            }
        }

        else if (other.CompareTag("Coin"))  // If the player triggers a coin the coins count incresses and the coins disapears.
        {
            coinsCollected += 1;
            levelController.CoinsDisplay(coinsCollected);
            Destroy(other.gameObject);
        }

        else if (other.CompareTag("Enemy"))   // When the player collides with an enemy they are sent to the start and fails are incremented
        {
            SendToStart();
            fails += 1;
            FailsDisplay();
        }

    }

    private void SendToStart()      // Send the player to the start of the curent level which is specified in the LevelController class.
    {
        playerRb.transform.position = new Vector3(levelController.StartXCordinantes, transform.position.y, levelController.StartZCordinantes);
    }

    private void FailsDisplay()     // Updates the Fails UI.
    {
        failsUI.text = "FAILS: " + fails;
    }
}
