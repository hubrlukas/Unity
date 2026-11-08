using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;

    void Start()
    {
        int enemiesToSpawn = PlayerPrefs.GetInt("EnemyCount", 1);

        if ( spawnPoints != null && spawnPoints.Length > 0 )
        {
            int countToSpawn = Mathf.Min(enemiesToSpawn, spawnPoints.Length);
            
            for ( int i = 0; i < countToSpawn; ++i )
            {
                Vector3 spawnPosition = spawnPoints[i].position;
                Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            }
        }
        else
        {
            Debug.LogWarning( "SpawnPoints not set!" );
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        }
    }
}
