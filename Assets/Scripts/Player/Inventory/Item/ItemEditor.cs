using System.Collections.Generic;
using N_RPG.N_Player.N_Inventory.N_Item.N_ItemComponent;
using N_RPG.N_Player.N_Inventory.N_Item.N_UseAction;
using N_RPG.N_UI.N_Crosshair;
using UnityEditor;
using UnityEngine;

namespace N_RPG.N_Player.N_Inventory.N_Item
{
	/// <summary>
	///   Custom editor for inventory item.
	/// </summary>
	[CustomEditor(typeof(Item))]
	public class ItemEditor : Editor
	{
		#region Protected and private fields
		
		/// <summary>
		///   Target item.
		/// </summary>
		private Item _item;
		
		#endregion
		
		#region Protected and private methods
		
		/// <summary>
		///   OnInspectorGUI.
		/// </summary>
		public override void OnInspectorGUI()
		{
			// 'target' is a part of 'Editor' class.
			_item = target as Item;
			if(_item == null)
			{
				return;
			}

			DrawIcon();

			DrawCrosshairIcon();

			DrawUseActionsCollection();
		}

		/// <summary>
		///   Draw item icon.
		/// </summary>
		private void DrawIcon()
		{
			// Begin horizontal grouping of items.
			EditorGUILayout.BeginHorizontal();
			// Label with given width.
			EditorGUILayout.LabelField("Icon", GUILayout.Width(160));
			if(_item.Icon != null)
			{
				// Draw icon texture.
				GUILayout.Box(_item.Icon.texture, GUILayout.Width((64)), GUILayout.Height(64));
			}
			else
			{
				// Draw warning message.
				EditorGUILayout.HelpBox("No Icon selected", MessageType.Warning);
			}
			// 'serializedObject' is a part of 'Editor' class.
			// It is a wrapper around 'target' object, that lets you access private properties/fields.
			// 'using' helps auto-cleaning of objects. 
			using(SerializedProperty prop = serializedObject.FindProperty("_icon"))
			{
				// 'ObjectField()' is used for references to an object (eg. MonoBehaviour, Component, ScriptableObject, Prefab).
				// Bool is a flag informing if scene objects are allowed to put at this control (false, means that only objects from project can be used there).
				// 'iconSprite' variable holds value from 'ObjectField()' control.
				Sprite iconSprite = EditorGUILayout.ObjectField(_item.Icon, typeof(Sprite), false) as Sprite;
				// Set value to property.
				prop.objectReferenceValue = iconSprite;
				// Apply changes to 'target' object.
				serializedObject.ApplyModifiedProperties();
			}
			// End horizontal grouping of items.
			EditorGUILayout.EndHorizontal();
		}

		/// <summary>
		///   If item is a weapon, then draw weapon crosshair icon.
		/// </summary>
		private void DrawCrosshairIcon()
		{
			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.LabelField("Crosshair type", GUILayout.Width(160));
			if((_item.CrosshairType != null) && (_item.CrosshairType.Sprite != null))
			{
				GUILayout.Box(_item.CrosshairType.Sprite.texture, GUILayout.Width((64)), GUILayout.Height(64));
			}
			else
			{
				EditorGUILayout.HelpBox("No crosshair type selected", MessageType.Warning);
			}
			using(SerializedProperty prop = serializedObject.FindProperty("_crosshairType"))
			{
				CrosshairType crosshairSprite = EditorGUILayout.ObjectField(_item.CrosshairType, typeof(CrosshairType), false) as CrosshairType;
				prop.objectReferenceValue = crosshairSprite;
				serializedObject.ApplyModifiedProperties();
			}
			EditorGUILayout.EndHorizontal();
		}

		/// <summary>
		///   Draw collection of use actions.
		/// </summary>
		private void DrawUseActionsCollection()
		{
			using(SerializedProperty useActionsProp = serializedObject.FindProperty("_useActions"))
			{
				DrawArrayOfUseActions(useActionsProp);

				DrawAddAllAvailableUseActionsBtn(useActionsProp);
			}
		}

		/// <summary>
		///    Draw array of use actions.
		/// </summary>
		/// <param name="useActionsProp">Property holding collection of use actions</param>
		private void DrawArrayOfUseActions(SerializedProperty useActionsProp)
		{
			for(int i = 0; i < useActionsProp.arraySize; i++)
			{
				EditorGUILayout.BeginHorizontal();
				if(GUILayout.Button("x", GUILayout.Width(20)))
				{
					useActionsProp.DeleteArrayElementAtIndex(i);
					serializedObject.ApplyModifiedProperties();
					// Break, because if someone remove element from array, this array size is changed, so we need
					// to wait for the next frame to refresh all this code ('OnInspectorGUI()' is called once per frame). 
					break;
				}

				SerializedProperty useAction = useActionsProp.GetArrayElementAtIndex(i);
				if(useAction != null)
				{
					// To 'FindPropertyRelative()' method, we can only pass serialized fields or public fields (they are also serialized). 
					// You cannot pass there a property.
					SerializedProperty raiseEventProp = useAction.FindPropertyRelative("_raiseEvent");
					SerializedProperty targetComponentProp = useAction.FindPropertyRelative("_targetComponent");
					// Get old raise event (value that is currently in 'Item._raiseEvent' field).
					RaiseEvent oldRaiseEvent = (RaiseEvent)raiseEventProp.enumValueIndex;
					// Draw enum drop dawn, with selected element ('enumValueIndex' is used for setting selected element).
					// 'EnumPopup' returns currently selected item (so if user changes selection in editor, we can get that way newly selected element).
					RaiseEvent newRaiseEvent = (RaiseEvent)EditorGUILayout.EnumPopup(oldRaiseEvent, GUILayout.Width(140));
					// Set newly selected element in property. 
					raiseEventProp.enumValueIndex = (int)newRaiseEvent;
					// Create simple control for changing '_targetComponent' property.
					EditorGUILayout.PropertyField(targetComponentProp, GUIContent.none, false);
					// Apply changes.
					serializedObject.ApplyModifiedProperties();
				}
				EditorGUILayout.EndHorizontal();
			}
		}

		/// <summary>
		///   Draw button that handle adding of all available use actions to item.
		/// </summary>
		/// <param name="useActionsProp">Property holding collection of use actions</param>
		private void DrawAddAllAvailableUseActionsBtn(SerializedProperty useActionsProp)
		{
			if(!GUILayout.Button("Add all available use actions"))
			{
				return;
			}

			List<ItemComponent> assignedItemComponents = GetAssignedItemComponents(useActionsProp);
			foreach(ItemComponent itemComponent in _item.GetComponentsInChildren<ItemComponent>())
			{
				if(assignedItemComponents.Contains(itemComponent))
				{
					continue;
				}

				// Create new array element.
				useActionsProp.InsertArrayElementAtIndex(useActionsProp.arraySize);
				// Get that newly created array element.
				SerializedProperty useAction = useActionsProp.GetArrayElementAtIndex(useActionsProp.arraySize - 1);
				// Get property '_targetComponent' from that element (this property will have no value by default).
				SerializedProperty targetComponentProp = useAction.FindPropertyRelative("_targetComponent");
				// Set value to '_targetComponent' property.
				targetComponentProp.objectReferenceValue = itemComponent;
				// Apply changes.
				serializedObject.ApplyModifiedProperties();
				// Enum property '_raiseEvent' have value by default (0), and we are not interested
				// in setting it to some special index, so we leave it as it is (designers can change it later).
			}
		}

		/// <summary>
		///   Get list of all 'ItemComponent's that are assigned in array of 'UseAction's. 
		/// </summary>
		/// <param name="useActionsProp">'UseAction' property</param>
		/// <returns>List of all 'ItemComponent's that are assigned in array of 'UseAction's.</returns>
		private static List<ItemComponent> GetAssignedItemComponents(SerializedProperty useActionsProp)
		{
			List<ItemComponent> assignedItemComponents = new List<ItemComponent>();
			for(int i = 0; i < useActionsProp.arraySize; i++)
			{
				SerializedProperty useActionProp = useActionsProp.GetArrayElementAtIndex(i);
				if(useActionProp != null)
				{
					SerializedProperty targetComponentProp = useActionProp.FindPropertyRelative("_targetComponent");
					ItemComponent assignedItemComponent = targetComponentProp.objectReferenceValue as ItemComponent;
					if(!assignedItemComponents.Contains(assignedItemComponent))
					{
						assignedItemComponents.Add(assignedItemComponent);
					}
				}
			}

			return assignedItemComponents;
		}
		
		#endregion
	}
}