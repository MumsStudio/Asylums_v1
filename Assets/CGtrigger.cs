using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CGtrigger : MonoBehaviour
{
    private playercontroller thePlayer;
    public GameObject orginal;
    public GameObject nurseImg;
    public GameObject FlashImg;
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
            soundSource.SetActive(false);

            
            StartCoroutine(FlashEffect(1));
      

        }
    }
    IEnumerator FlashEffect(int time)
    {

        yield return new WaitForSeconds(1);
        nurseImg.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        nurseImg.SetActive(false);
        yield return new WaitForSeconds(0.4f);
        nurseImg.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        nurseImg.SetActive(false);
        yield return new WaitForSeconds(0.8f);
        nurseImg.SetActive(true);

        yield return new WaitForSeconds(1);
        nurseImg.SetActive(false);
        FlashImg.SetActive(true);

        yield return new WaitForSeconds(0.5f);
       

        SceneManager.LoadScene(4);
    }
}
