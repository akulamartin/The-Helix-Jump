using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class theGameManager : MonoBehaviour
{
    public static bool gameOver;
    public static bool levelComplete;
    public static bool mute = false;
    public static bool isGameStarted;
    public GameObject gameOverPanel;
    public GameObject levelCompletePanel;
    public GameObject gamePlayPanel;
    public GameObject startMenuPanel;
    public static int currentLevelIndex;
    public TextMeshProUGUI currentLevelText;
    public TextMeshProUGUI nextLevelText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highhscoreText;
    public static int numberOfpassedRings;
    public Slider gameProgressSlider;
    public static int score = 0;

    // Start is called before the first frame update
    private void Awake()
    {
        currentLevelIndex = PlayerPrefs.GetInt("currentLevelIndex", 1);
    }

    void Start()
    {
        numberOfpassedRings = 0;
        Time.timeScale = 1;
        isGameStarted = gameOver = levelComplete = false;
        highhscoreText.text = "Best Score\n" + PlayerPrefs.GetInt("Highscore", 0);
        AdManager.instance.RequestInterstitial();
    }

    // Update is called once per frame
    void Update()
    {
        currentLevelText.text = currentLevelIndex.ToString();
        nextLevelText.text = (currentLevelIndex + 1).ToString();
        int progress = numberOfpassedRings * 100 / FindObjectOfType<HelixManager>().numberOfRings;
        gameProgressSlider.value = progress;
        scoreText.text = score.ToString();
        
        if (Input.touchCount>0 && Input.GetTouch(0).phase ==TouchPhase.Began && !isGameStarted){
            if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                return;
            isGameStarted = true;
            gamePlayPanel.SetActive(true);
            startMenuPanel.SetActive(false);
        }

        if(Input.GetMouseButtonDown(0) && !isGameStarted)
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return;
            isGameStarted = true;
            gamePlayPanel.SetActive(true);
            startMenuPanel.SetActive(false);
        }

        if (gameOver)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);

            if (Input.GetButtonDown("Fire1"))
            {
                if (score > PlayerPrefs.GetInt("Highscore",0))
                {
                    PlayerPrefs.SetInt("Highscore",score);   
                }
                score = 0;
                SceneManager.LoadScene("Level");
            }
            if (Random.Range(0,3)==0)
            {
                AdManager.instance.showInterstitial();    
            }
            
        }

        if (levelComplete)
        {

            levelCompletePanel.SetActive(true);

            if (Input.GetButtonDown("Fire1"))
            {
                PlayerPrefs.SetInt("currentLevelIndex", currentLevelIndex + 1);
                SceneManager.LoadScene("Level");
            }
        }
    }
}
