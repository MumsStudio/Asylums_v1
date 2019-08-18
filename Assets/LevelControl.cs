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


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (index == 1)
        {
            player.transform.position = pos;
        }

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

    }
}
