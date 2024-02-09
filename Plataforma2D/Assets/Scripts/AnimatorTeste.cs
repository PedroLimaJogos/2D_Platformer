using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorTeste : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;

    public string triggerToPlay = "fly";

    private void OnValidate()
    {
        if (animator == null) animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            animator.SetBool(triggerToPlay, !animator.GetBool(triggerToPlay));
        }
    }
}
