//  Levi Knight
//  07-28-2021
//  Final Project
//  "Worlds Hardest Game in 3D"

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRightAndLeft : MonoBehaviour
{
    private float speed = 6f;
    Rigidbody enemyRb;

    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);  // Moves at a constant speed
    }

    private void OnTriggerEnter(Collider other)  // When the enemy collides with a wall it will reverse course
    {
        if (other.CompareTag("Wall"))
        {
            speed *= -1;
        }
    }
}
