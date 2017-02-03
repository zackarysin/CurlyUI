using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

#if UNITY_EDITOR

using UnityEditor;

#endif

[RequireComponent(typeof(RectTransform))]
[RequireComponent(typeof(Text))]
public class CUIText : CUIGraphic
{

    public override void ReportSet()
    {
        if(uiGraphic == null)
            uiGraphic = GetComponent<Text>();

        base.ReportSet();
    }

}
