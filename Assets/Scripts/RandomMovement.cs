using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float changeInterval = 2f;
    public Vector3 movementBounds = new Vector3(10f, 10f, 10f);

    private Vector3 targetPosition;

    void Start()
    {
        StartCoroutine(MoveRandomly());
    }

    void Update()
    {
        // Move towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }

    IEnumerator MoveRandomly()
    {
        while (true)
        {
            // Generate a random position within the specified bounds
            float x = Random.Range(-movementBounds.x, movementBounds.x);
            float y = Random.Range(-movementBounds.y, movementBounds.y);
            float z = Random.Range(-movementBounds.z, movementBounds.z);
            Vector3 randomPosition = new Vector3(x, y, z);

            // Set the target position to the random position
            targetPosition = randomPosition;

            // Wait for the specified interval before changing the target position again
            yield return new WaitForSeconds(changeInterval);
        }
    }
}
