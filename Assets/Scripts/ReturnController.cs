using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ReturnController : MonoBehaviour
{
    [SerializeField] private Button m_newbutton;
    [SerializeField] private Button m_selectbutton;
    [SerializeField] private Button m_exitbutton;

    private void Start()
    {
        m_newbutton.onClick.AddListener(() => GameManagerEx.Instance.NewGame());
        m_selectbutton.onClick.AddListener(() => GameManagerEx.Instance.SelectMap());
        m_exitbutton.onClick.AddListener(() => GameManagerEx.Instance.ExitGame());
    }

    private void Update()
    {
        transform.localPosition = new Vector3(transform.localPosition.x,
            EventSystem.current.currentSelectedGameObject.transform.localPosition.y);
    }
}
