using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Monetization;
public class Ads : MonoBehaviour
{
    //trying to implement ads for the game

    private string Store_id = "3276222";
    private string Banner_ads = "banner";
    private string Intertitial = "inter";
    private string Video_ads_reward = "rewardedVideo";

    void Start()
    {
        Monetization.Initialize(Store_id, true);

        if (Monetization.IsReady(Intertitial))
        {
            ShowAdPlacementContent ad = null;
            ad = Monetization.GetPlacementContent(Intertitial) as ShowAdPlacementContent;

            if (ad != null)
            {
                ad.Show();
            }

        }


    }

    
    void Update()
    {

       


    }
}
