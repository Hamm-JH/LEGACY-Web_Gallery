using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Management
{
	using UnityEngine.SceneManagement;

	public partial class GameManager : Manager
	{
		/// <summary>
		/// curtain�� Fade in animation�� ����� ����, �� ���� �غ� ���� ���μ����� �����ϴ� �ڵ�
		/// </summary>
		private void OnSceneChangeProcess()
		{
			EndFadeIn();

			Def.SceneName _currentScene = core.currentScene;

			SceneManager.LoadScene(_currentScene.ToString(), LoadSceneMode.Single);

			switch (_currentScene)
			{
				case Def.SceneName.Scene01:
					{
						// ��01�� �ε��ϴ� ���μ��� ����
						//LoadScene01();

						// �� ���� �Ϸ�� �����ϴ� �޼���
						//LoadSceneComplete();
					}
					break;

				case Def.SceneName.Scene02:
					{ }
					break;

				case Def.SceneName.Scene03:
					{ }
					break;
			}

			LoadSceneComplete();
		}

		/// <summary>
		/// �� ���� �Ϸ�� ����
		/// </summary>
		private void LoadSceneComplete()
		{
			OnFadeOut();
		}

		#region ���� �� ���� �޼���

		/// <summary>
		/// ��01 ����
		/// </summary>
		private void LoadScene01()
		{

		}

		#endregion
	}
}
