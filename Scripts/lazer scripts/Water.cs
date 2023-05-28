using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour {

        public float speed;
        [SerializeField] private bool destroyedObject;
        public Rigidbody2D rb2D;
       
    // Use this for initialization

    void Update()
        {
            rb2D.velocity = transform.right * speed;
        

    }
        //repace GetDamage with Animation changes for paper airplane
       
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
