using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    private float speed;

    [SerializeField]
    private Animator animator;

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector2 currentVelocity = gameObject.GetComponent<Rigidbody2D>().velocity;

        float newVelocityX = 0f;

        if (moveHorizontal < 0 && currentVelocity.x <= 0)
        {
            newVelocityX = -speed;
            animator.SetBool("walkingLeft", true);
        }
        else if (moveHorizontal > 0 && currentVelocity.x >= 0)
        {
            newVelocityX = speed;
            animator.SetBool("walkingRight", true);
        }
        else
        {
            animator.SetBool("walkingLeft", false);
            animator.SetBool("walkingRight", false);
        }

        float newVelocityY = 0f;

        if (moveVertical < 0 && currentVelocity.y <= 0)
        {
            newVelocityY = -speed;
            animator.SetBool("walkingDown", true);
        }
        else if (moveVertical > 0 && currentVelocity.y >= 0)
        {
            newVelocityY = speed;
            animator.SetBool("walkingUp", true);
        }
        else
        {
            animator.SetBool("walkingDown", false);
            animator.SetBool("walkingUp", false);
        }

        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(newVelocityX, newVelocityY);
    }
}

