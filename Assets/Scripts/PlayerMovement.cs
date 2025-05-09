using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float speedMoving = 5f;
    public float jumpForce = 200f;
    public float groundCheckRadius = 0.1f;
    public Transform groundCheckPoint;
    public LayerMask whatIsGround;
    private Rigidbody2D rb;
    public bool isOnGround = false;
    public bool isOnLadder;
    public Animator playerAnimator;
    
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>(); 
    }
    
    void Update()
    {
        isOnGround = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatIsGround);
        
        float horizontalInput = Input.GetAxis("Horizontal");

        playerAnimator.SetFloat("PlayerMove", Mathf.Abs(horizontalInput));

        Vector3 movement = new Vector3(horizontalInput, 0f);
        transform.Translate(movement * speedMoving * Time.deltaTime);

        if (isOnGround == true && Input.GetKeyDown(KeyCode.Space)) rb.AddForce(new Vector2(0f, jumpForce));

        else if (!isOnGround && !isOnLadder) playerAnimator.SetBool("IsPlayerJumping", true);

        else playerAnimator.SetBool("IsPlayerJumping", false);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ladder")) isOnLadder = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ladder")) isOnLadder = false;
    }
}   