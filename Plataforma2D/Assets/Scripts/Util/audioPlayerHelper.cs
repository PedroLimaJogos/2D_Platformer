using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioPlayerHelper : MonoBehaviour
{
    public AudioSource audioSource;
    // Start is called before the first frame update

    // Update is called once per frame
    public void Play()
    {
        audioSource.Play();
    }

}
