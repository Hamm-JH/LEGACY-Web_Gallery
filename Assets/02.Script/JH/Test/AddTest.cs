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

		// Start is called before the first frame update
		void Start()
		{
			baseCube.InstantiateAsync().Completed += OnCompleted;
		}

		// Update is called once per frame
		void Update()
		{
			
		}

		void OnCompleted<T>(AsyncOperationHandle<T> _inst)
		{
			//Debug.Log(_inst.)
		}
	}
}
