using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventDef
{
	public partial class UIEvents : MonoBehaviour
	{
		[Header("URL 링크시 필요변수")]
		[SerializeField] string linkURL;

		private void OnLinkPage()
		{
			Application.OpenURL(linkURL);
		}
	}
}
