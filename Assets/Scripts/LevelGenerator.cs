using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] GameObject chunkPrefab;
    [SerializeField] int startChunkAmount = 12;
    [SerializeField] Transform chunkParent;
    [SerializeField] float chunkLength = 10;

    private void Start()
    {
        for (int i = 0; i < startChunkAmount; i++)
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

            Vector3 chunkPositionPos = new Vector3(transform.position.x, transform.position.y, spawnPositionZ);

            Instantiate(chunkPrefab, chunkPositionPos, Quaternion.identity, chunkParent);
        }


    }
}
