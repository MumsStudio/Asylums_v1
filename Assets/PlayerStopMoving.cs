using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStopMoving : MonoBehaviour {
    private playercontroller PMove;
    public void Pasue()
    {
        PMove = FindObjectOfType<playercontroller>();
        PMove.canMove = false;
    }
    public void resume()
    {
        PMove.canMove = true;
    }
  
}
