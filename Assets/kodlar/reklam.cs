using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class reklam : MonoBehaviour
{
    private InterstitialAd interstitial;
    static reklam reklamKontrol;
    void Start()
    {
        if (reklamKontrol == null)
        {
            DontDestroyOnLoad(gameObject);
            reklamKontrol = this;
            // 1. aşama
#if UNITY_ANDROID
            string appId = "ca-app-pub-2789041706785766~9369744246";
#elif UNITY_IPHONE
            string appId = "ca-app-pub-3940256099942544~1458002511";
#else
        string appId = "unexpected_platform";
#endif

            // Initialize the Google Mobile Ads SDK.
            MobileAds.Initialize(appId);

            //2. aşama

#if UNITY_ANDROID
            string adUnitId = "ca-app-pub-3940256099942544/1033173712";
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-3940256099942544/4411468910";
#else
        string adUnitId = "unexpected_platform";
#endif


            this.interstitial = new InterstitialAd(adUnitId);


            // 3. aşama
            AdRequest request = new AdRequest.Builder().AddTestDevice("2077ef9a63d2b398840261c8221a0c9b").Build();
            this.interstitial.LoadAd(request);

            // 4. aşama


        }
        else
        {
            Destroy(gameObject);
        }



    }


    public void reklamiGetir()
    {
        if (interstitial.IsLoaded())
        {
            interstitial.Show();
        }

        reklamKontrol = null;
        Destroy(gameObject);

    }
}
