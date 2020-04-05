using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour {

    public float speed;
    public bool movingRight;
    public bool NpcCanMove;
    public DialogHolder eventDialog;
    //public GameObject player;
    public float horizontalInput;
    public float verticalInput;


    private void Update()
    {
        //movement code
        //transform.position = player.transform.position;
        if (!movingRight)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        else { transform.Translate(Vector2.right * speed * Time.deltaTime); }
        


    }
    private void OnTriggerEnter2D(Collider2D colli)
    {
        //if collid with player start display dialog
        if (colli.gameObject.tag.Contains("Player")&& NpcCanMove)
        {
            speed = 0;
            Debug.Log("player");
            eventDialog.isEnforcedEvent = true;

        }
        else if(!NpcCanMove && colli.gameObject.tag.Contains("NPCpositon"))
        {
            speed = 0;
            transform.eulerAngles = new Vector3(0, 0, 0);
            Debug.Log("pl");

        }
    }
    private void OnTriggerExit2D(Collider2D colli)
    {
        if (NpcCanMove)
        {
            speed = 2;
            transform.eulerAngles = new Vector3(0, -180, 0);
        }
        NpcCanMove = false;

        //transform.position = transform.position + new Vector3(horizontalInput * speed * Time.deltaTime, verticalInput * speed * Time.deltaTime, 0);
    }
}
