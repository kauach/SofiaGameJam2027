using UnityEngine;
using UnityEngine.Tilemaps;

public class FieldOfView : MonoBehaviour
{
    public TileBase highlightTile;
    public Tilemap tilemap;
    public int radius;
    public int angle;
    private int segments = 30;
    public Vector2 lookDirection = Vector2.down;

    private Vector3Int[] highlightedTiles;
    private Vector3Int tilemapPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GenerateWedge();
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

    public void GenerateWedge()
    {
        Mesh mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        int vertexCount = segments + 2;
        Vector3[] vertices = new Vector3[vertexCount];
        int[] triangles = new int[segments * 3];

        // Center point of the circle
        vertices[0] = Vector3.zero;

        float angleStep = angle / segments;

        for (int i = 0; i <= segments; i++)
        {
            float rad = Mathf.Deg2Rad * (i * angleStep);
            // Draws flat on the XZ ground plane
            vertices[i + 1] = new Vector3(Mathf.Cos(rad) * radius, 0f, Mathf.Sin(rad) * radius);
        }

        for (int i = 0; i < segments; i++)
        {
            triangles[i * 3] = 0;
            triangles[i * 3 + 1] = i + 2;
            triangles[i * 3 + 2] = i + 1;
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
    }
}
