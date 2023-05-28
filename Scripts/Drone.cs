using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{

    public Rigidbody2D rb2D;
    public float flightForce;
    public Animator animator;
    public float timeToJump;
    public float speed;
    private bool alive = true;
    // Use this for initialization
    void Start()
    {
        
        StartCoroutine(JumpTimer());
        animator = GetComponent<Animator>();
        
    }
    void Update()
    {
        if (alive == true)
        {
            transform.Translate(Vector2.right * Time.deltaTime * speed);
        }
        else
        {
            GetComponent<Animator>().Play("Death");
            
            rb2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
    void Jump()
    {
        if (alive == true)
        {
            //fly up
            rb2D.velocity = new Vector2(transform.position.x, transform.position.y + flightForce);
            GetComponent<Animator>().Play("fly");
        }
        
    }

    IEnumerator JumpTimer()
    {
        bool jumpcontinuation = true;
        while (jumpcontinuation == true)
        {
            
            //waits for timeToJump seconds to jump automaticaly.
            Jump();
            yield return new WaitForSeconds(timeToJump);
        }
    }
    void OnCollisionEnter2D()
    {

        alive = false;

    }
}
