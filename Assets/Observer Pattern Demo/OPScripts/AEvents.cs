using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AEvents : MonoBehaviour
{
	public Datas myIndex;

	public abstract void Broadcast(Datas index);

	public abstract void OnClick(); 
}
