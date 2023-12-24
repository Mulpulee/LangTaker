using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BreakableBox : MonoBehaviour
{
    private Text m_count;
    private int m_remainCount;

    public void SetDurabillity(int pValue)
    {
        m_remainCount = pValue;
        m_count = transform.GetChild(0).GetChild(0).GetComponent<Text>();
        m_count.text = m_remainCount.ToString();
    }

    public bool GetHit()
    {
        m_remainCount--;
        m_count.text = m_remainCount.ToString();

        return m_remainCount == 0;
    }
}
