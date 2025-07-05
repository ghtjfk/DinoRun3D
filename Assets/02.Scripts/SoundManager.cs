using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource doorHit;     // door에 닿았을 때 사운드
    public AudioSource dinoDie;     // raptor가 파괴됐을 때 사운드
    public AudioSource gameClear;   // stage 클리어 때 사운드
    public AudioSource gameOver;    // gameover 때 사운드

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }
    
    public void DoorHitSoundPlay()
    {
        doorHit.Play();
    }

    public void DinoDieSoundPlay()
    {
        dinoDie.Play();
    }

    public void GameClearSoundPlay()
    {
        gameClear.Play();
    }

    public void GameOverSoundPlay()
    {
        gameOver.Play();
    }
}
