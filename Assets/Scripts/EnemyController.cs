//  Levi Knight
//  07-28-2021
//  Final Project
//  "Worlds Hardest Game in 3D"

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private int health;
    Rigidbody enemyRb;

    public int Health
    {
        get { return health; }
        set { health = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        health = 5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
