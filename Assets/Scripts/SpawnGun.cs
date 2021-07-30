//  Levi Knight
//  07-30-2021
//  Final Project
//  "Worlds Hardest Game in 3D"

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGun : MonoBehaviour
{
    public GameObject dartGun;

    public void Spawn()     // Spawns the specified object at the location of the object that callled the script.
    {
        Instantiate(dartGun, transform.position, transform.rotation);
    }
}
