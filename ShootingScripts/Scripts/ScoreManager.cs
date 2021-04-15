using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 이거 선언해야 UI 사용가능
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    // 현재 점수
    int currScore;
    // 현재 점수 UI(TexT)
    public Text currScoreUI;

    // 베스트 점수
    int bestScore;
    // 베스트 점수 UI(Text)
    public Text bestScoreUI;

    void Start()
    {
        SetBestScore(PlayerPrefs.GetInt("BS"));
    }


    public void AddScore(int addValue)
    {
        // 1. currScore증가 (addValue만큼)
        currScore += addValue;
        
        // 2.스코어 UI 갱신
        currScoreUI.text = "Score : " + currScore;

        // 3.currScore와 bestScore 비교
        // 만약에 현재점수가 최고점수보다 커지면 
        if (currScore > bestScore)
        {
            SetBestScore(currScore);
            // 최고점수 저장
            PlayerPrefs.SetInt("BS", bestScore);
        }
    }

    void SetBestScore(int bs)
    {
        // 최고점수를 현재점수로 갱신
        bestScore = bs;
        // 최고점수UI 갱신
        bestScoreUI.text = "Score : " + bestScore;
    }

}
