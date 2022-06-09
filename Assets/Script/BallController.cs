
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Vector2 ballFast;
    public int spd;
    private Rigidbody2D rb;

    private void Start(){
        rb = GetComponent<Rigidbody2D>();
        RestartGame();
        
    }
    private void Update()
    {
        
        
    }
    public void PushBall(){
        ballFast = new Vector2(Random.Range(-2,3)*2-1, 1);
        rb.velocity =  ballFast * spd;
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
}
