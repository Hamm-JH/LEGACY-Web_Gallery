using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _URL : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnLoad()
	{
        string url = "https://christmasexperiments.com/xps/2016/01/night-eye/";
        Application.OpenURL(url);
	}
}
