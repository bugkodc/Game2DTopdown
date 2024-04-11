using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Door : MonoBehaviour
{
    private bool isdoor = false;
    [SerializeField] private Animator animator;
    [SerializeField] private BoxCollider2D boxCollider;
    private @_2TopDown inputManager;

    private void Update()
    {
     
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            isdoor = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isdoor = false;
            AnimationDoor();
            boxCollider.isTrigger = false;
        }
    }
    private void AnimationDoor()
    {
        animator.SetBool("isdoor", isdoor);
    }
    public void OpenDoor(InputAction.CallbackContext context)
    {
        if(context.started && isdoor)
        {
            AnimationDoor();
            boxCollider.isTrigger = true;
           
        }
  
    }
}
