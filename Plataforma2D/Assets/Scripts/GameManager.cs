using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class GameManager : Singleton<GameManager>
{
    [Header("Animation")]
    public Ease ease = Ease.OutBack;
    public float duration = .2f;
    public float delay = .05f;


    [Header("Player")]
    public GameObject playerPrefab;

    [Header("Enemies")]
    public List<GameObject> enemies;

    [Header("References")]
    public Transform startPoint;

    private GameObject currentPlayer;

    private void Start()
    {
        init();
    }

    public void init()
    {
        spawnPlayer();
    }

    private void spawnPlayer()
    {
        currentPlayer = Instantiate(playerPrefab);
        currentPlayer.transform.position = startPoint.transform.position;
        currentPlayer.transform.DOScale(0, duration).SetEase(ease).From();
    }
}
