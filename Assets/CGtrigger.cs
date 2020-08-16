using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CGtrigger : MonoBehaviour
{
    private playercontroller thePlayer;
    public GameObject orginal;
    public GameObject CG;
    public GameObject soundSource;

    public void Start()
    {
        thePlayer = FindObjectOfType<playercontroller>();
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            thePlayer.canMove = false;
            orginal.SetActive(false);
            CG.SetActive(true);
            soundSource.SetActive(false);
            
            StartCoroutine(ChangeText(2));
        }
    }

    IEnumerator ChangeText(int time)
    {
        
        yield return new WaitForSeconds(time);
        CG.SetActive(false);

        SceneManager.LoadScene(4);
    }


}
