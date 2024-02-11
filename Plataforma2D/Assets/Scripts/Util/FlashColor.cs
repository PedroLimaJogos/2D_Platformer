using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using DG.Tweening;

public class FlashColor : MonoBehaviour
{
    // Start is called before the first frame update
    public List<SpriteRenderer> spriteRenderers;
    public Color color = Color.red;
    public float duration = .3f;

    private Tween _currentTween;

    // Update is called once per frame
    private void OnValidate()
    {
        spriteRenderers = new List<SpriteRenderer>();
        foreach (var child in transform.GetComponentsInChildren<SpriteRenderer>())
        {
            spriteRenderers.Add(child);
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Flash();
        }
    }
    public void Flash()
    {
        if (_currentTween != null)
        {
            _currentTween.Kill();
            spriteRenderers.ForEach(i => i.color = Color.white);
        }

        foreach (var c in spriteRenderers)
        {
            _currentTween = c.DOColor(color, duration).SetLoops(2, LoopType.Yoyo);
        }
    }
}
