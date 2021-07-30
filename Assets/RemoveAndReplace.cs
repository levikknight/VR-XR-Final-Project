//  Levi Knight
//  07-30-2021
//  Final Project
//  "Worlds Hardest Game in 3D"

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveAndReplace : MonoBehaviour
{

    public void RemoveObject()      // Deactivates the object that calls the script.
    {
        gameObject.SetActive(false);
    }

    public void ReplaceObject()     // Reactivate the object that calls the script.
    {
        gameObject.SetActive(true);
    }
}
