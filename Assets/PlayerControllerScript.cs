using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerScript : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float collisionOffset = 0.05f;
    public ContactFilter2D movementFilter;
    public SwordAttack swordAttack;

    Vector2 movementInput;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;
    Animator animator;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
   }
    
    private void FixedUpdate(){
        if(canMove){
            // If movement input is not 0, try to move
            if(movementInput != Vector2.zero){

                bool success = TryMove(movementInput);

                if(!success){
                    success = TryMove(new Vector2(movementInput.x, 0)); // kas saab liikuda vasakule voi paremale
                }    
                if(!success){
                    success = TryMove(new Vector2(0, movementInput.y)); // kas saab liikuda yles voi alla
                }        
                animator.SetFloat("isMovingX", movementInput.x);
                animator.SetFloat("isMovingY", movementInput.y);
            } else {
                animator.SetFloat("isMovingX", 0);
                animator.SetFloat("isMovingY", 0);
            }

            // Set direction of sprite to movement direction
            if(movementInput.x < 0){
                spriteRenderer.flipX = true;  // left
            } else if (movementInput.x > 0){
                spriteRenderer.flipX = false; // right
            }
        }
    }

    private bool TryMove(Vector2 direction){
        if(direction != Vector2.zero){
            // Check for potentsial collisions
            int count = rb.Cast(
                direction, // X and Y values between -1 and 1 that represent the direction from body to look for collisions
                movementFilter, // The setting that determine where a collision can occur on such as layers to collide with
                castCollisions, // List of collisions to store the found collisions into after the Cast is finished
                moveSpeed * Time.fixedDeltaTime + collisionOffset); // The amount to vast equal to the movement plus an offset
        
            if(count == 0){
                rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
                return true;
            } else {
                return false;
            }
        }else {
            // Can't move if there's no direction to move in
            return false;
        }


    }
    // Mängija vajutas mõnda liikumise klahvi või nuppu. Salvestame liikumise vektori muutujasse.
    void OnMove(InputValue movementValue){
        movementInput = movementValue.Get<Vector2>();
    }
    
    void OnFire(){
        animator.SetTrigger("swordAttack");
    }

    void OnPickUp(){
        animator.SetTrigger("pickUp");
    }

    public void PlayerAction() {
        LockMovement();
        if(spriteRenderer.flipX == true){
            swordAttack.ActionLeft();
        } else {
            swordAttack.ActionRight();
        }
    }

    public void EndPlayerAction() {
        UnlockMovement();
        swordAttack.StopAction();
    }





///
/// Rünnaku ja asjade võtmise ja mahapanemise ajaks on vaja tegelasel seisma jääda
///
    // Paneme liikumise seisma
    public void LockMovement(){
        canMove = false;
    }
    // Lubame tegelasel jälle liikuda
    public void UnlockMovement(){
        canMove = true;
    }
}
