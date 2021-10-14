using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class onClickEvents : MonoBehaviour
{
    public TextMeshProUGUI soundsText;
    // Start is called before the first frame update
    void Start()
    {
        if (theGameManager.mute)
            soundsText.text = "/";
        else
            soundsText.text = "";
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void ToggleMute()
    {
        if (theGameManager.mute)
        {
            theGameManager.mute = false;
            soundsText.text = "";
        }
        else
        {
            theGameManager.mute = true;
            soundsText.text = "/ ";
        }
    }
}
