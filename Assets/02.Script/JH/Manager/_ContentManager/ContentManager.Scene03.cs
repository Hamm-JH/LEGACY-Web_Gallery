using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Management
{
	public partial class ContentManager : Manager
	{
		
		public void OnLoadComplete()
		{
			if(_Data.ID == Def.SceneName.Scene03)
			{
				image03.enabled = true;
				animator03.SetTrigger("FadeIn");
			}
		}

	}
}
