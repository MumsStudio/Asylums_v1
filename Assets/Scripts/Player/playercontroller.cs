using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class playercontroller : MonoBehaviour {

    public float moveSpeed ;
    public GameObject RoomInitializer;
    public SaveData data;
    public GameObject PlayerObject;
    private bool playermoving;
    private Animator anim;
    private Rigidbody2D myRigidbody;
    public bool canMove;

    Vector3 pos1 = new Vector3(568, 337, 0);

    public int index;

    // Use this for initialization
    void Start () {
        //get data form global
       if (index==2)
        {
            PlayerObject.transform.position = carryDataBetwScreen.Instance.posM;
        }
       

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
     
        //shift keyword accelerate player 
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {    
            moveSpeed = 2.4f;
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = 0.8f;
        }

    }

    public void playerMoveEnable()
    {
        canMove = true;
        //Debug.Log("Player movement enable.");
    }
    
    //map values player currently have to the save data
    private void RefreshSaveData()
    {
        if (data.position == null)
        {
            data.position = new Position();
        }
        data.position.x = PlayerObject.transform.position.x;
        data.position.y = PlayerObject.transform.position.y;
        data.items = PlayerObject.GetComponentInChildren<Backpack>().items;
        data.infoDB = PlayerObject.GetComponentInChildren<Backpack>().infoDB;
        data.eventsDone = PlayerObject.GetComponentInChildren<Backpack>().eventsDone;
        data.roomExplored = PlayerObject.GetComponentInChildren<Backpack>().roomExplored;
        //Debug.Log("Save Data Refreshed.");
    }

    private void PutSaveDataToPlayer()
    {
        PlayerObject.transform.position = new Vector2(data.position.x, data.position.y);
        PlayerObject.GetComponentInChildren<Backpack>().items = data.items;
        PlayerObject.GetComponentInChildren<Backpack>().infoDB = data.infoDB;
        PlayerObject.GetComponentInChildren<Backpack>().eventsDone = data.eventsDone;
        PlayerObject.GetComponentInChildren<Backpack>().roomExplored = data.roomExplored;

        //set rooms' state
        RoomInitializer.GetComponentInChildren<RoomInitializer>().RoomInitialize();
        Debug.Log("Room Initialized.");
        //Debug.Log("Save Data has put onto player.");
    }

    public void PlayerSaveData()
    {
        //update data store first
        RefreshSaveData();

        //create a file or opne one to save to 
        FileStream file = new FileStream(Application.persistentDataPath+"/save.dat", FileMode.OpenOrCreate);
        //binary formater add
        BinaryFormatter formatter = new BinaryFormatter();
        //serialization method to WRITE to the file
        formatter.Serialize(file, data);
        file.Close();
        Debug.Log("Data Saved."); 
        //remeber to set player able to walk back to true
        canMove = true;
    }

    public void PlayerLoadData()
    {
        //opne a file to load from
        FileStream file = new FileStream(Application.persistentDataPath + "/save.dat", FileMode.OpenOrCreate);
        //binary formater add
        BinaryFormatter formatter = new BinaryFormatter();
        //serialization method to WRITE to the file
        data = (SaveData) formatter.Deserialize(file);
        file.Close();
        //Debug.Log("Data Load to Player.data");

        //put loaded data to where it should do the work
        PutSaveDataToPlayer();
        //Debug.Log("Load Done!");

        //remeber to set player able to walk back to true
        canMove = true;
    }

    public void SavePlayer()
    {
        if (index ==1)
        {
            carryDataBetwScreen.Instance.posM = pos1;
        }
    }
}
