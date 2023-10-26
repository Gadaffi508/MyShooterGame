using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerİnvisibleManager : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer Body_materyal;
    [SerializeField] private SkinnedMeshRenderer Joint_materyal;
    [SerializeField] private GameObject İnvisibleCam;

    bool İnvisibleTransition = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            İnvisibleTransition =! İnvisibleTransition;
            İnvisibleCam.SetActive(İnvisibleTransition);
            İnvisible(!İnvisibleTransition);
        }

        if (İnvisibleTransition && İnvisibleCam != null) İnvisibleCam.transform.Rotate(new Vector3(0, 0, 60 * Time.deltaTime));
    }

    private void İnvisible(bool _İnvisibleTransition)
    {
        Shader shader = Shader.Find("Universal Render Pipeline/Lit");

        // Shader ve materyal doğruysa devam ediyoruz
        if (shader != null && Joint_materyal != null && Body_materyal != null && _İnvisibleTransition)
        {
            // Shader'ı materyale atıyoruz
            Joint_materyal.material.shader = shader;
            Body_materyal.material.shader = shader;

            // Materyali tamamen transparan yapmak için gerekli ayarlamaları yapıyoruz
            Joint_materyal.material.SetFloat("_Surface", 1); // Transparent surface type
            Joint_materyal.material.SetFloat("_AlphaClip", 1); // Enable alpha clip (full transparency)

            Body_materyal.material.SetFloat("_Surface", 1); // Transparent surface type
            Body_materyal.material.SetFloat("_AlphaClip", 1);
        }

        if (shader != null && Joint_materyal != null && Body_materyal != null && !_İnvisibleTransition)
        {
            // Shader'ı materyale atıyoruz
            Joint_materyal.material.shader = shader;
            Body_materyal.material.shader = shader;

            // Materyali tamamen transparan yapmak için gerekli ayarlamaları yapıyoruz
            Joint_materyal.material.SetFloat("_Surface", 0); // Transparent surface type

            Body_materyal.material.SetFloat("_Surface", 0); // Transparent surface type
        }
    }
}
