using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    private @_2TopDown inputManager;
    private Vector2 movementVector;
    [SerializeField] private Rigidbody2D rigidbody2D;
    [SerializeField] private Animator animator;

    private void Awake()
    {
       rigidbody2D = GetComponent<Rigidbody2D>();
       inputManager = new @_2TopDown();
       animator = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        inputManager.Enable();
    }
    private void Update()
    {
        PlayerInput();
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void PlayerInput()
    {
        movementVector = inputManager.Player.Move.ReadValue<Vector2>();
    }
    private void Move() 
    {

        rigidbody2D.MovePosition(rigidbody2D.position + movementVector * (moveSpeed * Time.fixedDeltaTime));
        transform.localScale =  new Vector3(movementVector.x >= 0 ? 1 : -1, 1,1);
        AnimationPlayer();
    }
    private void AnimationPlayer()
    {
        animator.SetFloat("velocityX", movementVector.x);
        animator.SetFloat("velocityY", movementVector.y);
        if(movementVector.x != 0|| movementVector.y != 0)
        {
            animator.SetFloat("lastVelocityX", movementVector.x);
            animator.SetFloat("lastVelocityY" , movementVector.y);
        }
    }
   
}
