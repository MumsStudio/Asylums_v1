using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeVolume : MonoBehaviour {

    public Slider Volume;
    public AudioSource music;

    // Update is called once per frame
    private void Start()
    {
        music.volume = 0.5f;
    }
    void Update () {
        music.volume = Volume.value;
	}
}
