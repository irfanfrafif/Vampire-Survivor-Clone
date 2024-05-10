using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOrbAttack : MonoBehaviour
{
    [SerializeField] GameObject orbPrefab;
    [SerializeField] List<GameObject> orbs;
    [SerializeField] float orbRadius;

    [SerializeField] float orbSpeed;

    void Update()
    {
        RotateOrbs();
    }

    void RotateOrbs()
    {
        transform.Rotate(orbSpeed * Time.deltaTime * Vector3.forward);
    }

    void CalculateSpacing()
    {
        if (orbs.Count <= 0) return;
        float angleSpacing = 360 / orbs.Count;
        for (int i = 0; i < orbs.Count; i++)
        {
            Quaternion angle = Quaternion.AngleAxis(angleSpacing * i, Vector3.forward);
            Vector2 newOrbPos = angle *  new Vector3(0, orbRadius);
            orbs[i].transform.SetLocalPositionAndRotation(newOrbPos, angle);
        }
    }

    [ContextMenu(nameof(AddOrb))]
    public void AddOrb()
    {
        orbs.Add(Instantiate(orbPrefab, transform.position + new Vector3(0, orbRadius), Quaternion.identity, transform));
        CalculateSpacing();
    }

    [ContextMenu(nameof(RemoveOrb))]
    public void RemoveOrb()
    {
        if (orbs.Count <= 0) return;

        var orb = orbs[0];
        orbs.RemoveAt(0);
        Destroy(orb);
        CalculateSpacing();
    }
}
