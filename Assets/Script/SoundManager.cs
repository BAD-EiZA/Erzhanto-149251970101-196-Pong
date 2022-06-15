using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioClip ballBounce;
    public AudioClip goal;
    public AudioClip powerUps;
    private AudioSource audios;
    // Start is called before the first frame update
    private void Start()
    {
        if (instance != null)
            Destroy(goal);
        else
            instance = this;
        audios = GetComponent<AudioSource>();
    }
    public void BallBounces()
    {
        audios.PlayOneShot(ballBounce);
    }
    public void Goals()
    {
        audios.PlayOneShot(goal);
    }
    public void PowersUp()
    {
        audios.PlayOneShot(powerUps);
    }
}
