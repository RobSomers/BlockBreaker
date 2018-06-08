using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    public AudioClip crack;
    public Sprite[] hitSprites;
    public static int breakableCount = 0;
    public GameObject Smoke;

    private int timesHit;
    private LevelManager LevelManager;
    private bool isBreakable;

    void Start () {
        isBreakable = (this.tag == "Breakable");
        if (isBreakable)
        {
            breakableCount++;
        }
        timesHit = 0;
        LevelManager = GameObject.FindObjectOfType<LevelManager>();
  	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (isBreakable)
        {
            HandleHits();
        }
    }

    void HandleHits ()
    {
        AudioSource.PlayClipAtPoint(crack, transform.position);
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if(timesHit >= maxHits)
        {
            breakableCount--;
            GameObject smokePuff = Instantiate(Smoke, gameObject.transform.position, Quaternion.identity);
            smokePuff.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
            Destroy(gameObject);
            WinCheck();
        }
        else
        {
            LoadSprites();
        }
    }

    void WinCheck()
    {
        if(breakableCount <= 0)
        {
            LevelManager.LoadNextLevel();
        }
    }

    void LoadSprites ()
    {
        int spriteIndex = timesHit - 1;
        this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
    }

}
