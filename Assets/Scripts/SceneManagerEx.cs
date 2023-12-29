using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

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

    private GameObject m_fadeImage;
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

        m_fadeImage = Instantiate(Resources.Load<GameObject>("Fade"), transform);
        m_loading = Instantiate(Resources.Load<GameObject>("Loading"), transform);
        m_fadeImage.SetActive(false);
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

    public void LoadSceneWithFade(string pScene, bool pOnlyfade = false, Action pAction = null)
    {
        if (pOnlyfade)
        {
            StartCoroutine(FadeOut(pAction, pScene));
        }
        else
        {
            StartCoroutine(FadeOut(() => LoadScene(pScene, pAction)));
        }
    }

    public IEnumerator FadeOut(Action pAction, string pScene = null)
    {
        m_fadeImage.SetActive(true);
        Image image = m_fadeImage.transform.GetChild(0).GetComponent<Image>();
        while (image.color.a < 1)
        {
            yield return new WaitForSeconds(0.01f);
            image.color += new Color(0, 0, 0, 0.01f);
        }

        image.color = Color.black;
        if (pScene != null)
        {
            AsyncOperation async = SceneManager.LoadSceneAsync(pScene);
            yield return new WaitUntil(() => async.isDone);
        }
        image.color = new Color(0, 0, 0, 0);
        m_fadeImage.SetActive(false);

        if (pAction != null) pAction.Invoke();
    }

    public void LoadScene(string pScene, Action pAction = null)
    {
        m_loading.SetActive(true);
        SceneManager.sceneLoaded += LoadSceneEnd;
        m_loadSceneName = pScene;
        StartCoroutine(Load(pScene, pAction));
    }

    private IEnumerator Load(string pScene, Action pAction)
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(pScene);
        op.allowSceneActivation = false;

        yield return StartCoroutine(LoadingAnim());

        op.allowSceneActivation = true;
        yield return new WaitUntil(() => op.isDone);

        CloseLoading();
        if(pAction != null) pAction.Invoke();
    }

    private void LoadSceneEnd(Scene pScene, LoadSceneMode pLoadSceneMode)
    {
        if (pScene.name == m_loadSceneName)
        {
            SceneManager.sceneLoaded -= LoadSceneEnd;
        }
    }
}
