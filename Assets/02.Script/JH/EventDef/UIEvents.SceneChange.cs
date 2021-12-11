using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace EventDef
{
	public partial class UIEvents : MonoBehaviour, IPointerClickHandler
	{
		public Def.SceneName targetScene;

		public void OnPointerClick(PointerEventData eventData)
		{
			switch(eventCode)
			{
				case EventCode.Scene01_SceneChange:
				case EventCode.Scene02_SceneChange:
					OnRequest_SceneChange();
					break;
			}
		}

		public void OnRequest_SceneChange()
		{
			Management.ContentManager.Instance.MoveScene(targetScene);
		}
	}
}
