using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public class ServerLoaderTest : MonoBehaviour
{
    [SerializeField] Text SizeText;

    [Space]
    [Header("다운로드를 원하는 번들 또는 번들들에 포함된 레이블중 아무거나 입력해주세요.")]
    [SerializeField] string LableForBundleDown = string.Empty;


    private void Awake()
    {
        // _CreateServerObj();
    }

    public void _CreateServerObj() //기존에 만들어둔 함수.(서버에서 불어옴.)
    {
        Addressables.InstantiateAsync("World", new Vector3(0, 0, 0), Quaternion.identity);
        // Addressables.InstantiateAsync("LightHouse");

        Debug.Log("load success!");
    }


 

    public void _Click_BundleDown()
    {
        Addressables.DownloadDependenciesAsync(LableForBundleDown).Completed +=
            (AsyncOperationHandle handle) =>
            {
                //DownloadPercent프로퍼티로 다운로드 정도를 확인할 수 있음.
                 float DownloadPercent = handle.PercentComplete;
               // var locations = handle.Result;
               // Addressables.InstantiateAsync(locations[2]);
                Debug.Log(DownloadPercent + "다운로드 완료!");

                    //다운로드가 끝나면 메모리 해제.
                    Addressables.Release(handle);

            };
    }

    public void _Click_CheckTheDownloadFileSize()
    {
        //크기를 확인할 번들 또는 번들들에 포함된 레이블을 인자로 주면 됨.
        //long타입으로 반환되는게 특징임.
        Addressables.GetDownloadSizeAsync(LableForBundleDown).Completed +=
            (AsyncOperationHandle<long> SizeHandle) =>
            {
                string sizeText = string.Concat(SizeHandle.Result, " byte");

                SizeText.text = sizeText;

                    //메모리 해제.
                    Addressables.Release(SizeHandle);
            };


    }
}
  


