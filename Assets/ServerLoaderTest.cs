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

    [SerializeField] GameObject lightHouse;
    private void Start()
    {
        _CreateServerObj();
    }

    public void _CreateServerObj() //������ ������ �Լ�.(�������� �Ҿ��.)
    {
       // Addressables.InstantiateAsync("LightHouse", new Vector3(0, 0, 0), Quaternion.identity);
        Addressables.InstantiateAsync("LightHouse");
     
        Debug.Log("load success!");
    }




    public void _Click_BundleDown()
    {
        Addressables.DownloadDependenciesAsync(LableForBundleDown).Completed +=
            (AsyncOperationHandle Handle) =>
            {
                //DownloadPercent������Ƽ�� �ٿ�ε� ������ Ȯ���� �� ����.
                //ex) float DownloadPercent = Handle.PercentComplete;

                Debug.Log("�ٿ�ε� �Ϸ�!");

                //�ٿ�ε尡 ������ �޸� ����.
                Addressables.Release(Handle);

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
