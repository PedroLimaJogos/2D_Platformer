using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[CreateAssetMenu]
public class SOplayer : ScriptableObject
{
    // Start is called before the first frame update
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
}
