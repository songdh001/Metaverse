using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    //������ �ִϸ��̼� ȣ��
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

        //_Animator �ȿ� Animator�� �ִ� ������Ʈ�� �����ͼ� �־��ش�
        //�׷��� Animator�� Player�� �ٷ� �پ��ִ� �� �ƴ϶� �ڽ��� ��������Ʈ�� �پ������� GetComponentInChildren�� ����
        _Animator = GetComponentInChildren<Animator>();

        if (_Animator == null)
        {
            Debug.Log("Animator �� ã��");
        }

        //_RigidBody �ȿ� Rigidbody�� �ִ� ������Ʈ�� �����ͼ� �־��ش�
        _RigidBody = GetComponent<Rigidbody2D>();

        if (_RigidBody == null)
        {
            Debug.Log("Rigidbody �� ã��");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (IsDead)
        {
            if (deathCooldown <= 0)
            {
                //���� �����
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
            //GetMouseButtonDown(0)�� ����� ��ġ���� �ش�
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

        //�ö󰡳� ���������� ���� ȸ���� �־��� (����, �ּڰ�, �ִ�)����
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
