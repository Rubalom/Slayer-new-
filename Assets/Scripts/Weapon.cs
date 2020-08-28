using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private PlayerController pc;
    [SerializeField] private AttackStatus attackStatus;

    private void Start()
    {
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger Entered " + collision.gameObject.name);
        if (collision.gameObject.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().Death();
            pc.attackDelay = false;
            pc.GroundPlayer();
            pc.OnLanding();
        }
    }
}
