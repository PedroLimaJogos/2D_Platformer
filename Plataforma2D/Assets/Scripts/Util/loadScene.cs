using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Jobs;
using UnityEngine.SceneManagement;

public class loadScene : MonoBehaviour
{
    // Start is called before the first frame update
    public void Load(int i)
    {
        SceneManager.LoadScene(i);

    }

    // Update is called once per frame
    public void Load(string s)
    {
        SceneManager.LoadScene(s);
    }
}
