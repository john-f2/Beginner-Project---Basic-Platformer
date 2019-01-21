using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CursorScript : MonoBehaviour
{
    public float xOffSet;
    private float x;
    private float y1;
    private float y2;

    public GameObject startUI;
    public GameObject quitUI;


    private int currentSelection = 0; //0 represents start, 1 represents quit 
    // Start is called before the first frame update
    void Start()
    {
        x = startUI.transform.position.x + xOffSet;
        y1 = quitUI.transform.position.y ;
        y2 = startUI.transform.position.y + 1.0f;
        this.transform.position = new Vector2(x, y2);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) )
        {
            this.transform.position = new Vector2(x, y1);
            currentSelection = 1;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            this.transform.position = new Vector2(x, y2);
            currentSelection = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            if(currentSelection == 0)
            {
                //loads level 1
                SceneManager.LoadScene("Level1");
            }
            else
            {
                //exits the game 
                Application.Quit();
            }
        }



    }

}
