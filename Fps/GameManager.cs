using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // 자기자신을 담을 수 있는 변수(딱 하나만 존재)
    public static GameManager instance;

    // 게임 상태
    public enum GameState
    {
        Ready,
        Play,
        GameOver
    }

    // 현재상태
    public GameState state;
    // 상태 UI
    public Text stateUI;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;   
        }
    }

    void Start()
    {
        // 처음 상태 설정
        state = GameState.Ready;
        // 준비 -> 플레이 코루틴 시작
        StartCoroutine(ReadyToPlay());
    }

    
    void Update()
    {
        
    }

    IEnumerator ReadyToPlay()
    {
        // 2초 기다린다.
        yield return new WaitForSeconds(2);
        // 상태 Text를 "Start"로 바꾼다.
        stateUI.text = "Start!!";
        // 1초 기다린다.
        yield return new WaitForSeconds(1);
        // 상태 Text를 비활성화
        stateUI.gameObject.SetActive(false);
        // 현재 상태를 Play로
        state = GameState.Play;
    }

    public void GameOver()
    {
        // 상태 Text를 활성화
        stateUI.gameObject.SetActive(true);
        // 상태 Text를 "Game Over!!"로 바꾼다.
        stateUI.text = "Game Over!!";
        // 현재상태를 GameOver로
        state = GameState.GameOver;
    }

    public bool isPlaying()
    {
        return state == GameState.Play;
    }
}
        
       
