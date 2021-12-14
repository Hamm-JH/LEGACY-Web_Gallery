using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Management
{
    using Core;

    public partial class GameManager : Manager
    {
        private void ContentInit(CoreResource core, ContentManager _content, EnvSetting env)
		{
            //_content._Data.Character = core.character;
            core.character = _content._Data.Character;
			Camera cam = core.mainCamera;

            // ĳ���� �ʱ�ȭ
            //core.character.OnInit(cam, _content._Data.CharacterTransform);


			// ĵ���� �ʱ�ȭ
			foreach (var _canvas in _content._Data.CanvasList)
			{
                _canvas.worldCamera = cam;
			}
		}
    }
}
