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
    [Header("�ٿ�ε带 ���ϴ� ���� �Ǵ� ����鿡 ���Ե� ���̺��� �ƹ��ų� �Է����ּ���.")]
    [SerializeField] string LableForBundleDown = string.Empty;


    private void Awake()
    {
        // _CreateServerObj();
    }

    public void _CreateServerObj() //������ ������ �Լ�.(�������� �Ҿ��.)
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
                //DownloadPercent������Ƽ�� �ٿ�ε� ������ Ȯ���� �� ����.
                 float DownloadPercent = handle.PercentComplete;
               // var locations = handle.Result;
               // Addressables.InstantiateAsync(locations[2]);
                Debug.Log(DownloadPercent + "�ٿ�ε� �Ϸ�!");

                    //�ٿ�ε尡 ������ �޸� ����.
                    Addressables.Release(handle);

            };
    }

    public void _Click_CheckTheDownloadFileSize()
    {
        //ũ�⸦ Ȯ���� ���� �Ǵ� ����鿡 ���Ե� ���̺��� ���ڷ� �ָ� ��.
        //longŸ������ ��ȯ�Ǵ°� Ư¡��.
        Addressables.GetDownloadSizeAsync(LableForBundleDown).Completed +=
            (AsyncOperationHandle<long> SizeHandle) =>
            {
                string sizeText = string.Concat(SizeHandle.Result, " byte");

                SizeText.text = sizeText;

                    //�޸� ����.
                    Addressables.Release(SizeHandle);
            };


    }
}
  


