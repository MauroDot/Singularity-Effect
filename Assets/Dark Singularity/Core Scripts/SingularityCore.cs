using UnityEngine;
[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(SphereCollider))]
public class SingularityCore : MonoBehaviour
{
    public float teleportationRange = 100f; // Set this to the desired range

    void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<SingularityPullable>())
        {
            if (other.CompareTag("Player")) // Check if the object is the player
            {
                Vector3 randomDirection = Random.insideUnitSphere * teleportationRange;
                randomDirection += transform.position; // Ensure the random position is relative to the singularity's position

                other.transform.position = randomDirection; // Teleport the player
            }
            else
            {
                other.gameObject.SetActive(false); // Deactivate other objects
            }
        }
    }

    void Awake()
    {
        if (GetComponent<SphereCollider>())
        {
            GetComponent<SphereCollider>().isTrigger = true;
        }
    }
}
