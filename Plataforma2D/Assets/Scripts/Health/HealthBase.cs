using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBase : MonoBehaviour
{

    public Action Onkill;
    // Start is called before the first frame update
    public int startLife = 10;
    private int _currentLife;
    public bool destroyOnKill = false;
    public float delayToKill = 0f;
    private bool _isDead = false;

    [SerializeField] private FlashColor _flashColor;

    private void Init()
    {
        _currentLife = startLife;
        _isDead = false;
    }

    private void Awake()
    {
        Init();
        if (_flashColor == null)
        {
            _flashColor = GetComponent<FlashColor>();
        }
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

        if (_flashColor != null)
        {
            _flashColor.Flash();
        }
    }

    // Update is called once per frame
    private void Kill()
    {
        _isDead = true;

        if (destroyOnKill)
        {
            Destroy(gameObject, delayToKill);
        }
        Onkill?.Invoke();
    }


}
