using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikeAnimator : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    void Start()
    {
        
    }

    public void setIdle() {
        animator.SetBool("idle", true);



    }

    public void setMoving() {
        animator.SetBool("idle", false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
