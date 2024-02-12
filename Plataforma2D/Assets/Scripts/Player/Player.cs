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

    [Header("Setup")]
    public SOplayer SOPlayerSetup;


    public Animator animator;
    public float _currentSpeed;


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
        animator.SetTrigger(SOPlayerSetup.triggerDeath);

    }

    private void Update()
    {
        handleJump();
        handleMovement();
    }

    private void handleMovement()
    {
        if (Input.GetKey(KeyCode.LeftControl))
            _currentSpeed = SOPlayerSetup.speedRun;
        else
            _currentSpeed = SOPlayerSetup.speed;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            //myRigidBody.MovePosition(myRigidBody.position + velocity * Time.deltaTime);
            myRigidBody.velocity = new UnityEngine.Vector2(_currentSpeed, myRigidBody.velocity.y);
            if (myRigidBody.transform.localScale.x != 1)
            {
                myRigidBody.transform.DOScaleX(1, .1f);
            }
            animator.SetBool(SOPlayerSetup.boolRun, true);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            //myRigidBody.MovePosition(myRigidBody.position - velocity * Time.deltaTime);
            myRigidBody.velocity = new UnityEngine.Vector2(-_currentSpeed, myRigidBody.velocity.y);
            if (myRigidBody.transform.localScale.x != -1)
            {
                myRigidBody.transform.DOScaleX(-1, .1f);
            }

            animator.SetBool(SOPlayerSetup.boolRun, true);
        }
        else
        {
            animator.SetBool(SOPlayerSetup.boolRun, false);
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
            myRigidBody.velocity = UnityEngine.Vector2.up * SOPlayerSetup.jumpForce;
            myRigidBody.transform.localScale = UnityEngine.Vector2.one;

            DOTween.Kill(myRigidBody.transform);
            handleScaleJump();
        }
    }

    private void handleScaleJump()
    {
        myRigidBody.transform.DOScaleY(SOPlayerSetup.jumpScaleY, SOPlayerSetup.animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(SOPlayerSetup.ease);
        myRigidBody.transform.DOScaleX(SOPlayerSetup.jumpScaleX, SOPlayerSetup.animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(SOPlayerSetup.ease);
    }

    public void DestroyMe()
    {
        Destroy(gameObject);
    }
}
