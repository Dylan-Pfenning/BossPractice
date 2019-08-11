using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : Enemy
{
    [SerializeField]
    private Transform[] points = null;
    [SerializeField]
    private int goalPnt = 0;
    [SerializeField]
    private float _Speed = 2.5f;

    private void Start()
    {
        MaxHealth = 1500000000f;
        CurrentHealth = MaxHealth;
        Defence = 1000f;
        Damage = 16500f;
        points[0].position = new Vector3(31f, -2.5f, 0.0f);
        points[1].position = new Vector3(-27.63035f, -2.5f, 0.0f);
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, points[goalPnt].position) < .025f)
        {
            switch (goalPnt)
            {
                case 0:
                    goalPnt = 1;
                    break;
                case 1:
                    goalPnt = 0;
                    break;
                default:
                    goalPnt = 1;
                    break;
            }
        }
        float step = _Speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, points[goalPnt].position, step);
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            Player hitPlayer = other.gameObject.GetComponent<Player>();
            hitPlayer.Health -= Damage;
        }    
    }
}
