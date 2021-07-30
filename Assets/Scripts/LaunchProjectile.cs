//  Levi Knight
//  07-30-2021
//  Final Project
//  "Worlds Hardest Game in 3D"

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchProjectile : MonoBehaviour
{
    public GameObject projectile;
    public float launchVelocity = 700f;

    public void Fire()      // Instantiates a prefab at the location of the object that called the script and then adds to its velocity.
    {
        GameObject bullet = Instantiate(projectile, transform.position, transform.rotation);

        bullet.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, launchVelocity, 0));
    }
}
