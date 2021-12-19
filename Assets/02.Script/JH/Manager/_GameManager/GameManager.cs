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

		[Header("Animator Controllable Value")]
		public float audioVolume;
		private bool volumeUpdate;

		/// <summary>
		/// ���� ���ҽ� ����
		/// </summary>
		[Header("���� ��뺯��")]
		public CoreResource core;

		[Header("���� ȯ�溯�� ����Ʈ")]
		public List<EnvSetting> envSettings;

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

			core.currentScene = Def.SceneName.Scene01;

			// �� 01�� �ҷ��´�.
			OnSceneChange(new Request
			{
				sceneName = Def.SceneName.Scene01,
				optionIndex = 99	// �ʱ� ������ ��쿣, fade in �ܰ踦 �ǳʶٰ� ChangeProcess �ܰ迡 �����ؾ� �Ѵ�.
			});
		}

		/// <summary>
		/// [�ű� ������ �� �Ű�] 
		/// �ý��� ������ �ڵ� OnCreate
		/// :: ������ �����ڿ��� �ڱ� �ڽ��� �� �޼��带 ���� �ý��� �����ڿ��� �����Ѵ�.
		/// </summary>
		/// <param name="_this"></param>
		public override void OnCreate(ContentManager _this)
		{
			// ������ ������ �ڵ� ���� �Ҵ�
			content = _this;

			
			// ������ �ʱ�ȭ
			ContentInit(core, content, envSettings[(int)core.currentScene]);
			
			// fade out
			// TODO 1215 :: ��巹���� ����� �� �������� ����
			//OnFadeOut();

#if UNITY_EDITOR
			Debug.Log($"Debug : new content scene loaded :: Scene ID : {content._Data.ID}");
#endif
		}

		/// <summary>
		/// [�� ���� ��û] 
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
				prevRequest = currRequest;
				core.currentScene = prevRequest.sceneName;  // ������Ʈ�� �� ���¸� �����Ѵ�.

				ReadyToFadeIn();

				// �Ϲ� :: �� ������ �� ����� Fade in ����. �� ChangeProcess�� ����
				if (request.optionIndex != 99)
				{
					OnFadeIn(sName);
				}
				// 99 option :: �� �ʱ� �����, Fade in�� ��ġ�� �ʰ� �ٷ� ChangeProcess�� �����Ѵ�. (������ ����)
				else
				{
					Debug.Log($"index 99");
					OnSceneChangeProcess();
				}

				// TODO :: [�� ���� 2�ܰ�] 1205 �� �Ʒ��� �ڵ�� �� ���� �غ� �Ϸ�Ǿ��� �� ����
				Debug.Log($"Step 2 : Scene Change {sName.ToString()} ready");

				// ��û���� ����
				//SceneManager.LoadScene(sName.ToString(), LoadSceneMode.Single);
			}
		}

		/// <summary>
		/// DontDestroy
		/// </summary>
		private void Awake()
		{
			DontDestroyOnLoad(this);
		}

		/// <summary>
		/// animator IsStart ����
		/// </summary>
		void Start()
		{
			// 1�ʵ�, Start Anim clip ����
			// -> OnStart(); ����
			core.animator.SetBool("IsStart", true);
		}

		private void Update()
		{
			if(volumeUpdate)
			{
				//core.mainAudio.volume =
			}
		}
	}
}
