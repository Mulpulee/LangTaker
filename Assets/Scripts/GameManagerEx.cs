using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
                    m_status = instance.AddComponent<StatusManager>();
                    DontDestroyOnLoad(instance);
                }
            }
            return m_instance;
        }
    }

    private static StatusManager m_status;
    public static StatusManager Status
    {
        get
        {
            if (m_status == null)
            {
                m_status = Instance.GetComponent<StatusManager>();
                if (m_status == null) m_status = Instance.gameObject.AddComponent<StatusManager>();
            }
            return m_status;
        }
    }

    private void Awake()
    {
        if (GameObject.Find("GameManager") == gameObject)
        {
            if (m_instance == null)
            {
                GameObject instance = new GameObject("GameManager (Singleton)");
                m_instance = instance.AddComponent<GameManagerEx>();
                m_status = instance.AddComponent<StatusManager>();
                DontDestroyOnLoad(instance);
            }
            Destroy(gameObject);
        }
    }

    private void Start()
    {

    }

    public void NewGame()
    {
        // 인트로 재생 후 JS_1로 이동
        SceneManagerEx.Instance.LoadSceneWithFade("DialogScene", true, () => DialogSceneLoaded("Intro"));
    }

    public void SelectMap()
    {
        SceneManagerEx.Instance.LoadSceneWithFade("MapSelectScene", true);
    }

    public void StartPuzzle(string pMap, string pLang)
    {
        SceneManagerEx.Instance.LoadScene("PuzzleScene", () => PuzzleSceneLoaded(pMap, pLang));
    }

    private void PuzzleSceneLoaded(string pMap, string pLang)
    {
        GameObject.FindObjectOfType<PuzzleLogic>().ResetMap(pMap, pLang);
    }

    public void PuzzleCleared(string pDialog, bool pNoDialog = false, string pLang = null)
    {
        if (pNoDialog)
            StartPuzzle(pDialog, pLang);
        else
            SceneManagerEx.Instance.LoadSceneWithFade("DialogScene", true, () => DialogSceneLoaded(pDialog));
    }

    public void DialogSceneLoaded(string pDialog)
    {
        DialogueManager.Instance.RunDialog(pDialog);
    }

    public void DialogEnded(string pLang, float pProgress, string pNextMap)
    {
        StatusObject status = Status.GetStatus(pLang);
        Status.SetProgress(status.Type, status.Progress < pProgress ? pProgress : status.Progress);

        if (pNextMap != "end")
        {
            SceneManagerEx.Instance.LoadScene("PuzzleScene", () => PuzzleSceneLoaded(pNextMap, pLang));
        }
        else
        {
            SceneManagerEx.Instance.LoadScene("MapSelectScene");
        }
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
