using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/StatusObject", order = 1)]
public class StatusObject : ScriptableObject
{
    public Lang Type;
    public string Name;
    public string MapName;
    public Sprite Illust;
    public string Description;
    public int MapCount;

    public float Progress { get; set; }
}
