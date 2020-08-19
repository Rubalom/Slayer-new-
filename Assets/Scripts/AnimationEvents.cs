using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void OnAttackEnd()
    {
        animator.SetBool("IsAttacking", false);
        Debug.Log("Attack ended");
    }
}
