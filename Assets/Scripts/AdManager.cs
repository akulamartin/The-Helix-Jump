using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;
public class AdManager : MonoBehaviour
{
    private BannerView bannerAd;
    private InterstitialAd interstitial;
    public static AdManager instance;
    private RewardedAd rewardBasedVideoAd;
    bool isRewarded = false; 
    // Start is called before the first frame update

    private void Awake() {
        if (instance == null)
        {
            instance = this;
        }
        else{
            Destroy(gameObject);
            return;
        }
    }
    void Start()
    {
        MobileAds.Initialize(InitializationStatus => { });
        this.RequestRewardBasedVideo();
        //this.rewardBasedVideoAd = RewardedAd.Instance;
        this.rewardBasedVideoAd.OnUserEarnedReward += this.HandleRewardBasedVideoRewarded;
        this.rewardBasedVideoAd.OnAdClosed += this.HandleRewardBasedVideoClosed;
        
        
        this.RequestBanner();
    }

    private void RequestBanner()
    {
        string adUnitId = "ca-app-pub-3940256099942544/6300978111";
        bannerAd = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Bottom);
        this.bannerAd.LoadAd(this.CreateAdRequest());
    }

    private AdRequest CreateAdRequest(){
        return new AdRequest.Builder().Build();
    }


    public void RequestInterstitial()
    {
        string adUnitId = "ca-app-pub-3940256099942544/1033173712";
        if (this.interstitial != null)
        {
            this.interstitial.Destroy();
        }

        this.interstitial = new InterstitialAd(adUnitId);
        this.interstitial.LoadAd(this.CreateAdRequest());
    }
    // Update is called once per frame
    void Update()
    {
        if (isRewarded)
        {
            isRewarded = false;
        }
    }

    public void showInterstitial(){
        if (this.interstitial.IsLoaded())
        {
            interstitial.Show();
        }
        else{

        }
    }

    public void RequestRewardBasedVideo()
    {
        string adUnitId = "ca-app-pub-3940256099942544/5224354917";
        this.rewardBasedVideoAd = new RewardedAd(adUnitId);

        this.rewardBasedVideoAd.LoadAd(this.CreateAdRequest());
    }
    public void ShowRewardBasedVideo()
    {
        if (this.rewardBasedVideoAd.IsLoaded())
        {
            this.rewardBasedVideoAd.Show();
        }
    }

    #region RewardBasedVideo callback handlers

    public void HandleRewardBasedVideoClosed(object sender, EventArgs args)
    {
        this.RequestRewardBasedVideo();
    }

    public void HandleRewardBasedVideoRewarded(object sender, Reward args)
    {
        isRewarded = true;
    }

    #endregion
}
