using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventDef
{
	public partial class UIEvents : MonoBehaviour
	{
		[Header("Audio �̺�Ʈ�� �ʿ亯��")]
		[SerializeField] LightHouse lightHouse;

		private void OnAudioPlay()
		{
			lightHouse.OnAudioPlay();
		}
	}
}
