using UnityEngine;
using UnityEditor;
using System.Linq;

[CustomEditor(typeof(FSMExample))]
public class StateMachineEditor : Editor
{
    public bool showFoldout;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        FSMExample fsm = (FSMExample)target;

        EditorGUILayout.Space(30f);
        EditorGUILayout.LabelField("State Machine");
        if (fsm.StateMachine == null) return;

        if (fsm.StateMachine.CurrentState != null)
        {
            EditorGUILayout.LabelField("Current State: ", fsm.StateMachine.CurrentState.ToString());
        }

        showFoldout = EditorGUILayout.Foldout(showFoldout, "Available States");
        if (showFoldout)
        {
            if (fsm.StateMachine.DictonaryState != null)
            {
                var keys = fsm.StateMachine.DictonaryState.Keys.ToArray();
                var values = fsm.StateMachine.DictonaryState.Values.ToArray();

                for (int i = 0; i < keys.Length; i++)
                {
                    EditorGUILayout.LabelField(string.Format("{0} :: {1}", keys[i], values[i]));
                }
            }
        }
    }
}