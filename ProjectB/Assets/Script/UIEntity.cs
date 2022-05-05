using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIEntity : MonoBehaviour
{
    public GameObject GameTitle;
    public GameObject GameOverTitle;
    public GameObject GameCompleteTitle;
    public GameObject PlayButton;
    public GameObject RestartButton;
    public GameObject QuitButton;
    public GameObject MenuButton;
    public GameObject PauseButton;
    public GameObject PauseQuitButton;
    public GameObject PauseGoButton;
    public GameObject ReturnButton;
    public GameObject Panel;
    public GameObject Menu;
    public GameObject Score;
    public GameObject FinalScore;
    public GameObject RecentCamera;
    public Text Camera;
    public Text FinalScoreText;
    public static bool IsPlaying = false;
    public static UIEntity Instance;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        GameTitle.SetActive(true);
        Menu.SetActive(false);
        GameOverTitle.SetActive(false);
        GameCompleteTitle.SetActive(false);
        ReturnButton.SetActive(false);
        RestartButton.SetActive(false);
        PlayButton.SetActive(true);
        MenuButton.SetActive(true);
        QuitButton.SetActive(true);
        Score.SetActive(false);
        PauseButton.SetActive(false);
        PauseQuitButton.SetActive(false);
        PauseGoButton.SetActive(false);
        FinalScore.SetActive(false);
        RecentCamera.SetActive(false);
    }
    public void CheckMenu()
    {
        GameTitle.SetActive(false);
        PauseButton.SetActive(false);
        ReturnButton.SetActive(true);
        PlayButton.SetActive(false);
        MenuButton.SetActive(false);
        QuitButton.SetActive(false);
        Menu.SetActive(true);
        Score.SetActive(false);
    }
    public void Return()
    {
        Start();
    }
    public void GameStart()
    {
        IsPlaying = true;
        PointEntity.point = 100;
        WalkingPath.Arrive_count = 0;
        jailEntity.Jail_count = 0;
        Score.SetActive(true);
        PauseButton.SetActive(true);
        PauseQuitButton.SetActive(false);
        PauseGoButton.SetActive(false);
        GameTitle.SetActive(false);
        PlayButton.SetActive(false);
        MenuButton.SetActive(false);
        QuitButton.SetActive(false);
        Panel.SetActive(false);
        RecentCamera.SetActive(true);
        Camera.text = "<size=25><color=red>Free Camera</color></size>\n";
    }
    public void GameOver()
    {
        IsPlaying = false;
        Panel.SetActive(true);
        GameOverTitle.SetActive(true);
        RestartButton.SetActive(true);
        QuitButton.SetActive(true);
        PauseButton.SetActive(false);
        PauseGoButton.SetActive(false);
        PauseQuitButton.SetActive(false);
        Score.SetActive(false);
        RecentCamera.SetActive(false);
    }    
    public void GameComplete()
    {
        IsPlaying = false;
        Panel.SetActive(true);
        GameCompleteTitle.SetActive(true);
        RestartButton.SetActive(true);
        QuitButton.SetActive(true);
        PauseButton.SetActive(false);
        PauseGoButton.SetActive(false);
        PauseQuitButton.SetActive(false);
        Score.SetActive(false);
        FinalScore.SetActive(true);
        RecentCamera.SetActive(false);
        FinalScoreText.text = "<size=18>Final Score</size>\n" + PointEntity.point;
    }
    public void PauseGame()
    {
        PauseButton.SetActive(false);
        PauseGoButton.SetActive(true);
        PauseQuitButton.SetActive(true);
        Panel.SetActive(true);
        Time.timeScale = 0;
    }
    public void PauseGo()
    {
        Time.timeScale = 1;
        PauseGoButton.SetActive(false);
        PauseQuitButton.SetActive(false);
        PauseButton.SetActive(true);
        Panel.SetActive(false);
    }
    public void QuitGame()
    {
        Finish();
    }
    void Finish()
    {
        //Debug.Log("Try again!");
        UnityEditor.EditorApplication.isPlaying = false;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
        Start();
    }
    
}
