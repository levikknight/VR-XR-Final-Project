//  Levi Knight
//  07-30-2021
//  Final Project
//  "Worlds Hardest Game in 3D"

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private int health;
    Rigidbody enemyRb;
    private PlayQuickSound playQuickSound;
    private PlayAnotherQuickSound playAnotherQuickSound;

    public Material fullHealth;
    public Material halfHealth;
    public Material lowHealth;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        playQuickSound = GetComponent<PlayQuickSound>();
        playAnotherQuickSound = GetComponent<PlayAnotherQuickSound>();
        health = 5;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall")  || other.CompareTag("EnemyDirector"))       // When the enemy hits the wall or an enemyDirector call the script too play a sound.
        {
            playQuickSound.Play();
        } else if (other.CompareTag("Dart"))    // When a dart hits the enemy reduce health, destroy the dart, and call the UpdateHealthDisplay method.
        {
            health -= 1;
            Destroy(other.gameObject);
            UpdateHealthDisplay();
            playAnotherQuickSound.Play();
        }

    }

    private void UpdateHealthDisplay()      // Change the color of the enemy acording the health that it has remaining.
    {
        if (health == 3)
        {
            gameObject.GetComponent<MeshRenderer> ().material = halfHealth;
        } else if (health == 1)
        {
            gameObject.GetComponent<MeshRenderer> ().material = lowHealth;
        } else if (health == 0)
        {
            Destroy(gameObject);
        }
    }
}
