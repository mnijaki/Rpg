using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Item : MonoBehaviour
{
	#region Protected and private fields
	
	/// <summary>
	///   Flag if inventory item was already picked up.
	/// </summary>
	private bool _wasPickedUp;
	
	#endregion

	#region Protected and private methods
	
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