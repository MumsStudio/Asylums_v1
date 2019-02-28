using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour {

    public float moveSpeed;
	private bool playermoving;
    private Animator anim;
    public GameObject EscMenue;
    public GameObject SceneObject;
    public GameObject PlayerObject;

    private Rigidbody2D myRigidbody;    

    public bool canMove;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        canMove = true;
	}
	
	// Update is called once per frame
	void Update () {
		playermoving = false;

        if (!canMove)
        {
            myRigidbody.velocity = Vector2.zero;
            playermoving = false;
            
            anim.SetBool("playermoving", playermoving);
            return;
        }

        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            transform.Translate (new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime,0f,0f));
			playermoving = true;
            if (Input.GetAxisRaw("Horizontal") > 0.5f)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
        }
        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            transform.Translate(new Vector3(0f,Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
			playermoving = true;
        }
        
		anim.SetBool ("playermoving", playermoving);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            EscMenue.SetActive(true);
            SceneObject.SetActive(false);
            PlayerObject.SetActive(false);
        }
    }

    public void playerMoveEnable()
    {
        canMove = true;
        //Debug.Log("Player movement enable.");
    }
}
