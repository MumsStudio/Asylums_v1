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
    Vector3 pos1 = new Vector3(568, 337, 0);

    public void Start()
    {
        //get data form global
        if (index==1)
         {
            player.transform.position = carryDataBetwScreen.Instance.posM;
         }
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.CompareTag("Player"))
        {
            if (loop == false)
            {
                //load level with buikd index
                SceneManager.LoadScene(index);

                //load level with scene name
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
