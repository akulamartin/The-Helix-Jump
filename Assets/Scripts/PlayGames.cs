using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
public class PlayGames : MonoBehaviour
{
    public TextMeshProUGUI playerScore;
    string leaderboardID = "CgkI4760wNUBEAIQAQ";
    string achievementID = "CgkI4760wNUBEAIQAA";
    public static PlayGamesPlatform platform;
    // Start is called before the first frame update
    void Start()
    {
        if (platform == null)
        {
            PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
            PlayGamesPlatform.InitializeInstance(config);
            PlayGamesPlatform.DebugLogEnabled = true;
            platform = PlayGamesPlatform.Activate();
        }

        Social.Active.localUser.Authenticate(success =>
        {
            if (success)
            {
                Debug.Log("Logged in successfully");
            }
            else
            {
                Debug.Log("Login Failed");
            }
        });
        UnlockAchievement();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowAchievements()
    {
        if (Social.Active.localUser.authenticated)
        {
            platform.ShowAchievementsUI();
        }
    }
    public void UnlockAchievement()
    {
        if (Social.Active.localUser.authenticated)
        {
            Social.ReportProgress(achievementID, 100f, success => { });
        }
    }

    public void AddScoreToLeaderboard()
    {
        if (Social.Active.localUser.authenticated)
        {
            Social.ReportScore(int.Parse(playerScore.text), leaderboardID, success => { });
        }
    }

    public void ShowLeaderboard()
    {
        if (Social.Active.localUser.authenticated)
        {
            platform.ShowLeaderboardUI();
        }
    }
}
