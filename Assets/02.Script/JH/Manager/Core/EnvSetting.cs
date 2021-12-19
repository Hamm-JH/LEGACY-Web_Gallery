using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Management.Core
{
	public class EnvSetting : MonoBehaviour
	{
		[Range(1, 10)] [SerializeField] float moveSpeed;
		[Range(0, 1)] [SerializeField] float maxVolume;
		[SerializeField] AudioClip baseAudio;

		public float MoveSpeed { get => moveSpeed; }
		public float MaxVolume { get => maxVolume;}
		public AudioClip BaseAudio { get => baseAudio; }
	}
}
