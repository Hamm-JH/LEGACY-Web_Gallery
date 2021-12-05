using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Management
{
	using Core;

	/// <summary>
	/// 관리자 클래스의 부모 클래스
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
		/// 범용 리소스 모음
		/// </summary>
		public CoreResource core;

		/// <summary>
		/// 컨텐츠 관리자 클래스 :: 컨텐츠 씬 레벨 생성시 실행되는 코드
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
			// 컨텐츠과 같은 인스턴스일 경우에만 실행한다.
			if(content == _this)
			{
				content = null;
			}
		}

		// Fade in, Fade out 구현

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
