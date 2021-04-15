using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// �̰� �����ؾ� UI ��밡��
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    // ���� ����
    int currScore;
    // ���� ���� UI(TexT)
    public Text currScoreUI;

    // ����Ʈ ����
    int bestScore;
    // ����Ʈ ���� UI(Text)
    public Text bestScoreUI;

    void Start()
    {
        SetBestScore(PlayerPrefs.GetInt("BS"));
    }


    public void AddScore(int addValue)
    {
        // 1. currScore���� (addValue��ŭ)
        currScore += addValue;
        
        // 2.���ھ� UI ����
        currScoreUI.text = "Score : " + currScore;

        // 3.currScore�� bestScore ��
        // ���࿡ ���������� �ְ��������� Ŀ���� 
        if (currScore > bestScore)
        {
            SetBestScore(currScore);
            // �ְ����� ����
            PlayerPrefs.SetInt("BS", bestScore);
        }
    }

    void SetBestScore(int bs)
    {
        // �ְ������� ���������� ����
        bestScore = bs;
        // �ְ�����UI ����
        bestScoreUI.text = "Score : " + bestScore;
    }

}
