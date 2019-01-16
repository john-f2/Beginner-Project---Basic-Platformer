/*
 * 
 * Player Life script, keeps track of player life 
 * and whether or not the player has died 
 * 
 * @author johnf2 
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    public int health;

    //GameObject UI reference, set in the inspector 
    public GameObject healthUI;

    // Start is called before the first frame update
    void Start()
    {
        //initially sets the player health to 5
        health = 5;
        Debug.Log("starting health is " + health);

    }

    // Update is called once per frame
    void Update()
    {
        healthUI.gameObject.GetComponent<Text>().text = "Player Health: " + health;
    }
}
