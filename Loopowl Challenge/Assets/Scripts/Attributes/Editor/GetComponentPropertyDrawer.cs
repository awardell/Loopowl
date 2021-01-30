using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(GetComponentAttribute))]
public class GetComponentDrawer : PropertyDrawer
{
	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
	{
		GetComponentAttribute gc = attribute as GetComponentAttribute;
		if (property.objectReferenceValue == null)
		{
			var monoBehaviour = property.serializedObject.targetObject as MonoBehaviour;
			if (monoBehaviour != null)
			{
				var component = monoBehaviour.GetComponent(gc.type);
				if (component != null)
				{
					property.objectReferenceValue = component;
					property.serializedObject.ApplyModifiedPropertiesWithoutUndo();
				}
			}
		}

		if (gc.readOnly)
			GUI.enabled = false;
		EditorGUI.ObjectField(position, property, gc.type);
		if (gc.readOnly)
			GUI.enabled = true;
	}
}
