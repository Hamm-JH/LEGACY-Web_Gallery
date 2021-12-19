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
			// ���� ������Ʈ ����
			volumeUpdate = true;
			// ���̵��� ����� �ִϸ����Ϳ��� IsFadeOut = false�� ����
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
			// ī�޶� ���󺹱�
			core.mainCamera.transform.SetParent(transform);
			core.mainCamera.transform.position = new Vector3();
			core.mainCamera.transform.rotation = Quaternion.identity;
		}
		#endregion

		/// <summary>
		/// �� ���� �۾��� �Ϸ�Ǿ����� �����ϴ� Fade out �޼���
		/// </summary>
		private void OnFadeOut()
		{
			// ���� ������Ʈ ��
			volumeUpdate = false;

			// ���̵� �ƿ� ����� �ִϸ����Ϳ��� IsFadeOut = true�� ����
			core.progressbar.isOn = false;
			core.animator.SetBool("IsFadeOut", true);
			
		}

		private void EndFadeOut()
		{
			// Scene03 ������Ʈ
			content.OnLoadComplete();
		}

		public void TurnOffProgressBar()
        {
			
        }
	}
}
