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

    public void Init(PuzzleLogic pPuzzle, bool pOnOff)
    {
        m_puzzle = pPuzzle;
        m_isSpikeOn = !pOnOff;
        ChangeState();
    }

    private void Update()
    {
        if (checkChange != m_puzzle.TurnChange) ChangeState();
    }

    private void ChangeState()
    {
        checkChange = m_puzzle.TurnChange;
        m_isSpikeOn = !m_isSpikeOn;
        m_collider.enabled = !m_isSpikeOn;
        
        m_spriteRenderer.sprite = m_isSpikeOn ? OnSpikeSprite : OffSpikeSprite;
    }
}
