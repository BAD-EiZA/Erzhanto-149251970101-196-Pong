using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIRacket : MonoBehaviour
{
    Rigidbody2D rb;
    [Header("AI Setting")]
    public float spd;
    public float delayMove;
    private float randPos;
    private bool isMoveAI;
    private bool isSingleTake;
    private bool isUp;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if(!isMoveAI && !isSingleTake)
        {
            StartCoroutine("DelayAI");
            isSingleTake = true;
        }
        if (isMoveAI)
        {
            MoveAI();
        }
    }
    private IEnumerator DelayAI()
    {
        yield return new WaitForSeconds(delayMove);
        randPos = Random.Range(-2f, 2f);
        if(transform.position.y < randPos)
        {
            isUp = true;
        }
        else
        {
            isUp = false;
        }
        isSingleTake = false;
        isMoveAI = true;
    }
    private void MoveAI()
    {
        if (!isUp)
        {
            rb.velocity = new Vector2(0, -2) * spd;
            if(transform.position.y <= randPos)
            {
                rb.velocity = Vector2.zero;
                isMoveAI = false;
            }
        }
        if (isUp)
        {
            rb.velocity = new Vector2(0, 2) * spd;
            if (transform.position.y >= randPos)
            {
                rb.velocity = Vector2.zero;
                isMoveAI = false;
            }
        }
    }
}
