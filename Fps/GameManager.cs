using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // �ڱ��ڽ��� ���� �� �ִ� ����(�� �ϳ��� ����)
    public static GameManager instance;

    // ���� ����
    public enum GameState
    {
        Ready,
        Play,
        GameOver
    }

    // �������
    public GameState state;
    // ���� UI
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
        // ó�� ���� ����
        state = GameState.Ready;
        // �غ� -> �÷��� �ڷ�ƾ ����
        StartCoroutine(ReadyToPlay());
    }

    
    void Update()
    {
        
    }

    IEnumerator ReadyToPlay()
    {
        // 2�� ��ٸ���.
        yield return new WaitForSeconds(2);
        // ���� Text�� "Start"�� �ٲ۴�.
        stateUI.text = "Start!!";
        // 1�� ��ٸ���.
        yield return new WaitForSeconds(1);
        // ���� Text�� ��Ȱ��ȭ
        stateUI.gameObject.SetActive(false);
        // ���� ���¸� Play��
        state = GameState.Play;
    }

    public void GameOver()
    {
        // ���� Text�� Ȱ��ȭ
        stateUI.gameObject.SetActive(true);
        // ���� Text�� "Game Over!!"�� �ٲ۴�.
        stateUI.text = "Game Over!!";
        // ������¸� GameOver��
        state = GameState.GameOver;
    }

    public bool isPlaying()
    {
        return state == GameState.Play;
    }
}
        
       
