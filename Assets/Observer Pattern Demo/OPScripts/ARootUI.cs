using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ARootUI : MonoBehaviour
{
	#region instance
	private static ARootUI instance;

	public static ARootUI Instance
	{
		get
		{
			if (instance == null)
			{
				instance = FindObjectOfType<ARootUI>() as ARootUI;
			}
			return instance;
		}
	}
	#endregion

	public List<AEvents> targets;

	//public void InvokeEvent(Datas index)
	//{
		
	//}

	public void Broadcast(Datas index)
	{
		targets.ForEach(x => x.Broadcast(index));
	}

	#region
	public void ConditionalBranch()
	{
		Debug.Log("hello branch");
	}
	public void example<T>(List<T> t) where T : ARootUI
	{
		t.ForEach(x => x.ConditionalBranch());
	}
	#endregion
}
