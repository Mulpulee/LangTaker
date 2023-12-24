using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapSelector : MonoBehaviour
{
    [SerializeField] private GameObject m_status;

    private Image m_profile;
    private Image m_progress;
    private Text m_description;

    private Lang m_currentLang;

    private void Start()
    {
        m_profile = m_status.transform.GetChild(0).GetComponent<Image>();
        m_progress = m_status.transform.GetChild(1).GetComponent<Image>();
        m_description = m_status.transform.GetChild(2).GetComponent<Text>();

        m_status.SetActive(false);
    }

    public void ShowInfo(Lang pLang)
    {
        m_status.SetActive(true);
        m_currentLang = pLang;

        StatusObject status = GameManagerEx.Status.GetStatus(pLang);

        m_profile.sprite = status.Illust;
        m_progress.fillAmount = status.Progress;
        m_description.text = status.Description;
    }

    public void SelectLang(Lang pLang)
    {
        if (m_currentLang != pLang)
        {
            ShowInfo(pLang); return;
        }

        // ∏ º±≈√
    }
}
