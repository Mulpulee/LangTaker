using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

[CSharpCallLua]
public interface Map
{
    uint TurnCount { get; }
    uint Width { get; }
    uint Height { get; }
    string Puzzle { get; }
}

public class LuaRunner : MonoBehaviour
{
    [SerializeField] private TextAsset m_luaScript;
    private LuaEnv m_luaEnv;

    private void Awake()
    {
        m_luaEnv = new LuaEnv();
    }

    public Map GetMap(string pMapName)
    {
        m_luaEnv.DoString(m_luaScript.text);
        Map map = m_luaEnv.Global.Get<Map>(pMapName);
        return map;
    }
}
