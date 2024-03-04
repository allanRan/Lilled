using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 1;

    Animator animator;
    
    public float Health {
        set {
            health = value;
            if(health <= 0){
                Defeated();
            }
        }
        get {
            return health;
        }
    } 

    private void Start() {
        animator = GetComponent<Animator>();
    }

    public void Defeated() {
        animator.SetTrigger("Defeated"); // Alustab surma animatsiooni
    }

    public void RemoveEnemy() {
        Destroy(gameObject);     // Animatsiooni lõpus kustutab vaenlase
    }
}
