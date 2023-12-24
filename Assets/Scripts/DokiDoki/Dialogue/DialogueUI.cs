using System;
using System.Collections;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

using DialogueSystem;
using System.Collections.Generic;

public class DialogueUI : MonoBehaviour, IDialogueInput, IDialogueOutput
{
    [SerializeField] private Text m_talkLineText;
    [SerializeField] private Text m_talkerNameText;
    [SerializeField] private Image m_illustImage;
    [SerializeField] private Image m_selectShade;
    [SerializeField] private TextButton[] m_selectionButtons;

    private CanvasGroup m_canvasGroup;

    private String m_talkLine;
    private String m_talkerName;
    private String m_illustPath;
    private String[] m_selections;

    private Dictionary<String, Sprite> m_illusts;

    private Int32 m_lastIndex;
    private Coroutine m_printRoutine;
    private Boolean m_isPrinting;


    private void Awake()
    {
        m_lastIndex = -1;
        m_canvasGroup = GetComponent<CanvasGroup>();
        m_canvasGroup.Hide();

        m_illusts = new Dictionary<String, Sprite>();
        foreach(var s in Resources.LoadAll<Sprite>("Illust"))
        {
            m_illusts.Add(s.name, s);
        }
    }

    private void Start()
    {
        DialogueManager.Instance.RunDialog("JS_1");
    }

    public int ReadSelection()
    {
        return m_lastIndex;
    }

    public void WriteLine(string pLine)
    {
        m_talkLine = pLine;
    }

    public void WriteTalkerName(string pTalkerName)
    {
        m_talkerName = pTalkerName;
    }

    public void WriteSelections(string[] pSelections)
    {
        m_selections = pSelections;
    }

    public void WriteIllust(string pIllust)
    {
        m_illustPath = pIllust;
    }

    public void BeginPrint()
    {
        m_canvasGroup.Show();
        HideAllButtons();
    }

    public void DoPrint(Action pNext)
    {
        if (m_printRoutine != null)
            StopCoroutine(m_printRoutine);

        m_printRoutine = StartCoroutine(PrintRoutine(pNext));
    }

    public void EndPrint()
    {
        m_canvasGroup.Hide();
    }

    private void HideAllButtons()
    {
        m_selectShade.gameObject.SetActive(false);
        foreach (var button in m_selectionButtons)
        {
            button.CanvasGroup.Hide();
        }
    }

    private void OnSelect(Int32 pIndex)
    {
        m_lastIndex = pIndex;
        HideAllButtons();
    }

    private void Update()
    {
        if (!m_isPrinting)
            return;


        if (Input.GetKeyDown(KeyCode.Space))
            m_isPrinting = false;
    }

    private IEnumerator PrintRoutine(Action pNext)
    {
        m_talkLineText.text = "";
        m_talkerNameText.text = m_talkerName;
        m_illustImage.sprite = m_illusts[m_illustPath];
        m_illustImage.SetNativeSize();

        if (m_selections == null)
        {
            m_isPrinting = true;
            foreach (var ch in m_talkLine)
            {
                m_talkLineText.text += ch;
                yield return new WaitForSeconds(0.08f);

                if(!m_isPrinting)
                {
                    m_talkLineText.text = m_talkLine;
                    break;
                }
            }
            m_isPrinting = false;

            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
            pNext.Invoke();
        }
        else
        {
            m_talkLineText.text = m_talkLine;
            m_selectShade.gameObject.SetActive(true);
            for(int i=0;i<m_selections.Length;i++)
            {
                Int32 index = i;
                m_selectionButtons[i].CanvasGroup.Show();
                m_selectionButtons[i].Text.text = m_selections[i];
                m_selectionButtons[i].Button.onClick.RemoveAllListeners();
                m_selectionButtons[i].Button.onClick.AddListener(() => OnSelect(index));
                m_selectionButtons[i].Button.onClick.AddListener(new UnityAction(pNext));
            }
            m_selections = null;
        }
    }

}
