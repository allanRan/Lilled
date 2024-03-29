using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public Collider2D swordCollider;
    
    Vector2 rightAttackOffset;

    public float damage = 3;

    // Start is called before the first frame update
    void Start()
    {
        rightAttackOffset = transform.position;
    }


    public void ActionRight(){
        swordCollider.enabled = true;
        transform.localPosition = rightAttackOffset;
    }
    public void ActionLeft(){
        swordCollider.enabled = true;
        transform.localPosition = new Vector2(rightAttackOffset.x * -1, rightAttackOffset.y);
    }
    public void StopAction(){
        swordCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Enemy") {
            // Deal damage to the enemy
            Enemy enemy = other.GetComponent<Enemy>();

            if(enemy != null) {
                enemy.Health -= damage;
            }
        }
        if(other.tag == "Flower") {
            // PickUp the flower
            Flower flower = other.GetComponent<Flower>();

            if(flower != null) {
                if(flower.Picked == false){
                    flower.Picked = true;
                }
            }
        }
    }
}
