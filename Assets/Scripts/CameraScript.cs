/*
 * Camera Script, used to track the player 
 * attached to the Main Camera Object 
 * 
 * @author johnf2
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    //TODO: update when more class material is given 

    //reference to player gameObject
    private GameObject player;

    //position variables, will clamp the camera to a specific location 
    //hence: xMax is the farthest position the camera will go to
    public float xMin;
    public float yMin;
    public float xMax;
    public float yMax;


    // Start is called before the first frame update
    void Start()
    {
        //on initialization, the player object is set 
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    //LateUpdate is called at the end of the update cycle
    void LateUpdate()
    {
        //clamps the value of the player's position in between the min and max values 
        float x = Mathf.Clamp(player.transform.position.x, xMin, xMax);
        float y = Mathf.Clamp(player.transform.position.y, yMin, yMax);

        //the camera position changes based on player object
        //essentially keeps the player at the center of the camera 
        gameObject.transform.position = new Vector3(x, y, gameObject.transform.position.z);


    }
}
