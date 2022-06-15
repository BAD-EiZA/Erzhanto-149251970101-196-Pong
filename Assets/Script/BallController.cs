
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
    public bool isGoal;
    public float times = 2f;
    public float seconds;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        RestartGame();
        isBuffs = true;
        isGoal = false;
}
    private void Update()
    {
        times -= Time.deltaTime;
        seconds = Mathf.FloorToInt(times % 60);
        if (seconds % 3 == 0 && !isBuffs)
        {
            StartCoroutine("StopPowerUpSpeedUp");
        }
        else if (isGoal)
        {
            StopCoroutine("StopPowerUpSpeedUp");
        }
        if (transform.position.y > 7f || transform.position.y < -7f)
        {
            StopCoroutine("StopPowerUpSpeedUp");
            RestartGame();
        }
        buff.text = rb.velocity.magnitude.ToString();
        Debug.Log("Vector : " + rb.velocity);

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
        isGoal = false;
    }
    public void ActPowerUpSpeedUp(float magtitude)
    {
        rb.velocity *= magtitude;
        isBuffs = false;
    }
    
    public IEnumerator StopPowerUpSpeedUp()
    {
        yield return new WaitForSeconds(3);
        rb.velocity = rb.velocity.normalized * 6;
        isBuffs = true;
    }
    

}
