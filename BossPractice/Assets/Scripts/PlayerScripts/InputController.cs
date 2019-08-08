using UnityEngine;

public class InputController : MonoBehaviour
{
    [Header("Speed and distance values")]
    [SerializeField]
    private float _JumpHeight = 20f;
    [SerializeField]
    private float _Acceleration = 2f;
    [SerializeField]
    private float _AirAccel = 0.5f;
    [SerializeField]
    private float _MaxSpeed = 10f;
    [SerializeField]
    private int _MaxJumps = 2;

    //Groud Checks
    [Header("Ground Checking")]
    [SerializeField]
    private float _GroundDistance = 0.2f;
    [SerializeField]
    private LayerMask _Ground;



    private int JumpsLeft;
    private Transform GroundChecker;
    private bool isGrounded = true;
    private Rigidbody rb;

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

        if (rb.velocity.y <= 1 && !isGrounded)
        {
            //Set custom gravity for falling
            //rb.AddForce(new Vector2(0.0f, -25f), ForceMode.Acceleration);
        }
        //Resetting Jump count
        if (isGrounded && JumpsLeft < _MaxJumps)
        {
            JumpsLeft = _MaxJumps;
            //Reset the gravity to 0
            Vector3 tempVel = rb.velocity;
            tempVel.y = 0;
            rb.velocity = tempVel;
        }
        Debug.Log(JumpsLeft);

    }

    private void Jump()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector2.up * _JumpHeight, ForceMode.Impulse);
        }
        else
        {
            rb.AddForce(transform.right * 25f, ForceMode.Impulse);
        }
        JumpsLeft--;
    }


    //Physics update ticking
    private void FixedUpdate()
    {
        Debug.Log(transform.forward);

        //Jumping
        if (Input.GetButtonDown("Jump") && JumpsLeft != 0)
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
            else
            {
                //rb.velocity += Vector3.right * _AirAccel;
            }
             transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);

        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (isGrounded)
            {
                rb.velocity += Vector3.left * _Acceleration;
            }
            else
            {
                //rb.velocity += Vector3.left * _AirAccel;
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
        Debug.Log(rb.velocity);
    }
}
