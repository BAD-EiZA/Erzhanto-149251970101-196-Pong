using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideWall : MonoBehaviour
{
    public bool isRight;
    public ScoreManager sm;
    void OnTriggerEnter2D(Collider2D collide)
    {
        if (collide.name == "Ball")
        {
            if(isRight){
                SoundManager.instance.Goals();
                sm.AddRightScore(1);
            }
            else{
                SoundManager.instance.Goals();
                sm.AddLeftScore(1);
            }
            
        }
    }
}
