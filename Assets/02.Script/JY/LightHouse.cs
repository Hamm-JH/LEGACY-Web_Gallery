using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightHouse : MonoBehaviour
{
    public LightHouseData lhData;

    public void PrintLHData()
    {
        Debug.Log("등대 이름: " + lhData.LightHouseName);
        Debug.Log("------------------------------------");
    }

    
}
