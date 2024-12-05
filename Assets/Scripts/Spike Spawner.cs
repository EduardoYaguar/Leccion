using UnityEngine;

public class SpikeSpawner : MonoBehaviour
{
    public GameObject spikePrefab; 
    public KeyCode spawnKey = KeyCode.Space; 

    void Update()
    {
        if (Input.GetKeyDown(spawnKey))
        {
            SpawnSpike();
        }
    }

    private void SpawnSpike()
    {
        Instantiate(spikePrefab, transform.position, Quaternion.identity);
    }
}

