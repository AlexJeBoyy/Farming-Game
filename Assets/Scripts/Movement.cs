using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //add walking animation

    public float runSpeed;
    public float walkSpeed;
    private float speed;

    public Animator animator;

    private Vector3 direction;

    private void Start()
    {

    }


    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = walkSpeed;
            animator.SetBool("isWalking", true);
        }
        else
        {
            speed = runSpeed;
            animator.SetBool("isWalking", false);
        }
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        direction = new Vector2(horizontal, vertical);

        AnimateMovement(direction);

    }
    private void FixedUpdate()
    {
        transform.position += direction * speed * Time.deltaTime;
    }
    void AnimateMovement(Vector3 direction)
    {
        if (animator != null)
        {
            if (direction.magnitude > 0)
            {
                animator.SetBool("isMoving", true);

                animator.SetFloat("horizontal", direction.x);
                animator.SetFloat("vertical", direction.y);
            }
            else
            {
                animator.SetBool("isMoving", false);
            }
        }
    }
}
