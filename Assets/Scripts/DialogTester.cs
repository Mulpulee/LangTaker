using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTester : MonoBehaviour
{
    [SerializeField] private string m_script;

    private void Start()
    {
        DialogueManager.Instance.RunDialog(m_script);
    }
}
