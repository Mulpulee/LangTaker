using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StatusManager : MonoBehaviour
{
    private Dictionary<Lang, StatusObject> Status;

    private void Awake()
    {
        Status = new Dictionary<Lang, StatusObject>();

        foreach (var s in Resources.LoadAll<StatusObject>("Status"))
        {
            Status.Add(s.Type, s);
        }
    }

    public StatusObject GetStatus(string pLang)
    {
        return GetStatus(Status.FirstOrDefault(s => s.Value.Name == pLang).Value.Type);
    }

    public StatusObject GetStatus(Lang pType)
    {
        return Status[pType];
    }

    public void SetProgress(Lang pType, float pValue)
    {
        Status[pType].Progress = pValue; return;
    }
}
