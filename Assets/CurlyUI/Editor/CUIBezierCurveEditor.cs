using UnityEngine;
using System.Collections;

#if UNITY_EDITOR

using UnityEditor;

[CustomEditor(typeof(CUIBezierCurve))]
[CanEditMultipleObjects]
public class CUIBezierCurveEditor : Editor {

    #region Nature


    #endregion
    #region Flash-Phases


    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();
        DrawDefaultInspector();

        //CUIBezierCurve script = (CUIBezierCurve)this.target;
        
    }
   

    protected void OnSceneGUI()
    {
        CUIBezierCurve script = (CUIBezierCurve)this.target;

        if (script.ControlPoints != null)
        {

            Vector3[] controlPoints = script.ControlPoints;
            
            Transform handleTransform = script.transform;
            Quaternion handleRotation = script.transform.rotation;

            for (int p = 0; p < CUIBezierCurve.CubicBezierCurvePtNum; p++)
            {
                EditorGUI.BeginChangeCheck();
                Vector3 newPt = Handles.DoPositionHandle(handleTransform.TransformPoint(controlPoints[p]), handleRotation);
                if (EditorGUI.EndChangeCheck())
                {
                    
                    Undo.RecordObject(script, "Move Point");
                    EditorUtility.SetDirty(script);
                    controlPoints[p] = handleTransform.InverseTransformPoint(newPt);
                    script.Refresh();
                }
            }

            Handles.color = Color.gray;// new Color(0.8f,0.8f,0.8f)
            Handles.DrawLine(handleTransform.TransformPoint(controlPoints[0]), handleTransform.TransformPoint(controlPoints[1]));
            Handles.DrawLine(handleTransform.TransformPoint(controlPoints[1]), handleTransform.TransformPoint(controlPoints[2]));
            Handles.DrawLine(handleTransform.TransformPoint(controlPoints[2]), handleTransform.TransformPoint(controlPoints[3]));

            int sampleSize = 10;

            Handles.color = Color.white;
            for (int s = 0; s < sampleSize; s++)
            {
                Handles.DrawLine(handleTransform.TransformPoint(script.GetPoint((float)s/sampleSize)), handleTransform.TransformPoint(script.GetPoint((float)(s+1) / sampleSize)));
            }

            script.EDITOR_ControlPoints = controlPoints;

        }

    }
    

    #endregion

}

#endif