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

			UnityEngine.SceneManagement.SceneManager.LoadScene("Scene 01", LoadSceneMode.Additive);
		}

		// Fade in, Fade out ����

		// Start is called before the first frame update
		void Start()
		{
			OnStart();
		}
	}
}
