using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Management
{
	using Core;

	/// <summary>
	/// ������ Ŭ������ �θ� Ŭ����
	/// </summary>
	public class GameManager : Manager
	{
		#region Instance

		private static GameManager instance;

		public static GameManager Instance
		{
			get
			{
				if(instance == null)
				{
					instance = FindObjectOfType<GameManager>() as GameManager;
				}
				return instance;
			}
		}

		#endregion

		/// <summary>
		/// ���� ���ҽ� ����
		/// </summary>
		public CoreResource core;

		/// <summary>
		/// ������ ������ Ŭ���� :: ������ �� ���� ������ ����Ǵ� �ڵ�
		/// </summary>
		public ContentManager content;

		public override void OnStart()
		{
			Debug.Log("Hello new project");

			UnityEngine.SceneManagement.SceneManager.LoadScene("Scene 01", LoadSceneMode.Single);
		}

		public override void OnCreate(ContentManager _this)
		{
			content = _this;

			Debug.Log($"new content scene loaded :: Scene ID : {content._Data.ID}");
		}

		public override void OnDispose(ContentManager _this)
		{
			// �������� ���� �ν��Ͻ��� ��쿡�� �����Ѵ�.
			if(content == _this)
			{
				content = null;
			}
		}

		// Fade in, Fade out ����

		private void Awake()
		{
			DontDestroyOnLoad(this);
		}

		// Start is called before the first frame update
		void Start()
		{
			OnStart();
		}
	}
}
