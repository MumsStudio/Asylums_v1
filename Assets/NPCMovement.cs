using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour {

    public float speed;

    private bool movingRight = true;

    public Transform WallDetection;

    //public Transform notwall;

    private void Update()
    {
        //move code
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D colli)
    {
        //if collid with player start display dialog
        if (colli.gameObject.tag.Contains("Player"))
        {
            speed = 0;
            Debug.Log("player");
        }
       

    }
    private void OnTriggerExit2D(Collider2D colli)
    {
        transform.eulerAngles = new Vector3(0, -180, 0);
        speed = 2;
        
    }
}
