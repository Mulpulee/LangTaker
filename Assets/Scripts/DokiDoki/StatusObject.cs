using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/StatusObject", order = 1)]
public class StatusObject : ScriptableObject
{
    public Lang Type;
    public Sprite Illust;
    public string Description;

    public int Progress { get; set; }
}
