using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Management
{
	public abstract class Manager : MonoBehaviour
	{

		/// <summary>
		/// 관리자 인스턴스가 시작할때 실행되는 메서드
		/// </summary>
		public abstract void OnStart();

	}
}
