using UnityEngine;

public class LadderMovement : MonoBehaviour
{
    public float speedLadderMovement = 2;
    public GameObject player;
    public Animator playerAnimator;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerAnimator = player.GetComponent<Animator>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<Rigidbody2D>().gravityScale = 0;

            if (Input.GetKey(KeyCode.W))
            {
                other.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0, speedLadderMovement);
                playerAnimator.SetBool("IsOnLadder", true);
            }

            else if (Input.GetKey(KeyCode.S))
            {
                other.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0, -speedLadderMovement);
                playerAnimator.SetBool("IsOnLadder", true);
            }

            else
            {
                other.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0, 0);
                playerAnimator.SetBool("IsOnLadder", false);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<Rigidbody2D>().gravityScale = 1;
            playerAnimator.SetBool("IsOnLadder", false);
        }
    }
}
