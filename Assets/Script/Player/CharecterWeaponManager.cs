using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharecterWeaponManager : MonoBehaviour
{
    [SerializeField] private KeyCode keyCode;
    [SerializeField] private float slowTimeScale;
    [SerializeField] private float startFixedTimeStep;

    bool open;

    private void Update()
    {
        if (Input.GetKeyDown(keyCode))
        {
            open = !open;
            if(open) setTimeScale(slowTimeScale,startFixedTimeStep);
            else setTimeScale(1,Time.fixedDeltaTime);
        }
    }

    private void setTimeScale(float timeScale,float startFixedTimeStep)
    {
        Time.timeScale = timeScale;
        Time.fixedDeltaTime = startFixedTimeStep;
    }
}
