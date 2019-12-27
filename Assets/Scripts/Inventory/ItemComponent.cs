using System;
using UnityEngine;

public abstract class ItemComponent : MonoBehaviour
{
	#region Protected and private fields

	/// <summary>
	///   Flag if item can be used.
	/// </summary>
	private bool CanUse
	{
		get { return Time.time > _nextUseTime; }
	}
	
	/// <summary>
	///   Time, when item can be used again.
	/// </summary>
	private float _nextUseTime;

	#endregion

	#region Protected and private methods

	/// <summary>
	///   Use item.
	/// </summary>
	protected abstract void Use();

	/// <summary>
	///   Update (called once per frame).
	/// </summary>
	private void Update()
	{
		if((!CanUse) || (!Input.GetKeyDown(KeyCode.Space)))
		{
			return;
		}
		
		Use();
		_nextUseTime = Time.time + 1.0F;
	}

	#endregion
}