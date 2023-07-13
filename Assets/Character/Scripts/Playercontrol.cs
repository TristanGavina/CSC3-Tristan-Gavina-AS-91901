using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum PlayerState
{
    walk,
    attack,
    interact
}

public class Playercontrol : MonoBehaviour
{
    public PlayerState currentState;
    public float collisionOffset = 0.05f;
    public ContactFilter2D movementFilter;
    public float moveSpeed;
    private Rigidbody2D myRigidbody;
    private Vector3 change;
    private Animator animator;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();
    
    bool canMove = true;

    //Use this for initialization
    void Start() {
        currentState = PlayerState.walk;
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        animator.SetFloat("moveX", 0);
        animator.SetFloat("moveY", -1);
    }

    //Update is called once per frame
    void Update () {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
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
        animator.SetBool("swordAttack", true);
        currentState = PlayerState.attack;
        yield return null;
        animator.SetBool("swordAttack", false);
        yield return new WaitForSeconds(.3f);
        currentState = PlayerState.walk;
    }
    void UpdateAnimationAndMove() {
        if (change != Vector3.zero) {
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("isMoving", true);
        } else {
            animator.SetBool("isMoving", false);
        }
    }

    private void FixedUpdate() {
        if (canMove) {
            if(change != Vector3.zero) {
                bool success = TryMove(change);

                if(!success) {
                    success = TryMove(new Vector3(change.x, 0));

                    if(!success) {
                    success = TryMove(new Vector3(0, change.y));
                }
            }
                    
                animator.SetBool("isMoving", success);
            } else {
                animator.SetBool("isMoving", false);
            }
        }
    }    


    private bool TryMove(Vector3 direction) {
            if(direction != Vector3.zero){
                // Check for potention collisions
                int count = myRigidbody.Cast(
                    direction, // X and Y values between -1 and 1 that represent the direction from the body to look for collisions
                    movementFilter, // The settings that determine where a collision can occur on such as layers to collab with
                    castCollisions, // List of collisions to store the found collisions into after the Cast is finished
                    moveSpeed * Time.deltaTime + collisionOffset); // The amount to cast equal to the movement plus an offset

                if(count == 0){
                    myRigidbody.MovePosition(transform.position + direction * moveSpeed * Time.deltaTime);
                    return true;
                } else {
                    return false;
                }
            } else {
                //Cant move if theres no direction to move in
                return false;
            }
        }

    void OnMove(InputValue movementValue) {
        change = movementValue.Get<Vector2>();
    }

    void OnFire() {
        animator.SetTrigger("swordAttack");
    }

    public void LockMovement() {
        canMove = false;
    }

    public void UnlockMovement() {
        canMove = true;
    }
}