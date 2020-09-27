using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class TestComics : MonoBehaviour
{
    private playercontroller thePlayer;
    public GameObject curImg;
    public List<string> comicImages ;
    public int clickCount;
    public bool displayComic = true;

    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<playercontroller>();
        comicImages = new List<string>(new string[] { "Image1", "Image2", "Image3", "Image4" });
        clickCount = 1;


     //   Transform comic = transform.Find("Canvas");
     //   curImg = comic.Find("Image4").gameObject;
     //  curImg.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (displayComic)
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {

                if (clickCount >= 4)
                {
                    transform.Find("Canvas").Find(this.comicImages[3]).gameObject.SetActive(false);
                    thePlayer.canMove = true;
                    displayComic = false;
                }

                else
                {
                    //Transform comic = transform.Find("Canvas");
                    string ImgName = this.comicImages[this.clickCount];
                    curImg = transform.Find("Canvas").Find(ImgName).gameObject;
                    curImg.SetActive(true);

                    curImg = transform.Find("Canvas").Find(this.comicImages[this.clickCount - 1]).gameObject;
                    curImg.SetActive(false);
                    this.clickCount++;
                }

            }

        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (displayComic)
            {
                thePlayer.canMove = false;
                curImg = transform.Find("Canvas").Find(this.comicImages[0]).gameObject;
                curImg.SetActive(true);
            }
        }
    }


}
