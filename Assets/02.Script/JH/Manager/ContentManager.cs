using Management.Content;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Management
{
	public class ContentManager : Manager
	{
		[SerializeField] Content.Data contentData;

		public Data _Data { get => contentData; set => contentData=value; }

		#region System
		public override void OnStart()
		{
			OnCreate(this);
		}

		public override void OnCreate(ContentManager _this)
		{
			GameManager.Instance.OnCreate(_this);
		}

		public override void OnDispose(ContentManager _this)
		{
			GameManager.Instance.OnDispose(_this);
		}
		#endregion

		// Start is called before the first frame update
		void Start()
		{
			OnStart();
		}

		// Update is called once per frame
		void Update()
		{
			if(_Data.ID == "Scene 01")
			{
				if(Input.GetKeyDown(KeyCode.Space))
				{
					OnDispose(this);
					//Scene scene = UnityEngine.SceneManagement.SceneManager.GetSceneByName("Scene 01");
					UnityEngine.SceneManagement.SceneManager.LoadScene("Scene 02", UnityEngine.SceneManagement.LoadSceneMode.Single);
					//Destroy(scene);
					//Debug.Log(UnityEngine.SceneManagement.SceneManager..GetActiveScene().name);
				}
			}
		}

	}
}
