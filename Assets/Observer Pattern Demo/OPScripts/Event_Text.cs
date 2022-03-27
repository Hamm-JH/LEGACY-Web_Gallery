using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Event_Text : AEvents
{
	public Text text;

	public override void Broadcast(Datas index)
	{
		text.text = index.ToString();
	}

	public override void OnClick()
	{
		throw new System.NotImplementedException();
	}

	// Start is called before the first frame update
	void Start()
    {
		Text txt;
		if(gameObject.TryGetComponent<Text>(out txt))
		{
			text = txt;
		}
    }
}
