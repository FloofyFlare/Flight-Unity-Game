using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public int damage;
    public float projectileSpeedx;
    public float projectileSpeedy;
    public float spin;
    public bool destroyedObject;

    // Use this for initialization

    void Update()
    {
        
        transform.Rotate(0, 0, transform.rotation.z + spin, Space.World);
    }
    //repace GetDamage with Animation changes for paper airplane
    public int GetDamage()
    {
        return damage;
    }
    public void Death()
    {
        Destroy(gameObject);

    }
    void OnCollisionEnter2D(Collision2D collider)
    {
       
        if (destroyedObject)
        {
            Destroy(this.gameObject);
            // add later on to activate an animation
        }
    }
}
