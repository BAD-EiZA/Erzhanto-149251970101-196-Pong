using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    public static PowerUpController instance;
    [Header("Variable")]
    public int maxPowerUp;
    public float seconds;
    public float timer;
    [Header("Game Setting")]
    public bool isSpawning;
    public bool isBuffz;
    [Header("Prefab")]
    public List<GameObject> powerUpTemplateList;
    public List<GameObject> powerUpList;
    void Start()
    {
        if(instance != null)
            Destroy(gameObject);
        else
            instance = this;

        powerUpList = new List<GameObject>();
        isSpawning = false;
        isBuffz = false;
    }
    private void Update()
    {
        timer -= Time.deltaTime;
        seconds = Mathf.FloorToInt(timer % 60);
        if (seconds % 10 == 0 && !isSpawning)
        {
            StartCoroutine("SpawnPowerUp", 2f);
        }
        Debug.Log("Index : " + powerUpList.Count);
    }
    public IEnumerator SpawnPowerUp()
    {
        isSpawning = true;
        int randomIndex = Random.Range(0, powerUpTemplateList.Count);
        GameObject Powers = Instantiate(powerUpTemplateList[randomIndex], new Vector3(Random.Range(-5f, 6f), Random.Range(-3f, 1f), powerUpTemplateList[randomIndex].transform.position.z), Quaternion.identity);
        powerUpList.Add(Powers);
        yield return new WaitForSeconds(1);
        if (powerUpList.Count >= maxPowerUp)
        {
            isSpawning = true;
            yield return new WaitForSeconds(7);
            RemoveAllPowerUp();
            isSpawning = false;
        }
        else
        {
            isSpawning = false;
        }
    }
    public void RemovePowerUp(GameObject Powers)
    {
        powerUpList.Remove(Powers);
        Destroy(Powers);
    }

    public void RemoveAllPowerUp()
    {
        while (powerUpList.Count > 0)
        {
            RemovePowerUp(powerUpList[0]);
        }
    }

}
