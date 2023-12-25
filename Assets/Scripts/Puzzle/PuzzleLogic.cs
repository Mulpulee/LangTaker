using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleLogic : MonoBehaviour
{
    [SerializeField] private Text CountDisplay;

    [SerializeField] private PuzzleLoader m_loader;

    private string m_mapName;
    private string m_lang;

    private GameObject m_player;

    private int m_moveCount;
    private bool m_gotKey = false;

    private GameObject[] m_portals;

    public bool TurnChange = false;

    public void Init(string pMap, string pLang, GameObject pPlayer, int pMoveCount, GameObject[] pPortals)
    {
        m_mapName = pMap;
        m_lang = pLang;
        m_player = pPlayer;
        m_moveCount = pMoveCount;
        m_portals = pPortals;
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

        CountDisplay.text = m_moveCount.ToString() + ".";
    }

    private void PlayerMove(Vector2 pDir)
    {
        Collider2D facing = CheckTile(m_player.transform, 8, pDir);

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
            if (CheckTile(facing.transform, 8, pDir) == null)
            {
                facing.transform.position += new Vector3(pDir.x, pDir.y, 0);
            }
        }
        else if (facing.CompareTag("Monster"))
        {
            Collider2D further = CheckTile(facing.transform, 8, pDir);
            if (further == null)
            {
                facing.transform.position += new Vector3(pDir.x, pDir.y, 0);
            }
            else if (further.CompareTag("Wall") || further.CompareTag("Box"))
            {
                Destroy(facing.gameObject);
            }

            further = CheckTile(facing.transform, 9, Vector2.zero);
            if (further != null && further.CompareTag("Spike"))
            {
                Destroy(facing.gameObject);
            }
        }
        else if (facing.CompareTag("Key"))
        {
            m_player.transform.position += new Vector3(pDir.x, pDir.y, 0);
            
            Destroy(facing.gameObject);
            m_gotKey = true;
        }
        else if (facing.CompareTag("LockedBox"))
        {
            if (m_gotKey) Destroy(facing.gameObject);
        }
        else if (facing.CompareTag("BreakableBox"))
        {
            if(facing.GetComponent<BreakableBox>().GetHit()) Destroy(facing.gameObject);
        }
        else if (facing.CompareTag("Portal_1"))
        {
            m_player.transform.position = m_portals[1].transform.position;
        }
        else if (facing.CompareTag("Portal_2"))
        {
            m_player.transform.position = m_portals[0].transform.position;
        }

        facing = CheckTile(m_player.transform, 9, Vector2.zero);

        if (facing != null && facing.CompareTag("Spike"))
        {
            m_moveCount--;
        }

        m_moveCount--;
        CountDisplay.text = m_moveCount.ToString() + ".";
        TurnChange = !TurnChange;
        return;
    }

    private Collider2D CheckTile(Transform pTarget, int pLayer, Vector2 pDir)
    {
        return Physics2D.OverlapBox((Vector2)pTarget.position + pDir, new Vector2(0.2f, 0.2f), 0, 1 << pLayer);
    }

    private void ResetMap()
    {
        TurnChange = false; m_gotKey = false;
        m_loader.StartGame(m_mapName, m_lang);
    }
    
    public void ResetMap(string pMap, string pLang)
    {
        TurnChange = false; m_gotKey = false;
        m_loader.StartGame(pMap, pLang);
    }
}
