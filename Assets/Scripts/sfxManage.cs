using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sfxManage : MonoBehaviour {
    public AudioSource watereflush;
    public AudioSource pickItem;
    public AudioSource footstep;
    public AudioSource monster;
    public AudioSource buttonPress;

    private static bool sfxmanExist;

    // Use this for initialization
    void Start () {
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
}
