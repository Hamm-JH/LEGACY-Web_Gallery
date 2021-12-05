using Def;
using Management.Scene;
using Person;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Management.Content
{
	/// <summary>
	/// ������ ���� ���� ���� Ŭ����
	/// </summary>
	[System.Serializable]
	public class Data
	{
		[SerializeField] Def.SceneName id;
		[SerializeField] Person.Character character;
		[SerializeField] List<Canvas> canvasList;

		public SceneName ID { get => id; set => id=value; }
		public Character Character { get => character; set => character=value; }
		public List<Canvas> CanvasList { get => canvasList; set => canvasList=value; }
	}
}
