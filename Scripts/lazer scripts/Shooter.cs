using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    [SerializeField] private float timeToShoot;
    public GameObject water;
    [SerializeField] Transform spraybottleTransform;
    public bool pause;
    private bool onlyOnce;
    public int Rotation;
    public GameObject shooter;
    public GameObject firingMarker;

   
    public void spawnBullet(float posX, float posY)
    {

        
        
            GameObject childGameObject = Instantiate(water, new Vector2(posX, posY), transform.rotation);


    }
    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (onlyOnce == false)
            {
                StartCoroutine(JumpTimer());
                onlyOnce = true;
            }
        }
    }
   

    IEnumerator JumpTimer()
    {

        while (true)
        {

            //waits for timeToJump seconds to jump automaticaly.
            //add function call here
            spawnBullet(firingMarker.transform.position.x, firingMarker.transform.position.y);
            yield return new WaitForSeconds(timeToShoot);
        }
    }
}