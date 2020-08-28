using UnityEditorInternal;
using UnityEngine;

public class AttackBehaviour : StateMachineBehaviour
{
    public float step = 0.1f;
    [SerializeField] private GameObject weapon;
    private Transform player;
    private Rigidbody2D rb;
    private GameObject clone;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = player.GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        clone = Instantiate(weapon, player);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1f;
        Destroy(clone);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        if (stateInfo.normalizedTime <= 0.1f)
        {
            clone.transform.localScale = new Vector3(Mathf.Lerp(0f, 1f, stateInfo.normalizedTime * 10), clone.transform.localScale.y, clone.transform.localScale.z);
            return;
        }
        if (stateInfo.normalizedTime >= 0.9f)
        {
            clone.transform.localScale = new Vector3(Mathf.Lerp(0f, 1f, (1f - stateInfo.normalizedTime) * 10), clone.transform.localScale.y, clone.transform.localScale.z);
            return;
        }
        if ((stateInfo.normalizedTime >= 0.1f) && (stateInfo.normalizedTime <= 0.9f))
        {
            clone.transform.localScale = new Vector3(1f, clone.transform.localScale.y, clone.transform.localScale.z);
            return;
        }
    }

    override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    
    }

    override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    
    }
}