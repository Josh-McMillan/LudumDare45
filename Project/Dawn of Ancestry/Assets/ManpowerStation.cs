using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManpowerStation : MonoBehaviour
{
    public static Action<bool> OnShowPeopleMenu;

    public static Action OnFirstHutBuilt;

    [SerializeField] private Construction construction;

    [SerializeField] private GameObject humanPrefab;

    public static ManpowerStation lastStationUsed;

    private static bool hasBuiltCampfire = false;

    private void OnEnable()
    {
        Construction.OnConstructionComplete += ShowMenu;
    }

    private void OnDisable()
    {
        Construction.OnConstructionComplete -= ShowMenu;
    }

    private void ShowMenu(GameObject construction)
    {
        if (construction == transform.parent.gameObject)
        {
            if (!hasBuiltCampfire)
            {
                hasBuiltCampfire = true;
                OnFirstHutBuilt();
            }

            OnShowPeopleMenu(true);
        }
    }

    public void SpawnMan()
    {
        Instantiate(humanPrefab, transform.position + Vector3.down, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (construction.IsBuilt)
        {
            lastStationUsed = this;

            OnShowPeopleMenu(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (construction.IsBuilt)
        {
            OnShowPeopleMenu(false);
        }
    }
}
