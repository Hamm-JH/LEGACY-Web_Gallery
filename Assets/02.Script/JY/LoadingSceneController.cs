
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Michsky.UI.ModernUIPack;

public class LoadingSceneController : MonoBehaviour
{
    static string nextScene;
    public ProgressBar pb;

    public static void LoadScene(string sceneName)
    {
        nextScene = sceneName;
        SceneManager.LoadScene("Loading");
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadSceneProcess());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator LoadSceneProcess()
    {
       AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        op.allowSceneActivation = false;
        float timer = 0f;
        while(!op.isDone)
        {
            yield return null;//반복문 한번 돌때마다 유니티애게 제어권을 넘겨줘서 바가 차오르는 게 보이게 해야 한다.

            if(op.progress <0.9f)
            {
                pb.loadingBar.fillAmount = op.progress;
               
            }
            else //페이크로 1초간 진행 후 씬 로드.
            {
                timer += Time.unscaledDeltaTime;
                pb.loadingBar.fillAmount = Mathf.Lerp(0.9f, 1f, timer);
                if(pb.loadingBar.fillAmount >=1f)
                {
                    op.allowSceneActivation = true;
                    yield break;
                }
            }
        }
    }
}
