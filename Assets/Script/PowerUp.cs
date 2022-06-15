using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    
    public float magtitude;

    private void OnTriggerEnter2D(Collider2D coli)
    {
        if(coli.name == "Ball")
        {
            BallController ball = coli.GetComponent<BallController>();
            ball.ActPowerUpSpeedUp(magtitude);
            SoundManager.instance.PowersUp();
            Destroy(gameObject);
        }
    }
    
}
