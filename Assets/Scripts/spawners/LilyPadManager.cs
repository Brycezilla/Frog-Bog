using UnityEngine;
using System.Collections.Generic;

public class LilyPadManager : MonoBehaviour
{
    public GameObject lilyPadPrefab; 
    public Transform spawnPoint; 
    public float spawnInterval = 1.0f; 
    public float destroyOffset = 100.0f; 
    public float minOffsetFrogPosition = 5.0f;
    public float maxOffsetFrogPosition = 15.0f;
    public float spawnerRestriction = 5.0f;

    private float nextSpawnTime;
    private Camera mainCamera;
    [SerializeField] private Transform Frog;

    private List<Vector3> spawnedLilyPadPositions = new List<Vector3>();

    private void Start()
    {
        mainCamera = Camera.main;
        SetNextSpawnTime();
    }

    private void Update()
    {
        float randomSpawnRange = Random.Range(minOffsetFrogPosition, maxOffsetFrogPosition);

        transform.position = new Vector3(Frog.position.x + randomSpawnRange, transform.position.y, transform.position.z);

        if (Time.time >= nextSpawnTime)
        {
            SpawnLilyPad();
            SetNextSpawnTime();
        }

        DestroyOffCameraLilyPads();
    }

    void SetNextSpawnTime()
    {
        nextSpawnTime = Time.time + spawnInterval;
    }

    void SpawnLilyPad()
    {
       int maxAttempts = 100;

        for (int i = 0; i < maxAttempts; i++)
        {
            Vector3 newSpawnPosition = GetRandomSpawnPosition();
            
            if (!IsTooCloseToExistingLilyPads(newSpawnPosition))
            {
                GameObject newLilyPad = Instantiate(lilyPadPrefab, newSpawnPosition, Quaternion.identity);

                spawnedLilyPadPositions.Add(newLilyPad.transform.position);
                break;
            }
        }
    }

    Vector3 GetRandomSpawnPosition()
    {
        float randomXOffset = Random.Range(minOffsetFrogPosition, maxOffsetFrogPosition);
        return new Vector3(Frog.position.x + randomXOffset, spawnPoint.position.y, spawnPoint.position.z);
    }

    bool IsTooCloseToExistingLilyPads(Vector3 position)
    {
        foreach (var existingPosition in spawnedLilyPadPositions)
        {
            float distance = Vector3.Distance(position, existingPosition);
            float minimumDistanceBetweenLilyPads = spawnerRestriction;

            if (distance < minimumDistanceBetweenLilyPads)
            {
                return true;
            }
        }

        return false;
    }

    void DestroyOffCameraLilyPads()
    {
        GameObject[] lilyPads = GameObject.FindGameObjectsWithTag("LilyPad");

        foreach (var lilyPad in lilyPads)
        {
            if (lilyPad.transform.position.x + destroyOffset < Frog.transform.position.x)
            {
                Destroy(lilyPad);
            }
        }
    }
}