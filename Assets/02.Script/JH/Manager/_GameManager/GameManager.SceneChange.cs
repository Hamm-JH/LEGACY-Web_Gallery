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
			// TODO :: [�� ���� 1�ܰ�] 1205 �ӽ� �ڵ� ��ġ (Fade In)
			Color color = core.curtain.color;
			// Fade In �غ�
			core.curtain.color = new Color(color.r, color.g, color.b, 0);
			// Fade In Ÿ�ֿ̹� ��Ʈ ĵ���� On
			core.rootCanvas.enabled = true;
		}

		private void StartFadeIn()
		{
			Color color = core.curtain.color;

			// Scene ��û �߻� Ȯ�ν�, curtain Fade In :: ����� ���� �������� �����ص�
			core.curtain.color = new Color(color.r, color.g, color.b, 0);       // Fade In ��� �ӽ������� ���Ƶ�
		}

		private void EndFadeIn()
		{
			// ī�޶� ���󺹱�
			core.mainCamera.transform.SetParent(transform);
			core.mainCamera.transform.position = new Vector3();
			core.mainCamera.transform.rotation = Quaternion.identity;
		}
		#endregion

		private void OnFadeOut()
		{
			// TODO :: [�� ���� 3�ܰ�] 1205 �� �Ʒ��� �ڵ�� �� ������ �Ϸ�Ǿ��� �� ����
			Debug.Log($"Step 3 : Scene Change success");

			// TODO :: [�� ���� 4�ܰ�] 1205 �ӽ� �ڵ� ��ġ (Fade In)
			Color color = core.curtain.color;
			// Scene ���� �Ϸ��, curtain Fade Out :: ����� ���� �������� �����ص�
			core.curtain.color = new Color(color.r, color.g, color.b, 0);   // �տ��� a���� 1�� ���, Fade out�� ������ ��ó�� ����
																			// Scene ���� �Ϸ�� rootCanvas Off
			core.rootCanvas.enabled = false;
		}
	}
}
