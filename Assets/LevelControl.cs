using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;


public class LevelControl : MonoBehaviour
{

    public string levelName;
    public int index;
    public bool loop;


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

    }
}
