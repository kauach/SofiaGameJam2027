using System;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GirlLogic : MonoBehaviour
{
    public TileBase highlightTile;
    public Tilemap tilemap;
    public int radius;
    public int angle;
    public float angerGain = 0.3f;
    public float angerDecay = 0.05f;
    private int segments = 30;
    public Vector2 lookDirection = Vector2.down;

    private Vector3Int[] highlightedTiles;
    private Vector3Int tilemapPosition;

    public float Anger { get; set; } = 0.0f;

    private Canvas personalCanvas;
    private ProgressBarLogic angerProgressBar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Transform tr = transform.Find("UI");
        if (tr != null)
        {
            personalCanvas = tr.gameObject.GetComponent<Canvas>();
            angerProgressBar = tr.Find("AngerProgressBar").GetComponent<ProgressBarLogic>();
            angerProgressBar.SetProgress(Anger);
            personalCanvas.enabled = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        tilemapPosition = tilemap.WorldToCell(transform.localPosition);

        Vector2 checkedTile = new Vector2(tilemapPosition.x - radius, tilemapPosition.y - radius);

        for (; checkedTile.x <= tilemapPosition.x + radius; checkedTile.x++)
        {
            checkedTile.y = tilemapPosition.y - radius;
            for (; checkedTile.y <= tilemapPosition.y + radius; checkedTile.y++)
            {
                if (checkedTile.x == tilemapPosition.x && checkedTile.y == tilemapPosition.y)
                    continue;
                tilemap.SetTile(new Vector3Int((int)checkedTile.x, (int)checkedTile.y, tilemapPosition.z), IsTargetInsideFOV(checkedTile) ? highlightTile : null);  
            }
        }

        UIUpdate();
    }

    bool IsTargetInsideFOV(Vector2 target)
    {
        Vector2 pos = new Vector2(tilemapPosition.x, tilemapPosition.y);
        Vector2 directionToTarget = (target - pos).normalized;

        float angleToTarget = Vector2.Angle(lookDirection, directionToTarget);
        //UnityEngine.Debug.Log($"{directionToTarget}, {lookDirection}");
        if (angleToTarget < angle / 2)
        {
            float distance = Vector2.Distance(target, pos);
            //UnityEngine.Debug.Log($"{distance}, {target}");
            return distance < radius;
        }
        return false;
    }

    public void CheckPlayerPosition(Vector3 playerPosition)
    {
        if (IsTargetInsideFOV(new Vector2(playerPosition.x, playerPosition.y)))
            Anger += angerGain * Time.deltaTime;
        else
            Anger -= angerDecay * Time.deltaTime;
        
        Anger = Math.Min(1.0f, Math.Max(0.0f, Anger));

        UIUpdate();
    }

    void UIUpdate()
    {
        angerProgressBar.SetProgress(Anger);

        personalCanvas.enabled = (Anger > 0.0f);

        float pingpong = Mathf.PingPong((Time.time) * 1.5f, 1);
        float scale = Mathf.Lerp(1f, 1.1f, pingpong);
        personalCanvas.transform.localScale = new Vector3(scale, scale, scale);

        //UnityEngine.Debug.Log($"Anger {Anger}");
    }
}
