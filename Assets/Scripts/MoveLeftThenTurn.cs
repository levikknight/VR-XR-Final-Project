//  Levi Knight
//  07-09-2021
//  MidTerm Project
//  "Worlds Hardest Game in 3D"

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftThenTurn : MonoBehaviour
{
    private float speed = -6.0f;
    bool turn = true;
    bool revers = true;
    Vector3 move;
    Rigidbody enemyRb;

    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        move = Vector3.right;
    }

    void Update()
    {
        transform.Translate(move * Time.deltaTime * speed);  // Moves at a constant speed
    }

    private void OnTriggerEnter(Collider other)  // When the enemy collides with a wall it will call these two functions and ultimatly turn right.
    {
        if (other.CompareTag("EnemyDirector"))
        {
            FlipSpeed();
            FlipDirection();
        }
    }

    private void FlipSpeed()        // inverse speed everyother time the function is called.
    {
        if (revers)
        {
            speed *= -1.0f;
            revers = false;
        }
        else
        {
            revers = true;
        }
    }

    private void FlipDirection()        // Change the direction of travel everyother time the function is called.
    {
        if (turn)
        {
            move = Vector3.forward;
            turn = false;
        }
        else
        {
            move = Vector3.right;
            turn = true;
        }
    }


}
