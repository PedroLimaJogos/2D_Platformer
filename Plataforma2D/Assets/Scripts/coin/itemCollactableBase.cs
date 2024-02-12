using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemCollactableBase : MonoBehaviour
{
    // Start is called before the first frame update
    public string tagCompare = "player";
    public ParticleSystem particleSystem;
    public float timeToHide = 3f;
    public GameObject graphicItem;

    private void Awake()
    {
        //if (particleSystem != null) particleSystem.transform.SetParent(null);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Tocou em algo");
        if (collision.transform.CompareTag(tagCompare))
        {
            Collect();
        }
    }
    protected virtual void Collect()
    {
        if (graphicItem != null) graphicItem.SetActive(false);
        Invoke(nameof(HideObject), timeToHide);
        OnCollect();
    }

    private void HideObject()
    {

        gameObject.SetActive(false);
    }

    protected virtual void OnCollect()
    {
        if (particleSystem != null) particleSystem.Play();
    }

    private void Update()
    {

    }

}

