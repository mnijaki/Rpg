using System;
using UnityEngine;

namespace N_RPG.N_Entity
{
	/// <summary>
	///   Entity.
	/// </summary>
	public class Entity : MonoBehaviour, IDamageTaker
	{
		#region Events

		/// <summary>
		///   Event - fired after entity died.
		/// </summary>
		public event Action Died;

		#endregion

		#region Public fields

		/// <summary>
		///   Entity health.
		/// </summary>
		public int Health { get; private set; }
		
		/// <summary>
		///   Flag if entity is dead.
		/// </summary>
		public bool IsDead
		{
			get { return Health <= 0; }
		}

		#endregion

		#region Serialized fields

		/// <summary>
		///   Maximum health of entity.
		/// </summary>
		[SerializeField]
		[Range(1, 1000)]
		[Tooltip("Maximum health of entity")]
		private int _maxHealth = 10;

		#endregion

		#region Public methods

		/// <summary>
		///   Take damage.
		/// </summary>
		/// <param name="val">Value of damage</param>
		public void TakeDamage(int val)
		{
			Health -= val;
			if(Health <= 0)
			{
				Die();
			}
			else
			{
				HandleNonLethalDamage();
			}
		}

		#endregion

		#region Protected and private methods

		/// <summary>
		///   On enable.
		/// </summary>
		private void OnEnable()
		{
			Health = _maxHealth;
		}

		/// <summary>
		///   Handling for entity when it dies.
		/// </summary>
		private void Die()
		{
			Debug.Log($"Entity [{gameObject.name}] died");
			Died?.Invoke();
		}

		/// <summary>
		///   Handle non lethal damage on entity.
		/// </summary>
		private void HandleNonLethalDamage()
		{
			Debug.Log($"Entity [{gameObject.name}] got damaged");
		}

		/// <summary>
		///   MN:TO_DO: remove after testing is done.
		///   Kill entity (only for debug purposes).
		/// </summary>
		[ContextMenu("TakeLethalDamage")]
		private void TakeLethalDamage()
		{
			TakeDamage(Health);
		}

		#endregion
	}
}