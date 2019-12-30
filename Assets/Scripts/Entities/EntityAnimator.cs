using UnityEngine;

/// <summary>
///   Entity animator.
/// </summary>
[RequireComponent(typeof(Entity))]
public class EntityAnimator : MonoBehaviour
{
	#region Protected and private fields

	/// <summary>
	///   Animator.
	/// </summary>
	private Animator _animator;

	/// <summary>
	///   Entity for which animation will be handled.
	/// </summary>
	private Entity _entity;
	
	/// <summary>
	///   Hash string for 'Die' animation flag.
	/// </summary>
	private static readonly int DIE_HASH = Animator.StringToHash("Die");

	#endregion
	
	#region Protected and private methods
	
	/// <summary>
	///   Awake.
	/// </summary>
	private void Awake()
	{
		_animator = GetComponentInChildren<Animator>();
		_entity = GetComponent<Entity>();
		
		_entity.Died += EntityOnDied;
	}

	#endregion
	
	#region Event handlers
	
	/// <summary>
	///   Event - fired after entity died.
	/// </summary>
	private void EntityOnDied()
	{
		_animator.SetBool(DIE_HASH, true);
	}
	
	#endregion
}
