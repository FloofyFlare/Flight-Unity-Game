using System.Collections;
using UnityEngine;

public class SprayBottle : MonoBehaviour {

    [SerializeField] private float timeToShoot;
    public GameObject water;
    [SerializeField] Transform spraybottleTransform;
    public bool pause;
    public float sprayOffset;
    [SerializeField] private GameObject overlayController;

    void Start()
    {
        StartCoroutine(JumpTimer());
       
    }
	void Update () {
        overlayController = GameObject.Find("OverlayController");

        Overlay overlay = overlayController.GetComponent<Overlay>();

        pause = overlay.pause;
	}
    void spawnBullet (int zRotation, float posX ,float posY)
    {
        
        if (pause == false)
        {
            Instantiate(water, new Vector2(posX, posY), Quaternion.Euler(0, 0, zRotation));
        }
       
    }
  
    IEnumerator JumpTimer()
    {
        
        while (true)
        {

            //waits for timeToJump seconds to jump automaticaly.
            //add function call here
            spawnBullet(270,transform.position.x -0.9f, transform.position.y +sprayOffset);
            spawnBullet(255,transform.position.x -0.9f, transform.position.y +0.5f +sprayOffset);
            spawnBullet(285,transform.position.x -0.9f, transform.position.y -0.5f +sprayOffset);
            yield return new WaitForSeconds(timeToShoot);
        }
    }
    void OnTriggerEnter2D()
    {
        Destroy(this.gameObject);
    }
}
