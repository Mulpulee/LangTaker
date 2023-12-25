using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapSelector : MonoBehaviour
{
    [SerializeField] private GameObject m_status;
    [SerializeField] private GameObject m_lang;
    [SerializeField] private GameObject m_map;

    [SerializeField] private LuaRunner m_lua;

    private Image m_profile;
    private Image m_progress;
    private Text m_description;

    private Text m_name;
    private GameObject[] m_obstacles;

    private StatusObject m_currentLang;
    private int m_currentIndex;

    private void Start()
    {
        m_profile = m_status.transform.GetChild(0).GetComponent<Image>();
        m_progress = m_status.transform.GetChild(1).GetComponent<Image>();
        m_description = m_status.transform.GetChild(2).GetComponent<Text>();

        m_name = m_map.transform.GetChild(0).GetChild(0).GetComponent<Text>();
        m_obstacles = m_map.transform.GetChild(1).GetComponentsInChildren<GameObject>();

        LangSelectWindow();
    }

    public void LangSelectWindow()
    {
        m_status.SetActive(false);
        m_lang.SetActive(true);
        m_map.SetActive(false);
    }

    public void MapSelectWindow()
    {
        m_status.SetActive(true);
        m_lang.SetActive(false);
        m_map.SetActive(true);


    }

    public void ShowLangInfo(Lang pLang)
    {
        m_status.SetActive(true);
        m_currentLang = GameManagerEx.Status.GetStatus(pLang);

        m_profile.sprite = m_currentLang.Illust;
        m_progress.fillAmount = m_currentLang.Progress;
        m_description.text = m_currentLang.Description;
    }

    private void ShowMapInfo(int pIndex)
    {
        Map map = m_lua.GetMap($"{m_currentLang.Name}_{pIndex}");

        m_name.text = $"{m_currentLang.name} - {pIndex}";

        for (int i = 1; i < m_obstacles.Length; i++)
        {
            m_obstacles[i].SetActive(map.Obstacles[i - 1]);
        }
    }

    public void SelectLang(Lang pLang)
    {
        if (m_currentLang.Type != pLang)
        {
            ShowLangInfo(pLang); return;
        }

        MapSelectWindow();
    }

    public void SelectMap(int pIndex)
    {
        if (m_currentIndex != pIndex)
        {
            ShowMapInfo(pIndex); return;
        }

    }
}
