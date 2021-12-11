using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Management
{
	public partial class GameManager : Manager
	{
		#region Ready Fade in
		private void OnFadeIn()
		{
			ReadyFadeIn();

			StartFadeIn();

			EndFadeIn();
		}

		private void ReadyFadeIn()
		{
			// TODO :: [씬 변경 1단계] 1205 임시 코드 배치 (Fade In)
			Color color = core.curtain.color;
			// Fade In 준비
			core.curtain.color = new Color(color.r, color.g, color.b, 0);
			// Fade In 타이밍에 루트 캔버스 On
			core.rootCanvas.enabled = true;
		}

		private void StartFadeIn()
		{
			Color color = core.curtain.color;

			// Scene 요청 발생 확인시, curtain Fade In :: 현재는 색상 변경으로 지정해둠
			core.curtain.color = new Color(color.r, color.g, color.b, 0);       // Fade In 기능 임시적으로 막아둠
		}

		private void EndFadeIn()
		{
			// 카메라 원상복귀
			core.mainCamera.transform.SetParent(transform);
			core.mainCamera.transform.position = new Vector3();
			core.mainCamera.transform.rotation = Quaternion.identity;
		}
		#endregion

		private void OnFadeOut()
		{
			// TODO :: [씬 변경 3단계] 1205 이 아래의 코드는 씬 변경이 완료되었을 때 시행
			Debug.Log($"Step 3 : Scene Change success");

			// TODO :: [씬 변경 4단계] 1205 임시 코드 배치 (Fade In)
			Color color = core.curtain.color;
			// Scene 변경 완료시, curtain Fade Out :: 현재는 색상 변경으로 지정해둠
			core.curtain.color = new Color(color.r, color.g, color.b, 0);   // 앞에서 a값이 1인 경우, Fade out이 나오는 것처럼 보임
																			// Scene 변경 완료시 rootCanvas Off
			core.rootCanvas.enabled = false;
		}
	}
}
