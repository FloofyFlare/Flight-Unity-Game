using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedReset : MonoBehaviour
{
    public GameObject Levelmanager;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine((timedReset()));
    }

    // Update is called once per frame
   IEnumerator timedReset()
    {
        LevelManager levelManager = Levelmanager.GetComponent<LevelManager>();

        yield return new WaitForSeconds(40);

        levelManager.LoadLevel("Start Menu");
    }
}
