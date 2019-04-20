using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStopMoving : MonoBehaviour {
    public playercontroller PMove;
    public GameObject gameScene;
    public GameObject pauseMenuUI;

    public static bool GameIsPaused = false;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }


    public void Pause()
    {
        gameScene.SetActive(false);
        pauseMenuUI.SetActive(true);
        PMove = FindObjectOfType<playercontroller>();
        PMove.canMove = false;
        GameIsPaused = true;
    }
    public void Resume()
    {
        gameScene.SetActive(true);
        pauseMenuUI.SetActive(false);
        PMove.canMove = true;
        GameIsPaused = false;
    }
  

}
