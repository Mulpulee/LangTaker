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

    private List<GameObject> m_lockedBoxes;
    private int m_moveCount;

    public bool TurnChange = false;

    public void Init(string pMap, string pLang, GameObject pPlayer, List<GameObject> pLockedBoxes, int pMoveCount)
    {
        m_mapName = pMap;
        m_lang = pLang;
        m_player = pPlayer;
        m_lockedBoxes = pLockedBoxes;
        m_moveCount = pMoveCount;
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
        else if (facing.CompareTag("Key"))
        {
            m_player.transform.position += new Vector3(pDir.x, pDir.y, 0);
            
            Destroy(facing.gameObject);
            foreach(var b in m_lockedBoxes) Destroy(b.gameObject);
        }

        facing = Physics2D.OverlapBox((Vector2)m_player.transform.position, new Vector2(0.2f, 0.2f), 0, 1 << 9);
        
        if (facing != null && facing.CompareTag("Spike"))
        {
            m_moveCount--;
        }

        m_moveCount--;
        CountDisplay.text = m_moveCount.ToString() + ".";
        TurnChange = !TurnChange;
        return;
    }

    private void ResetMap()
    {
        TurnChange = false;
        m_loader.StartGame(m_mapName, m_lang);
    }
    
    public void ResetMap(string pMap, string pLang)
    {
        TurnChange = false;
        m_loader.StartGame(pMap, pLang);
    }
}
