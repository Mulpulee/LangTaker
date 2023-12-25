using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MapSelector : MonoBehaviour
{
    [SerializeField] private GameObject m_status;
    [SerializeField] private GameObject m_lang;
    [SerializeField] private GameObject m_map;

    [SerializeField] private LuaRunner m_lua;

    [SerializeField] private Sprite[] m_mapButtonSprites;
    [SerializeField] private GameObject m_noneButton;

    private Image m_profile;
    private Image m_progress;
    private Text m_description;

    private Text m_name;
    private Transform[] m_obstacles;
    private Image[] m_mapButtons;
    private RectTransform m_line;

    private StatusObject m_currentLang;
    private int m_currentIndex;

    private void Start()
    {
        m_profile = m_status.transform.GetChild(0).GetComponent<Image>();
        m_progress = m_status.transform.GetChild(1).GetComponent<Image>();
        m_description = m_status.transform.GetChild(2).GetComponent<Text>();

        m_name = m_map.transform.GetChild(0).GetChild(0).GetComponent<Text>();
        m_obstacles = m_map.transform.GetChild(0).GetChild(1).GetComponentsInChildren<Transform>();
        m_mapButtons = m_map.transform.GetChild(2).GetComponentsInChildren<Image>();
        m_line = m_map.transform.GetChild(1).GetComponent<RectTransform>();

        LangSelectWindow();
    }

    public void LangSelectWindow()
    {
        m_status.SetActive(false);
        m_lang.SetActive(true);
        m_map.SetActive(false);

        EventSystem.current.SetSelectedGameObject(m_noneButton);
    }

    public void MapSelectWindow()
    {
        m_status.SetActive(true);
        m_lang.SetActive(false);
        m_map.SetActive(true);

        m_name.text = "";
        m_currentIndex = -1;

        foreach (var s in m_mapButtons)
        {
            s.sprite = m_mapButtonSprites[0];
            s.SetNativeSize();
        }

        for (int i = 2; i > m_currentLang.MapCount - 1; i--)
        {
            m_mapButtons[i].gameObject.SetActive(false);
            m_line.sizeDelta = new Vector2(m_line.sizeDelta.x - 700, m_line.sizeDelta.y);
        }

        for (int i = 1; i < m_obstacles.Length; i++)
        {
            m_obstacles[i].gameObject.SetActive(false);
        }

        EventSystem.current.SetSelectedGameObject(m_mapButtons[0].gameObject);
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
        Map map = m_lua.GetMap($"{m_currentLang.Name}_{pIndex + 1}");

        m_name.text = $"{m_currentLang.name} - {pIndex + 1}";

        for (int i = 1; i < m_obstacles.Length; i++)
        {
            m_obstacles[i].gameObject.SetActive(map.Obstacles[i - 1]);
        }

        foreach (var s in m_mapButtons)
        {
            s.sprite = m_mapButtonSprites[0];
            s.SetNativeSize();
        }

        m_mapButtons[pIndex].sprite = m_mapButtonSprites[1];
        m_mapButtons[pIndex].SetNativeSize();
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
