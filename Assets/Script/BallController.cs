
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    public Text buff;
    public Vector2 ballFast;
    public int spd;
    private Rigidbody2D rb;

    private void Start(){
        rb = GetComponent<Rigidbody2D>();
        spd = 2;
        RestartGame();
        
    }
    private void Update()
    {
        Debug.Log("Vector 2 : " + ballFast + "*" + "Speed : " + spd);
        buff.text = spd.ToString();
        
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
