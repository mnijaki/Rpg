using UnityEngine;

namespace N_RPG.N_Player.N_Inventory.N_Item.N_ItemComponent
{
	/// <summary>
	///   Logger for inventory item.
	/// </summary>
	public class ItemLogger : ItemComponent
	{
		#region Public methods

		/// <summary>
		///   Use item.
		/// </summary>
		public override void Use()
		{
			Debug.Log("Item was used");
		}

		#endregion
	}
}