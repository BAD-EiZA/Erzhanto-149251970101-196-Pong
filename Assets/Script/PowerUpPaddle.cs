using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpPaddle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D coli)
    {
        if (coli.name == "Ball")
        {
            BallController ball = coli.GetComponent<BallController>();
            ball.LongPaddle();
            PowerUpController.instance.RemovePowerUp(gameObject);
            SoundManager.instance.PowersUp();
            Destroy(gameObject);
        }
    }
}
