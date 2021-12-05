using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Management.Content
{
	[System.Serializable]
	public class Data
	{
		[SerializeField] string id;

		public string ID { get => id; set => id=value; }
	}
}
