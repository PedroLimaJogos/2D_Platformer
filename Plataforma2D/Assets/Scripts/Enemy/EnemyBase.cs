using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int damage = 5;

    public Animator animator;
    public string triggerAttack = "Attack";
    public string triggerKill = "Kill";

    public HealthBase healthBase;

    public float timeToDestroy = 1f;

    private void Awake()
    {
        if (healthBase != null)
        {
            healthBase.Onkill += onEnemyKill;
        }
    }

    private void onEnemyKill()
    {
        healthBase.Onkill -= onEnemyKill;
        PlayKillAnimation();
        Destroy(gameObject, timeToDestroy);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        {
            Debug.Log(collision.transform.name);
            var health = collision.gameObject.GetComponent<HealthBase>();

            if (health != null)
            {
                health.Damage(damage);
                PlayAttackAnimation();
            }
        }


    }

    private void PlayAttackAnimation()
    {
        animator.SetTrigger(triggerAttack);
    }
    private void PlayKillAnimation()
    {
        animator.SetTrigger(triggerKill);
    }

    public void Damage(int amount)
    {
        healthBase.Damage(amount);
    }
}
