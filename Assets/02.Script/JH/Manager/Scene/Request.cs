using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Management.Scene
{
	/// <summary>
	/// 씬 변경에 대한 요청 인스턴스
	/// </summary>
	public class Request
	{
		/// <summary>
		/// 변경하고자 하는 씬 이름
		/// </summary>
		public Def.SceneName sceneName;

		/// <summary>
		/// 변경시 옵션 인덱스
		/// </summary>
		public int optionIndex;
	}
}
