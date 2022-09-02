using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : MonoBehaviour, IDamage, IAttack
{
    public Animator animator;

    public float health;

    public float dmg;

    public System.Action<Collider> damageReceived;

    public Stats damage { get; set; }

    public Stats hp { get; set; }

    public AudioSource hitAudio;

    public AudioSource dieAudio;


    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "PlayerWeapon")
        {
            damageReceived (coll);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        hp = new Stats() { baseValue = health };
        damage = new Stats() { baseValue = dmg };
        damageReceived += TakeDamage;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public virtual void TakeDamage(Collider coll)
    {
        animator.SetTrigger("Hit");
        hitAudio.Play();

        float attackerDamage =
            coll.gameObject.GetComponent<Weapon>().GetValue();
        Debug.Log("damage" + ":" + attackerDamage);
        hp.AddModifier(attackerDamage * (-1));
        hp.baseValue = hp.GetValue();
        if (hp.GetValue() <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        animator.SetBool("isDead",true);
        dieAudio.Play();
        GetComponent<Collider>().enabled=false;
        this.enabled=false;
        
    }
}