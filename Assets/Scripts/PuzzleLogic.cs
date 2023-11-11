using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PuzzleLogic : MonoBehaviour
{
    [SerializeField] private GameObject Player;             // p
    [SerializeField] private GameObject Monster;            // m
    [SerializeField] private GameObject Goal;               // g
    [SerializeField] private GameObject EmptyTile;          // .
    [SerializeField] private GameObject WallTile;           // w
    [SerializeField] private GameObject BoxTile;            // b
    [SerializeField] private GameObject SpikeTile;          // s
    [SerializeField] private GameObject OnOffSpikeTile;     // A / v

    [SerializeField] private Text CountDisplay;

    [SerializeField] private LuaRunner m_lua;

    [SerializeField] private string MapName;

    private string m_map;
    private GameObject MapParent;

    private GameObject m_player;

    private int m_moveCount;

    public bool TurnChange = false;

    private void Start()
    {
        StartGame();
    }

    private void StartGame()
    {
        Map pMap = m_lua.GetMap(MapName);
        m_moveCount = (int)pMap.TurnCount;

        int width = (int)pMap.Width;
        int height = (int)pMap.Height;

        m_map = pMap.Puzzle;
        MapParent = new GameObject("Map");

        for(int i = 0; i < height; i++)
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
                        SummonTile(SpikeTile, i, j, width, height);
                        break;
                    case 'A':
                        SummonTile(OnOffSpikeTile, i, j, width, height).GetComponent<OnOffSpike>().Init(this, true);
                        break;
                    case 'v':
                        SummonTile(OnOffSpikeTile, i, j, width, height).GetComponent<OnOffSpike>().Init(this, false);
                        break;
                    case 'b':
                        SummonTile(EmptyTile, i, j, width, height);
                        SummonTile(BoxTile, i, j, width, height);
                        break;
                    case 'm':
                        SummonTile(EmptyTile, i, j, width, height);
                        SummonTile(Monster, i, j, width, height);
                        break;
                    case 'g':
                        SummonTile(EmptyTile, i, j, width, height);
                        SummonTile(Goal, i, j, width, height);
                        break;
                    case 'p':
                        SummonTile(EmptyTile, i, j, width, height);
                        m_player = SummonTile(Player, i, j, width, height);
                        break;

                    default: break;
                }
            }
        }

        Camera.main.orthographicSize = height / 2 + 1;
    }

    private GameObject SummonTile(GameObject pTile, int i, int j, int w, int h)
    {
        return Instantiate(pTile, new Vector3(j - w / 2, h - i - (float)h / 2 - 0.5f, 0),
            Quaternion.identity, MapParent.transform);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            PlayerMove(Vector2.up);
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            PlayerMove(Vector2.left);
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            PlayerMove(Vector2.down);
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            PlayerMove(Vector2.right);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetMap();
        }

        CountDisplay.text = m_moveCount.ToString();
    }

    private void PlayerMove(Vector2 pDir)
    {
        Collider2D facing = Physics2D.OverlapBox((Vector2)m_player.transform.position + pDir, new Vector2(0.2f, 0.2f), 0, 1 << 8);

        if (facing == null)
        {
            m_player.transform.position += new Vector3(pDir.x, pDir.y, 0);
        }
        else if (facing.CompareTag("Wall"))
        {
            return;
        }
        else if (facing.CompareTag("Box"))
        {
            Collider2D further = Physics2D.OverlapBox((Vector2)facing.transform.position + pDir, new Vector2(0.2f, 0.2f), 0, 1 << 8);
            if (further == null)
            {
                facing.transform.position += new Vector3(pDir.x, pDir.y, 0);
            }
        }
        else if (facing.CompareTag("Monster"))
        {
            Collider2D further = Physics2D.OverlapBox((Vector2)facing.transform.position + pDir, new Vector2(0.2f, 0.2f), 0, 1 << 8);
            if (further == null)
            {
                facing.transform.position += new Vector3(pDir.x, pDir.y, 0);
            }
            else if (further.CompareTag("Wall") || further.CompareTag("Box"))
            {
                Destroy(facing.gameObject);
            }

            further = Physics2D.OverlapBox((Vector2)facing.transform.position, new Vector2(0.2f, 0.2f), 0, 1 << 9);
            if (further != null && further.CompareTag("Spike"))
            {
                Destroy(facing.gameObject);
            }
        }

        facing = Physics2D.OverlapBox((Vector2)m_player.transform.position, new Vector2(0.2f, 0.2f), 0, 1 << 9);
        
        if (facing != null && facing.CompareTag("Spike"))
        {
            m_moveCount--;
        }

        m_moveCount--;
        CountDisplay.text = m_moveCount.ToString();
        TurnChange = !TurnChange;
        return;
    }

    private void ResetMap()
    {
        Destroy(MapParent);
        TurnChange = false;
        StartGame();
    }
}
