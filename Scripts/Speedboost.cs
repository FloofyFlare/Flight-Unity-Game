using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speedboost : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    
    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collider)
    {
        //saving game
        Player player = collider.gameObject.GetComponent<Player>();
        
        if (player)
        {
            GetComponent<Animator>().Play("Speed Boost");
        }
    }
}
