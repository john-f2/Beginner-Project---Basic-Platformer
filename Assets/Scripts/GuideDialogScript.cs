using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuideDialogScript : MonoBehaviour
{
    public GameObject DialogText;
    public string dialog;
    [SerializeField] protected int fontSize = 13;

    // Start is called before the first frame update
    void Start()
    {
        //does not show dialog text until interacted with 
        DialogText.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Text guideText = DialogText.gameObject.GetComponent<Text>();
        guideText.fontSize = fontSize;
        if (other.CompareTag("Player"))
        {
            DialogText.SetActive(true);
            
            guideText.text = dialog;
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
