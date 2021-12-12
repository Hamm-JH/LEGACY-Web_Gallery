using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace EventDef
{
	public partial class UIEvents : MonoBehaviour, IPointerClickHandler
	{
		public enum EventCode
		{
			Not_Defined = -1,
			Scene01_SceneChange = 0,
			Scene02_SceneChange = 1,
			Scene03_SceneChange = 2,

			Scene03_LinkPage = 10,

			Scene03_AudioPlay = 20,
		}

		[Header("Essential part")]
		[SerializeField] EventCode eventCode;

		public void OnPointerClick(PointerEventData eventData)
		{
			switch (eventCode)
			{
				case EventCode.Scene01_SceneChange:
				case EventCode.Scene02_SceneChange:
				case EventCode.Scene03_SceneChange:
					OnRequest_SceneChange();
					break;

				case EventCode.Scene03_LinkPage:
					OnLinkPage();
					break;

				case EventCode.Scene03_AudioPlay:
					OnAudioPlay();
					break;
			}
		}
	}
}
