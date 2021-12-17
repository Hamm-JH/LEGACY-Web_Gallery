using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{
    bool isClicked;
    public GameObject image;
    // Start is called before the first frame update
    void Start()
    {
        isClicked = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  public void Button_Click()
    {
       
        if(isClicked)
        {
            image.SetActive(true);
            isClicked = false;
            Debug.Log("image open" + image.activeSelf);
        }
        else
        {
            image.SetActive(false);
            isClicked = true;
            Debug.Log("image open" + image.activeSelf);
        }
       
    }
}
