
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    public Text buff;
    private Vector2 ballFast;
    private Rigidbody2D rb;

    private void Start(){
        rb = GetComponent<Rigidbody2D>();
        RestartGame();
        
        

    }
    private void Update()
    {

        buff.text = rb.velocity.ToString();
        
    }
    public void PushBall(){
        rb.velocity = new Vector2(Random.Range(0, 4) * 2 - 1, 4f); 
    }
    public void ResetBall()
    {
        transform.position = Vector2.zero;
        rb.velocity = Vector2.zero;
    }
    public void RestartGame(){
        ResetBall();
        Invoke("PushBall", 2);
    }
    public void ActPowerUpSpeedUp(float magtitude)
    {
        rb.velocity *= magtitude;
    }
}
