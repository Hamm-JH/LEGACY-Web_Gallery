using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LightHouseType { BlackLH, RedLH, WhiteLH}
public class LightHouseSpawner : MonoBehaviour
{
    //���?������ ����Ʈ�� ����.
    [SerializeField]
    private List<LightHouseData> lightHouseData;
    //���?�������� ���� ���ӿ�����Ʈ.

    public ServerLoaderTest serverloader;
    [SerializeField]
    private GameObject lhPrefab;

    [SerializeField]
    private Vector3[] lightHousePos;

    [SerializeField]
    private Quaternion[] lightHouseRot;
    // Start is called before the first frame update
    void Start()
    {
        //SetCountLightHouse();
    }

    public void SetCountLightHouse()
    {
        for (int i = 0; i < lightHouseData.Count; i++)
        {
            GameObject lh = SpawnLightHouse((LightHouseType)i);
            //lh.PrintLHData();
            lh.transform.position = lightHousePos[i];
            lh.transform.rotation = lightHouseRot[i];

        }
    }
   public GameObject SpawnLightHouse(LightHouseType type)
    {
        //GameObject newLH = Instantiate(lhPrefab);
       GameObject newLH = GameObject.FindGameObjectWithTag("LightHouse");
        LightHouse lh = newLH.GetComponent<LightHouse>();
       
        lh.lhData = lightHouseData[(int)type];
        lh.InitializePrefab();
        newLH.name = lh.lhData.LightHouseName;

        GameObject child = newLH.transform.GetChild(0).transform.GetChild(0).gameObject;
        var childMat = child.GetComponent<MeshRenderer>();
        if(childMat != null)
        {
            childMat.material = null; //?�째?�인지 모르지�??�번 null처리�??�줘??깔끔?�게 ?�어�?
            childMat.material = lh.lhData.Mat;
            Debug.Log("childMat material is now " + childMat.material);
            childMat.material.mainTexture = lh.lhData.Texture;
        }
        return newLH;

        


    }


  
}
