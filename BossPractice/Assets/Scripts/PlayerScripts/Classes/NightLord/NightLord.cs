using System.Collections;
using UnityEngine;

public class NightLord : Player
{
    [SerializeField]
    private GameObject _Star = null;
    [SerializeField]
    private float _StarSpeed = 100f;

    private Vector3 SpawnLoc;
    private Quaternion SpawnRot;
    private Vector3 ForwardVec;

    private bool _SPActive = true;
    private bool _QSReady = true;

    // Start is called before the first frame update
    private void Start()
    {
        InputController myInput = GetComponent<InputController>();
        myInput.SetMaxJumps(3);
        myInput.SetAccel(6.0f);

        //Setting Stats
        Level = 220;

        Luk = 21066;
        Dex = 4007;
        Str = 2769;
        Int = 2573;

        IED = .90f;
        Attack = 316 + 12 + 62 + 16 + 29 + 37 + 66 + 74 + 37 + 22 + 22 + 4 + 54 + 50 + 15 + 65 + 67 + 98 + 2 + 2 + 30 + 3 + 30 + 40 + 5;
        PerAtt = .18f + .12f + .09f + .12f + .12f + .09f;
        TotalAtt = Attack * PerAtt;

        SF = 261;
        AF = 290;
        Health = 22000f;
        Multiplier = 1.75f;
        DamagePercent = .29f;
        FinalDamagePercent = .25f;

        float upperActual = (Multiplier * ((Luk * 4) + Dex) * (TotalAtt / 100));
        float lowerActual = ((upperActual * (.72f)) / 100);
        UpperRange = upperActual * (1 + DamagePercent) * (1 + FinalDamagePercent);
        LowerRange = lowerActual * (1 + DamagePercent) * (1 + FinalDamagePercent);

    }

    // Update is called once per frame
    private void Update()
    {

        if (Input.GetKey(KeyCode.F))
        {
            //Making sure the last throw is out before the next set starts
            if (!_QSReady) return;
            //Quad throw throws 5 stars because of hyper skill over a period
            SpawnLoc = transform.position + (.5f * ForwardVec);
            SpawnRot = transform.rotation;
            ForwardVec = transform.right;
            StartCoroutine("QuadThrow");
        }

         if (Health <= 0.1f)
        {
            Debug.LogWarning("You're dead D:");
            Destroy(gameObject);
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
        starRB.velocity = ForwardVec * (_StarSpeed);
        if (!GetComponent<InputController>().isGrounded)
        {
            SpawnLoc.y -= .10f;
        }
    }
    private IEnumerator QuadThrow()
    {
        _QSReady = false;
        for (int i = 0; i < 5; i++)
        {
            ThrowStars();
            //Throw extra star for shadow partner
            if (_SPActive)
            {
                yield return new WaitForSeconds(0.05f);
                ThrowStars();
            }
            yield return new WaitForSeconds(0.075f);
        }
        _QSReady = true;
        EndSkill("QuadThrow");
    }
    #endregion
}
