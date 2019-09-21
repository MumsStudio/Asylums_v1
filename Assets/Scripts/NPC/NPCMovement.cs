using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour {

    public float speed;
    private bool movingRight = true;
    //public GameObject player;
    public float horizontalInput;
    public float verticalInput;

    private void Update()
    {
        //movement code
        //transform.position = player.transform.position;
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
        else
        {
            speed = 0;
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }
    private void OnTriggerExit2D(Collider2D colli)
    {
        transform.eulerAngles = new Vector3(0, -180, 0);
        speed = 2;
        //transform.position = transform.position + new Vector3(horizontalInput * speed * Time.deltaTime, verticalInput * speed * Time.deltaTime, 0);
    }
}
