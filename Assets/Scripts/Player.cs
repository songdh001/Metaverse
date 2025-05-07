using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    //만들어둔 애니메이션 호출
    Animator _Animator;
    Rigidbody2D _RigidBody;

    public float FlapForce = 6f;
    public float ForwardSpeed = 3f;
    public bool IsDead = false;
    float deathCooldown = 0f;

    bool IsFlap = false;


    public bool GodMode = false;

    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;

        //_Animator 안에 Animator에 있는 컴포넌트를 가져와서 넣어준다
        //그런데 Animator는 Player에 바로 붙어있는 게 아니라 자식인 스프라이트에 붙어있으니 GetComponentInChildren을 쓴다
        _Animator = GetComponentInChildren<Animator>();

        if (_Animator == null)
        {
            Debug.Log("Animator 못 찾음");
        }

        //_RigidBody 안에 Rigidbody에 있는 컴포넌트를 가져와서 넣어준다
        _RigidBody = GetComponent<Rigidbody2D>();

        if (_RigidBody == null)
        {
            Debug.Log("Rigidbody 못 찾음");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (IsDead)
        {
            if (deathCooldown <= 0)
            {
                //게임 재시작
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                    gameManager.RestartGame();
                }
            }
            else
            {
                deathCooldown -= Time.deltaTime;
            }
        }
        else
        {
            //GetMouseButtonDown(0)은 모바일 터치에도 해당
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                IsFlap = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if (IsDead) return;

        Vector3 velocity = _RigidBody.velocity;
        velocity.x = ForwardSpeed;
        
        if (IsFlap)
        {
            velocity.y += FlapForce;
            IsFlap = false ;
        }

        _RigidBody.velocity = velocity;

        //올라가나 내려가나에 따라서 회전도 넣어줌 (각도, 최솟값, 최댓값)순서
        float Angle = Mathf.Clamp((_RigidBody.velocity.y * 5f) , -90, 90);
        transform.rotation = Quaternion.Euler(0, 0, Angle);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (GodMode) return;

        if (IsDead) return;

        IsDead = true;
        deathCooldown = 1f;

        _Animator.SetBool("IsDie", true);

        gameManager.GameOver();
    }
}
