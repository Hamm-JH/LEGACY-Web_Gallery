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
		public Person.Character character;

		/// <summary>
		/// ������ Fade ��Ʈ�� animator
		/// </summary>
		public Animator animator;

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

		/// <summary>
		/// ���� ���� ��Ÿ���� ���ź���
		/// </summary>
		public Def.SceneName currentScene;

		/// <summary>
		/// ���α׷�����
		/// </summary>
		public Michsky.UI.ModernUIPack.ProgressBar progressbar;
	}
}
