using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    private bool picked;

//    Animator animator;
    
    public bool Picked {
        set {
            picked = value;
//            if(picked){
//                Defeated(); // mängi animatsiooni
//            }
        }
        get {
            return picked;
        }
    } 

    private void Start() {
//        animator = GetComponent<Animator>();
    }

    public void Defeated() {
//        animator.SetTrigger("Defeated");
    }

    public void PickUpFlower() {
        Destroy(gameObject);
    }
}
