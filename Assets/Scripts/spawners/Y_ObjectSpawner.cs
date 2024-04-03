using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Y_ObjectSpawner : MonoBehaviour
{
    public GameObject WaspsPrefab; 
    public Transform spawnPoint;
    public float spawnInterval = 1.0f; 
    public float destroyOffset = 100.0f; 
    public float minOffsetYPosition = 5.0f;
    public float maxOffsetYPosition = 15.0f;
    public float spawnerRestriction = 5.0f;

    private float nextSpawnTime;
    private Camera mainCamera;
    [SerializeField] private Transform Frog;

    private List<Vector3> spawnedWaspsPositions = new List<Vector3>();

    private void Start()
    {
        mainCamera = Camera.main;
        SetNextSpawnTime();
    }

    private void Update()
    {
        float randomSpawnRange = Random.Range(minOffsetYPosition, maxOffsetYPosition);

        transform.position = new Vector3(Frog.position.x + 30, randomSpawnRange, transform.position.z);

        if (Time.time >= nextSpawnTime)
        {
            SpawnWasp();
            SetNextSpawnTime();
        }

        DestroyOffCameraWasps();
    }

    void SetNextSpawnTime()
    {
        nextSpawnTime = Time.time + spawnInterval;
    }

    void SpawnWasp()
    {
       int maxAttempts = 100;

        for (int i = 0; i < maxAttempts; i++)
        {
            Vector3 newSpawnPosition = GetRandomSpawnPosition();

            GameObject newWasp = Instantiate(WaspsPrefab, newSpawnPosition, Quaternion.identity);

            spawnedWaspsPositions.Add(newWasp.transform.position);
            break;
        }
    }

    Vector3 GetRandomSpawnPosition()
    {
        float randomXOffset = Random.Range(minOffsetYPosition, maxOffsetYPosition);
        return new Vector3(Frog.position.x + 30, randomXOffset, spawnPoint.position.z);
    }

    void DestroyOffCameraWasps()
    {
        GameObject[] Wasps = GameObject.FindGameObjectsWithTag("Wasp");

        foreach (var Wasp in Wasps)
        {
            if (Wasp.transform.position.x + destroyOffset < Frog.transform.position.x)
            {
                Destroy(Wasp);
            }
        }
    }
}
