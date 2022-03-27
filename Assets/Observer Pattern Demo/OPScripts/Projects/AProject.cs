using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AProject : MonoBehaviour
{
	#region instance
	private static AProject instance;

	public static AProject Instance
	{
		get
		{
			if (instance == null)
			{
				instance = FindObjectOfType<AProject>() as AProject;
			}
			return instance;
		}
	}
	#endregion

	public List<ARootUI> targets;

	public void InvokeEvent(Datas index)
	{
		targets.ForEach(x => x.Broadcast(index));
	}

	
}
