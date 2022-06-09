using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PowerUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collides){
        if(collides.name == "Ball"){
            BallController bl = collides.GetComponent<BallController>();
            bl.spd +=1;
            Destroy(gameObject);
        }
    }
}
