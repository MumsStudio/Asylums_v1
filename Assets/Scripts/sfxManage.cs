using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sfxManage : MonoBehaviour
{
    private sfxManage sfxman;
    public Collider2D player2D;
    public Collider2D toilet2D;
    public Collider2D monster2D;

    public AudioSource watereflush;
    public AudioSource pickItem;
    public AudioSource footstep;
    public AudioSource monster;
    public AudioSource buttonPress;

    private static bool sfxmanExist;

    // Use this for initialization
    void Start()
    {
        sfxman = FindObjectOfType<sfxManage>();

        if (!sfxmanExist)
        {
            sfxmanExist = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (toilet2D != null && player2D.IsTouching(toilet2D))
        {
            sfxman.watereflush.Play();
        }
        else if (monster2D != null && player2D.IsTouching(monster2D))
        {
            sfxman.monster.Play();
        }
    }
}
