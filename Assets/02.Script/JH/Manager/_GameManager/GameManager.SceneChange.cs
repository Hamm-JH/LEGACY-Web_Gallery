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
			// ���̵��� ����� �ִϸ����Ϳ��� IsFadeOut = false�� ����
			core.animator.SetBool("IsFadeOut", false);
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
			// ���̵� �ƿ� ����� �ִϸ����Ϳ��� IsFadeOut = true�� ����
			core.animator.SetBool("IsFadeOut", true);
		}
	}
}
