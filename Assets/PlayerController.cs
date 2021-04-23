using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Mover mover;
    Fighter fighter;
    // Start is called before the first frame update
    void Start()
    {
        fighter = GetComponent<Fighter>();
        mover = GetComponent<Mover>();
    }

    // Update is called once per frame
    void Update()
    {
        if(ClickToFight()) return;
        if(ClickToMove()) return;
        print("Nothing going on");
    }

    private bool ClickToFight()
    {
        RaycastHit[] raycastHits = Physics.RaycastAll(GetRay());
        foreach (RaycastHit hit in raycastHits) {
            CombatTarget target = hit.transform.GetComponent<CombatTarget>();

            if (target == null) continue;

            if (Input.GetMouseButtonDown(0))
            {
                fighter.Attack(target);
            }
            return true;
        }
        return false;
        
    }

    bool ClickToMove()
    {
        RaycastHit hit;
        bool hasHit = Physics.Raycast(GetRay(), out hit);
        if (hasHit)
        {
            if (Input.GetMouseButton(0) && !GetComponent<Health>().IsDead())
            {
                fighter.Cancel();
                mover.MoveTo(hit.point);
            }
            return true;
        }
        return false;

    }

    private static Ray GetRay()
    {
        return Camera.main.ScreenPointToRay(Input.mousePosition);
    }
}
