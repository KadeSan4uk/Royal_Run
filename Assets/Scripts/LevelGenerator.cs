using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] GameObject chunkPrefab;
    [SerializeField] int startChunkAmount = 12;
    [SerializeField] Transform chunkParent;
    [SerializeField] float chunkLength = 10;
    [SerializeField] float moveSpeed = 8f;

    List<GameObject> chunks = new List<GameObject>();


    private void Start()
    {
        SpawnStartingChunks();
    }

    private void Update()
    {
        MoveChunks();
    }

    void SpawnStartingChunks()
    {
        for (int i = startChunkAmount - 1; i >= 0; i--)
        {
            SpawnChunk();
        }
    }

    private void SpawnChunk()
    {
        float spawnPositionZ = CalculateSpawnPositionZ();

        Vector3 chunkPositionPos = new Vector3(transform.position.x, transform.position.y, spawnPositionZ);

        GameObject newChunk = Instantiate(chunkPrefab, chunkPositionPos, Quaternion.identity, chunkParent);

        chunks.Add(newChunk);
    }

    float CalculateSpawnPositionZ()
    {
        float spawnPositionZ;
        if (chunks.Count == 0)
        {
            spawnPositionZ = transform.position.z;
        }
        else
        {
            spawnPositionZ = chunks[chunks.Count - 1].transform.position.z + chunkLength;
        }

        return spawnPositionZ;
    }

    void MoveChunks()
    {
        for (int i = 0; i < chunks.Count; i++)
        {
            GameObject chunk = chunks[i];
            chunk.transform.Translate(-transform.forward * (moveSpeed * Time.deltaTime));

            if (chunk.transform.position.z <= Camera.main.transform.position.z - chunkLength)
            {
                chunks.Remove(chunk);
                Destroy(chunk);
                SpawnChunk();
            }
        }
    }
}
