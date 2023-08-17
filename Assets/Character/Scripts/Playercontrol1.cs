using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontrol1 : MonoBehaviour
{
    //Variables
    public float speed;
    private Rigidbody2D myRigidbody;
    private Vector3 change;
    private Animator animator;
    public PlayerState currentState;
    // Start is called before the first frame update
    void Start()
    {
        //Player animation imports
        currentState = PlayerState.walk;
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();  
    }

    // Update is called once per frame
    void Update () 
    {
        //Player movement
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        //Player attack animation call
        if(Input.GetButtonDown("attack") && currentState != PlayerState.attack)
        {
            StartCoroutine(AttackCo());
        }
        else if(currentState == PlayerState.walk)
        {
            UpdateAnimationAndMove();
        }
    }

    private IEnumerator AttackCo()
    {
        //Player attack animation call
        animator.SetBool("swordAttack", true);
        currentState = PlayerState.attack;
        yield return null;
        animator.SetBool("swordAttack", false);
        yield return new WaitForSeconds(.3f);
        currentState = PlayerState.walk;
    }
    
    void UpdateAnimationAndMove()
    {
        //Player movement call
        change.Normalize();
        if (change != Vector3.zero)
        {
            MoveCharacter();
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("isMoving", true);
        }
        else 
        {
            animator.SetBool("isMoving", false);
        }
    }

    //Player movement speed
    void MoveCharacter()
    {
        myRigidbody.MovePosition(transform.position + change * speed * Time.fixedDeltaTime);
    }

}
