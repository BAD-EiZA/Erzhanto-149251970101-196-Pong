using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public static EnemyController instance;
    [Header("Variable")]
    public float spdAI;
    public float spdPaddle;
    public float delayMove;
    private float randPos;
    [Header("Bool")]
    private bool isMoveAI;
    private bool isSingleTake;
    private bool isUp;
    public bool isOver;
    [Header("Another")]
    public KeyCode upButton = KeyCode.W;
    public KeyCode downButton = KeyCode.S;
    public Rigidbody2D rb;

    
    void Start()
    {
        instance = this;
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (GameData.instance.isSingleplayer == false)
        {
            MoveObject(GetInput());
        }
        if (GameData.instance.isSingleplayer == true)
        {
            if (!isMoveAI && !isSingleTake)
            {
                StartCoroutine("DelayAI");
                isSingleTake = true;
            }
            if (isMoveAI)
            {
                MoveAI();
            }
           
        }
        if (isOver)
        {
            rb.velocity = Vector3.zero;
        }   
    }
    private Vector2 GetInput()
    {
        if (Input.GetKey(upButton))
        {
            return Vector2.up * spdPaddle;
        }
        else if (Input.GetKey(downButton))
        {
            return Vector2.down * spdPaddle;
        }
        return Vector2.zero;
    }
    private void MoveObject(Vector2 movement)
    {
        Debug.Log("Speed Paddle :" + movement);
        rb.velocity = movement;
    }
    private IEnumerator DelayAI()
    {
        yield return new WaitForSeconds(delayMove);
        randPos = Random.Range(-1f, 1f);
        if (transform.position.y < randPos)
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
            rb.velocity = new Vector2(0, -0.5f) * spdAI;
            if (transform.position.y <= randPos)
            {
                rb.velocity = Vector2.zero;
                isMoveAI = false;
            }
        }
        if (isUp)
        {
            rb.velocity = new Vector2(0, 0.5f) * spdAI;
            if (transform.position.y >= randPos)
            {
                rb.velocity = Vector2.zero;
                isMoveAI = false;
            }
        }
    }


}
