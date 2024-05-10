using UnityEngine;
using UnityEngine.Tilemaps;

// Very simple tiles generation

public class TileGenerator : MonoBehaviour
{
    [SerializeField] Transform playerPosition;
    [SerializeField] Tilemap tilemap;
    [SerializeField] TileBase[] tilePrefabs;

    [SerializeField] int range;
    [SerializeField] float generateTimerInterval;
    float timer;

    private void Start()
    {
        GenerateTiles();
        timer = Time.time + generateTimerInterval;
    }

    void Update()
    {
        if (timer < Time.time)
        {
            GenerateTiles();
            timer = Time.time + generateTimerInterval;
        }
    }

    void GenerateTiles()
    {
        Vector3Int playerPos = tilemap.WorldToCell(playerPosition.position);

        for (int x = playerPos.x - range; x <= playerPos.x + range; x++)
        {
            for (int y = playerPos.y - range; y <= playerPos.y + range; y++)
            {
                if (tilemap.GetTile(new Vector3Int(x, y, 0)) == null)
                {
                    TileBase randomTile = tilePrefabs[Random.Range(0, tilePrefabs.Length)];
                    tilemap.SetTile(new Vector3Int(x, y, 0), randomTile);
                }
            }
        }
    }
}

