using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDestroyerHelper : MonoBehaviour
{
    public Player player;
    // Start is called before the first frame update
    public void KillPlayer()
    {
        player.DestroyMe();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
