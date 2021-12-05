using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Person
{
	public class Character : MonoBehaviour
	{
		[SerializeField] pInput.InputSetting setting;

		/// <summary>
		/// 캐릭터 초기화
		/// </summary>
		/// <param name="cam"> 메인카메라 </param>
		/// <param name="InitPosition"> 객체 시작위치 </param>
		public void OnInit(Camera cam, Vector3 InitPosition)
		{
			transform.position = InitPosition;
			
			setting.MainCamera = cam;
			setting.MainCamera.transform.SetParent(setting.CamPosition);

			setting.MainCamera.transform.localPosition = new Vector3();
			setting.MainCamera.transform.rotation = Quaternion.identity;
		}

		// Update is called once per frame
		void Update()
		{
			if(setting.MainCamera != null)
			{
				float h = setting.HorizontalSpeed * Input.GetAxis("Mouse X");
				float v = setting.VerticalSpeed * Input.GetAxis("Mouse Y");

				transform.Rotate(0, h, 0);
				setting.MainCamera.transform.Rotate(-v, 0, 0);

				float moveH = Time.deltaTime * Input.GetAxis("Horizontal");
				float moveV = Time.deltaTime * Input.GetAxis("Vertical");

				transform.Translate(moveH, 0, moveV);
			}
		}
	}
}
