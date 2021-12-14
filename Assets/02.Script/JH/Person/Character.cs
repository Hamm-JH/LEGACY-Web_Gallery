using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Person
{
	public class Character : MonoBehaviour
	{
		[SerializeField] pInput.InputSetting setting;

		[System.Serializable]
		public struct InputParameter
		{
			public bool isClicked;
			public float movementSpeed;
		}

		public InputParameter inputs;

		/// <summary>
		/// ĳ���� �ʱ�ȭ
		/// </summary>
		/// <param name="cam"> ����ī�޶� </param>
		/// <param name="InitPosition"> ��ü ������ġ </param>
		public void OnInit(Camera cam, Transform InitTransform, float moveSpeed)
		{
			// ĳ���� �̵��ӵ� ������Ʈ
			inputs.movementSpeed = moveSpeed;

			setting.MainCamera = cam;
			setting.MainCamera.transform.SetParent(setting.CamPosition);

			setting.MainCamera.transform.localPosition = new Vector3();
			setting.MainCamera.transform.rotation = Quaternion.identity;

			setting.CharacterPosition.position = InitTransform.position;
			setting.CharacterPosition.rotation = InitTransform.rotation;

		}

		// Update is called once per frame
		void Update()
		{
			float moveH = Time.deltaTime * Input.GetAxis("Horizontal") * inputs.movementSpeed;
			float moveV = Time.deltaTime * Input.GetAxis("Vertical") * inputs.movementSpeed;

			setting.CharacterPosition.Translate(moveH, 0, moveV);


			if(Input.GetMouseButtonDown(0))
			{
				inputs.isClicked = true;
			}
			else if(Input.GetMouseButton(0))
			{
				if(inputs.isClicked)
				{
					if(setting.MainCamera != null)
					{
						float h = setting.HorizontalSpeed * Input.GetAxis("Mouse X");
						float v = setting.VerticalSpeed * Input.GetAxis("Mouse Y");

						setting.CharacterPosition.Rotate(0, h, 0);
						setting.MainCamera.transform.Rotate(-v, 0, 0);

					}
				}
			}
			else if(Input.GetMouseButtonUp(0))
			{
				inputs.isClicked = false;
			}

		}
	}
}
