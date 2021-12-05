using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Person.pInput
{
	[System.Serializable]
	public class InputSetting
	{
		[SerializeField] float horizontalSpeed = 2.0f;
		[SerializeField] float verticalSpeed = 2.0f;

		[SerializeField] Transform camPosition;
		[SerializeField] Camera mainCamera;

		public float HorizontalSpeed { get => horizontalSpeed; set => horizontalSpeed=value; }
		public float VerticalSpeed { get => verticalSpeed; set => verticalSpeed=value; }

		public Transform CamPosition { get => camPosition; set => camPosition=value; }
		public Camera MainCamera { get => mainCamera; set => mainCamera=value; }
	}
}
