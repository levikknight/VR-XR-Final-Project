//  Levi Knight
//  07-09-2021
//  MidTerm Project
//  "Worlds Hardest Game in 3D"

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRightThenTurn : MonoBehaviour
{
    private float speed = 8.0f;
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

    private void OnTriggerEnter(Collider other)  // When the enemy collides with a wall it will reverse course
    {
        if (other.CompareTag("EnemyDirector"))
        {
            FlipSpeed();
            FlipDirection();
        }
    }

    private void FlipSpeed()
    {
        if (revers)
        {
            speed *= -1.0f;
            revers = false;
        } else
        {
            revers = true;
        }
    }

    private void FlipDirection()
    {
        if (turn)
        {
            move = Vector3.forward;
            turn = false;
        } else
        {
            move = Vector3.right;
            turn = true;
        }
    }


}
