using UnityEngine;

public class PlayerInput : IPlayerInput
{
	public float Vertical
	{
		get { return Input.GetAxis("Vertical"); }
	}

	public float Horizontal
	{
		get { return Input.GetAxis("Horizontal"); }
	}

	public float MouseX
	{
		get { return Input.GetAxis("Mouse X"); }
	}
}