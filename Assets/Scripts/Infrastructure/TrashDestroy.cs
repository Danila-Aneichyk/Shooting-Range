using System;
using UnityEngine;

public class TrashDestroy : MonoBehaviour
{
    public static event Action OnAllRacksDestroyed;

    private void OnEnable()
    {
        OnAllRacksDestroyed += DestroyRacks;
    }

    private void OnDestroy()
    {
        OnAllRacksDestroyed -= DestroyRacks;
    }

    public void DestroyRacks()
    {
        if (GameObject.FindGameObjectWithTag("Target") == null)
        {
            foreach (GameObject rack in GameObject.FindGameObjectsWithTag("Rack"))
                Destroy(rack);
        }
    }
}