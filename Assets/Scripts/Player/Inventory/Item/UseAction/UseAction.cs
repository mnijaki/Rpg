using System;
using N_RPG.N_Player.N_Inventory.N_Item.N_ItemComponent;
using UnityEngine;

namespace N_RPG.N_Player.N_Inventory.N_Item.N_UseAction
{
	/// <summary>
	///   Action that can be performed on inventory item usage.
	/// </summary>
	[Serializable]
	public struct UseAction
	{
		#region Public fields

		/// <summary>
		///   Event that will raise use action.
		/// </summary>
		public RaiseEvent RaiseEvent
		{
			get { return _raiseEvent; }
		}

		/// <summary>
		///   Item component on which use action will be called. 
		/// </summary>
		public ItemComponent TargetComponent
		{
			get { return _targetComponent; }
		}

		#endregion

		#region Serialized fields

		/// <summary>
		///   Event that will raise use action.
		/// </summary>
		[SerializeField]
		[Tooltip("Event that will raise use action")]
		private RaiseEvent _raiseEvent;

		/// <summary>
		///   Item component on which use action will be called. 
		/// </summary>
		[SerializeField]
		[Tooltip("Item component on which use action will be called")]
		private ItemComponent _targetComponent;

		#endregion
	}
}