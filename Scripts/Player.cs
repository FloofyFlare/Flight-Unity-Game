using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.IO;

public class Player : MonoBehaviour
{
    int DoOnce = 0;
    public static int ShowAd = 0;
    public float speed;
    public Rigidbody2D rb2D;
    public float flightForce;
    public bool alive = true;
    public Animator animator;
    public bool startGame = false;
    public bool collisonDeath = false;
    [SerializeField] private GameObject overlayController;
    public bool is_A_FreeStyle;
    public bool death = false;
    [SerializeField] private float waitingTime;
    [SerializeField] public int counter;
    [SerializeField] private float speedIncrease;
    [SerializeField] private bool pause;
    [SerializeField] private float speedLimit;
    public int lvlprogress;
    public int highScore;
    public bool onlyOnce = false;
    public UnityEvent Ad;
    public GameObject Levelmanager;
    public string level;
    private bool adFailure = false;

    // Use this for initialization

    void Start()
    {
        StartCoroutine(TimeCounter());

        animator = GetComponent<Animator>();

    }

    IEnumerator TimeCounter()
    {
        Overlay overlay = overlayController.GetComponent<Overlay>();

        while (alive)
        {
            // speeds up the plane
            if (speed < speedLimit && pause == false && startGame == true)
            {
                speed = speed + speedIncrease;

            }
            if (startGame == true && overlay.pause == false)
            {
                counter++;
            }
            yield return new WaitForSeconds(1);
        }

    }

    // Update is called once per frame
    void Update()
    {

        Overlay overlay = overlayController.GetComponent<Overlay>();
        pause = overlay.pause;
        if (overlay.pause == true)
        {
            rb2D.constraints = RigidbodyConstraints2D.FreezePositionY;
        }
        //access startGame bool from Destroy on Tap
        // if the game is not paused then the Plane can move 
        if (overlay.pause == false)
        {


            if (alive == true)
            {

                if (startGame == true)
                {
                    
                    //move forward
                    transform.Translate(Vector2.right * Time.deltaTime * speed);

                }


                if (Input.GetMouseButtonDown(0) && !overlay.win)
                {

                    startGame = true;

                    int onetime;
                    for (onetime = 0; onetime < 1; onetime = 1)
                    {
                        rb2D.constraints = RigidbodyConstraints2D.None;
                    }
                    rb2D.constraints = RigidbodyConstraints2D.FreezePositionX;

                    //fly up
                    rb2D.velocity = new Vector2(0, 0 );
                    rb2D.AddForce(Vector2.up * flightForce); 
                    GetComponent<Animator>().Play("fly");
                }
            }
            else
            {
                //dead animation

                GetComponent<Animator>().Play("Death");
                if (onlyOnce == false)
                {
                    overlay.DeathOverlay();
                    onlyOnce = true;
                }
                rb2D.constraints = RigidbodyConstraints2D.FreezePositionX;
                rb2D.constraints = RigidbodyConstraints2D.FreezeRotation;




                while (DoOnce == 0)
                {
                    DoOnce = 1;
                    ShowAd++;
                }
            }
        }

    }
    void OnCollisionEnter2D()
    {
        Overlay overlay = overlayController.GetComponent<Overlay>();
        if (overlay.pause == false)
        {
            alive = false;

        }

        if (is_A_FreeStyle == true)
        {
            SaveSystem.SaveScore(this);
        }

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        //saving game
        finishline finish = collider.gameObject.GetComponent<finishline>();
        string path = Application.persistentDataPath + "/player.data";
        PlayerData data = SaveSystem.LoadPlayer();

        if (!File.Exists(path))
        {
            Debug.Log("saved");
            lvlprogress = finish.thislvl;
            SaveSystem.SavePlayer(this);
        }
        if (finish && data.lvlprogress < finish.thislvl)
        {
            Debug.Log("saved");
            lvlprogress = finish.thislvl;
            SaveSystem.SavePlayer(this);
        }
        if (is_A_FreeStyle == true)
        {
            SaveSystem.SaveScore(this);
        }



        //speedboost
        Speedboost speedboost = collider.gameObject.GetComponent<Speedboost>();

        if (speedboost)
        {
            Debug.Log(speed);
            StartCoroutine(SpeedBoost());

        }
        Upboost upboost = collider.gameObject.GetComponent<Upboost>();

        if (upboost)
        {

            rb2D.AddForce(new Vector2(0, 500));
            Debug.Log("Up");

        }
    }
    

    IEnumerator SpeedBoost()
    {
        speedLimit = 10;
        speed = speedLimit;
        yield return new WaitForSeconds(2.5f);
        speed = 5.6f;
        speedLimit = 8;
        StopCoroutine(SpeedBoost());
    }
    public void ShowAdOnDeath()
    {


        Debug.Log(ShowAd);
        if (ShowAd >= 9 && adFailure == false)
        {
            
            ShowAd = 0;
            Debug.Log("Death Ad presented");
            Ad.Invoke();
        }
        else
        {
            LevelManager levelManager = Levelmanager.GetComponent<LevelManager>();
            levelManager.LoadLevel(level);
        }
    }
    public void AdFail()
    {
        adFailure = true;
    }
    public void LoadWeekSelection()
    {
    LevelManager levelManager = Levelmanager.GetComponent<LevelManager>();
    levelManager.LoadLevel("WeekSelection");
    }
   
}

