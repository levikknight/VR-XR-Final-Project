using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchProjectile : MonoBehaviour
{
    public GameObject projectile;
    public float launchVelocity = 700f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Fire()
    {
        //Debug.Log("BIG KABOOM AND SMASH!");
        GameObject bullet = Instantiate(projectile, transform.position, transform.rotation);

        bullet.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, launchVelocity, 0));
    }
}
