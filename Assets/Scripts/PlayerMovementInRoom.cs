using UnityEngine;

public class PlayerMovementInRoom : MonoBehaviour
{
    public float speedMovementInRoom = 2f;
    public Animator playerAnimator;

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        playerAnimator.SetFloat("PlayerMove", Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));

        Vector2 movement = new Vector2(horizontalInput, verticalInput);
        transform.Translate(movement * speedMovementInRoom * Time.deltaTime);
    }
}

