using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Event_Button : AEvents
{
    public Button thisBtn;

	private void Start()
	{
		thisBtn.onClick.AddListener(new UnityAction(OnClick));
	}

	public override void Broadcast(Datas index)
	{
		Debug.Log($"I am {gameObject.name}, I get index {index.ToString()}");
	}

	public override void OnClick()
	{
		// Observer로 이벤트 발생 보고
		AProject.Instance.InvokeEvent(myIndex);


		//Debug.Log($"Hello {thisBtn.name}");

		//RootUI1.Instance.ConditionalBranch();
	}
}
