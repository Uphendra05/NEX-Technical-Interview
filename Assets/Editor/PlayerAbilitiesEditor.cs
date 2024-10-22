

using UnityEditor;



public class PlayerAbilitiesEditor : Editor
{
    SerializedProperty objectToScale;
    SerializedProperty startScale;
    SerializedProperty endScale;
    SerializedProperty startPosition;
    SerializedProperty endPosition;
    SerializedProperty lerpTime;    
    SerializedProperty isOn;
    SerializedProperty isLerping;
      SerializedProperty cooldown;

    bool ShieldAbility;

    private void OnEnable()
    {
        objectToScale = serializedObject.FindProperty("objectToScale");
        startScale = serializedObject.FindProperty("startScale");
        endScale = serializedObject.FindProperty("endScale");
        startPosition = serializedObject.FindProperty("startPosition");
        endPosition = serializedObject.FindProperty("endPosition");
        lerpTime = serializedObject.FindProperty("lerpTime");        
        isOn = serializedObject.FindProperty("isOn");
        isLerping = serializedObject.FindProperty("isLerping");
        cooldown = serializedObject.FindProperty("cooldown");


    }


    public override void OnInspectorGUI()
    {
        serializedObject.Update();


        ShieldAbility = EditorGUILayout.BeginFoldoutHeaderGroup(ShieldAbility, "Shield Ability");
        if(ShieldAbility)
        {
            EditorGUILayout.PropertyField(objectToScale);
            EditorGUILayout.PropertyField(startScale);
            EditorGUILayout.PropertyField(endScale);
            EditorGUILayout.PropertyField(startPosition);
            EditorGUILayout.PropertyField(endPosition);
            EditorGUILayout.PropertyField(lerpTime);           
            EditorGUILayout.PropertyField(isOn);
            EditorGUILayout.PropertyField(isLerping);
            EditorGUILayout.PropertyField(cooldown);
        }
        EditorGUILayout.EndFoldoutHeaderGroup();

        serializedObject.ApplyModifiedProperties();
    }
}
