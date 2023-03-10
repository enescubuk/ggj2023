using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Attack))]
[RequireComponent(typeof(Health))]
 [DisallowMultipleComponent]
public class Player : MonoBehaviour
{
    public PlayerDetailsSO playerDetails;
    private Health health;
    private HealthEvents healthEvents;
    private GameEvents gameEvents;
    private GameObject leafsParent;
    private int leafToAdd;

    private void Awake()
    {
        health = GetComponent<Health>();
        healthEvents = GetComponent<HealthEvents>();
        //leafsParent = (GameObject)Instantiate(null, transform.position, transform.rotation, transform);
    }

    private void OnEnable()
    {
        healthEvents.OnHealthChanged += HandleOnHealthChangedEvent;
        //gameEvents.OnTurnStart += HandleOnDayChangedEvent;
    }

    private void OnDisable()
    {
        healthEvents.OnHealthChanged -= HandleOnHealthChangedEvent;
        //gameEvents.OnTurnStart -= HandleOnDayChangedEvent;
    }
    
    private void HandleOnHealthChangedEvent(float healthPercent, int healthAmount, int damage)
    {
        if (healthAmount <= 0)
        {
            PlayerDestroyed();
        }
    }

    private void HandleOnDayChangedEvent()
    {
        AddLeafToPlayer();
    }

    private void AddLeafToPlayer()
    {
        for (int i = 0; i < playerDetails.leafToAdd; i++)
        {
            float leafpositionX = Random.Range(leafsParent.transform.position.x - playerDetails.leafSpawnDistanceMax.x,
                leafsParent.transform.position.x + playerDetails.leafSpawnDistanceMax.x);
            float leafpositionY = Random.Range(leafsParent.transform.position.y - playerDetails.leafSpawnDistanceMax.y,
                leafsParent.transform.position.y + playerDetails.leafSpawnDistanceMax.y);
            
            Vector3 leafPosition = new Vector3(leafpositionX, leafpositionY, transform.position.z);
            
            var newLeaf = Instantiate(playerDetails.leafObject, leafPosition, transform.rotation, leafsParent.transform);
        }
    }

    private void PlayerDestroyed()
    {
        healthEvents.CallDestroyEvent(true, 0);
        Destroy(gameObject);
    }
}
