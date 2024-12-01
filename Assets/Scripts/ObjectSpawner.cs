using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public ObjectPool poolManager; // Referencia al PoolManager
    public float minSpawnRate = 1f; // Tiempo mínimo entre spawns
    public float maxSpawnRate = 3f; // Tiempo máximo entre spawns
    private float spawnRate; // Intervalo entre spawns
    public float minSpawnRangeY; // Minimo rango de posición vertical
    public float maxSpawnRangeY; // Máximo rango de posición vertical
    private float spawnX; // Punto de aparición (eje X)
    private float despawnX = -30f; // Punto donde los objetos se reciclan

    private float timer;

    void Start()
    {
        spawnRate = Random.Range(minSpawnRate, maxSpawnRate);
        spawnX = transform.position.x;
    }

    void Update()
    {
        // Temporizador para gestionar el spawn
        timer += Time.deltaTime;
        if (timer >= spawnRate)
        {
            timer = 0;
            SpawnObject();
            spawnRate = Random.Range(minSpawnRate, maxSpawnRate);
        }

        // Recicla objetos que salieron de la pantalla
        foreach (Transform child in poolManager.transform)
        {
            if (child.gameObject.activeInHierarchy && child.position.x <= despawnX)
            {
                poolManager.ReturnObject(child.gameObject);
            }
        }
    }

    void SpawnObject()
    {
        // Obtén un objeto de la piscina
        GameObject obj = poolManager.GetObject();
        if (obj != null)
        {
            // Asigna una posición aleatoria al objeto
            obj.transform.position = new Vector3(spawnX, Random.Range(minSpawnRangeY, maxSpawnRangeY), 0);
        }
    }
}
