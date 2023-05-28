using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AgeOverlay : MonoBehaviour
{
    public int age;
    public GameObject ageOverlay;
    public Text text_box;
    public void LoadAge()
    {
        Age data = SaveSystem.LoadAge();
        age = 0;
        age = data.age;
        Debug.Log(age);
    }
    // Start is called before the first frame update
    void Start()
    {
        LoadAge();
        if (age == 0)
        {
            ageOverlay.SetActive(true);

        }
    }

    // Update is called once per frame
    void Update()
    { 

        text_box.text = (age.ToString("0"));
        
        
       
           
        

    }
    public void AgeUp()
    {
        if (100 > age)
        {
            age++;
        }
    }
    public void AgeDown()
    {
        if(age > 0)
        age--;
    }
    public void Save()
    {

        SaveSystem.SaveAge(this);
        ageOverlay.SetActive(false);
    }
}
