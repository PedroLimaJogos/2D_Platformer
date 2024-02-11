using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    // Update is called once per frame
    public Rigidbody2D myRigidBody;
    public HealthBase healthBase;

    public UnityEngine.Vector2 friction = new UnityEngine.Vector2(.1f, 0);

    [Header("Speed Setup")]
    public float jumpForce = 2;
    public float speed;
    public float speedRun;
    private float _currentSpeed;

    [Header("Animation Setup")]
    public float jumpScaleY = 1.5f;
    public float jumpScaleX = 0.7f;
    public float animationDuration = .3f;

    public Ease ease = Ease.OutBack;

    [Header("Animation Setup")]
    public string boolRun = "Run";
    public string triggerDeath = "Death";
    public Animator animator;


    private void Awake()
    {
        if (healthBase != null)
        {
            healthBase.Onkill += onPlayerKill;
        }

    }

    private void onPlayerKill()
    {
        healthBase.Onkill -= onPlayerKill;
        animator.SetTrigger(triggerDeath);

    }

    private void Update()
    {
        handleJump();
        handleMovement();
    }

    private void handleMovement()
    {
        if (Input.GetKey(KeyCode.LeftControl))
            _currentSpeed = speedRun;
        else
            _currentSpeed = speed;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            //myRigidBody.MovePosition(myRigidBody.position + velocity * Time.deltaTime);
            myRigidBody.velocity = new UnityEngine.Vector2(_currentSpeed, myRigidBody.velocity.y);
            if (myRigidBody.transform.localScale.x != 1)
            {
                myRigidBody.transform.DOScaleX(1, .1f);
            }
            animator.SetBool(boolRun, true);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            //myRigidBody.MovePosition(myRigidBody.position - velocity * Time.deltaTime);
            myRigidBody.velocity = new UnityEngine.Vector2(-_currentSpeed, myRigidBody.velocity.y);
            if (myRigidBody.transform.localScale.x != -1)
            {
                myRigidBody.transform.DOScaleX(-1, .1f);
            }

            animator.SetBool(boolRun, true);
        }
        else
        {
            animator.SetBool(boolRun, false);
        }

        if (myRigidBody.velocity.x > 0)
        {
            myRigidBody.velocity -= friction;
        }
        if (myRigidBody.velocity.x < 0)
        {
            myRigidBody.velocity += friction;
        }
    }

    private void handleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myRigidBody.velocity = UnityEngine.Vector2.up * jumpForce;
            myRigidBody.transform.localScale = UnityEngine.Vector2.one;

            DOTween.Kill(myRigidBody.transform);
            handleScaleJump();
        }
    }

    private void handleScaleJump()
    {
        myRigidBody.transform.DOScaleY(jumpScaleY, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
        myRigidBody.transform.DOScaleX(jumpScaleX, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
    }

    public void DestroyMe()
    {
        Destroy(gameObject);
    }
}
