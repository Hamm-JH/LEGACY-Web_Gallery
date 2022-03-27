using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Datas
{
	public int index;
	public string m_str;

	public override string ToString()
	{
		string str = $"index : {index}\n" +
			$"str : {m_str.ToString()}";

		return str;
	}
}
