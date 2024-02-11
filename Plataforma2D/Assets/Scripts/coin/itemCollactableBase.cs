using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemCollactableBase : MonoBehaviour
{
    // Start is called before the first frame update
    public string tagCompare = "player";

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
        Debug.Log("collect");
        OnCollect();
        gameObject.SetActive(false);
    }
    protected virtual void OnCollect()
    {

    }

    private void Update()
    {

    }

}

