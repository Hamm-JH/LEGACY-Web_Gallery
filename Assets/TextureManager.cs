using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureManager : MonoBehaviour
{
    public Material worldMat;
    public GameObject world;
    public List<GameObject> worldArray;
    public Texture2D t;
    public List<Texture2D> worldTextures;

    [SerializeField]
    List<string> texturePath = new List<string>();
    // Start is called before the first frame update
    void Start()
    {
       
        WorldChild();
        GetModeling();
        SetMaterial();
        SetTexture();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


   
    int WorldChild()
    {
        int worldChildCount = world.transform.childCount;
        Debug.Log("count is now" + worldChildCount);
        return worldChildCount;

    }
    void GetModeling()
    {
        for (int i = 0; i <WorldChild(); i++)
        {
            worldArray.Add(world.transform.GetChild(i).gameObject);
            Debug.Log("childName is now" + worldArray[i].name);
        }
       
    }

    void SetMaterial()
    {
        for (int i = 0; i < WorldChild(); i++)
        {
            worldArray[i].GetComponent<MeshRenderer>().material = worldMat;
            Debug.Log("worldArray mat is now" + worldArray[i].GetComponent<MeshRenderer>().material);
        }
    }

    
    void SetTexture()
    {
        
        for (int i = 0; i < WorldChild(); i++)
        {
            int num = i + 481;
            texturePath.Add("texture/" + num + ".jpg");
            Debug.Log("pass");
            // worldTextures.Add(Resources.Load(texturePath[i], typeof(Texture)) as Texture);
            Texture2D texture = new Texture2D(0, 0);
           texture = Resources.Load<Texture2D>(texturePath[i]);
           
          //  Debug.Log("texture is now" + texture);
            worldTextures.Add(t);
            worldArray[i].GetComponent<MeshRenderer>().material.mainTexture = worldTextures[i];
          //  Debug.Log("pass");
        }
    }
}
