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
    public float attackDelay = 3f;
    // ���� �ð�
    float currTime = 0f;
    // ���ݷ�
    public float attackPower = 10f;
    // �̵����� ����
    public float moveDistance = 20f;
    // �ʱ� ��ġ��
    Vector3 originPos;

    // �ִϸ�����
    Animator anim;

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

        // Animator ����
        anim = GetComponentInChildren<Animator>();
    }

    
    void Update()
    {
        // ���࿡ GameState�� Play�� �ƴҶ�
        if (GameManager.instance.state != GameManager.GameState.Play)
        {
            return; // ���⼭ �Լ� ������ if�� �ؿ� �ڵ� �������
        }

        // ���� ���¿� ���� ������ ��� �����ϰ� �ʹ�.
        switch (state)
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
            // move �ִϷ� ����
            anim.SetTrigger("Move");
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
            // Attack �ִϷ� ����
            //anim.SetTrigger("Attack");
        }
        else
        {
            MoveAction(player.position);
            
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
                
                currTime = 0;
                // Attack �ִϷ� ����
                anim.SetTrigger("Attack");
            }
        }
        else
        {
            // �̵� ���·� ��ȯ�Ѵ�.
            state = EnemyState.Move;
            print("���� ��ȯ : Attack -> Move");
            // Move �ִϷ� ����
            anim.SetTrigger("Move");
        }
    }

    public void AttackAction()
    {
        player.GetComponent<PlayerMove>().DamagedAction(attackPower);
    }

    void Return()
    {
        MoveAction(originPos);
        

        // ���࿡ �ʱ���ġ�� �������� ���̰� 0.1���� ������
        if (Vector3.Distance(originPos, transform.position) < 0.1f)
        {
            // ���¸� ���(Idle)���·�!
            state = EnemyState.Idel;
            print("���� ��ȯ : Return -> Idle");
            // ������ ��ġ�� �ʱ���ġ�� ����
            transform.position = originPos;
            anim.SetTrigger("Idle");
        }
    }
        

    IEnumerator Damaged()
    {
        yield return new WaitForSeconds(1.14f);

        //���¸� Move���·�
        state = EnemyState.Move;
        print("���� ��ȯ : Damaged -> Move");
        // Move �ִ� ����
        

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
        // ��� �ڷ�ƾ ��ž
        StopAllCoroutines();

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
            // Damaged �ִ� ����
            anim.SetTrigger("Damaged");
        }
    }

    void MoveAction(Vector3 targetPos)
    {
        
        Vector3 dir = targetPos - transform.position;
        dir.Normalize();
        transform.forward = dir;
        
        transform.position += dir * moveSpeed * Time.deltaTime;
    }
}

    


            
       
        


