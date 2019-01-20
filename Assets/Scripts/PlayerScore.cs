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
    private int gemsCollected;


    //public variables used to keep track of time 
    public float time = 100;

    //items 
    private bool keyCollected = false;

    //GameObject used to reference which UI GameObject scoreUI is
    //the reference is set in the inspector 
    public GameObject scoreUI;
    public GameObject gemUI;
    public GameObject keyUI;
    public Sprite key;

    //GameObjects for prefabs, used for instantiation 
    public GameObject openChest;
    public GameObject gemObject; 


    // Start is called before the first frame update
    void Start()
    {
        coinsCollected = 0;
        gemsCollected = 0;
        keyUI.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        //time = time - Time.deltaTime;
        //Debug.Log(time);
        scoreUI.gameObject.GetComponent<Text>().text = ":" + coinsCollected;
        gemUI.gameObject.GetComponent<Text>().text = ":" + gemsCollected;

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        
        if (collider.CompareTag("Coin"))
        {
            Destroy(collider.gameObject);
            coinsCollected++;
            PlayerPrefs.SetInt("coins", coinsCollected);

        }

        if (collider.CompareTag("Key"))
        {
            Destroy(collider.gameObject);
            keyCollected = true;
            keyUI.SetActive(true);

        }

        if (collider.CompareTag("Gem"))
        {
            Destroy(collider.gameObject);
            gemsCollected++;
            PlayerPrefs.SetInt("gems", gemsCollected);
        }

        if (collider.CompareTag("Chest") && keyCollected == true)
        {
            //Debug.Log("chest opening!");

            //changes chest sprite to an open chest sprite
            Vector3 chest_postion = collider.gameObject.transform.position;
            Destroy(collider.gameObject);
            Instantiate(openChest, chest_postion, Quaternion.identity);

            //Instatiates a gem object
            Vector2 gemPos = (Vector2)chest_postion + (Vector2.up * 2);
            Instantiate(gemObject, gemPos, Quaternion.identity);

            //deactivates the key UI image and removes key from inventory 
            keyUI.SetActive(false);
            keyCollected = false;

        }




    }

    void OnCollisionEnter2D(Collision2D collision)
    {

    }
}



