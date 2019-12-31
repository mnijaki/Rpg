using System;
using UnityEngine;

/// <summary>
///   Player input.
/// </summary>
public class PlayerInput : IPlayerInput
{
	#region Events
	
	/// <summary>
	///   Event - fired after movement mode key was pressed.
	/// </summary>
	public event Action MovementModeKeyPressed;
	
	/// <summary>
	///   Event - fired after Alpha key was pressed.
	///   <para></para>
	///   int - index of pressed Alpha key (0 - Alpha1, 1 - Alpha2, 2 - Alpha3...)
	/// </summary>
	public event Action<int> AlphaKeyPressed;
	
	#endregion
	
	#region Public fields
	
	/// <summary>
	///   Vertical input.
	/// </summary>
	public float Vertical
	{
		get { return Input.GetAxis("Vertical"); }
	}

	/// <summary>
	///   Horizontal input.
	/// </summary>
	public float Horizontal
	{
		get { return Input.GetAxis("Horizontal"); }
	}

	/// <summary>
	///   Mouse X input.
	/// </summary>
	public float MouseX
	{
		get { return Input.GetAxis("Mouse X"); }
	}
	
	#endregion
	
	#region Public methods

	/// <summary>
	///   Tick.
	/// </summary>
	public void Tick()
	{
		CheckIfMovementModeKeyWasPressed();
		CheckIfAlphaKeyWasPressed();
	}

	#endregion
	
	#region Private methods

	/// <summary>
	///   Check if movement mode key was pressed.
	/// </summary>
	private void CheckIfMovementModeKeyWasPressed()
	{
		if(MovementModeKeyPressed == null)
		{
			return;
		}

		if(Input.GetKeyDown(KeyCode.F1))
		{
			MovementModeKeyPressed.Invoke();
		}
	}
	
	/// <summary>
	///   Check if Alpha key was pressed.
	/// </summary>
	private void CheckIfAlphaKeyWasPressed()
	{
		if(AlphaKeyPressed == null)
		{
			return;
		}

		for(int i = 0; i < 9; i++)
		{
			if(Input.GetKeyDown(KeyCode.Alpha1 + i))
			{
				AlphaKeyPressed.Invoke(i);
			}
		}
	}
	
	#endregion
}