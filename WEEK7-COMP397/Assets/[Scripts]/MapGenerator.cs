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


    // Start is called before the first frame update
    void Start()
    {
        BuildMap();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BuildMap()
    {

        //Generate first 3 tiles
        for (int i = 0; i < 3; i++)
        {
            var randomPrefabIndex = Random.Range(0, 4);
            var randomRotation = Quaternion.Euler(0.0f, Random.Range(0, 4) * 90.0f, 0.0f);
            tiles.Add(Instantiate(tilePrefabs[randomPrefabIndex], Vector3.zero, randomRotation, parent));
           
        }

        tiles[1].transform.position = new Vector3(0.0f, 0.0f, 20.0f);
        tiles[2].transform.position = new Vector3(20.0f, 0.0f, 20.0f);
        tiles[3].transform.position = new Vector3(20.0f, 0.0f, 0.0f);

        int count = 0;
        // generate more tiles if both width and depth are both greater than 2
        if (width > 2 && depth > 2)
        {
            for (int row = 0; row <= depth; row++)
            { 
           
                for (int col = 0; col <= width; col++)
                    {
                    count++;

                    if (count > 2)
                    {
                        var randomPrefabIndex = Random.Range(0, 4);
                        var randomRotation = Quaternion.Euler(0.0f, Random.Range(0, 4) * 90.0f, 0.0f);
                        tiles.Add(Instantiate(tilePrefabs[randomPrefabIndex], new Vector3(col * 20.0f, 0.0f, row * 20.0f), randomRotation, parent)); 
                    }

                    
                    }
             
               
            }
        }
    }

    
}