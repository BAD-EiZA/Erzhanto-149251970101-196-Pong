
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    public Text buff;
    private Vector2 ballFast;
    private Rigidbody2D rb;
    public bool isBuffs;
    public float times = 2f;
    public float seconds;
    private void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        RestartGame();
        isBuffs = true;
    }
    private void Update()
    {
        times -= Time.deltaTime;
        seconds = Mathf.FloorToInt(times % 60);
        if (seconds % 3 == 0 && !isBuffs)
        {
            StartCoroutine("StopPowerUpSpeedUp");
        }

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
        
        
        rb.velocity = rb.velocity * magtitude;
        isBuffs = false;
        
        
        




    }
    
    public IEnumerator StopPowerUpSpeedUp()
    {
        yield return new WaitForSeconds(3);
        isBuffs = true;
        rb.velocity -= rb.velocity * 0.1f;
        

    }
    

}
