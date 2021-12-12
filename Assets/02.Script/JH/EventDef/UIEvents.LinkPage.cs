using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventDef
{
	public partial class UIEvents : MonoBehaviour
	{
		[Header("URL ��ũ�� �ʿ亯��")]
		[SerializeField] string linkURL;

		private void OnLinkPage()
		{
			Application.OpenURL(linkURL);
		}
	}
}
