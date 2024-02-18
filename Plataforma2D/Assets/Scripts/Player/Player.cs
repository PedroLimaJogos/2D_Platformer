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
    public ParticleSystem JumpVFX;
    public AudioSource audioSource;


    public Animator animator;
    public float _currentSpeed;

    [Header("Jump Collision Check")]
    public Collider2D collider2D;
    public float disToGround;
    public float spaceToGround = .1f;

    private void Awake()
    {
        if (healthBase != null)
        {
            healthBase.Onkill += onPlayerKill;
        }

        if (collider2D != null)
        {
            disToGround = collider2D.bounds.extents.y;
        }
    }

    private bool IsGrounded()
    {
        Debug.DrawRay(transform.position, -UnityEngine.Vector2.up, Color.magenta, disToGround + spaceToGround);
        return Physics2D.Raycast(transform.position, -UnityEngine.Vector2.up, disToGround + spaceToGround);
    }

    private void onPlayerKill()
    {
        healthBase.Onkill -= onPlayerKill;
        animator.SetTrigger(SOPlayerSetup.triggerDeath);

    }

    private void Update()
    {
        IsGrounded();
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
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            myRigidBody.velocity = UnityEngine.Vector2.up * SOPlayerSetup.jumpForce;
            myRigidBody.transform.localScale = UnityEngine.Vector2.one;

            DOTween.Kill(myRigidBody.transform);
            handleScaleJump();

            PlayJumpVFX();
        }
    }

    private void handleScaleJump()
    {
        myRigidBody.transform.DOScaleY(SOPlayerSetup.jumpScaleY, SOPlayerSetup.animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(SOPlayerSetup.ease);
        myRigidBody.transform.DOScaleX(SOPlayerSetup.jumpScaleX, SOPlayerSetup.animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(SOPlayerSetup.ease);
    }

    private void PlayJumpVFX()
    {
        if (JumpVFX != null) JumpVFX.Play();
        if (audioSource) audioSource.Play();
    }

    public void DestroyMe()
    {
        Destroy(gameObject);
    }
}
