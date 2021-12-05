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

		//----

		/// <summary>
		/// 컨텐츠 관리자 생성시 시스템 관리자에 신고
		/// </summary>
		/// <param name="_this"> 컨텐츠 관리자 인스턴스 </param>
		public abstract void OnCreate(ContentManager _this);

		/// <summary>
		/// 씬 변경 :: 컨텐츠 관리자 소멸시 시스템 관리자에 신고
		/// </summary>
		/// <param name="request"> 변경 요청 인스턴스 </param>
		public abstract void OnSceneChange(Scene.Request request);

	}
}
