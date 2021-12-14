using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Management.Core
{
	public class EnvSetting : MonoBehaviour
	{
		[Range(1, 10)] [SerializeField] float moveSpeed;
		[SerializeField] AudioClip baseAudio;

		public float MoveSpeed { get => moveSpeed; }
		public AudioClip BaseAudio { get => baseAudio; }
	}
}
