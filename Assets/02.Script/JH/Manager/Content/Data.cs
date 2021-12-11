using Def;
using Management.Scene;
using Person;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Management.Content
{
	/// <summary>
	/// 컨텐츠 고유 정보 저장 클래스
	/// </summary>
	[System.Serializable]
	public class Data
	{
		[SerializeField] Def.SceneName id;
		[SerializeField] Person.Character character;
		[SerializeField] List<Canvas> canvasList;

		[SerializeField] Transform characterTransform;
		[SerializeField] Transform basePlaneTransform;

		public SceneName ID { get => id; set => id=value; }
		public Character Character { get => character; set => character=value; }
		public List<Canvas> CanvasList { get => canvasList; set => canvasList=value; }
		
		public Transform CharacterTransform { get => characterTransform; set => characterTransform=value; }
		public Transform BasePlaneTransform { get => basePlaneTransform; set => basePlaneTransform=value; }
	}
}
