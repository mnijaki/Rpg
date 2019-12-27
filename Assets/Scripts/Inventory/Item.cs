using System.Collections.Generic;
using UnityEngine;

/// <summary>
///   Inventory item.
/// </summary>
[RequireComponent(typeof(Collider))]
public class Item : MonoBehaviour
{
	#region Public fields
	
	/// <summary>
	///   Collection of actions that can be performed when item is used.
	/// </summary>
	public IEnumerable<UseAction> UseActions
	{
		get { return _useActions; }
	}
	
	#endregion
	
	#region Serialized fields
	
	/// <summary>
	///   Collection of actions that can be performed when item is used.
	/// </summary>
	[SerializeField]
	[Tooltip("Collection of actions that can be performed when item is used")]
	private UseAction[] _useActions;
	
	#endregion
	
	#region Protected and private fields
	
	/// <summary>
	///   Flag if inventory item was already picked up.
	/// </summary>
	private bool _wasPickedUp;

	#endregion

	#region Protected and private methods
	
	/// <summary>
	///   On trigger enter.
	/// </summary>
	/// <param name="other">Collider of object that entered this object trigger zone</param>
	private void OnTriggerEnter(Collider other)
	{
		if(_wasPickedUp)
		{
			return;
		}

		Inventory inventory = other.GetComponent<Inventory>();
		if(inventory == null)
		{
			return;
		}
		
		inventory.Pickup(this);
		_wasPickedUp = true;
	}

	private void OnValidate()
	{
		// Force collider on item to be 'Trigger' collider.
		GetComponent<Collider>().isTrigger = true;
	}

	#endregion
}