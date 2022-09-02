//using System.Action;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour, IDamage, IAttack
{
    public float health;

    public float dmg;

    public System.Action<Collider> damageReceived;

    public Stats damage { get; set; }

    public Stats hp { get; set; }

    void OnTriggerEnter(Collider coll)
    {
        if (
            coll.gameObject.tag == "PlayerWeapon" ||
            coll.gameObject.tag == "EnemyWeapon"
        )
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
    }

    // Update is called once per frame
    void Update()
    {
    }

    public virtual void TakeDamage(Collider coll)
    {
        Debug.Log("Trigerred");
        float attackerDamage =
            coll.gameObject.GetComponent<Weapon>().GetValue();
        Debug.Log("damage" + ":" + attackerDamage);
        hp.AddModifier(attackerDamage * (-1));
        hp.baseValue = hp.GetValue();
        Debug.Log(hp.GetValue());
        if (hp.GetValue() <= 0) Destroy(gameObject);
    }
}
