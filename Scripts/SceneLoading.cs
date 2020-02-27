using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneLoading : MonoBehaviour {

    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private Image loagingImage;
    [SerializeField] private TextMeshProUGUI progressText;
    [Range(0.1f, 3f)] [SerializeField] private float speed = 1;
    [Range(0.1f, 3f)] [SerializeField] private float fadeSpeed = 1;
    void Awake () {
        DontDestroyOnLoad(gameObject);
        StartCoroutine(AsyncLoad(1));
	}
	
    IEnumerator AsyncLoad(int index)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(index);
        while (loagingImage.fillAmount != 1 || !operation.isDone)
        {
            loagingImage.fillAmount = Mathf.Min(operation.progress / 0.9f, loagingImage.fillAmount + (Time.deltaTime * speed));
            progressText.text = string.Format("{0:0}%", loagingImage.fillAmount * 100);
            yield return new WaitForEndOfFrame();
        }
        float alpha = 1;
        while (alpha > 0.1f)
        {
            canvasGroup.alpha = alpha;
            alpha -= Time.deltaTime * fadeSpeed;
            yield return new WaitForEndOfFrame();
        }
        Destroy(gameObject);
    }
}
