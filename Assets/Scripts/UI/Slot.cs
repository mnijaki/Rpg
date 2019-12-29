using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
///   Hotbar slot.
/// </summary>
public class Slot : MonoBehaviour
{
	#region Public fields

	/// <summary>
	///   Item in the slot.
	/// </summary>
	public Item Item { get; private set; }
	
	/// <summary>
	///   Flag if slot is empty.
	/// </summary>
	public bool IsEmpty
	{
		get { return Item == null; }
	}

	#endregion
	
	#region Serialized fields
	
	/// <summary>
	///   Slot icon.
	/// </summary>
	[SerializeField]
	[Tooltip("Slot icon")]
	private Image _icon;

	/// <summary>
	///   Text displayed in the slot.
	/// </summary>
	[SerializeField]
	[Tooltip("Text displayed in the slot.")]
	private TMP_Text _text;
	
	#endregion

	#region Public methods
	
	/// <summary>
	///   Set item in the slot.
	/// </summary>
	/// <param name="item">Item to set in the slot</param>
	public void SetItem(Item item)
	{
		Item = item;
		_icon.sprite = item.Icon;
	}
	
	#endregion
	
	#region Protected and private methods

	/// <summary>
	///   On validate.
	/// </summary>
	private void OnValidate()
	{
		_text = GetComponentInChildren<TMP_Text>();
		
		int keyNumber = transform.GetSiblingIndex() + 1;
		_text.SetText(keyNumber.ToString());

		gameObject.name = "Slot " + keyNumber;
	}

	#endregion
}