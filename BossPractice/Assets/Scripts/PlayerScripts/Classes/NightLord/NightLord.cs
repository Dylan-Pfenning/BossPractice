using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightLord : Player
{
    [SerializeField]
    private GameObject _Star;
    [SerializeField]
    private float _StarSpeed = 10f;

    private Vector3 SpawnLoc;
    private Quaternion SpawnRot;

    // Start is called before the first frame update
    private void Start()
    {
        InputController myInput = GetComponent<InputController>();
        myInput.SetMaxJumps(3);
        myInput.SetAccel(6.0f);

        //Setting Stats
        Level = 220;

        Luk = 22000;
        Dex = 6000;
        Str = 2000;
        Int = 2000;

        Attack = 450;
        PerAtt = 24 * 3;
        
        SF = 210;
        AF = 250;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            //Quad throw throws 5 stars because of hyper skill over a period
            SpawnLoc = transform.position;
            SpawnRot = transform.rotation;
            StartCoroutine("QuadThrow");
        }
    }
    private void EndSkill(string name)
    {
        StopCoroutine(name);
    }

    #region QuadThrow

    private void ThrowStars()
    {
        GameObject starThrown = Instantiate(_Star, SpawnLoc, SpawnRot);
        Rigidbody starRB = starThrown.GetComponent<Rigidbody>();
        Physics.IgnoreCollision(starThrown.GetComponent<SphereCollider>(), GetComponent<CapsuleCollider>());
        starThrown.GetComponent<ThrowingStar>().Owner = this;
        Debug.Log("Owner Set");
        
        starRB.velocity = transform.right * _StarSpeed;
    }
    private IEnumerator QuadThrow()
    {
        ThrowStars();
        for (int i = 1; i < 5; i++)
        {
            yield return new WaitForSeconds(0.2f);
            ThrowStars();
        }
        EndSkill("QuadThrow");
    }
    #endregion
}
