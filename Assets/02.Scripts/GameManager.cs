using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isGameStart;
    public GameObject titlePanel;
    public GameObject gamePanel;
    public GameObject gameOverPanel;
    public GameObject stageClearPanel;
    public Slider progressBar;

    public TextMeshProUGUI nowStageText;
    public TextMeshProUGUI nextStageText;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }

        // PlayerPrefs.DeleteAll();    // PlayerPrefs로 저장된 데이터를 싹 지움.
    }

    public void SetDistanceProgressBar()
    {
        if (isGameStart.Equals(false))
        {
            return;
        }

        // 전체 거리 중 Dino의 위치 계산
        float goalDistance = DinoController.instance.transform.position.z / MapManager.instance.GetGoalDistance();
        progressBar.value = goalDistance;
    }

    public void GameStart()
    {
        Debug.Log("게임 시작");
        isGameStart = true;
        Time.timeScale = 1f;
        titlePanel.SetActive(false);
        gamePanel.SetActive(true);
    }

    public void ReStartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void GameOver()
    {
        SoundManager.instance.GameOverSoundPlay();  // 효과음 실행
        isGameStart = false;
        Time.timeScale = 0f;
        gamePanel.SetActive(false);
        gameOverPanel.SetActive(true);
    }

    public void StageClear()
    {
        SoundManager.instance.GameClearSoundPlay();  // 효과음 실행
        isGameStart=false;
        Time.timeScale = 0f;
        gamePanel.SetActive(false);
        stageClearPanel.SetActive(true);
    }

    void Start()
    {
        Time.timeScale = 0f;
        progressBar.value = 0f;
        titlePanel.SetActive(true);
        gamePanel.SetActive(false);
        gameOverPanel.SetActive(false);
        stageClearPanel.SetActive(false);
        nowStageText.text = MapManager.instance.GetStage().ToString();
        nextStageText.text = (MapManager.instance.GetStage()+1).ToString();
    }

    void Update()
    {
        SetDistanceProgressBar();
    }
}
