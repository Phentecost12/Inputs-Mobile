using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Vector3 movement;
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    [SerializeField] Rigidbody rb;
    [SerializeField] Animator animator;

    public void Move(InputAction.CallbackContext context)
    {
        if (context.canceled) { animator.SetBool("Move", false); return; }
        
        Vector2 input = context.ReadValue<Vector2>();
        float angle = Mathf.Atan2(input.y, -input.x) * Mathf.Rad2Deg;
        Debug.Log(angle);
        movement.x = input.x;
        movement.z = input.y;
        transform.position += movement * speed;
        animator.SetBool("Move", true);
        transform.rotation = Quaternion.Euler(0, angle - 90, 0);
    }

    public void Jump(InputAction.CallbackContext context)
    {

        if (context.started) 
        {
            animator.SetTrigger("Jump");
            rb.AddForce(jumpForce * Vector3.up, ForceMode.Impulse);
            
        }
    }
}
