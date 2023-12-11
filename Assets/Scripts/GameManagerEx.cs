using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerEx : MonoBehaviour
{
    private static GameManagerEx m_instance;
    public static GameManagerEx Instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<GameManagerEx>();
                if (m_instance == null)
                {
                    GameObject instance = new GameObject("GameManager (Singleton)");
                    m_instance = instance.AddComponent<GameManagerEx>();
                    DontDestroyOnLoad(instance);
                }
            }
            return m_instance;
        }
    }

    private GameObject m_loadingPrefab;
    private GameObject m_loading;
    private string m_loadSceneName;

    private void Awake()
    {
        if (GameObject.Find("GameManager") == gameObject)
        {
            if (m_instance == null)
            {
                GameObject instance = new GameObject("GameManager (Singleton)");
                m_instance = instance.AddComponent<GameManagerEx>();
                DontDestroyOnLoad(instance);
            }
            Destroy(gameObject);
        }

        m_loadingPrefab = Resources.Load<GameObject>("Loading");
        m_loading = Instantiate(m_loadingPrefab, transform);
        m_loading.SetActive(false);
    }

    public void NewGame()
    {

    }

    public void LoadGame()
    {

    }

    public void LoadScene(string pScene)
    {
        m_loading.SetActive(true);
        SceneManager.sceneLoaded += LoadSceneEnd;
        m_loadSceneName = pScene;
        StartCoroutine(Load(pScene));
    }

    private IEnumerator Load(string pScene)
    {
        Image bar = m_loading.transform.GetChild(4).GetComponent<Image>();
        bar.fillAmount = 0f;

        AsyncOperation op = SceneManager.LoadSceneAsync(pScene);
        op.allowSceneActivation = false;

        float timer = 0.0f;
        while (!op.isDone)
        {
            yield return null;
            timer += Time.unscaledDeltaTime;

            if (op.progress < 0.9f)
            {
                bar.fillAmount = Mathf.Lerp(bar.fillAmount, op.progress, timer);
                if (bar.fillAmount >= op.progress)
                {
                    timer = 0f;
                }
            }
            else
            {
                bar.fillAmount = Mathf.Lerp(bar.fillAmount, 1f, timer);

                if (bar.fillAmount == 1.0f)
                {
                    op.allowSceneActivation = true;
                    yield break;
                }
            }
        }
    }

    private void LoadSceneEnd(Scene pScene, LoadSceneMode pLoadSceneMode)
    {
        if (pScene.name == m_loadSceneName)
        {
            SceneManager.sceneLoaded -= LoadSceneEnd;
            m_loading.SetActive(false);
        }
    }
}
