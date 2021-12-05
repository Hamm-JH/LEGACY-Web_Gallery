using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Management.Core
{
	/// <summary>
	/// �ý��� ������ ������ ���� ����
	/// </summary>
	[System.Serializable]
	public class CoreResource
	{
		/// <summary>
		/// �ַ� ����ϴ� ī�޶� ����
		/// </summary>
		public Camera mainCamera;

		/// <summary>
		/// ����� ȭ�� ������ Ȯ���ϱ� ���� �������� ��� ĵ����
		/// </summary>
		public Canvas rootCanvas;

		/// <summary>
		/// ��������� ��밡���� �����
		/// </summary>
		public AudioSource mainAudio;

		/// <summary>
		/// Fade In, Fade Out�� ������ Ÿ��Ʋ �̹��� �г�
		/// </summary>
		public Image curtain;
	}
}
