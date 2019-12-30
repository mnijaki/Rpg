using UnityEngine;

/// <summary>
///   Entity.
/// </summary>
public class Entity : MonoBehaviour, IDamageTaker
{
	#region Public fields

	/// <summary>
	///   Entity health.
	/// </summary>
	public int Health { get; private set; }

	#endregion
	
	#region Serialized fields

	/// <summary>
	///   Maximum health of entity.
	/// </summary>
	[SerializeField]
	[Range(1,1000)]
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
	}
	
	/// <summary>
	///   Handle non lethal damage on entity.
	/// </summary>
	private void HandleNonLethalDamage()
	{
		Debug.Log($"Entity [{gameObject.name}] got damaged");
	}

	#endregion
}