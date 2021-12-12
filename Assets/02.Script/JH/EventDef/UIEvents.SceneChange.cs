using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace EventDef
{
	public partial class UIEvents : MonoBehaviour
	{
		[Header("Scene ����� �ʿ� ����")]
		public Def.SceneName targetScene;

		public void OnRequest_SceneChange()
		{
			Management.ContentManager.Instance.MoveScene(targetScene);
		}
	}
}
