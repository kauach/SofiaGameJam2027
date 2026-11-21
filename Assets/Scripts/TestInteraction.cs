using System.Diagnostics;
using UnityEngine;

public class TestInteraction : InteractionBase
{
    public override void OnInteraction(GameObject player)
    {
        UnityEngine.Debug.Log($"Interaction kurwa {player.name}");
        PlayerLogic pl = player.GetComponent<PlayerLogic>();
        pl.TestInteraction("DUPA");
    }
}
