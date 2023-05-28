using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using GoogleMobileAds.Placement;
public class Admob : MonoBehaviour
{
    public int age;
    public bool under13 = true;
    // Start is called before the first frame update
    public void LoadAge()
    {
        Age data = SaveSystem.LoadAge();
        age = 0;
        age = data.age;
        Debug.Log(age);
    }
    void Start()
    {
        LoadAge();
        if (age > 13)
        {
            under13 = false;
        }
        else
        {
            RequestConfiguration requestConfiguration = new RequestConfiguration.Builder()
            .SetTagForChildDirectedTreatment(TagForChildDirectedTreatment.True)
            .SetTagForUnderAgeOfConsent(TagForUnderAgeOfConsent.True)
            .SetMaxAdContentRating(MaxAdContentRating.G)
            .build();
            MobileAds.SetRequestConfiguration(requestConfiguration);
            Debug.Log("under 13");
        }

        // Initalize the Google Mobile Ads SDK.
        MobileAds.Initialize(initStatus => { });
            //only needed if you are not using auto load
            //The name is referening the hierarchy name
            //fetches the ad

    }

  
}
