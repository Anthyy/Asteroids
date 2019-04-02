using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    public GameObject[] asteroidPrefabs; // Array of prefabs to spawn (since we made the asteroids prefabs)
    public float maxVelocity = 3f; // Max velocity an asteroid can move
    public float spawnRate = 1f; // Rate of spawn
    public float spawnPadding = 2f; // Padding to spawn

    public Color debugColor = Color.cyan;

    // Making the spawn radius visible in the scene for debugging purposes
    private void OnDrawGizmos()
    {
        Gizmos.color = debugColor;
        Gizmos.DrawWireSphere(transform.position, spawnPadding);
    }

    // Use this for initialization
    void Start()
    {
        // Invoke a function repeatedly with given rate
        InvokeRepeating("SpawnLoop", 0, spawnRate);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Spawns an asteroid at a position specified
    public void Spawn(GameObject prefab, Vector3 position) // So we need an object to spawn and a position to spawn it in
    {
        // Randomise a rotation for the asteroid
        Quaternion randomRot = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));

        // Spawn random asteroid at random position and 
        GameObject asteroid = Instantiate(prefab, position, randomRot, transform);

        // Get Rigidbody2D from asteroid
        Rigidbody2D rBody = asteroid.GetComponent<Rigidbody2D>();

        // Apply random force to rigidbody
        Vector2 randomForce = Random.insideUnitCircle * maxVelocity;
        rBody.AddForce(randomForce, ForceMode2D.Impulse);
    }

    // Spawns a random asteroid in the array at a random position
    void SpawnLoop()
    {
        // Generate random position inside sphere with spawn padding (radius)
        Vector3 randomPos = Random.insideUnitSphere * spawnPadding;

        // Generate random index into asteroid prefabs array
        int randomIndex = Random.Range(0, asteroidPrefabs.Length);

        // Get random asteroid prefab from array using index
        GameObject randomAsteroid = asteroidPrefabs[randomIndex];

        // Spawn using random pos
        Spawn(randomAsteroid, randomPos);
    }
}
