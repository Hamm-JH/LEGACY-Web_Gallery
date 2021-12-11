using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventDef
{
	public partial class UIEvents : MonoBehaviour
	{
		public enum EventCode
		{
			Not_Defined = -1,
			Scene01_SceneChange = 0,
			Scene02_SceneChange = 1,
		}

		[Header("Essential part")]
		[SerializeField] EventCode eventCode;
	}
}
