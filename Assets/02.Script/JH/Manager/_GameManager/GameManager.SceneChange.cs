using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Management
{
	public partial class GameManager : Manager
	{
		#region Ready Fade in
		private void OnFadeIn(Def.SceneName _sceneName)
		{
			// 볼륨 업데이트 시작
			volumeUpdate = true;
			// 페이드인 진행시 애니메이터에서 IsFadeOut = false로 변경
			core.animator.SetBool("IsFadeOut", false);

			if(_sceneName == Def.SceneName.Scene03)
			{
				core.animator.SetBool("IsThirdScene", true);
			}
			else
			{
				core.animator.SetBool("IsThirdScene", false);
			}
		}

		private void ReadyToFadeIn()
		{
			//if (isFirst) core.progressbar.isOn = isFirst;
			//else core.progressbar.isOn = true;

			core.progressbar.isOn = true;
			core.progressbar.isCompleted = false;
			core.progressbar.currentPercent = 0;
		}

		private void EndFadeIn()
		{
			// 카메라 원상복귀
			core.mainCamera.transform.SetParent(transform);
			core.mainCamera.transform.position = new Vector3();
			core.mainCamera.transform.rotation = Quaternion.identity;
		}
		#endregion

		/// <summary>
		/// 씬 생성 작업이 완료되었을때 실행하는 Fade out 메서드
		/// </summary>
		private void OnFadeOut()
		{
			// 볼륨 업데이트 끝
			volumeUpdate = false;

			// 페이드 아웃 진행시 애니메이터에서 IsFadeOut = true로 변경
			core.progressbar.isOn = false;
			core.animator.SetBool("IsFadeOut", true);
			
		}

		private void EndFadeOut()
		{
			// Scene03 업데이트
			content.OnLoadComplete();
		}

		public void TurnOffProgressBar()
        {
			
        }
	}
}
