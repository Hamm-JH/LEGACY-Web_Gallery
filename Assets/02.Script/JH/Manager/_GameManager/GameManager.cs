using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Management
{
	using Core;
	using Management.Scene;

	/// <summary>
	/// 관리자 클래스의 부모 클래스
	/// </summary>
	public partial class GameManager : Manager
	{
		#region Instance

		private static GameManager instance;

		public static GameManager Instance
		{
			get
			{
				if(instance == null)
				{
					instance = FindObjectOfType<GameManager>() as GameManager;
				}
				return instance;
			}
		}

		#endregion

		/// <summary>
		/// 범용 리소스 모음
		/// </summary>
		[Header("범용 사용변수")]
		public CoreResource core;

		[Header("환경변수")]
		public EnvSetting envSetting;

		[SerializeField] EnvDictionary envs;

		#region Content Refresh
		/// <summary>
		/// 컨텐츠 관리자 클래스 :: 컨텐츠 씬 레벨 생성시 실행되는 코드
		/// </summary>
		[Header("컨텐츠 관리 인스턴스")]
		public ContentManager content;

		/// <summary>
		/// 직전의 Scene 이동시의 요청사항 저장
		/// </summary>
		public Request prevRequest;
		#endregion

		/// <summary>
		/// 시스템 관리자 코드 OnStart
		/// :: 컨텐츠 초기화시 한 번만 진입한다.
		/// </summary>
		public override void OnStart()
		{
			Debug.Log("Hello new project");

			UnityEngine.SceneManagement.SceneManager.LoadScene(
				Def.SceneName.Scene01.ToString(), 
				LoadSceneMode.Single);
		}

		/// <summary>
		/// 시스템 관리자 코드 OnCreate
		/// :: 컨텐츠 관리자에서 자기 자신을 이 메서드를 통해 시스템 관리자에게 공지한다.
		/// </summary>
		/// <param name="_this"></param>
		public override void OnCreate(ContentManager _this)
		{
			// 컨텐츠 관리자 코드 새로 할당
			content = _this;

			// 컨텐츠 초기화
			ContentInit(core, content, envSetting);
			
			// fade out
			OnFadeOut();

#if UNITY_EDITOR
			Debug.Log($"Debug : new content scene loaded :: Scene ID : {content._Data.ID}");
#endif
		}

		/// <summary>
		/// 시스템 관리자 코드 OnSceheChange
		/// :: 컨텐츠 관리자에서 Scene 이동 발생시, 씬 이동에 대한 요청 변수를 받는다.
		/// </summary>
		/// <param name="request"> Scene 이동 옵션 인스턴스 </param>
		public override void OnSceneChange(Request request)
		{
			// 컨텐츠 변수 리셋
			content = null;

			// 임시 요청변수 저장
			Request currRequest = request;

			// 이전 요청변수 prevRequest에 대한 처리가 필요할 경우, 이 영역 안에서 prevRequest값이 변하기 전에 실행
			{
				// 씬 이름 확인
				Def.SceneName sName = request.sceneName;

				Debug.Log($"Step 1 : Scene Change {sName.ToString()} stanby");

				OnFadeIn();

				// TODO :: [씬 변경 2단계] 1205 이 아래의 코드는 씬 변경 준비가 완료되었을 때 시행
				Debug.Log($"Step 2 : Scene Change {sName.ToString()} ready");

				// 요청변수 갱신
				prevRequest = currRequest;
				SceneManager.LoadScene(sName.ToString(), LoadSceneMode.Single);
			}
		}

		// Fade in, Fade out 구현

		private void Awake()
		{
			DontDestroyOnLoad(this);
		}

		// Start is called before the first frame update
		void Start()
		{
			OnStart();
		}

		
	}
}
