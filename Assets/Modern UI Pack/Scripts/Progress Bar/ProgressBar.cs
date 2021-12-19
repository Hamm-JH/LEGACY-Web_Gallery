using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Michsky.UI.ModernUIPack
{
    public class ProgressBar : MonoBehaviour
    {
        // Content
        public float currentPercent;
        [Range(0, 100)] public int speed;
        public float maxValue = 100;

        // Resources
        public Image loadingBar;
        public TextMeshProUGUI textPercent;

        // Settings
        public bool isOn;
        public bool restart;
        public bool invert;
        public bool isPercent = true;

        public bool isCompleted;

        void Start()
        {
            if (isOn == false)
            {
                loadingBar.fillAmount = currentPercent / maxValue;
                textPercent.text = ((int)currentPercent).ToString("F0") + "%";
            }
        }

        void Update()
        {
            if (isOn == true)
            {
                if (currentPercent <= maxValue && invert == false)
                    currentPercent += speed * Time.deltaTime;
                else if (currentPercent >= 0 && invert == true)
                    currentPercent -= speed * Time.deltaTime;

                if (currentPercent >= maxValue && speed != 0 && restart == true && invert == false)
                    currentPercent = 0;
                else if (currentPercent <= 0 && speed != 0 && restart == true && invert == true)
                    currentPercent = maxValue;

                loadingBar.fillAmount = currentPercent / maxValue;

                if (isPercent == true)
                    textPercent.text = ((int)currentPercent).ToString("F0") + "%";
                else
                    textPercent.text = ((int)currentPercent).ToString("F0");

                Debug.Log("-------------------------");
                Debug.Log($"currentPercent : {currentPercent}");
                Debug.Log($"maxValue : {maxValue}");
                Debug.Log($"current / max : {currentPercent / maxValue}");
                Debug.Log($"load.fillam : {loadingBar.fillAmount}");

                if(loadingBar.fillAmount == 1 && !isCompleted)
				{
                    isOn = false;
                    isCompleted = true;
                    Management.GameManager.Instance.LoadSceneComplete();
				}
            }
        }

        public void UpdateUI()
        {
            loadingBar.fillAmount = currentPercent / maxValue;
          
            if (isPercent == true)
                textPercent.text = ((int)currentPercent).ToString("F0") + "%";
            else
                textPercent.text = ((int)currentPercent).ToString("F0");
        }
    }
}