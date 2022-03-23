using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMaker : MonoBehaviour
{
    [Header("World Properties")]
    [Range(1, 16)]
    public int height = 1;
    [Range(1, 64)]
    public int width = 1;
    [Range(1, 64)]
    public int depth = 1;


    [Header("Tile Properties")]
    public Transform tileParent;
    public GameObject threeDTile;
   

    // Start is called before the first frame update
    void Start()
    {
        float offsetX = Random.Range(-1024.0f, 1024.0f);
        float offsetZ = Random.Range(-1024.0f, 1024.0f);
        //generation
        for (int y = 0; y < height; y++)
        {
            float rand = Random.Range(16.0f, 24.0f);

            
            for (int z = 0; z < depth; z++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (0.5f < Mathf.PerlinNoise((x + offsetX) / rand, (z + offsetZ) / rand)) // * depth * 0.5f)
                    {
                        var tile=Instantiate(threeDTile, new Vector3(x, y, z), Quaternion.identity);
                         tile.transform.parent = tileParent;
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
