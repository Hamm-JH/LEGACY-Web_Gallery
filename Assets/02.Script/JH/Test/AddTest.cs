using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Test
{
	public class AddTest : MonoBehaviour
	{
		public AssetReference baseCube;
		public AssetReferenceAtlasedSprite addSprite;


		// Start is called before the first frame update
		void Start()
		{
			//baseCube.InstantiateAsync().Completed += OnCompleted;
			Addressables.InstantiateAsync("Cube", new Vector3(0, 0, 0), Quaternion.identity);

		}

		void OnCompleted<T>(AsyncOperationHandle<T> _inst)
		{
			//Debug.Log(_inst.)
		}
	}
}
