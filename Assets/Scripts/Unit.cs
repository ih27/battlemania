using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public bool selected;
    GameMaster gm;

    public int tileSpeed;
    public bool hasMoved;

    private void Start()
    {
        gm = FindObjectOfType<GameMaster>();
    }

    private void OnMouseDown()
    {
        if (selected)
        {
            selected = false;
            gm.selectedUnit = null;
        } else
        {
            if (gm.selectedUnit != null)
            {
                gm.selectedUnit.selected = false;
            }
            selected = true;
            gm.selectedUnit = this;
            GetWalkableTiles();
        }
    }

    void GetWalkableTiles()
    {
        if (hasMoved)
        {
            return;
        }

        foreach (Tile tile in FindObjectsOfType<Tile>())
        {
            if (Math.Abs(transform.position.x - tile.transform.position.x) +
                Math.Abs(transform.position.y - tile.transform.position.y) <= tileSpeed)
            {
                if (tile.IsClear())
                {
                    tile.Highlight();
                }
            }
        }
    }
}
