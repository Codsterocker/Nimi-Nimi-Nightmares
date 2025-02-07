using UnityEngine;

public class NightmareSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;    // The GameObject to spawn
    public GameObject objectParent;     // The parent the spawn objects will be created under
    public GameObject arena;            // The arena that the objects will be spawn in

    public float waitTimeLow = 1f;      // The minimum wait time (seconds)
    public float waitTimeHigh = 5f;     // The maximum wait time (seconds)
    public float spawnForceLow = 1f;    // The minimum force of the nightmare spawning
    public float spawnForceHigh = 5f;   // The maximum force of the nightmare spawning

    private float radius;               // The radius of the circle
    private float elapsedTime = 0f;     // Time elapsed since the script started
    private float timeUntilStop;        // Seconds until timer ends

    private void Start()
    {
        // Set items to spawn for duration of round
        timeUntilStop = MatchData.instance.GetRoundDuration();

        // Calculate the radius based on the arena diameter
        radius = arena.transform.localScale.x / 2f;

        // Start the spawn loop
        StartCoroutine(SpawnObjects());
    }

    private System.Collections.IEnumerator SpawnObjects()
    {
        while (elapsedTime < timeUntilStop)
        {
            // Calculate a random angle (between 0 and 360 degrees) along the circle's edge
            float randomAngle = Random.Range(0f, 360f);

            // Convert the angle to radians and calculate the spawn position on the circle's edge
            Vector3 spawnPosition = new Vector3(Mathf.Cos(randomAngle * Mathf.Deg2Rad) * radius,
                                                transform.position.y,
                                                Mathf.Sin(randomAngle * Mathf.Deg2Rad) * radius);

            // Instantiate the object and set its parent under objectParent
            GameObject spawnedObject = Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
            spawnedObject.transform.SetParent(objectParent.transform);

            // Add a random force to the spawned object back into the arena
            Rigidbody rb = spawnedObject.GetComponent<Rigidbody>();
            float returnAngle = Random.Range(-70, 70);
            float spawnStrength = Random.Range(spawnForceLow, spawnForceHigh);

            Vector3 spawnDirection = (transform.position - spawnedObject.transform.position);
            Quaternion spawnRotation = Quaternion.AngleAxis(returnAngle, Vector3.up);
            Vector3 spawnForce = (spawnRotation * spawnDirection) * spawnStrength;

            spawnedObject.GetComponent<Rigidbody>().AddForce(spawnForce);

            // Wait for a random time between waitTimeLow and waitTimeHigh
            float waitTime = Random.Range(waitTimeLow, waitTimeHigh);
            yield return new WaitForSeconds(waitTime);

            // Increment elapsed time
            elapsedTime += waitTime;
        }

        // Once time is up, stop spawning and stop the coroutine
        Debug.Log("Spawning stopped after " + elapsedTime + " seconds.");
    }
}
