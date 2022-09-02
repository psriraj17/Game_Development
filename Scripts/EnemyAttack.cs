using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float Range = 1f;

    public Transform AttackPoint;

    public LayerMask playerMask;

    public Animator animator;

    BoxCollider colliderWeapon;

    private GameObject objWeapon;

    bool PlayerCheck;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        objWeapon = GameObject.FindGameObjectsWithTag("EnemyWeapon")[0];
        colliderWeapon = objWeapon.GetComponent<BoxCollider>();

        colliderWeapon.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerCheck =
            Physics.CheckSphere(AttackPoint.position, Range, playerMask);

        if (PlayerCheck)
        {
            Attack();
        }
    }

    void Attack()
    {
        animator.SetTrigger("Attack");
    }

    public void EnemyAttackStart()
    {
        colliderWeapon.enabled = true;
    }

    public void EnemyAttackEnd()
    {
        colliderWeapon.enabled = false;
    }
}
