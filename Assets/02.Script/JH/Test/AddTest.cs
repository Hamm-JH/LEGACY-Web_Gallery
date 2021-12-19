using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

namespace Test
{
	public class AddTest : MonoBehaviour
	{
		public AssetReference baseCube;
		public AssetReferenceAtlasedSprite addSprite;


		public Image img;

		// Start is called before the first frame update
		void Start()
		{
			//baseCube.InstantiateAsync().Completed += OnCompleted;
			Addressables.InstantiateAsync("Cube", new Vector3(0, 0, 0), Quaternion.identity);
			//Addressables.LoadAssetAsync<Sprite>("Assets/Resources_moved/texture/001").Completed += OnCompleted;
			//Addressables.LoadAssetAsync<Texture2D>("Assets/Resources_moved/texture/002.jpg").Completed += OnCompleted;
		}

		void OnCompleted(AsyncOperationHandle<Texture2D> _inst)
		{

		}

		void OnCompleted(AsyncOperationHandle<Sprite> _inst)
		{
			//Debug.Log(_inst.)
			//img.sprite = _inst.GetDownloadStatus.;
			Texture2D tex = _inst.Result.texture;
			Rect _rect = _inst.Result.rect;
			Vector2 _pivot = _inst.Result.pivot;

			img.sprite = Sprite.Create(tex, _rect, _pivot);
		}

		void OnCompleted<T>(AsyncOperationHandle<T> _inst)
		{
			//Debug.Log(_inst.)
		}
	}
}
