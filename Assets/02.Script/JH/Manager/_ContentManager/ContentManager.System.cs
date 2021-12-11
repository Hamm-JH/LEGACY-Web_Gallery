using Management.Scene;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Management
{
	public partial class ContentManager : Manager
	{
		// 시스템 등록 메서드 설정구간

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
