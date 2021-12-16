using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LightHouseType { BlackLH, RedLH, WhiteLH}
public class LightHouseSpawner : MonoBehaviour
{
    //ï¿½ï¿½ï¿?ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½Æ®ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½.
    [SerializeField]
    private List<LightHouseData> lightHouseData;
    //ï¿½ï¿½ï¿?ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½Ó¿ï¿½ï¿½ï¿½ï¿½ï¿½Æ®.

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
            childMat.material = null; //?´ì§¸?œì¸ì§€ ëª¨ë¥´ì§€ë§??œë²ˆ nullì²˜ë¦¬ë¥??´ì¤˜??ê¹”ë”?˜ê²Œ ?¤ì–´ê°?
            childMat.material = lh.lhData.Mat;
            Debug.Log("childMat material is now " + childMat.material);
            childMat.material.mainTexture = lh.lhData.Texture;
        }
        return newLH;

        


    }


  
}
