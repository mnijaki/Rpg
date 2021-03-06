﻿using System.Collections.Generic;
using N_RPG.N_Player.N_Inventory.N_Item.N_UseAction;
using N_RPG.N_UI.N_Crosshair;
using UnityEngine;

namespace N_RPG.N_Player.N_Inventory.N_Item
{
	/// <summary>
	///   Inventory item.
	/// </summary>
	[RequireComponent(typeof(Collider))]
	public class Item : MonoBehaviour
	{
		#region Public fields

		/// <summary>
		///   Type of crosshair associated with this item. 
		/// </summary>
		public CrosshairType CrosshairType
		{
			get { return _crosshairType; }
		}

		/// <summary>
		///   Icon representing item.
		/// </summary>
		public Sprite Icon
		{
			get { return _icon; }
		}

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
		///   Type of crosshair associated with this item. 
		/// </summary>
		[SerializeField]
		[Tooltip("Type of crosshair associated with this item.")]
		private CrosshairType _crosshairType;

		/// <summary>
		///   Icon representing item.
		/// </summary>
		[SerializeField]
		[Tooltip("Icon representing item")]
		private Sprite _icon;

		/// <summary>
		///   Collection of actions that can be performed when item is used.
		///   Automatically initialised, because it helps during tests.
		/// </summary>
		[SerializeField]
		[Tooltip("Collection of actions that can be performed when item is used")]
		private UseAction[] _useActions = new UseAction[0];

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
			Collider col = GetComponent<Collider>();
			// Check is added because Unity had problem with going into loop with this validation and constantly changes trigger to 'True'.
			if(col.isTrigger == false)
			{
				// Force collider on item to be 'Trigger' collider.
				col.isTrigger = true;
			}
		}

		#endregion
	}
}