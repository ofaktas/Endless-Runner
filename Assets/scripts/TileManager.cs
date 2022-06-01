using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] TilePrefabs;
    private Transform playertransform;
    private float SpawnZ = -10.6f;
    private float SafeZone = 15f;
    private float tileLength = 7.6f;
    private readonly int AmnTilesOnScreen = 7;
    private int LastPrefabIndex = 0;

    private List<GameObject> activeTiles;
    void Start()
    {
        activeTiles = new List<GameObject>();
        playertransform = GameObject.FindGameObjectWithTag("Player").transform;
        for (int i = 0; i < AmnTilesOnScreen; i++)
        {
            if (i < 2)
            {
                SpawnTile(1);
            }else
                SpawnTile(0);
        }
    }
    void Update()
    {
        if (playertransform.position.z - SafeZone > (SpawnZ - AmnTilesOnScreen * tileLength))
        {
            SpawnTile();
            DeteleTile();
        }
    }
    private void SpawnTile(int PrefabIndex = -1)
    {
        GameObject go;
        if (PrefabIndex == -1)
        {
            go = Instantiate(TilePrefabs[RandomPrefabIndex()]) as GameObject;
        }
        else
            go = Instantiate(TilePrefabs[PrefabIndex]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * SpawnZ;
        SpawnZ += tileLength;
        activeTiles.Add(go);

    }
    private void DeteleTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
    private int RandomPrefabIndex()
    {
        if (TilePrefabs.Length <= 1)
            return 0;
        int randomIndex = LastPrefabIndex;
        while (randomIndex == LastPrefabIndex)
        {
            randomIndex = Random.Range(0, TilePrefabs.Length);
        }
        LastPrefabIndex = randomIndex;
        return randomIndex;
    }
}