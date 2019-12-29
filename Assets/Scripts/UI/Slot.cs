using UnityEngine;
using UnityEngine.UI;

/// <summary>
///   Hotbar slot.
/// </summary>
public class Slot : MonoBehaviour
{
	#region Public fields

	/// <summary>
	///   Flag if slot is empty.
	/// </summary>
	public bool IsEmpty
	{
		get { return _item == null; }
	}

	#endregion
	
	#region Serialized fields
	
	/// <summary>
	///   Slot icon.
	/// </summary>
	[SerializeField]
	[Tooltip("Slot icon")]
	private Image _icon;
	
	#endregion
	
	#region Protected and private fields
	
	/// <summary>
	///   Item in the slot.
	/// </summary>
	private Item _item;

	#endregion

	#region Public methods
	
	/// <summary>
	///   Set item in the slot.
	/// </summary>
	/// <param name="item">Item to set in the slot</param>
	public void SetItem(Item item)
	{
		_item = item;
		_icon.sprite = item.Icon;
	}
	
	#endregion
}