using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour
{
    
    public float speed;
    public bool start = false;
    public bool exception = false;
    public GameObject playerObject;
    
    void Update()
    {
        Player player = playerObject.GetComponent<Player>();

        if (Input.GetMouseButtonDown(0))
        {
            start = true;
           
        }
        if (exception)
        {
            start = true;
            
        }
        if (start && player.alive)
        {
            transform.Translate(Vector2.right * Time.deltaTime * speed);
        }
    }
}
