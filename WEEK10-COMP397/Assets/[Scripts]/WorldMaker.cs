using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMaker : MonoBehaviour
{
    [Header("World Properties")]
    [Range(1, 5)]
    public int height = 1;
    [Range(1, 5)]
    public int width = 1;
    [Range(1, 5)]
    public int depth = 1;


    [Header("Tile Properties")]
    public GameObject threeDTile;
    public float size = 10;

    // Start is called before the first frame update
    void Start()
    {
        float rand = Random.Range(16.0f, 24.0f);

        float offsetX = Random.Range(-1024.0f, 1024.0f);
        float offsetZ = Random.Range(-1024.0f, 1024.0f);
        //generation
        for (int y = 0; y < height; y++)
        {
            for (int z = 0; z < depth; z++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (y < Mathf.PerlinNoise((x + offsetX) / rand, (z + offsetZ) / rand) * depth * 0.5f)
                    {
                        Instantiate(threeDTile, new Vector3(x, y, z), Quaternion.identity);
                    }

                }

            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
