using Management.Content;
using Management.Scene;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Management
{
	/// <summary>
	/// �� Scene�� �Ҵ�� ������ ������ �ν��Ͻ�
	/// </summary>
	public partial class ContentManager : Manager
	{
		#region Instance

		private static ContentManager instance;

		public static ContentManager Instance
		{
			get
			{
				if (instance == null)
				{
					instance = FindObjectOfType<ContentManager>() as ContentManager;
				}
				return instance;
			}
		}

		#endregion

		#region Values
		/// <summary>
		/// �� ������ ������ ������ ����ִ� ����
		/// </summary>
		[SerializeField] Content.Data contentData;

		public Data _Data { get => contentData; set => contentData=value; }
		#endregion

		private void Awake()
		{
			if(instance != null)
			{
				Destroy(this);
			}
		}

		// Start is called before the first frame update
		void Start()
		{
			OnStart();
		}

		// Update is called once per frame
		void Update()
		{
			RaycastHit hit;
			Ray ray = GameManager.Instance.core.mainCamera.ScreenPointToRay(new Vector2(960, 540));
			if (Physics.Raycast(ray, out hit, 100)) { }

			Rect rect = GameManager.Instance.core.rootCanvas.GetComponent<RectTransform>().rect;
			Vector2 center = new Vector2(rect.width / 2, rect.height / 2);

			Vector2 mp = GameManager.Instance.core.mainCamera.ScreenToWorldPoint(
				center);
			Ray2D ray2 = new Ray2D(mp, Vector2.zero);
			RaycastHit2D _hit = Physics2D.Raycast(ray2.origin, ray2.direction);

			{
				// (�ӽ�) :: �� �̵� ����
				//if (Input.GetKeyDown(KeyCode.Space))
				//{
				//	if (_Data.ID == Def.SceneName.Scene01)
				//	{
				//		OnSceneChange(new Scene.Request
				//		{
				//			sceneName = Def.SceneName.Scene02,
				//			optionIndex = 1
				//		});
				//	}
				//	else if (_Data.ID == Def.SceneName.Scene02)
				//	{
				//		OnSceneChange(new Scene.Request
				//		{
				//			sceneName = Def.SceneName.Scene01,
				//			optionIndex = 0
				//		});
				//	}
				//}

				// Ŀ�� ���� ����
				//if (Input.GetMouseButtonDown(0))
				//{
				//	Cursor.lockState = CursorLockMode.Locked;
				//	Cursor.lockState = CursorLockMode.Confined;
				//	Cursor.visible = true;
				//}
				//else if(Input.GetMouseButton(0))
				//{
				//	Cursor.lockState = CursorLockMode.Locked;
				//	Cursor.lockState = CursorLockMode.None;
				//	Cursor.visible = true;
				//}
				//else
				//{
				//	Cursor.lockState = CursorLockMode.Locked;
				//	//Cursor.lockState = CursorLockMode.Confined;
				//	Cursor.visible = true;
				//}
			}
		}

		//----- event

		public void MoveScene(Def.SceneName sceneName)
		{
			OnSceneChange(new Scene.Request
			{
				sceneName = sceneName,
				optionIndex = 0
			});
		}
	}
}
