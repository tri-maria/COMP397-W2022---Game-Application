using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [Header("Tile Resources")]
    public List<GameObject> tilePrefabs;

    [Header("Map Properties")]
    [Range(2, 30)]
    public int width = 2;
    [Range(2, 30)]
    public int depth = 2;
    public Transform parent;

    [Header("Generated Tiles")]
    public List<GameObject> tiles;

    private int startWidth;
    private int startDepth;

    // Start is called before the first frame update
    void Start()
    {
        startWidth = width;
        startDepth = depth;
        BuildMap();
    }

    // Update is called once per frame
    void Update()
    {
        if (width != startWidth || depth != startDepth)
        {
            ResetMap();
            BuildMap();

        }
    }

    public void ResetMap()
    {
        startWidth = width;
        startDepth = depth;
        var size = tiles.Count;

        for (int i = 0; i < size; i++)
        {
            Destroy(tiles[i]);
        }

        tiles.Clear(); // removes all tiles
    }
    public void BuildMap()
    {
        var offset = new Vector3( 20.0f, 0.0f, 20.0f);
        // generate more tiles if both width and depth are both greater than 2

        for (int row = 0; row <= depth; row++)
            {

                for (int col = 0; col <= width; col++)
                {
                    if (row == 1 && col == 1) { continue; }

                    var randomPrefabIndex = Random.Range(0, 4);
                    var randomRotation = Quaternion.Euler(0.0f, Random.Range(0, 4) * 90.0f, 0.0f);
                    var tilePositiion = new Vector3(col * 20.0f, 0.0f, row * 20.0f) - offset;
                    tiles.Add(Instantiate(tilePrefabs[randomPrefabIndex], tilePositiion, randomRotation, parent));
                }

            }
        
    }

    
}