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

		[Header("Animator Controllable Value")]
		public float audioVolume;
		private bool volumeUpdate;

		/// <summary>
		/// 범용 리소스 모음
		/// </summary>
		[Header("범용 사용변수")]
		public CoreResource core;

		[Header("씬별 환경변수 리스트")]
		public List<EnvSetting> envSettings;

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

			core.currentScene = Def.SceneName.Scene01;

			// 씬 01을 불러온다.
			OnSceneChange(new Request
			{
				sceneName = Def.SceneName.Scene01,
				optionIndex = 99	// 초기 시작의 경우엔, fade in 단계를 건너뛰고 ChangeProcess 단계에 접근해야 한다.
			});
		}

		/// <summary>
		/// [신규 생성된 씬 신고] 
		/// 시스템 관리자 코드 OnCreate
		/// :: 컨텐츠 관리자에서 자기 자신을 이 메서드를 통해 시스템 관리자에게 공지한다.
		/// </summary>
		/// <param name="_this"></param>
		public override void OnCreate(ContentManager _this)
		{
			// 컨텐츠 관리자 코드 새로 할당
			content = _this;

			
			// 컨텐츠 초기화
			ContentInit(core, content, envSettings[(int)core.currentScene]);
			
			// fade out
			// TODO 1215 :: 어드레서블 시행시 이 구간에서 삭제
			//OnFadeOut();

#if UNITY_EDITOR
			Debug.Log($"Debug : new content scene loaded :: Scene ID : {content._Data.ID}");
#endif
		}

		/// <summary>
		/// [씬 변경 요청] 
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
				prevRequest = currRequest;
				core.currentScene = prevRequest.sceneName;  // 업데이트된 씬 상태를 저장한다.

				ReadyToFadeIn();

				// 일반 :: 앱 실행중 씬 변경시 Fade in 실행. 후 ChangeProcess로 진입
				if (request.optionIndex != 99)
				{
					OnFadeIn(sName);
				}
				// 99 option :: 앱 초기 실행시, Fade in을 거치지 않고 바로 ChangeProcess로 진입한다. (깜빡임 방지)
				else
				{
					Debug.Log($"index 99");
					OnSceneChangeProcess();
				}

				// TODO :: [씬 변경 2단계] 1205 이 아래의 코드는 씬 변경 준비가 완료되었을 때 시행
				Debug.Log($"Step 2 : Scene Change {sName.ToString()} ready");

				// 요청변수 갱신
				//SceneManager.LoadScene(sName.ToString(), LoadSceneMode.Single);
			}
		}

		/// <summary>
		/// DontDestroy
		/// </summary>
		private void Awake()
		{
			DontDestroyOnLoad(this);
		}

		/// <summary>
		/// animator IsStart 실행
		/// </summary>
		void Start()
		{
			// 1초뒤, Start Anim clip 실행
			// -> OnStart(); 실행
			core.animator.SetBool("IsStart", true);
		}

		private void Update()
		{
			if(volumeUpdate)
			{
				//core.mainAudio.volume =
			}
		}
	}
}
