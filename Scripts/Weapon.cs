using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour, IWeapon
{
    public float damage;

    public float modify { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        modify = damage;
    }

    public void Equip(IAttack attacker)
    {
    }

    public float GetValue()
    {
        return modify;
    }
}
