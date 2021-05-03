using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puzzle : MonoBehaviour
{
    // ī�� �迭
    public Image[] cards;
    // ī�� ��
    public int[] cardValues;
    // ������ ī�� ��
    int selectCardValue;
    // ���� ���� ���� ī�� ����Ʈ
    public List<int> sameCardList;

    public int size = 100;
    public int sizeH = 4;
    public int sizeV = 3;
    int index;

    private void Start()
    {
        // ī�� �� ���� �Ҵ�
        cardValues = new int[cards.Length];
        sameCardList = new List<int>();
        InitCard();
    }

    void InitCard()
    {
        // ���� ī�� ����Ʈ ����
        sameCardList.Clear();

        // ī�� �� ����
        for (int i = 0; i < cardValues.Length; i++)
        {
            cardValues[i] = Random.Range(0, 2);
            // ī�� �� ����
            // 0�̸� ���, 1�̸� ������
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
        // 1��Ű�� ������ ī�� ����
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            InitCard();
        }

        // ���콺 ���� ��ư�� Ŭ���ϸ�
        if (Input.GetButtonDown("Fire1"))
        {
            RectTransform rt = cards[0].GetComponent<RectTransform>();
            
            index = (int)(Input.mousePosition.x - rt.anchoredPosition.x) / size + 
                    (int)(Input.mousePosition.y - rt.anchoredPosition.y) / size * sizeH;
            
            // ���� Ŭ���� ��ġ�� ���ڰ� print�ǰ�����.
            print(index);

            // �����ѳ� �߰�
            sameCardList.Add(index);
            // ������ ī�尪 ����
            selectCardValue = cardValues[index];
            FindNearCard(index);

            // ���� ī�� �����z �� ����
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
            print("�� : " + up);
            FindSameCard(up);
        }

        if (index / sizeH > 0)
        {
            int down = index - sizeH;
            print("�Ʒ� : " +  down);
            FindSameCard(down);
        }
        
        if (index % sizeH > 0)
        {
            int left = index - 1;
            print("���� : " + left);
            FindSameCard(left);
        }

        if (index % sizeH < sizeH - 1)
        {
            int right = index + 1;
            print(" ������ : " + right);
            FindSameCard(right);

        }
    }

    void FindSameCard(int index)
    {
        // ã�� ���� cardValue����Ʈ�� �����ϸ� �Լ��� ������.
        for (int i = 0; i < sameCardList.Count; i++)
        {
            if (sameCardList[i] == index) return;
        }

        // ���࿡ index�� �ش�Ǵ� ī�尪�� ���� ������ ī�尪�� ���ٸ�
        if (cardValues[index] == selectCardValue)
        {
            sameCardList.Add(index);
            // �߰��� �𿡼� �ٽ� �˻�
            FindNearCard(index);

        }
    }

            
        
}
