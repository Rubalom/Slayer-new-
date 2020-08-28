using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;

public class AnimationEvents : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private TMP_Text text;
    [SerializeField] private PlayerController pc;
    [SerializeField] private AttackStatus attackStatus;
    private bool isRefreshed;

    public void OnAttackEnd()
    {
        animator.SetBool("IsAttacking", false);
        pc.attack = false;
        attackStatus.SetStatus(AttackStatus.Status.Reloading);
        StartCoroutine(AttackDelay());
        Debug.Log("Attack ended");
    }

    public void OnAttackingBegin()
    {
        attackStatus.SetStatus(AttackStatus.Status.Attacking);
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

    private IEnumerator AttackDelay()
    {
        float time = 0f;
        while (time < 0.5f)
        {
            attackStatus.SetReloadAmount(time/0.5f);
            time += Time.deltaTime;
            if (pc.attackDelay == false)
            {
                //attackStatus.SetStatus(AttackStatus.Status.Ready);
                isRefreshed = true;
                if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Attacking"))
                    attackStatus.SetStatus(AttackStatus.Status.Ready);
            }
            yield return null;
        }
        if (!isRefreshed)
        {
            pc.attackDelay = false;
        }
        else
            isRefreshed = false;
    }

}
