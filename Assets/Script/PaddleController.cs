using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float spd;
    public KeyCode upButton = KeyCode.W;
    public KeyCode downButton = KeyCode.S;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
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
        rb.velocity = movement;

    }
}
