
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    public Text buff;
    private Vector2 ballFast;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        RestartGame();
    }
    private void Update()
    {
        buff.text = rb.velocity.ToString();

    }
    public void PushBall()
    {
        ballFast = new Vector2(Random.Range(-1, 3) * 2 - 1, Random.Range(3f, 7f));
        rb.velocity = ballFast;
    }
    public void ResetBall()
    {
        transform.position = Vector2.zero;
        rb.velocity = Vector2.zero;
    }
    public void RestartGame()
    {
        ResetBall();
        Invoke("PushBall", 2);
    }
    public void ActPowerUpSpeedUp(float magtitude)
    {

        rb.velocity *= magtitude;

    }
    public void StopPowerUpSpeedUp()
    {
        rb.velocity /= 1;
    }
    

}
