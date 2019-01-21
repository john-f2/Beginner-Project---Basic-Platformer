using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatDialogScript : MonoBehaviour
{
    //Reference to DialogUI gameObject 
    public GameObject DialogText;
    public GameObject invisibleWall;
    //public string dialog;

    // Start is called before the first frame update
    void Start()
    {
        DialogText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Text catText = DialogText.gameObject.GetComponent<Text>();
        catText.fontSize = 25;
        if (other.CompareTag("Player"))
        {
            if (PlayerPrefs.GetInt("gems") < 2 || PlayerPrefs.GetInt("coins") < 5 )
            {
                catText.text = "I want 5 gold coins and 3 gems!";

            }
            else
            {
                catText.text = "Heheh... You can pass";
                Destroy(invisibleWall.gameObject);
            }
            DialogText.SetActive(true);


        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DialogText.SetActive(false);
        }
    }
}
