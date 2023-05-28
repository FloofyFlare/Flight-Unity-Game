using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScript : MonoBehaviour {

    void OnTriggerEnter2D()
    {
        Destroy(this.gameObject);
    }

}