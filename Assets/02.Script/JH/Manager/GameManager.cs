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

			UnityEngine.SceneManagement.SceneManager.LoadScene("Scene 01", LoadSceneMode.Additive);
		}

		// Fade in, Fade out 구현

		// Start is called before the first frame update
		void Start()
		{
			OnStart();
		}
	}
}
