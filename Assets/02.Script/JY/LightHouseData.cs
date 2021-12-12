using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="LightHouseData", menuName = "Scriptable Object/Lighthouse", order = int.MaxValue)]
public class LightHouseData : ScriptableObject
{
    [SerializeField]
    private string lightHouseName;

    public string LightHouseName { get { return lightHouseName; } }

    [SerializeField]
    private Vector3 pos;

    public Vector3 Pos { get { return pos; } }
    
    [SerializeField]
    private Material mat;

    public Material Mat { get { return mat; } }

    [SerializeField]
    private Texture texture;

    public Texture Texture { get { return texture; } }

    [SerializeField]
    private AudioClip audioClip;
	public AudioClip AudioClip { get => audioClip; set => audioClip=value; }
}
