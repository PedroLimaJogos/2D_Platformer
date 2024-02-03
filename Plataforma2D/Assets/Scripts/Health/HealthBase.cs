using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBase : MonoBehaviour
{
    // Start is called before the first frame update
    public int startLife = 10;
    private int _currentLife;
    public bool destroyOnKill = false;
    public float delayToKill = 0f;
    private bool _isDead = false;

    private void Init()
    {
        _currentLife = startLife;
        _isDead = false;
    }

    private void Awake()
    {
        Init();
    }
    public void Damage(int damage)
    {
        if (_isDead)
            return;

        _currentLife -= damage;

        if (_currentLife <= damage)
        {
            Kill();
        }
    }

    // Update is called once per frame
    private void Kill()
    {
        _isDead = true;

        if (destroyOnKill)
            Destroy(gameObject, delayToKill);
    }
}
