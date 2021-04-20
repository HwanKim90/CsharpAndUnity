using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    // enum(������)
    enum EnemyState
    {
        Idel,
        Move,
        Attack,
        Return,
        Damaged,
        Die
    }
    // maxHP
    float maxHP = 100f;
    // ���� HP
    float hp;
    // ���¸� ���� ����
    EnemyState state;
    // Player
    Transform player;
    // Player �߰� ����
    public float findDistance = 8f;
    // ���� ���� ����
    public float attackDistance = 2f;
    // �̵� �ӷ�
    public float moveSpeed = 3f;
    // ���� ��� �ð�
    public float attackDelay = 1f;
    // ���� �ð�
    float currTime = 0f;
    // ���ݷ�
    public float attackPower = 10f;
    // �̵����� ����
    public float moveDistance = 20f;
    // �ʱ� ��ġ��
    Vector3 originPos;

    void Start()
    {
        // �ʱ⿡�� Idle����
        state = EnemyState.Idel;

        // Player�� TransForm
        player = GameObject.Find("Player").transform;

        // �ʱ� ��ġ�� ����
        originPos = transform.position;

        // hp �ʱ� ����
        hp = maxHP;
    }

    
    void Update()
    {
        // ���� ���¿� ���� ������ ��� �����ϰ� �ʹ�.
        switch(state)
        {
            case EnemyState.Idel:
                Idle();
                break;
            case EnemyState.Move:
                Move();
                break;
            case EnemyState.Attack:
                Attack();
                break;
            case EnemyState.Return:
                Return();
                break;
            case EnemyState.Damaged:
                //Damaged();
                break;
            case EnemyState.Die:
                //Die();
                break;
        }
    }
           


    
    void Idle()
    {
        // ���� �÷��̾���� �Ÿ��� �׼� ���� ������ ������ Move ���·� ����
        float dist = Vector3.Distance(transform.position, player.position);
        if (dist < findDistance)
        {
            state = EnemyState.Move;
            print("���� ��ȯ : Idel -> Move");
        }
    }

    void Move()
    {
        // ���࿡ ���� ��ġ�� �ʱ� ��ġ�� �Ÿ��� �̵����ɹ����� �����
        if (Vector3.Distance(transform.position, originPos) > moveDistance)
        {
            // ���� ���¸� Return���� ��ȯ
            state = EnemyState.Return;
            print("���� ��ȯ : Move -> Return");
        }
        //float dist = Vector3.Distance(transform.position, player.position);
        // ���࿡ �÷��̾���� �Ÿ��� ���ݰ��ɹ����� ���Դٸ�
        else if (Vector3.Distance(transform.position, player.position) < attackDistance)
        {
            // ���ݻ��·� ��ȯ
            state = EnemyState.Attack;
            print("���� ��ȯ : Move -> Attack");
            // �����ð��� ���� ���ð���ŭ �̸� ������� ����.
            currTime = attackDelay;
        }
        else
        {
            // �÷��̾ ���� ��������
            // 1.������ ���ϰ�
            Vector3 dir = player.position - transform.position;
            dir.Normalize();
            // 2.�� �������� ��������.
            transform.position += dir * moveSpeed * Time.deltaTime;
        }
    }




    void Attack()
    {
        float dist = Vector3.Distance(transform.position, player.position);
        // ���࿡ �÷��̾���� �Ÿ��� ���ݹ����� �ִٸ� �����Ѵ�.
        if (dist < attackDistance)
        {
            currTime += Time.deltaTime;
            // �����ð��� ������ ����!
            if (currTime > attackDelay)
            {
                // PlyaerMove �� DamageAction�Լ��� ����
                // 1.PlayerMove ������Ʈ�� ��������.
                //PlayerMove pm = player.GetComponent<PlayerMove>();
                //// 2.DamageAction ����
                //pm.DamagedAction(attackPower);
                player.GetComponent<PlayerMove>().DamagedAction(attackPower);
                currTime = 0;
            }
        }
        else
        {
            // �̵� ���·� ��ȯ�Ѵ�.
            state = EnemyState.Move;
            print("���� ��ȯ : Attack -> Move");
        }
    }
    void Return()
    {
        // �ʱ���ġ�� ���� ������ ���ϰ�
        Vector3 dir = originPos - transform.position;
        dir.Normalize();
        // �ד������� ��������.
        transform.position += dir * moveSpeed * Time.deltaTime; 

        // ���࿡ �ʱ���ġ�� �������� ���̰� 0.1���� ������
        if (Vector3.Distance(originPos, transform.position) < 0.1f)
        {
            // ���¸� ���(Idle)���·�!
            state = EnemyState.Idel;
            print("���� ��ȯ : Return -> Idle");
            // ������ ��ġ�� �ʱ���ġ�� ����
            transform.position = originPos;
        }
    }
        

    IEnumerator Damaged()
    {
        yield return new WaitForSeconds(1);

        //���¸� Move���·�
        state = EnemyState.Move;
        print("���� ��ȯ : Damaged -> Move");

        //currTime += Time.deltaTime;
        ////�����ð��� ������(�´� ��Ǹ�ŭ ��ٷȴٰ�)
        //if (currTime > 1)
        //{
        //    //���¸� Move���·�
        //    state = EnemyState.Move;
        //    print("���� ��ȯ : Damaged -> Move");
        //    currTime = 0;
        //}

    }

    void Die()
    {
        Destroy(gameObject);
    }

    // Hp UI
    public GameObject hpUI;
    public void HitEnemy(float damage)
    {
        //���� hp�� damage��ŭ �ٿ�����
        hp -= damage;

        // hpUI -> slider ������Ʈ ��������
        Slider slider = hpUI.GetComponent<Slider>();
        // value ���� ��������.
        slider.value = hp / maxHP;

        // ���࿡ hp�� 0���� ���ų� ������
        if (hp <= 0)
        {
            // ���� ���¸� Die ���·�
            state = EnemyState.Die;
            print("���� ��ȯ : Any State -> Die");
            // Die�Լ� ����
            Die();
        }
        else
        {
            // ������¸� Damaged ���·�
            state = EnemyState.Damaged;
            print("���� ��ȯ : Any State -> Damaged");
            // Damaged�Լ� ����
            StartCoroutine(Damaged());
        }
    }
}
            
       
        


