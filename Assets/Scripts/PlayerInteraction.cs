using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private HashSet<Collider2D> activeTriggers = new HashSet<Collider2D>();

    // Called when the player enters a trigger collider
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other != null && other.isTrigger)
        {
            activeTriggers.Add(other);
        }
    }

    // Called while the player stays inside a trigger collider
    void Update()
    {
        foreach (var trigger in activeTriggers)
        {
            InteractionBase interaction = GetInteractionFromTrigger(trigger);
            if (Input.GetButtonDown(interaction.button))
            {
                interaction.OnInteraction(gameObject);
            }
        }
    }

    // Called when the player exits a trigger collider
    void OnTriggerExit2D(Collider2D other)
    {
        if (other != null && other.isTrigger)
        {
            activeTriggers.Remove(other);
        }
    }

    private InteractionBase GetInteractionFromTrigger(Collider2D trigger)
    {
        return trigger.gameObject.GetComponent<InteractionBase>();
    }
}
