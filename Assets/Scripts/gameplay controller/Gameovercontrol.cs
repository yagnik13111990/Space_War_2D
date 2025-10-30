using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gameovercontrol : MonoBehaviour
{
    public static Gameovercontrol instance;

    [SerializeField]
    private Canvas PlayerInfoCanvas, ShipAndMeteorInfoCanvas, GameOverCanvas;

    [SerializeField]
    private Text CurrentWaveScore, CurrentShipDestroyedScore, CurrentMeteorDestroyedScore;

    [SerializeField]
    private Text HighestWaveScore, HighestShipDestroyedScore, HighestMeteorDestroyedScore;

    private int currentwave, currentshipdestroyed, currentmeteordestroyed;

    private void Awake()
    {
        if(instance == null)
            instance = this;
    }

    public void OpenGameOverPanel()
    {
        PlayerInfoCanvas.enabled = false;
        ShipAndMeteorInfoCanvas.enabled = false;
        GameOverCanvas.enabled = true;

        //current score

         currentwave = UiControl.Instance.GetWaveCount();
         currentshipdestroyed = UiControl.Instance.GetShipCount();
         currentmeteordestroyed = UiControl.Instance.GetMeteorCount();

        currentwave--;

        CurrentWaveScore.text = "wave: " + currentwave;
        CurrentShipDestroyedScore.text = "x" + currentshipdestroyed;
        CurrentMeteorDestroyedScore.text = "x" + currentmeteordestroyed;

        //high score
        Calcualtehighscore(currentwave, currentshipdestroyed, currentmeteordestroyed);

    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    void Calcualtehighscore(int wavecurr , int shipcurr ,int meteorcurr)
    {
        int wave_high = PlayerPrefs.GetInt("wave");
        int ship_high = PlayerPrefs.GetInt("ship");
        int meteor_high = PlayerPrefs.GetInt("meteor");

        if (currentwave > wave_high)
            PlayerPrefs.SetInt("wave", wavecurr);

        if (currentshipdestroyed > ship_high)
            PlayerPrefs.SetInt("ship", shipcurr);

        if (currentmeteordestroyed > meteor_high)
            PlayerPrefs.SetInt("meteor", meteorcurr);


       HighestWaveScore.text = "Wave :" + PlayerPrefs.GetInt("wave");
       HighestShipDestroyedScore.text = "x" + PlayerPrefs.GetInt("ship");
       HighestMeteorDestroyedScore.text = "x" + PlayerPrefs.GetInt("meteor");

    }
}
