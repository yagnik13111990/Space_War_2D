using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuCon : MonoBehaviour
{
    [SerializeField]
    private Canvas highscoreCanvas, mainmenuCanvas;

    [SerializeField]
    private Text shipdestroyedHigh, waveHigh, meteorHigh;

    public void OpenCloseHighScore(bool open)
    {
        mainmenuCanvas.enabled = !open;
        highscoreCanvas.enabled = open;

        if (open)
            DisplayHighscore();
    }

    public void setTrue()
    {
        OpenCloseHighScore(true);
    }

    public void setfalse()
    {
        OpenCloseHighScore(false);
    }

    void DisplayHighscore()
    {
        waveHigh.text = "Wave Survived :" + PlayerPrefs.GetInt("wave");
        shipdestroyedHigh.text = "x" + PlayerPrefs.GetInt("ship");
        meteorHigh.text = "x" + PlayerPrefs.GetInt("meteor");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

  
}
