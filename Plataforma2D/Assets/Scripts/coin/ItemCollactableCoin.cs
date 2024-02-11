using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollactableCoin : itemCollactableBase
{
    // Start is called before the first frame update
    protected override void OnCollect()
    {
        base.OnCollect();
        itemManager.Instance.AddCoins();
    }

}
