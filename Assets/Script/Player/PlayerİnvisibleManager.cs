using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerİnvisibleManager : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer Body_Materyal;
    [SerializeField] private SkinnedMeshRenderer Joint_Materyal;
    [SerializeField] private GameObject İnvisibleCam;

    bool İnvisibleTransition = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            İnvisibleTransition = !İnvisibleTransition;
            İnvisibleCam.SetActive(İnvisibleTransition);
            İnivisible(!İnvisibleTransition);
        }

        if (İnvisibleTransition) İnvisibleCam?.transform.Rotate(0,0,60 * Time.deltaTime);
    }

    private void İnivisible(bool _invisibleTransition)
    {
        Shader shader = Shader.Find("Universal Render Pipeline/Lit");

        if (shader != null && Joint_Materyal != null && Body_Materyal != null && _invisibleTransition)
        {
            Joint_Materyal.material.shader = shader;
            Body_Materyal.material.shader = shader;

            Joint_Materyal.material.SetFloat("_Surface",1);
            Joint_Materyal.material.SetFloat("_AlphaClip",1);

            Body_Materyal.material.SetFloat("_Surface", 1);
            Body_Materyal.material.SetFloat("_AlphaClip", 1);
        }

        if (shader != null && Joint_Materyal != null && Body_Materyal != null && !_invisibleTransition)
        {
            Joint_Materyal.material.shader = shader;
            Body_Materyal.material.shader = shader;

            Joint_Materyal.material.SetFloat("_Surface", 0);

            Body_Materyal.material.SetFloat("_Surface", 0);
        }
    }
}
