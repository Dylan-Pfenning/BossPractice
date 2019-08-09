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

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player") return;

        if(other.gameObject.tag == "Enemy")
        {
            if(Owner == null)
            {
                Debug.LogWarning("Null Owner D:");
                return;
            }
            //Deal damage to enemy here :)
            //Check owners stats for damage formula same with enemy
            
        }
    }
}
