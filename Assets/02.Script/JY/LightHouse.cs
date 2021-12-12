using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightHouse : MonoBehaviour
{
    public LightHouseData lhData;

    public AudioSource lightHouseAudioSource;

    public Canvas canvasResource;
    //public EventDef.UIEvents soundEventPoint;

    public void InitializePrefab()
	{
        lightHouseAudioSource.clip = lhData.AudioClip;

        canvasResource.worldCamera = Management.GameManager.Instance.core.mainCamera;
	}

    public void PrintLHData()
    {
        Debug.Log("등대 이름: " + lhData.LightHouseName);
        Debug.Log("------------------------------------");
    }

    #region Event
    public void OnAudioPlay()
	{
        lightHouseAudioSource.Play();
	}
	#endregion
}
