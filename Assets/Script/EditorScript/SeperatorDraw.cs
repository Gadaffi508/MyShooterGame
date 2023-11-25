using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(SeperatorAttrib))]
public class SeperatorDraw : DecoratorDrawer
{
    public override void OnGUI(Rect position)
    {
        SeperatorAttrib seperatorAttrib = attribute as SeperatorAttrib;

        Rect seperatorRect = new Rect(position.xMin,position.yMin + seperatorAttrib.Spacing,position.width,seperatorAttrib.Height);
        
        EditorGUI.DrawRect(seperatorRect,Color.white);
    }

    public override float GetHeight()
    {
        SeperatorAttrib seperatorAttrib = attribute as SeperatorAttrib;;

        float totalSpacing = seperatorAttrib.Spacing + seperatorAttrib.Height + seperatorAttrib.Spacing;

        return totalSpacing;
    }
}
