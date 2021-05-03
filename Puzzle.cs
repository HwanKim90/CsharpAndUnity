using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puzzle : MonoBehaviour
{
    // 카드 배열
    public Image[] cards;
    // 카드 값
    public int[] cardValues;
    // 선택한 카드 값
    int selectCardValue;
    // 같은 값을 갖는 카드 리스트
    public List<int> sameCardList;

    public int size = 100;
    public int sizeH = 4;
    public int sizeV = 3;
    int index;

    private void Start()
    {
        // 카드 값 공간 할당
        cardValues = new int[cards.Length];
        sameCardList = new List<int>();
        InitCard();
    }

    void InitCard()
    {
        // 같은 카드 리스트 리셋
        sameCardList.Clear();

        // 카드 값 세팅
        for (int i = 0; i < cardValues.Length; i++)
        {
            cardValues[i] = Random.Range(0, 2);
            // 카드 색 세팅
            // 0이면 흰색, 1이며 빨간색
            if (cardValues[i] == 0)
            {
                cards[i].color = new Color(1, 1, 1, 0.5f); //Color.white;
            }
            else
            {
                cards[i].color = new Color(1, 0, 0, 0.5f);
            }
        }
    }
        

    void Update()
    {
        // 1번키를 누르면 카드 리셋
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            InitCard();
        }

        // 마우스 왼쪽 버튼을 클릭하면
        if (Input.GetButtonDown("Fire1"))
        {
            RectTransform rt = cards[0].GetComponent<RectTransform>();
            
            index = (int)(Input.mousePosition.x - rt.anchoredPosition.x) / size + 
                    (int)(Input.mousePosition.y - rt.anchoredPosition.y) / size * sizeH;
            
            // 현재 클릭한 위치에 숫자가 print되게하자.
            print(index);

            // 선택한놈 추가
            sameCardList.Add(index);
            // 선택한 카드값 저장
            selectCardValue = cardValues[index];
            FindNearCard(index);

            // 같은 카드 리스틑 색 변경
            for (int i = 0; i < sameCardList.Count; i++)
            {
                cards[sameCardList[i]].color = Color.green;
            }
        }
    }

    void FindNearCard(int index)
    {
        if (index / sizeH < sizeV - 1)
        {
            int up = index + sizeH;
            print("위 : " + up);
            FindSameCard(up);
        }

        if (index / sizeH > 0)
        {
            int down = index - sizeH;
            print("아래 : " +  down);
            FindSameCard(down);
        }
        
        if (index % sizeH > 0)
        {
            int left = index - 1;
            print("왼쪽 : " + left);
            FindSameCard(left);
        }

        if (index % sizeH < sizeH - 1)
        {
            int right = index + 1;
            print(" 오른쪽 : " + right);
            FindSameCard(right);

        }
    }

    void FindSameCard(int index)
    {
        // 찾은 값이 cardValue리스트에 존재하면 함수를 나가라.
        for (int i = 0; i < sameCardList.Count; i++)
        {
            if (sameCardList[i] == index) return;
        }

        // 만약에 index에 해당되는 카드값이 내가 선택한 카드값과 같다면
        if (cardValues[index] == selectCardValue)
        {
            sameCardList.Add(index);
            // 추가한 놈에서 다시 검사
            FindNearCard(index);

        }
    }

            
        
}
