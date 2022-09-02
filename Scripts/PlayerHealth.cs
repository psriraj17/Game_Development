using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
 
    public PlayerCharacter playerCharacter;
    public HealtBar healthBar;

    float health;
    
    // Start is called before the first frame update
    void Start()
    {
        health= playerCharacter.health;
        healthBar.SetMaxHealth (health);
    }

    // Update is called once per frame
    void Update()
    {
        health=playerCharacter.hp.GetValue();
        healthBar.SetHealth (health);
    }
}
