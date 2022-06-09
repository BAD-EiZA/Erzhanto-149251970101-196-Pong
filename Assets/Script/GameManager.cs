using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [Header("Game Setting")]
    public float timer;
    public bool isSpawnPowerUp;

    [Header("Prefab")]
    public GameObject powerUp;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    private void Update()
    {
        timer-= Time.deltaTime;
        float seconds = Mathf.FloorToInt(timer % 60);
        if(seconds % 15 == 0 && !isSpawnPowerUp){
            StartCoroutine("SpawnPowerUp");
            
        }
        
    }
    public IEnumerator SpawnPowerUp(){
        isSpawnPowerUp = true;
        Instantiate(powerUp, new Vector3(Random.Range(-7f , 3f), Random.Range(-3f, 1f), 0), Quaternion.identity);
        yield return new WaitForSeconds(20);
        isSpawnPowerUp = false;
        
        
    }

}
