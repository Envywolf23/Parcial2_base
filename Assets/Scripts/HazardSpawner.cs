using UnityEngine;

public static class SpawnerExtensions
{
    public static Vector3 GetPointInVolume(this Collider2D collider)
    {
        Vector3 result = Vector3.zero;
        result = new Vector3(Random.Range(collider.bounds.min.x, collider.bounds.max.x), collider.transform.position.y, 0F);

        return result;
    }
}

[RequireComponent(typeof(Collider2D))]
public class HazardSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject hazardTemplate;

    [SerializeField]
    private GameObject debrisTemplate;

    [SerializeField]
    private GameObject invaderTemplate;

    private Collider2D myCollider;

    [SerializeField]
    private float spawnFrequencyHazard = 1F;

    [SerializeField]
    private float spawnFrequencyDebris = 1F;

    [SerializeField]
    private float spawnFrequencyInvader = 1F;

    // Use this for initialization
    private void Start()
    {
        myCollider = GetComponent<Collider2D>();

        InvokeRepeating("SpawnHazard", 0.2F, spawnFrequencyHazard);
        InvokeRepeating("SpawnDebris", 1.3F, spawnFrequencyDebris);
        InvokeRepeating("SpawnInvader", 2.4F, spawnFrequencyInvader);
    }

    private void SpawnHazard()
    {
        if (hazardTemplate == null)
        {
            CancelInvoke();
        }
        else
        {
            Instantiate(hazardTemplate, myCollider.GetPointInVolume(), transform.rotation);
        }

    }

    private void SpawnDebris()
    {
        if (debrisTemplate == null)
        {
            CancelInvoke();
        }
        else
        {
            Instantiate(debrisTemplate, myCollider.GetPointInVolume(), transform.rotation);
        }

    }

    private void SpawnInvader()
    {
        if (invaderTemplate == null)
        {
            CancelInvoke();
        }
        else
        {
            Instantiate(invaderTemplate, myCollider.GetPointInVolume(), transform.rotation);
        }

    }
}