using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Chunk : MonoBehaviour
{
    [SerializeField] GameObject fencePrefab;
    [SerializeField] float[] lanes = { -2.5f, 0f, 2.5f };

    private void Start()
    {
        SpawbFence();
    }

    void SpawbFence()
    {
        List<int> availibleLanes = new List<int> { 0, 1, 2 };

        int fencesToSpawn = Random.Range(0, lanes.Length);

        for (int i = 0; i < fencesToSpawn; i++)
        {
            if (availibleLanes.Count <= 0) break;

            int randomLaneIndex = Random.Range(0, availibleLanes.Count);
            int selectedLane = availibleLanes[randomLaneIndex];
            availibleLanes.RemoveAt(randomLaneIndex);

            Vector3 spawnPosition = new Vector3(lanes[selectedLane], transform.position.y, transform.position.z);
            Instantiate(fencePrefab, spawnPosition, Quaternion.identity, this.transform);
        }


    }
}
