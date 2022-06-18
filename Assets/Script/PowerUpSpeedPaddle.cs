using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpeedPaddle : MonoBehaviour
{
    public float spds;
    private void OnTriggerEnter2D(Collider2D coli)
    {
        if (coli.name == "Ball")
        {
            BallController ball = coli.GetComponent<BallController>();
            ball.SpeedPadle(spds);
            PowerUpController.instance.RemovePowerUp(gameObject);
            SoundManager.instance.PowersUp();
            Destroy(gameObject);
        }
    }
}
