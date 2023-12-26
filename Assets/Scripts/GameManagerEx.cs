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

    }

    public void SelectMap()
    {

    }

    public void StartPuzzle(string pMap, string pLang)
    {
        SceneManagerEx.Instance.LoadScene("PuzzleScene", () => PuzzleSceneLoaded(pMap, pLang));
    }

    private void PuzzleSceneLoaded(string pMap, string pLang)
    {
        GameObject.FindObjectOfType<PuzzleLogic>().ResetMap(pMap, pLang);
    }
}
