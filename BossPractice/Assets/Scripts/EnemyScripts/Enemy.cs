using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Base class for enemies. Including HP/Damage
    [SerializeField]
    GameObject AnotherEnemyToSpawn = null;
    [SerializeField]
    private float _CurrentHealth;
    public float CurrentHealth
    {
        get { return _CurrentHealth; }
        set { _CurrentHealth = value; }
    }
    [SerializeField]
    private float _MaxHealth;
    public float MaxHealth
    {
        get { return _MaxHealth; }
        set { _MaxHealth = value; }
    }
    [SerializeField]
    private float _Defence;
    public float Defence
    {
        get { return _Defence; }
        set { _Defence = value; }
    }
    [SerializeField]
    private float _Damage;
    public float Damage
    {
        get { return _Damage; }
        set { _Damage = value; }
    }

    private void Start()
    {
        tag = "Enemy";
    }

    public void TakeDmg(Player Attacker, float FinalDamage)
    {
        CurrentHealth -= FinalDamage;

        if (CurrentHealth <= 0)
        {
            Attacker.Experiance += 1;
            Die();
            Destroy(this.gameObject);
        }
    }

    private void Die()
    {
        //Handle Death
        //Spawn another for fun
        Vector3 SpawnPos = Vector3.zero;
        SpawnPos.y = -2.3f;
        Instantiate(AnotherEnemyToSpawn, SpawnPos, transform.rotation);
        
    }


}
