using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour {

    public float speed;

    private bool movingRight = true;

    public Transform WallDetection;

    public Transform notwall;

    private void Update()
    {
        //move code
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D WallInfo = Physics2D.Raycast(WallDetection.position, Vector2.right, 2f);
        //change direction when hit the wall
        if (WallInfo.collider.transform.parent != notwall)
        {
            Debug.Log(WallInfo.collider.transform.parent);
            
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }

    }
}
