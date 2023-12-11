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
    [SerializeField] private GameObject WallTile;           // w
    [SerializeField] private GameObject BoxTile;            // b
    [SerializeField] private GameObject LockedBoxTile;      // l
    [SerializeField] private GameObject SpikeTile;          // s
    [SerializeField] private GameObject OnOffSpikeTile;     // A / v
    [SerializeField] private GameObject SpecialSpikeTile;   // 1 - ??

    [SerializeField] private LuaRunner m_lua;
    [SerializeField] private PuzzleLogic m_logic;

    private string m_mapName;
    private string m_lang;
    private Dictionary<string, Dictionary<string, Sprite>> m_sprites;

    private string m_map;
    private GameObject MapParent;

    private GameObject m_player;

    private List<GameObject> m_lockedBoxes;
    private int m_moveCount;

    private void Awake()
    {
        m_sprites = new Dictionary<string, Dictionary<string, Sprite>>();

        m_sprites.Add("c", new Dictionary<string, Sprite>());
        m_sprites.Add("c++", new Dictionary<string, Sprite>());
        m_sprites.Add("c#", new Dictionary<string, Sprite>());
        m_sprites.Add("java", new Dictionary<string, Sprite>());
        m_sprites.Add("js", new Dictionary<string, Sprite>());
        m_sprites.Add("python", new Dictionary<string, Sprite>());
        m_sprites.Add("ruby", new Dictionary<string, Sprite>());
        m_sprites.Add("lua", new Dictionary<string, Sprite>());

        foreach(var d in m_sprites)
        {
            foreach (var s in Resources.LoadAll<Sprite>($"Object/{d.Key}"))
            {
                d.Value.Add(s.name, s);
            }
        }
    }

    public void StartGame(string pMap, string pLang)
    {
        m_mapName = pMap;
        m_lang = pLang;
        Map map = m_lua.GetMap(pMap);
        m_moveCount = (int)map.TurnCount;

        int width = (int)map.Width;
        int height = (int)map.Height;

        m_map = map.Puzzle;
        if (MapParent != null) Destroy(MapParent);
        MapParent = new GameObject("Map");
        m_lockedBoxes = new List<GameObject>();

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
                        SummonTile(WallTile, i, j, width, height);
                        break;
                    case 's':
                        SummonTile(EmptyTile, i, j, width, height);
                        SummonTile(SpikeTile, i, j, width, height, "spike");
                        break;
                    case 'A':
                        SummonTile(EmptyTile, i, j, width, height);
                        SummonTile(OnOffSpikeTile, i, j, width, height, "nspike");
                        break;
                    case 'v':
                        SummonTile(EmptyTile, i, j, width, height);
                        SummonTile(OnOffSpikeTile, i, j, width, height, "fspike");
                        break;
                    case 'b':
                        SummonTile(EmptyTile, i, j, width, height);
                        SummonTile(BoxTile, i, j, width, height, "box");
                        break;
                    case 'k':
                        SummonTile(EmptyTile, i, j, width, height);
                        SummonTile(Key, i, j, width, height);
                        break;
                    case 'l':
                        SummonTile(EmptyTile, i, j, width, height);
                        m_lockedBoxes.Add(SummonTile(LockedBoxTile, i, j, width, height));
                        break;
                    case 'm':
                        SummonTile(EmptyTile, i, j, width, height);
                        SummonTile(Monster, i, j, width, height, "monster");
                        break;
                    case 'g':
                        SummonTile(EmptyTile, i, j, width, height);
                        SummonTile(Goal, i, j, width, height);
                        break;
                    case 'p':
                        SummonTile(EmptyTile, i, j, width, height);
                        m_player = SummonTile(Player, i, j, width, height);
                        break;
                    case 'n': // Box on Spike
                        SummonTile(EmptyTile, i, j, width, height);
                        SummonTile(SpikeTile, i, j, width, height, "spike");
                        SummonTile(BoxTile, i, j, width, height, "box");
                        break;

                    default: break;
                }
            }
        }

        Camera.main.orthographicSize = height / 2 + 1;
        m_logic.Init(m_mapName, m_lang, m_player, m_lockedBoxes, m_moveCount);
    }

    private GameObject SummonTile(GameObject pTile, int i, int j, int w, int h, string type = "")
    {
        GameObject go = Instantiate(pTile, new Vector3(j - w / 2, h - i - (float)h / 2 - 0.5f, 0),
            Quaternion.identity, MapParent.transform);

        if(type == "nspike")
            go.GetComponent<OnOffSpike>().Init(m_logic, true, m_sprites[m_lang]["spike"], m_sprites[m_lang]["offspike"]);
        else if(type == "fspike")
            go.GetComponent<OnOffSpike>().Init(m_logic, false, m_sprites[m_lang]["spike"], m_sprites[m_lang]["offspike"]);
        else if (type != "")
            go.GetComponent<SpriteRenderer>().sprite = m_sprites[m_lang][type];

        return go;
    }
}
