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
    public int score;
    public int coinsCollected;

    //public variables used to keep track of time 
    public float time = 100;

    //GameObject used to reference which UI GameObject scoreUI is
    //the reference is set in the inspector 
    public GameObject scoreUI;


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

    }

    void OnCollisionEnter2D(Collision2D collision)
    {

    }
}
