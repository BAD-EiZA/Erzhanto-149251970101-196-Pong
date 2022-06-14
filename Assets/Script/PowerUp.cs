using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public PowerUpController pcu;
    public float magtitude;
    private void OnTriggerEnter2D(Collider2D coli)
    {
        if(coli.name == "Ball")
        {
            BallController ball = coli.GetComponent<BallController>();
            ball.ActPowerUpSpeedUp(magtitude);
            Destroy(gameObject);
        }
    }
    
}
