using Management.Scene;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Management
{
	public partial class ContentManager : Manager
	{
		// �ý��� ��� �޼��� ��������

		#region System
		public override void OnStart()
		{
			OnCreate(this);
		}

		public override void OnCreate(ContentManager _this)
		{
			GameManager.Instance.OnCreate(_this);
		}

		public override void OnSceneChange(Request request)
		{
			GameManager.Instance.OnSceneChange(request);
		}
		#endregion
	}
}
