
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    public Text buff;
    private Vector2 ballFast;
    private Rigidbody2D rb;
    public bool isGoal;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        RestartGame();
        isGoal = false;
}
    private void Update()
    {
        if (transform.position.y > 7f || transform.position.y < -7f)
        {
            RestartGame();
        }
        buff.text = rb.velocity.magnitude.ToString();
        Debug.Log("Vector : " + rb.velocity);

    }
    public void PushBall()
    {
        if(GameData.instance.isSingleplayer == true)
        {
            ballFast = new Vector2(Random.Range(-1, 3) * 2 - 1, Random.Range(3, 7));
            rb.velocity = ballFast * 2;
        }
        if(GameData.instance.isSingleplayer == false)
        {
            ballFast = new Vector2(Random.Range(-1, 3) * 2 - 1, Random.Range(3, 7));
            rb.velocity = ballFast;
        } 
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
        StopCoroutine("StopPowerUpSpeedUp");
    }
    public void ActPowerUpSpeedUp(float magtitude)
    {
        rb.velocity *= magtitude;
        StartCoroutine("StopPowerUpSpeedUp");
    }
    
    public IEnumerator StopPowerUpSpeedUp()
    {
        yield return new WaitForSeconds(5);
        rb.velocity = rb.velocity.normalized * 6;
    }
    public void LongPaddle()
    {
        if (GameData.instance.isSingleplayer == true)
        {
            PaddleController.instance.rb.transform.localScale = new Vector3(2.4f, 1.7f, 2.4f);
            EnemyController.instance.rb.transform.localScale = new Vector3(2.4f, 1.7f, 2.4f);
        }
        if(GameData.instance.isSingleplayer == false)
        {
            PaddleController.instance.rb.transform.localScale = new Vector3(0.3f, 2.7f, 1);

            EnemyController.instance.rb.transform.localScale = new Vector3(0.3f, 2.7f, 1);
        }
        
        
        StartCoroutine("StopLong");
    }
    public IEnumerator StopLong()
    {
        yield return new WaitForSeconds(5);
        if (GameData.instance.isSingleplayer == true)
        {
            PaddleController.instance.rb.transform.localScale = new Vector3(2.4f, 1.2f, 2.4f);
            EnemyController.instance.rb.transform.localScale = new Vector3(2.4f, 1.2f, 2.4f);
        }
        if (GameData.instance.isSingleplayer == false)
        {
            PaddleController.instance.rb.transform.localScale = new Vector3(0.3f, 1.7f, 1);

            EnemyController.instance.rb.transform.localScale = new Vector3(0.3f, 1.7f, 1);
        }
    }
    public void SpeedPadle(float spds)
    {
        PaddleController.instance.spd *= spds;
        EnemyController.instance.spdPaddle *= spds;
        StartCoroutine("StopSpeed");

    }
    public IEnumerator StopSpeed()
    {
        yield return new WaitForSeconds(5);
        PaddleController.instance.spd = 5;
        EnemyController.instance.spdPaddle = 5;
    }
    public void SlowProjectile(float slow)
    {
        Projectile.instance.spd = slow;
        StartCoroutine("StopSlow");
    }
    public IEnumerator StopSlow()
    {
        yield return new WaitForSeconds(5);
        Projectile.instance.spd = 5;
    }
}
