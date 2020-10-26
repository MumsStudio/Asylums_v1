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

    public GameObject blood1;
    public GameObject blood2;
    public GameObject blood3;
    public GameObject blood4;
    public GameObject blood5;
    public GameObject blood6;

    public AudioSource monster;

    public GameObject soundSource;
    public string deathWay;



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

            if (deathWay == "nurse")
            {
                StartCoroutine(FlashEffect());
            }

            else if (deathWay == "blood")
            {
                StartCoroutine(BloodEffect());
            }


        }
    }
    IEnumerator FlashEffect()
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

    IEnumerator BloodEffect()
    {
        
        yield return new WaitForSeconds(2);

        blood1.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        blood2.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        blood3.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        blood4.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        blood5.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        blood6.SetActive(true);

        yield return new WaitForSeconds(1);
        

        SceneManager.LoadScene(4);
    }
}
