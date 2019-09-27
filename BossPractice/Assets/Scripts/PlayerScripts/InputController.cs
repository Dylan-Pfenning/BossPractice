using UnityEngine;

public class InputController : MonoBehaviour
{
    [Header("Speed and distance values")]
    [SerializeField]
    private float _JumpHeight = 20f;
    [SerializeField]
    private float _Acceleration = 2f;
    [SerializeField]
    private float _MaxSpeed = 10f;
    [SerializeField]
    private int _MaxJumps = 1;
    [SerializeField]
    private float _JumpCD = 0.0f;
    private bool _CanJump = true;
    //Groud Checking
    [Header("Ground Checking")]
    [SerializeField]
    private float _GroundDistance = 0.2f;
    [SerializeField]
    private LayerMask _Ground= 0;
    private int JumpsLeft = 0;
    private Transform GroundChecker;
    public bool isGrounded = true;
    //Extra class properties
    private Rigidbody rb;

    //Getters and setters
    public int GetMaxJumps() {return _MaxJumps;}
    public void SetMaxJumps(int val) { _MaxJumps = val;}

    public float GetAccel() {return _Acceleration;}
    public void SetAccel(float val) {_Acceleration = val;} 

    // Start is called before the first frame update
    private void Start()
    {
        GroundChecker = transform.GetChild(0);
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        //Checking if player is grounded
        isGrounded = Physics.CheckSphere(GroundChecker.position, _GroundDistance, _Ground, QueryTriggerInteraction.Ignore);
        //Resetting Jump count
        if (isGrounded && JumpsLeft < _MaxJumps)
        {
            JumpsLeft = _MaxJumps;
            //Reset the gravity to 0
            Vector3 tempVel = rb.velocity;
            tempVel.y = 0;
            rb.velocity = tempVel;
        }
        //Debug.Log(JumpsLeft);

        if(!_CanJump && _JumpCD <= .10f)
        {
            _JumpCD += Time.deltaTime;
            if(_JumpCD >= .10f)
            {
                _CanJump = true;
                _JumpCD = 0;
            }
        }

    }

    private void Jump()
    {
        Debug.Log("Jump");
        
        if (isGrounded)
        {
            rb.AddForce(Vector2.up * _JumpHeight, ForceMode.Impulse);
        }
        else
        {
            rb.velocity = Vector3.zero;
            rb.AddForce(transform.right * 25f, ForceMode.Impulse);
        }
        JumpsLeft--;
        _CanJump = false;
    }


    //Physics update ticking
    private void FixedUpdate()
    {
        //Jumping
        if (Input.GetButtonDown("Jump") && _CanJump && JumpsLeft != 0 )
        {
            Jump();
        }
        //Left Right Movement
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (isGrounded)
            {
                rb.velocity += Vector3.right * _Acceleration;
            }
            transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);

        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (isGrounded)
            {
                rb.velocity += Vector3.left * _Acceleration;
            }
            transform.rotation = new Quaternion(0.0f, 180.0f, 0.0f, 0.0f);
        }
        //Making sure to keep a speed cap invalid after FJ
        if (JumpsLeft == _MaxJumps)
        {
            if (rb.velocity.x > _MaxSpeed)
            {
                Vector3 tempVel = rb.velocity;
                tempVel.x = _MaxSpeed;
                rb.velocity = tempVel;
            }
            else if (rb.velocity.x < (-1 * _MaxSpeed))
            {
                Vector3 tempVel = rb.velocity;
                tempVel.x = -1 * _MaxSpeed;
                rb.velocity = tempVel;
            }
        }
    }
}
