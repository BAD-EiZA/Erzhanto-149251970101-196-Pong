using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;
    private Animator anim;
    public Transform spwn;
    public float cooldown = 10;
    private float timeatt;
    private bool CanAtt = true;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Att();
        if(ScoreManager.instance.isHit == true)
        {
            stopatt();
        }
    }
    private void Att()
    {
        if (!CanAtt)
        {
            timeatt += Time.deltaTime;
        }
        if (timeatt >= cooldown)
        {
            CanAtt = true;
        }
        if (CanAtt)
        {
            CanAtt = false;
            timeatt = 0;
            anim.SetBool("Attack", true);
        }
    }
    public void Shoots()
    {
        GameObject tembak = Instantiate(bullet, spwn.position, Quaternion.identity);
        Vector3 arah = new Vector3(transform.localPosition.x, 0);
        tembak.GetComponent<Projectile>().Setup(arah);
    }
    public void stopatt()
    {
        anim.SetBool("Attack", false);
    }
}
