using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStopMoving : MonoBehaviour {
    public playercontroller PMove;
    public GameObject gameScene;
    public GameObject pauseMenuUI;

    public GameObject Menue;
    public GameObject PlayerInfor;
    public GameObject Backpack;
    public GameObject Option;
    public GameObject GameData;

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
        if (PlayerInfor.activeSelf)
        {
            PlayerInfor.SetActive(false);
            Menue.SetActive(true);
        }
        else if (Backpack.activeSelf)
        {
            Backpack.SetActive(false);
            Menue.SetActive(true);
        }
        else if(Option.activeSelf)
        {
            Option.SetActive(false);
            Menue.SetActive(true);
        }
        else if(GameData.activeSelf)
        {
            GameData.SetActive(false);
            Menue.SetActive(true);
        }
        else
        {
            gameScene.SetActive(true);
            pauseMenuUI.SetActive(false);
            PMove.canMove = true;
            GameIsPaused = false;
        }

    }
  

}
