using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] GameObject chunkPrefab;
    [SerializeField] int startChunkAmount = 12;
    [SerializeField] Transform chunkParent;
    [SerializeField] float chunkLength = 10;
    [SerializeField] float moveSpeed = 8f;

    GameObject[] chunks = new GameObject[12];

    private void Start()
    {
        SpawnChunks();
    }

    private void Update()
    {
        MoveChunks();
    }

    void SpawnChunks()
    {
        for (int i = startChunkAmount - 1; i >= 0; i--)
        {
            float spawnPositionZ = CalculateSpawnPositionZ(i);

            Vector3 chunkPositionPos = new Vector3(transform.position.x, transform.position.y, spawnPositionZ);

            GameObject newChunk = Instantiate(chunkPrefab, chunkPositionPos, Quaternion.identity, chunkParent);

            chunks[i] = newChunk;
        }
    }

    float CalculateSpawnPositionZ(int i)
    {
        float spawnPositionZ;
        if (i == 0)
        {
            spawnPositionZ = transform.position.z;
        }
        else
        {
            spawnPositionZ = transform.position.z + (i * chunkLength);
        }

        return spawnPositionZ;
    }

    void MoveChunks()
    {
        for (int i = 0; i < chunks.Length; i++)
        {
            chunks[i].transform.Translate(-transform.forward * (moveSpeed * Time.deltaTime));
        }
    }
}
