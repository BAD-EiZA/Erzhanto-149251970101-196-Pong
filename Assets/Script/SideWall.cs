using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideWall : MonoBehaviour
{
    public BallController bc;
    public bool isRight;
    public ScoreManager sm;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D collide)
    {
        if (collide.name == "Ball")
        {
            if(isRight){
                sm.AddRightScore(1);
                
            }
            else{
                sm.AddLeftScore(1);
                
            }
            
        }
    }
}
