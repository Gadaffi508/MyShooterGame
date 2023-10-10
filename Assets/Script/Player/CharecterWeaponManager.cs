using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharecterWeaponManager : MonoBehaviour
{
    [SerializeField] private KeyCode keyCode;
    [SerializeField] private float slowTimeScale;
    float startFixedTimeStep;

    bool open;

    private void Start()
    {
        startFixedTimeStep = Time.fixedDeltaTime;
    }

    private void Update()
    {
        if (Input.GetKeyDown(keyCode))
        {
            open = !open;
            if(open) setTimeScale(slowTimeScale);
            else setTimeScale(1);
        }
    }

    private void setTimeScale(float timeScale)
    {
        Time.timeScale = timeScale;
        Time.fixedDeltaTime =timeScale * startFixedTimeStep;
    }
}
