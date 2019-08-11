using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingStar : MonoBehaviour
{
    [SerializeField]
    private float _lifetime = 5f;

    public NightLord Owner;

    private void Awake()
    {
        Destroy(gameObject, _lifetime);
    }
    private void Start()
    {
        tag = "Star";
    }

    private void Update()
    {
        //Rotate the star to look cool
        transform.Rotate (0,0,250*Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        //Dont collide with myself
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Star") return;

        if (other.gameObject.tag == "Enemy")
        {
            if (Owner == null)
            {
                Debug.LogWarning("Null Owner D:");
                return;
            }
            //Deal damage to enemy here :)
            Enemy hitEnemy = other.gameObject.GetComponent<Enemy>();
            //Check owners stats for damage formula same with enemy
            //Do final damage calculations
            float finalDamage = 710f/100;
            finalDamage *= Random.Range(Owner.LowerRange, Owner.UpperRange); 
            finalDamage -= hitEnemy.Defence - (hitEnemy.Defence * Owner.IED);
            hitEnemy.TakeDmg(Owner,finalDamage);
        }

        Destroy(gameObject, 0);
    }
}
