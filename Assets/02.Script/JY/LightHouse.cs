using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightHouse : MonoBehaviour
{
    public LightHouseData lhData;

    public void PrintLHData()
    {
        Debug.Log("��� �̸�: " + lhData.LightHouseName);
        Debug.Log("------------------------------------");
    }

    
}
