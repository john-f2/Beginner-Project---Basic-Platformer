/*
 * 
 * Player Score Script
 * Used to keep track of player score and potentially time
 * 
 * @author johnf2
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    //used to keep track of score
    private int score;
    private int coinsCollected;


    //public variables used to keep track of time 
    public float time = 100;

    //items 
    private bool keyCollected = false;

    //GameObject used to reference which UI GameObject scoreUI is
    //the reference is set in the inspector 
    public GameObject scoreUI;
    public GameObject keyUI;

    public Sprite key;


    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        coinsCollected = 0;

    }

    // Update is called once per frame
    void Update()
    {
        //time = time - Time.deltaTime;
        //Debug.Log(time);
        scoreUI.gameObject.GetComponent<Text>().text = "Coins: " + coinsCollected;
        if (keyCollected == true)
        {
            keyUI.gameObject.GetComponent<Image>().sprite = key;
        }

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        //Debug.Log(collider.tag);
        if (collider.CompareTag("Coin"))
        {
            Destroy(collider.gameObject);
            coinsCollected++;
        }

        if (collider.CompareTag("Key"))
        {
            Destroy(collider.gameObject);
            keyCollected = true;
        }


    }

    void OnCollisionEnter2D(Collision2D collision)
    {

    }
}
