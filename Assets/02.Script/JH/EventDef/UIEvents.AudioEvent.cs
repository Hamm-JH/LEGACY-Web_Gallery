using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventDef
{
	public partial class UIEvents : MonoBehaviour
	{
		[Header("Audio 이벤트시 필요변수")]
		[SerializeField] LightHouse lightHouse;

		private void OnAudioPlay()
		{
			lightHouse.OnAudioPlay();
		}
	}
}
