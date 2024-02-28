using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    Collider2D swordCollider;
    Vector2 rightAttackOffset;

    public enum AttackDirection{
        left, right
    }

    public AttackDirection attackDirection;

    // Start is called before the first frame update
    void Start()
    {
        swordCollider = GetComponent<Collider2D>();
        rightAttackOffset = transform.position;
    }

    public void Attack() {
        switch(attackDirection){
            case AttackDirection.left:
                AttackLeft();
                break;
            case AttackDirection.right:
                AttackRight();
                break;

        }

    }

    private void AttackRight(){
        swordCollider.enabled = true;
        transform.position = rightAttackOffset;
    }
    private void AttackLeft(){
        swordCollider.enabled = true;
        transform.position = new Vector2(rightAttackOffset.x * -1, rightAttackOffset.y);
    }
    public void StopAttack(){
        swordCollider.enabled = false;
        
    }
}
