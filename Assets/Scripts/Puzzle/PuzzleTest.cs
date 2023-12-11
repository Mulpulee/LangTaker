using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleTest : MonoBehaviour
{
    [SerializeField] private PuzzleLogic logic;
    [SerializeField] private string MapName;
    [SerializeField] private string Lang;

    private void Start()
    {
        logic.ResetMap(MapName, Lang);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            logic.ResetMap(MapName, Lang);
        }
    }
}
