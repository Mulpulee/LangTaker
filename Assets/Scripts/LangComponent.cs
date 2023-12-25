using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[Serializable]
public enum Lang
{
    JS,
    PY,
    JA,
    CS,
    CP,
    C,
    RU,
    LU
}

public class LangComponent : MonoBehaviour, ISelectHandler
{
    [SerializeField] private MapSelector mapSelector;
    private Button button;
    public Lang lang;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() => mapSelector.SelectLang(lang));
    }

#if UNITY_EDITOR_WIN && UNITY_STANDALONE_WIN
    public void OnSelect(BaseEventData eventData)
    {
        mapSelector.ShowLangInfo(lang);
    }
#endif
}
