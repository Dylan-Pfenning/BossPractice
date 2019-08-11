using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBarScript : MonoBehaviour
{
    // Update is called once per frame
    [SerializeField]
    private Enemy Owner = null;
    private void Start()
    {
        Owner = gameObject.GetComponentInParent<Enemy>();
    }
    void Update()
    {
        Vector3 HealthBarVec = gameObject.transform.localScale;
        HealthBarVec.x = (Owner.CurrentHealth / Owner.MaxHealth);
        gameObject.transform.localScale = HealthBarVec;
    }
}
