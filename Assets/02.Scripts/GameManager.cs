using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isGameStart;
    public GameObject titlePanel;

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

    public void GameStart()
    {
        Debug.Log("게임 시작");
        isGameStart = true;
        titlePanel.SetActive(false);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
