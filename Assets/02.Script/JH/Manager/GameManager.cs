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

		/// <summary>
		/// ������ Scene �̵����� ��û���� ����
		/// </summary>
		public Request prevRequest;

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

			//||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||

			// TODO :: [�� ���� 3�ܰ�] 1205 �� �Ʒ��� �ڵ�� �� ������ �Ϸ�Ǿ��� �� ����
			Debug.Log($"Step 3 : Scene Change success");

			content.Init();

			//||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||

			// TODO :: [�� ���� 4�ܰ�] 1205 �ӽ� �ڵ� ��ġ (Fade In)
			Color color = core.curtain.color;
			// Scene ���� �Ϸ��, curtain Fade Out :: ����� ���� �������� �����ص�
			core.curtain.color = new Color(color.r, color.g, color.b, 0);
			// Scene ���� �Ϸ�� rootCanvas Off
			core.rootCanvas.enabled = false;

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

				//||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||

				Debug.Log($"Step 1 : Scene Change {sName.ToString()} stanby");

				// TODO :: [�� ���� 1�ܰ�] 1205 �ӽ� �ڵ� ��ġ (Fade In)
				Color color = core.curtain.color;
				// Fade In �غ�
				core.curtain.color = new Color(color.r, color.g, color.b, 0);
				// Fade In Ÿ�ֿ̹� ��Ʈ ĵ���� On
				core.rootCanvas.enabled = true;

				// Scene ��û �߻� Ȯ�ν�, curtain Fade In :: ����� ���� �������� �����ص�
				core.curtain.color = new Color(color.r, color.g, color.b, 1);

				// ī�޶� ���󺹱�
				core.mainCamera.transform.SetParent(transform);
				core.mainCamera.transform.position = new Vector3();
				core.mainCamera.transform.rotation = Quaternion.identity;

				//||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||

				// TODO :: [�� ���� 2�ܰ�] 1205 �� �Ʒ��� �ڵ�� �� ���� �غ� �Ϸ�Ǿ��� �� ����
				Debug.Log($"Step 2 : Scene Change {sName.ToString()} ready");

				// ��û���� ����
				prevRequest = currRequest;
				SceneManager.LoadSceneAsync(sName.ToString(), LoadSceneMode.Single);
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
