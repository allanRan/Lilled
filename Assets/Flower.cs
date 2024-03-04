using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    private bool picked = false;
    
    public bool Picked {
        set {
            picked = value;
            print("Paneme picked väärtuseks" + picked);
            if(picked){
                Destroy(gameObject);
                print("Korjame lille üles");
            }
            else {
//              Spawn(gameObject);
                print("Paneme lille maha");
            }
        }
        get {
            return picked;
        }
    } 
}
