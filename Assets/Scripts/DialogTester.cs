using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTester : MonoBehaviour
{
    private void Start()
    {
        DialogueManager.Instance.RunDialog("JS_1");
    }
}
