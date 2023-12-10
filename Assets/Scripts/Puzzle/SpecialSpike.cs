using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialSpike : MonoBehaviour
{
    [SerializeField] private Sprite OnSpikeSprite;
    [SerializeField] private Sprite OffSpikeSprite;

    private bool m_isSpikeOn;
    private bool[] m_pattern;
    private int m_index;

    private SpriteRenderer m_spriteRenderer;
    private Collider2D m_collider;
    private PuzzleLogic m_puzzle;

    private bool checkChange = false;

    private void Awake()
    {
        m_spriteRenderer = GetComponent<SpriteRenderer>();
        m_collider = GetComponent<Collider2D>();

        m_pattern = new bool[4];
    }

    public void Init(PuzzleLogic pPuzzle, bool[] pPattern)
    {
        m_puzzle = pPuzzle;
        m_pattern = pPattern;
        m_index = 3;
        ChangeState();
    }

    private void Update()
    {
        if (checkChange != m_puzzle.TurnChange) ChangeState();
    }

    private void ChangeState()
    {
        m_index++;
        if (m_index == m_pattern.Length) m_index = 0;

        checkChange = m_puzzle.TurnChange;
        m_isSpikeOn = m_pattern[m_index];
        m_collider.enabled = !m_isSpikeOn;
        
        m_spriteRenderer.sprite = m_isSpikeOn ? OnSpikeSprite : OffSpikeSprite;
    }
}
