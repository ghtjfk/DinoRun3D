using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isGameStart;
    public GameObject titlePanel;
    public GameObject gamePanel;
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

    void Start()
    {
        Time.timeScale = 0f;
        progressBar.value = 0f;
        titlePanel.SetActive(true);
        gamePanel.SetActive(false);
        nowStageText.text = MapManager.instance.GetStage().ToString();
        nextStageText.text = (MapManager.instance.GetStage()+1).ToString();
    }

    void Update()
    {
        SetDistanceProgressBar();
    }
}
