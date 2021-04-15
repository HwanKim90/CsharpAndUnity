using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
    public Text textTitle;

    float alpha = 0;
    float dir = 1;
    float r, g, b;
    
    void Update()
    {
        r = Random.Range(0f, 256f) * Time.deltaTime;
        g = Random.Range(0f, 256f) * Time.deltaTime;
        b = Random.Range(0f, 256f) * Time.deltaTime;
        alpha += 0.001f * dir;
        
        textTitle.color = new Color(r, g, b, alpha);

        // ���࿡ alpha�� 1���� ���ų� Ŀ���� alpha 0����
        if (alpha >= 1 || alpha <= 0) dir *= -1;
        
        
    }
        
        
        
        
    public void OnClickStart()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
