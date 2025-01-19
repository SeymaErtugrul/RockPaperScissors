using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatAnimator : MonoBehaviour
{
   private CatAnimator mCatAnimator;
    private Animator animator;
    void Start()
    {
       animator = GetComponent<Animator>();
    }


    public void SetIsMoving(bool isMoving)
    {
        animator.SetBool("isWalking", isMoving); 
    }
}
