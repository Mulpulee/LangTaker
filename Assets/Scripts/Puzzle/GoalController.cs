using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour
{
    private string m_dialog;
    private string m_lang;
    private bool m_noDialog = false;

    public void Init(string pDialog, string pLang, string pNextMap)
    {
        m_dialog = pDialog;
        m_lang = pLang;
        if (m_dialog == "")
        {
            m_noDialog = true;
            m_dialog = pNextMap;
        }
    }

    private void Update()
    {
        var detect = Physics2D.OverlapBox(transform.position, new Vector2(1.5f, 0.2f), 0, 1 << 0);
        if (detect != null && detect.CompareTag("Player"))
        {
            GameManagerEx.Instance.PuzzleCleared(m_dialog, m_noDialog, m_lang);
            Destroy(gameObject);
        }
        
        detect = Physics2D.OverlapBox(transform.position, new Vector2(0.2f, 1.5f), 0, 1 << 0);
        if (detect != null && detect.CompareTag("Player"))
        {
            GameManagerEx.Instance.PuzzleCleared(m_dialog, m_noDialog, m_lang);
            Destroy(gameObject);
        }
    }
}
