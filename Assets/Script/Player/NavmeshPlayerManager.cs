using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavmeshPlayerManager : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;

    void Start()
    {
        // NavMeshAgent bileþenini al
        navMeshAgent = GetComponent<NavMeshAgent>();

        if (navMeshAgent == null)
        {
            Debug.LogError("NavMeshAgent component not found on " + gameObject.name);
        }
    }

    void Update()
    {
        // Fare týklamalarýný kontrol et
        if (Input.GetMouseButtonDown(0))
        {
            // Fare pozisyonunu al
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Fare týklanan konumu kontrol et
            if (Physics.Raycast(ray, out hit))
            {
                // Týklanan konuma hareket et
                MoveToDestination(hit.point);
            }
        }
    }

    void MoveToDestination(Vector3 destination)
    {
        // NavMeshAgent'i hedefe yönlendir
        navMeshAgent.SetDestination(destination);
    }
}


