using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Management
{
	public abstract class Manager : MonoBehaviour
	{

		/// <summary>
		/// ������ �ν��Ͻ��� �����Ҷ� ����Ǵ� �޼���
		/// </summary>
		public abstract void OnStart();

		//----

		/// <summary>
		/// ������ ������ ������ �ý��� �����ڿ� �Ű�
		/// </summary>
		/// <param name="_this"> ������ ������ �ν��Ͻ� </param>
		public abstract void OnCreate(ContentManager _this);

		/// <summary>
		/// �� ���� :: ������ ������ �Ҹ�� �ý��� �����ڿ� �Ű�
		/// </summary>
		/// <param name="request"> ���� ��û �ν��Ͻ� </param>
		public abstract void OnSceneChange(Scene.Request request);

	}
}
