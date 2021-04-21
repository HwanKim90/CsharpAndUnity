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
    public float attackDelay = 3f;
    // 누적 시간
    float currTime = 0f;
    // 공격력
    public float attackPower = 10f;
    // 이동가능 범위
    public float moveDistance = 20f;
    // 초기 위치값
    Vector3 originPos;

    // 애니메이터
    Animator anim;

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

        // Animator 세팅
        anim = GetComponentInChildren<Animator>();
    }

    
    void Update()
    {
        // 만약에 GameState가 Play가 아닐때
        if (GameManager.instance.state != GameManager.GameState.Play)
        {
            return; // 여기서 함수 끝나고 if문 밑에 코드 실행안함
        }

        // 현재 상태에 따라 정해진 기능 수행하고 싶다.
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
        // 만일 플레이어와의 거리가 액션 시작 범위에 들어오면 Move 상태로 전이
        float dist = Vector3.Distance(transform.position, player.position);
        if (dist < findDistance)
        {
            state = EnemyState.Move;
            print("상태 전환 : Idel -> Move");
            // move 애니로 변경
            anim.SetTrigger("Move");
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
            // Attack 애니로 변경
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
                
                currTime = 0;
                // Attack 애니로 변경
                anim.SetTrigger("Attack");
            }
        }
        else
        {
            // 이동 상태로 전환한다.
            state = EnemyState.Move;
            print("상태 전환 : Attack -> Move");
            // Move 애니로 변경
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
        

        // 만약에 초기위치와 나의위의 차이가 0.1보다 작으면
        if (Vector3.Distance(originPos, transform.position) < 0.1f)
        {
            // 상태를 대기(Idle)상태로!
            state = EnemyState.Idel;
            print("상태 전환 : Return -> Idle");
            // 강제로 위치를 초기위치로 세팅
            transform.position = originPos;
            anim.SetTrigger("Idle");
        }
    }
        

    IEnumerator Damaged()
    {
        yield return new WaitForSeconds(1.14f);

        //상태를 Move상태로
        state = EnemyState.Move;
        print("상태 전환 : Damaged -> Move");
        // Move 애니 실행
        

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
        // 모든 코루틴 스탑
        StopAllCoroutines();

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
            // Damaged 애니 실행
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

    


            
       
        


