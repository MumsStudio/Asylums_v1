using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;


public class LevelControl : MonoBehaviour
{

    public string levelName;
    public int index;
    public bool loop;
    public GameObject player;
    public Vector3 pos;
    public Camera cam;
    Vector3 pos1 = new Vector3(568, 337, 0);

    private sfxManage sfxman;

    public void Start()
    {
        //get data from global
        if (index==1)
         {
            player.transform.position = carryDataBetwScreen.Instance.posM;
            cam.transform.position = carryDataBetwScreen.Instance.camPos;
        }

        sfxman = FindObjectOfType<sfxManage>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            sfxman.footstep.Play();
            if (loop == false)
            {
                
                //load level with build index
                //SceneManager.LoadScene(index);

                //load level with scene name
                carryDataBetwScreen.prevScene = SceneManager.GetActiveScene().name;
                SceneManager.LoadScene(levelName);
            }
            //loop
            if (loop == true)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }

        if (index == 1) {
            carryDataBetwScreen.Instance.posM = pos1;
            carryDataBetwScreen.Instance.camPos = cam.transform.position;
        }
    }

    /*public void SavePlayer()
    {
        if (index ==2)
       {
           carryDataBetwScreen.Instance.posM = new Vector3(0, 0, 0);
           carryDataBetwScreen.Instance.posM = pos1;
       }
    }*/
}
