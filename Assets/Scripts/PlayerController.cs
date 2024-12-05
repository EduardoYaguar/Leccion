using UnityEngine;

public class PlayerController : MonoBehaviour
{
   
    private Rigidbody2D myRigidbody;
    private Animator myAnimator;
    private BoxCollider2D myBoxCollider;


    [SerializeField] private float runSpeed = 10f;
    [SerializeField] private float jumpSpeed = 12f;
    [SerializeField] private LayerMask groundLayer;

    private bool isRunning = false;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myBoxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        Run();
        FlipSprite();
        Jump();
    }

    private void Run()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); 

        Vector2 playerVelocity = new Vector2(horizontalInput * runSpeed, myRigidbody.linearVelocityY);

        myRigidbody.linearVelocity = playerVelocity;

        isRunning = Mathf.Abs(horizontalInput) > Mathf.Epsilon;
        myAnimator.SetBool("IsRunning", isRunning);
    }

    private void FlipSprite()
    {
        bool hasHorizontalSpeed = Mathf.Abs(myRigidbody.linearVelocityX) > Mathf.Epsilon;
        if (hasHorizontalSpeed)
        {
            transform.localScale = new Vector3(Mathf.Sign(myRigidbody.linearVelocityX), 1f, 1f);
        }
    }

    private void Jump()
    {
        bool isGrounded = myBoxCollider.IsTouchingLayers(groundLayer);

        if (isGrounded && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)))
        {
            myRigidbody.linearVelocity = new Vector2(myRigidbody.linearVelocityX, jumpSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Spikes"))
        {
            Destroy(gameObject);
        }
    }
}
