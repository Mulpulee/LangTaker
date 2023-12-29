using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PuzzleLoader : MonoBehaviour
{
    [SerializeField] private GameObject Player;             // p
    [SerializeField] private GameObject Monster;            // m
    [SerializeField] private GameObject Goal;               // g
    [SerializeField] private GameObject Key;                // k
    [SerializeField] private GameObject EmptyTile;          // .
    [SerializeField] private GameObject Wall;               // w
    [SerializeField] private GameObject Box;                // b
    [SerializeField] private GameObject BreakableBox;       // 1 - 9
    [SerializeField] private GameObject LockedBox;          // l
    [SerializeField] private GameObject Spike;              // s
    [SerializeField] private GameObject OnOffSpike;         // A / v
    [SerializeField] private GameObject SpecialSpike;       // ({[<>]})
    [SerializeField] private GameObject Portal;             // o

    [SerializeField] private LuaRunner m_lua;
    [SerializeField] private PuzzleLogic m_logic;

    private string m_mapName;
    private string m_lang;
    private Dictionary<string, Dictionary<string, Sprite>> m_sprites;
    private GameObject[] m_portals;

    private string m_map;
    private GameObject MapParent;

    private GameObject m_player;

    private int m_moveCount;

    private void Awake()
    {
        m_sprites = new Dictionary<string, Dictionary<string, Sprite>>
        {
            { "c", new Dictionary<string, Sprite>() },
            { "c++", new Dictionary<string, Sprite>() },
            { "c#", new Dictionary<string, Sprite>() },
            { "java", new Dictionary<string, Sprite>() },
            { "js", new Dictionary<string, Sprite>() },
            { "python", new Dictionary<string, Sprite>() },
            { "ruby", new Dictionary<string, Sprite>() },
            { "lua", new Dictionary<string, Sprite>() }
        };

        foreach (var d in m_sprites)
        {
            foreach (var s in Resources.LoadAll<Sprite>($"Object/{d.Key}"))
            {
                d.Value.Add(s.name, s);
            }
        }
    }

    public void StartGame(string pMap, string pLang)
    {
        SceneManagerEx.Instance.PlayLoading(true);
        m_mapName = pMap;
        m_lang = pLang;

        StartCoroutine(LoadMap());
    }

    private IEnumerator LoadMap()
    {
        Map map = m_lua.GetMap(m_mapName);

        yield return new WaitUntil(() => map != null);

        MapLoaded(map);
    }

    private void MapLoaded(Map map)
    {
        Pattern m_patterns = m_lua.GetPatterns();

        m_moveCount = (int)map.TurnCount;
        int width = (int)map.Width;
        int height = (int)map.Height;

        m_map = map.Puzzle;
        if (MapParent != null) Destroy(MapParent);
        MapParent = new GameObject("Map");
        m_portals = new GameObject[2];

        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                switch (m_map[i * width + j])
                {
                    case '.':
                        SummonTile(EmptyTile, i, j, width, height);
                        break;
                    case 'w':
                        SummonTile(Wall, i, j, width, height);
                        break;
                    case 's':
                        SummonTile(EmptyTile, i, j, width, height);
                        SummonTile(Spike, i, j, width, height, "spike");
                        break;
                    case 'A':
                        SummonTile(EmptyTile, i, j, width, height);
                        SummonTile(OnOffSpike, i, j, width, height, "nspike");
                        break;
                    case 'v':
                        SummonTile(EmptyTile, i, j, width, height);
                        SummonTile(OnOffSpike, i, j, width, height, "fspike");
                        break;
                    case 'b':
                        SummonTile(EmptyTile, i, j, width, height);
                        SummonTile(Box, i, j, width, height, "box");
                        break;
                    case 'k':
                        SummonTile(EmptyTile, i, j, width, height);
                        SummonTile(Key, i, j, width, height);
                        break;
                    case 'l':
                        SummonTile(EmptyTile, i, j, width, height);
                        SummonTile(LockedBox, i, j, width, height);
                        break;
                    case 'm':
                        SummonTile(EmptyTile, i, j, width, height);
                        SummonTile(Monster, i, j, width, height, "monster");
                        break;
                    case 'g':
                        SummonTile(EmptyTile, i, j, width, height);
                        SummonTile(Goal, i, j, width, height).AddComponent<GoalController>().Init(map.Dialog, m_lang, map.NextMap);
                        break;
                    case 'p':
                        SummonTile(EmptyTile, i, j, width, height);
                        m_player = SummonTile(Player, i, j, width, height);
                        break;
                    case 'n': // Box on Spike
                        SummonTile(EmptyTile, i, j, width, height);
                        SummonTile(Spike, i, j, width, height, "spike");
                        SummonTile(Box, i, j, width, height, "box");
                        break;
                    case 'o':
                        SummonTile(EmptyTile, i, j, width, height);
                        if(m_portals[0] == null) m_portals[0] = SummonTile(Portal, i, j, width, height, "portal");
                        else m_portals[1] = SummonTile(Portal, i, j, width, height, "portal");
                        break;

                    case '{':
                        SummonTile(EmptyTile, i, j, width, height);
                        SummonTile(SpecialSpike, i, j, width, height, "special", m_patterns.Pattern1);
                        break;
                    case '(':
                        SummonTile(EmptyTile, i, j, width, height);
                        SummonTile(SpecialSpike, i, j, width, height, "special", m_patterns.Pattern2);
                        break;
                    case '[':
                        SummonTile(EmptyTile, i, j, width, height);
                        SummonTile(SpecialSpike, i, j, width, height, "special", m_patterns.Pattern3);
                        break;
                    case '<':
                        SummonTile(EmptyTile, i, j, width, height);
                        SummonTile(SpecialSpike, i, j, width, height, "special", m_patterns.Pattern4);
                        break;


                    default:
                        if (1 <= int.Parse(m_map[i * width + j] + "")
                            && int.Parse(m_map[i * width + j] + "") <= 9)
                        {
                            SummonTile(EmptyTile, i, j, width, height);
                            SummonTile(BreakableBox, i, j, width, height, "box").
                                GetComponent<BreakableBox>().SetDurabillity(int.Parse(m_map[i * width + j] + ""));
                        }
                        break;
                }
            }
        }

        if (m_portals[0] != null)
        {
            m_portals[0].tag = "Portal_1";
            m_portals[1].tag = "Portal_2";
        }
        Camera.main.orthographicSize = height / 2 + 2.5f;
        m_logic.Init(m_mapName, m_lang, m_player, m_moveCount, m_portals);
    }

    private GameObject SummonTile(GameObject pTile, int i, int j, int w, int h, string type = "", bool[] pattern = null)
    {
        GameObject go = Instantiate(pTile, new Vector3(j - w / 2.0f + 0.5f, h - i - (float)h / 2.0f - 0.9f, 0),
            Quaternion.identity, MapParent.transform);

        if (type == "nspike")
            go.GetComponent<OnOffSpike>().Init(m_logic, true);// , m_sprites[m_lang]["spike"], m_sprites[m_lang]["offspike"]);
        else if (type == "fspike")
            go.GetComponent<OnOffSpike>().Init(m_logic, false);// , m_sprites[m_lang]["spike"], m_sprites[m_lang]["offspike"]);
        else if (type == "special")
            go.GetComponent<SpecialSpike>().Init(m_logic, pattern);
        else if (type == "portal") { }
        //else if (type != "")
        //    go.GetComponent<SpriteRenderer>().sprite = m_sprites[m_lang][type];

        return go;
    }
}
