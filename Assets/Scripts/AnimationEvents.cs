using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AnimationEvents : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private TMP_Text text;

    public void OnAttackEnd()
    {
        animator.SetBool("IsAttacking", false);
        Debug.Log("Attack ended");
    }

    public void OnAttackingBegin()
    {
        text.text = "ATTACKING";
    }

    public void OnIdleBegin()
    {
        text.text = "IDLE";
    }

    public void OnRunningBegin()
    {
        text.text = "RUNNING";
    }
}
