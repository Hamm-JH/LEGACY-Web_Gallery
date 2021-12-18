using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Textures
{
	public class TextureManager : MonoBehaviour
	{
		#region Instance

		private static TextureManager instance;

		public static TextureManager Instance
		{
			get
			{
				if(instance == null)
				{
					instance = FindObjectOfType<TextureManager>() as TextureManager;
				}
				return instance;
			}
		}

		#endregion

		public Material worldMat;
		public GameObject world;
		public List<GameObject> worldArray;
		public Texture2D t;
		public List<Texture2D> worldTextures;

		public int worldChildIndex;

		[SerializeField]
		List<string> texturePath = new List<string>();
		// Start is called before the first frame update
		void Start()
		{
			worldChildIndex = WorldChild();
			GetModeling();
			SetMaterial();
			SetTexture();
		}

		/// <summary>
		/// 1번 
		/// </summary>
		/// <returns></returns>
		int WorldChild()
		{
			int worldChildCount = world.transform.childCount;
			return worldChildCount;
		}

		/// <summary>
		/// 2번
		/// </summary>
		void GetModeling()
		{
			for (int i = 0; i < worldChildIndex; i++)
			{
				worldArray.Add(world.transform.GetChild(i).gameObject);
			}
		}

		/// <summary>
		/// 3번
		/// </summary>
		void SetMaterial()
		{
			for (int i = 0; i < worldChildIndex; i++)
			{
				worldArray[i].GetComponent<MeshRenderer>().material = worldMat;
			}
		}

		/// <summary>
		/// 4번
		/// </summary>
		void SetTexture()
		{

			for (int i = 0; i < worldChildIndex; i++)
			{
				{
					//int num = i+1;
					//Debug.Log("num now :"+num);
					//if (i<9)
					//{
					//	texturePath.Add("texture/00" + num);
					//}
					//if (9<=i && i<99)
					//{
					//	texturePath.Add("texture/0" + num);
					//}
					//if (99<=i)
					//{
					//	texturePath.Add("texture/" + num);
					//}

					//Debug.Log("pass");
					//// worldTextures.Add(Resources.Load(texturePath[i], typeof(Texture)) as Texture);

					////  texture = Resources.Load<Texture2D>(texturePath[i]);
					//var texture = Resources.Load(texturePath[i]) as Texture2D;


					//Debug.Log(texture.GetType());
					//worldTextures.Add(texture);
				}
				worldArray[i].GetComponent<MeshRenderer>().material.mainTexture = worldTextures[i];
			}
		}

		public void SetTexture(AsyncOperationHandle importedTexture)
		{
			string textureName = importedTexture.DebugName;

			GameObject obj = worldArray.Find(x => x.name.Substring(0, 3) == textureName);

			//obj.GetComponent<MeshRenderer>().material.mainTexture = importedTexture.Result;
		}

		public void SetTextureTest()
		{

			for (int i = 0; i < worldChildIndex; i++)
			{
				if (i == 0)
				{
					worldArray[i].GetComponent<MeshRenderer>().material.mainTexture = worldTextures[i];
				}
				else
				{
					worldArray[i].GetComponent<MeshRenderer>().material.mainTexture = worldTextures[i];
				}

			}
		}
		private void OnDestroy()
		{
			Destroy(instance);
			instance = null;
		}
	}
}
