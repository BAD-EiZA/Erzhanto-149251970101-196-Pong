
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public static PaddleController instance;
    public float spd;
    public KeyCode upButton = KeyCode.W;
    public KeyCode downButton = KeyCode.S;
    public Rigidbody2D rb;
    public bool isLong;
    public bool isSpeed;
    void Start()
    {
        instance = this;
        rb = GetComponent<Rigidbody2D>();
        isLong = true;
        isSpeed = true;
    }
    void Update()
    {
        MoveObject(GetInput());
    }
    private Vector2 GetInput(){
        if(Input.GetKey(upButton)){
            return Vector2.up * spd;
        }
        else if(Input.GetKey(downButton)){
            return Vector2.down * spd;
        }
        return Vector2.zero;
    }
    private void MoveObject(Vector2 movement){
        Debug.Log("Speed Paddle :" + movement);
        rb.velocity = movement;
    }
    public void ResetPaddle()
    {
        rb.velocity = Vector2.zero;
    }
    
    
}
