using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpPaddle : MonoBehaviour
{
    public float longs;
    private void OnTriggerEnter2D(Collider2D coli)
    {
        if (coli.name == "Ball")
        {
            BallController ball = coli.GetComponent<BallController>();
            ball.LongPaddle(longs);
            PowerUpController.instance.RemovePowerUp(gameObject);
            SoundManager.instance.PowersUp();
            Destroy(gameObject);
        }
    }
}
