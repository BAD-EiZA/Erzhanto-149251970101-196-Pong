using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public static Projectile instance;
    public float spd;
    private Vector2 arah;
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        player = GameObject.Find("PaddlePlayer").transform;
        arah = new Vector2(player.position.x, player.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, arah, spd * Time.deltaTime);
        if (transform.position.x == arah.x && transform.position.y == arah.y)
        {
            DestroyBullet();
        }
    }
    void DestroyBullet()
    {
        Destroy(gameObject);
    }
    public void Setup(Vector2 arah)
    {
        this.arah = arah;
    }
    public void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D coli)
    {
        if (coli.gameObject.CompareTag("Player"))
        {
            ScoreManager.instance.isHit = true;
            ScoreManager.instance.GameOver();
            Destroy(gameObject);
        }
    }
}
