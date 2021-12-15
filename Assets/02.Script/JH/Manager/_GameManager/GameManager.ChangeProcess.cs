using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Management
{
	using UnityEngine.SceneManagement;

	public partial class GameManager : Manager
	{
		/// <summary>
		/// curtain의 Fade in animation이 진행된 직후, 씬 변경 준비를 위한 프로세스를 진행하는 코드
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
						// 씬01을 로딩하는 프로세스 진행
						//LoadScene01();

						// 씬 생성 완료시 실행하는 메서드
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
		/// 씬 생성 완료시 실행
		/// </summary>
		private void LoadSceneComplete()
		{
			OnFadeOut();
		}

		#region 개별 씬 생성 메서드

		/// <summary>
		/// 씬01 생성
		/// </summary>
		private void LoadScene01()
		{

		}

		#endregion
	}
}
