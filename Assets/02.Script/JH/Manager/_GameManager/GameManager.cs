using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Management
{
	using Core;
	using Management.Scene;

	/// <summary>
	/// ������ Ŭ������ �θ� Ŭ����
	/// </summary>
	public partial class GameManager : Manager
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
		[Header("���� ��뺯��")]
		public CoreResource core;

		[Header("ȯ�溯��")]
		public EnvSetting envSetting;

		[SerializeField] EnvDictionary envs;

		#region Content Refresh
		/// <summary>
		/// ������ ������ Ŭ���� :: ������ �� ���� ������ ����Ǵ� �ڵ�
		/// </summary>
		[Header("������ ���� �ν��Ͻ�")]
		public ContentManager content;

		/// <summary>
		/// ������ Scene �̵����� ��û���� ����
		/// </summary>
		public Request prevRequest;
		#endregion

		/// <summary>
		/// �ý��� ������ �ڵ� OnStart
		/// :: ������ �ʱ�ȭ�� �� ���� �����Ѵ�.
		/// </summary>
		public override void OnStart()
		{
			Debug.Log("Hello new project");

			UnityEngine.SceneManagement.SceneManager.LoadScene(
				Def.SceneName.Scene01.ToString(), 
				LoadSceneMode.Single);
		}

		/// <summary>
		/// �ý��� ������ �ڵ� OnCreate
		/// :: ������ �����ڿ��� �ڱ� �ڽ��� �� �޼��带 ���� �ý��� �����ڿ��� �����Ѵ�.
		/// </summary>
		/// <param name="_this"></param>
		public override void OnCreate(ContentManager _this)
		{
			// ������ ������ �ڵ� ���� �Ҵ�
			content = _this;

			// ������ �ʱ�ȭ
			ContentInit(core, content, envSetting);
			
			// fade out
			OnFadeOut();

#if UNITY_EDITOR
			Debug.Log($"Debug : new content scene loaded :: Scene ID : {content._Data.ID}");
#endif
		}

		/// <summary>
		/// �ý��� ������ �ڵ� OnSceheChange
		/// :: ������ �����ڿ��� Scene �̵� �߻���, �� �̵��� ���� ��û ������ �޴´�.
		/// </summary>
		/// <param name="request"> Scene �̵� �ɼ� �ν��Ͻ� </param>
		public override void OnSceneChange(Request request)
		{
			// ������ ���� ����
			content = null;

			// �ӽ� ��û���� ����
			Request currRequest = request;

			// ���� ��û���� prevRequest�� ���� ó���� �ʿ��� ���, �� ���� �ȿ��� prevRequest���� ���ϱ� ���� ����
			{
				// �� �̸� Ȯ��
				Def.SceneName sName = request.sceneName;

				Debug.Log($"Step 1 : Scene Change {sName.ToString()} stanby");

				OnFadeIn();

				// TODO :: [�� ���� 2�ܰ�] 1205 �� �Ʒ��� �ڵ�� �� ���� �غ� �Ϸ�Ǿ��� �� ����
				Debug.Log($"Step 2 : Scene Change {sName.ToString()} ready");

				// ��û���� ����
				prevRequest = currRequest;
				SceneManager.LoadScene(sName.ToString(), LoadSceneMode.Single);
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
