using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.AttributeUsage(System.AttributeTargets.Field,AllowMultiple = true)]
public class SeperatorAttrib : PropertyAttribute
{
    public readonly float Height;
    public readonly float Spacing;

    public SeperatorAttrib(float height = 1, float spacing = 10)
    {
        Height = height;
        Spacing = spacing;
    }
}
