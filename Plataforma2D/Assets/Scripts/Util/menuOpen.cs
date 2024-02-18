using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuOpen : MonoBehaviour
{
    public GameObject menu;
    // Start is called before the first frame update

    public void toggleMenu()
    {
        if (menu.activeSelf)
            menu.SetActive(false);
        else
            menu.SetActive(true);
    }

}
