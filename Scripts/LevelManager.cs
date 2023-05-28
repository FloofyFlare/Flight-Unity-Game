using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    //Loads lvl after x number of seconds given in the inspector
    public float autoLoadNextLevelAfter;

   

    void Start()
    {
        
        if (autoLoadNextLevelAfter == 0)
        {
            Debug.Log("Level auto load disabled");
        } else
        {
            Invoke("LoadNextLevel", autoLoadNextLevelAfter);
        }
        
    }

    //call this to load a new scene
    public void LoadLevel(string name){
		Debug.Log ("New Level load: " + name);
		SceneManager.LoadScene (name);
	}

    //call this to quit a game
	public void QuitRequest(){
		Debug.Log ("Quit requested");
		Application.Quit ();
	}

    //call this to lead the next level avalible in the Build Settings
    public void LoadNextLevel()
    {
        SceneManager.LoadScene("Start Menu");
    }
}
