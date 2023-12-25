using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOffSpike : MonoBehaviour
{
    [SerializeField] private Sprite OnSpikeSprite;
    [SerializeField] private Sprite OffSpikeSprite;

    private bool m_isSpikeOn;

    private SpriteRenderer m_spriteRenderer;
    private Collider2D m_collider;
    private PuzzleLogic m_puzzle;

    private bool checkChange = false;

    private void Awake()
    {
        m_spriteRenderer = GetComponent<SpriteRenderer>();
        m_collider = GetComponent<Collider2D>();
    }

    public void Init(PuzzleLogic pPuzzle, bool pOnOff, Sprite pOn = null, Sprite pOff = null)
    {
        m_puzzle = pPuzzle;
        m_isSpikeOn = !pOnOff;

        if(pOff != null)
        {
            OnSpikeSprite = pOn;
            OffSpikeSprite = pOff;
        }

        ChangeState();
    }

    private void Update()
    {
        if (checkChange != m_puzzle.TurnChange) ChangeState();

        if (m_isSpikeOn)
        {
            var standing = Physics2D.OverlapBox(transform.position, new Vector2(0.2f, 0.2f), 0, 1 << 8);

            if (standing != null && standing.CompareTag("Monster"))
            {
                Destroy(standing.gameObject);
            }
        }
    }

    private void ChangeState()
    {
        checkChange = m_puzzle.TurnChange;
        m_isSpikeOn = !m_isSpikeOn;
        m_collider.enabled = !m_isSpikeOn;
        
        m_spriteRenderer.sprite = m_isSpikeOn ? OnSpikeSprite : OffSpikeSprite;
    }
}
