using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Vector2 spd;
    private Rigidbody2D rb;
    //[Range(1f,40f)]
    //public float degreeRange;
    //public float initialForce;

    private void Start(){
        rb = GetComponent<Rigidbody2D>();
        RestartGame();
    }
    private void Update()
    {
        
    }
    void PushBall(){
        rb.velocity = spd;
        //float randomAngle = Random.Range(-degreeRange, degreeRange);
        //.if (randomAngle == 0) {
            //randomAngle += Random.Range(1f, 10f);
        //}
        //float randomRadian = randomAngle * Mathf.PI / 180;
     
        //float randomDirection = Random.Range(0, 2);

        //float xInitialForce = initialForce * Mathf.Cos(randomRadian);
        //float yInitialForce = initialForce * Mathf.Sin(randomRadian); 
        //if (randomDirection < 1.0f) {
            //xInitialForce = -xInitialForce;
        //}
        //rb.AddForce(new Vector2(xInitialForce, yInitialForce));
    }
    void ResetBall()
    {
        transform.position = Vector2.zero;
        rb.velocity = Vector2.zero;
    }
    public void RestartGame(){
        ResetBall();
        Invoke("PushBall", 2);
    }
}
