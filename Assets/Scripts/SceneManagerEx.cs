using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManagerEx : MonoBehaviour
{
    private static SceneManagerEx m_instance;
    public static SceneManagerEx Instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<SceneManagerEx>();
                if (m_instance == null)
                {
                    GameObject instance = new GameObject("SceneManager (Singleton)");
                    m_instance = instance.AddComponent<SceneManagerEx>();
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
        if (GameObject.Find("SceneManager") == gameObject)
        {
            if (m_instance == null)
            {
                GameObject instance = new GameObject("SceneManager (Singleton)");
                m_instance = instance.AddComponent<SceneManagerEx>();
                DontDestroyOnLoad(instance);
            }
            Destroy(gameObject);
        }

        m_loadingPrefab = Resources.Load<GameObject>("Loading");
        m_loading = Instantiate(m_loadingPrefab, transform);
        m_loading.SetActive(false);
    }

    public void PlayLoading(bool pAutoClose = false)
    {
        StartCoroutine(LoadingAnim(pAutoClose));
    }

    private IEnumerator LoadingAnim(bool pAutoClose = false)
    {
        m_loading.SetActive(true);

        Image bar = m_loading.transform.GetChild(4).GetComponent<Image>();
        bar.fillAmount = 0f;

        float timer = 0f;
        float blank = 0.8f;
        while (timer < 0.25f)
        {
            yield return null;
            yield return new WaitForSeconds(0.01f);
            timer += 0.005f;
            if (blank > 0.15f) blank -= timer;

            bar.fillAmount += blank / 10f;
        }

        if (pAutoClose) CloseLoading();
    }

    public void CloseLoading()
    {
        m_loading.SetActive(false);
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
        AsyncOperation op = SceneManager.LoadSceneAsync(pScene);
        op.allowSceneActivation = false;

        yield return StartCoroutine(LoadingAnim());

        op.allowSceneActivation = true;
        yield return new WaitUntil(() => op.isDone);

        CloseLoading();
    }

    private void LoadSceneEnd(Scene pScene, LoadSceneMode pLoadSceneMode)
    {
        if (pScene.name == m_loadSceneName)
        {
            SceneManager.sceneLoaded -= LoadSceneEnd;
        }
    }
}
