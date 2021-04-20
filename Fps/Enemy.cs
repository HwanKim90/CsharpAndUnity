using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    // enum(열거형)
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
    // 현재 HP
    float hp;
    // 상태를 담을 변수
    EnemyState state;
    // Player
    Transform player;
    // Player 발견 범위
    public float findDistance = 8f;
    // 공격 가능 범위
    public float attackDistance = 2f;
    // 이동 속력
    public float moveSpeed = 3f;
    // 공격 대기 시간
    public float attackDelay = 1f;
    // 누적 시간
    float currTime = 0f;
    // 공격력
    public float attackPower = 10f;
    // 이동가능 범위
    public float moveDistance = 20f;
    // 초기 위치값
    Vector3 originPos;

    void Start()
    {
        // 초기에는 Idle상태
        state = EnemyState.Idel;

        // Player의 TransForm
        player = GameObject.Find("Player").transform;

        // 초기 위치값 설정
        originPos = transform.position;

        // hp 초기 세팅
        hp = maxHP;
    }

    
    void Update()
    {
        // 현재 상태에 따라 정해진 기능 수행하고 싶다.
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
        // 만일 플레이어와의 거리가 액션 시작 범위에 들어오면 Move 상태로 전이
        float dist = Vector3.Distance(transform.position, player.position);
        if (dist < findDistance)
        {
            state = EnemyState.Move;
            print("상태 전환 : Idel -> Move");
        }
    }

    void Move()
    {
        // 만약에 현재 위치와 초기 위치의 거리가 이동가능범위를 벗어나면
        if (Vector3.Distance(transform.position, originPos) > moveDistance)
        {
            // 현재 상태를 Return으로 전환
            state = EnemyState.Return;
            print("상태 전환 : Move -> Return");
        }
        //float dist = Vector3.Distance(transform.position, player.position);
        // 만약에 플레이어와의 거리가 공격가능범위에 들어왔다면
        else if (Vector3.Distance(transform.position, player.position) < attackDistance)
        {
            // 공격상태로 전환
            state = EnemyState.Attack;
            print("상태 전환 : Move -> Attack");
            // 누적시간을 공격 대기시간만큼 미리 진행시켜 놓자.
            currTime = attackDelay;
        }
        else
        {
            // 플레이어를 향해 움직이자
            // 1.방향을 구하고
            Vector3 dir = player.position - transform.position;
            dir.Normalize();
            // 2.그 방향으로 움직이자.
            transform.position += dir * moveSpeed * Time.deltaTime;
        }
    }




    void Attack()
    {
        float dist = Vector3.Distance(transform.position, player.position);
        // 만약에 플레이어와의 거리가 공격범위에 있다면 공격한다.
        if (dist < attackDistance)
        {
            currTime += Time.deltaTime;
            // 일정시간이 지나면 공격!
            if (currTime > attackDelay)
            {
                // PlyaerMove 의 DamageAction함수를 실행
                // 1.PlayerMove 컴포넌트를 가져오자.
                //PlayerMove pm = player.GetComponent<PlayerMove>();
                //// 2.DamageAction 실행
                //pm.DamagedAction(attackPower);
                player.GetComponent<PlayerMove>().DamagedAction(attackPower);
                currTime = 0;
            }
        }
        else
        {
            // 이동 상태로 전환한다.
            state = EnemyState.Move;
            print("상태 전환 : Attack -> Move");
        }
    }
    void Return()
    {
        // 초기위치로 가는 방향을 구하고
        Vector3 dir = originPos - transform.position;
        dir.Normalize();
        // 그뱡향으로 움직이자.
        transform.position += dir * moveSpeed * Time.deltaTime; 

        // 만약에 초기위치와 나의위의 차이가 0.1보다 작으면
        if (Vector3.Distance(originPos, transform.position) < 0.1f)
        {
            // 상태를 대기(Idle)상태로!
            state = EnemyState.Idel;
            print("상태 전환 : Return -> Idle");
            // 강제로 위치를 초기위치로 세팅
            transform.position = originPos;
        }
    }
        

    IEnumerator Damaged()
    {
        yield return new WaitForSeconds(1);

        //상태를 Move상태로
        state = EnemyState.Move;
        print("상태 전환 : Damaged -> Move");

        //currTime += Time.deltaTime;
        ////일정시간이 지나면(맞는 모션만큼 기다렸다가)
        //if (currTime > 1)
        //{
        //    //상태를 Move상태로
        //    state = EnemyState.Move;
        //    print("상태 전환 : Damaged -> Move");
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
        //현재 hp를 damage만큼 줄여주자
        hp -= damage;

        // hpUI -> slider 컴포넌트 가져오자
        Slider slider = hpUI.GetComponent<Slider>();
        // value 값을 세팅하자.
        slider.value = hp / maxHP;

        // 만약에 hp가 0보다 같거나 작으면
        if (hp <= 0)
        {
            // 현재 상태를 Die 상태로
            state = EnemyState.Die;
            print("상태 전환 : Any State -> Die");
            // Die함수 실행
            Die();
        }
        else
        {
            // 현재상태를 Damaged 상태로
            state = EnemyState.Damaged;
            print("상태 전환 : Any State -> Damaged");
            // Damaged함수 실행
            StartCoroutine(Damaged());
        }
    }
}
            
       
        


