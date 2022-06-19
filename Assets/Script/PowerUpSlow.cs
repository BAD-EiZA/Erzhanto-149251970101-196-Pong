using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSlow : MonoBehaviour
{
    public float slow;
    private void OnTriggerEnter2D(Collider2D coli)
    {
        if (coli.name == "Ball")
        {
            BallController ball = coli.GetComponent<BallController>();
            ball.SlowProjectile(slow);
            PowerUpController.instance.RemovePowerUp(gameObject);
            SoundManager.instance.PowersUp();
            Destroy(gameObject);
        }
    }
}
