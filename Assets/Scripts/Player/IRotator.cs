/// <summary>
///   Rotator interface.
/// </summary>
public interface IRotator
{
	#region Public fields
	
	/// <summary>
	///   Type of rotator.
	/// </summary>
	RotatorType RotatorType { get; }
	
	#endregion
	
	#region Public methods
	
	/// <summary>
	///   Tick (called once per update frame).
	/// </summary>
	void Tick();
	
	#endregion
}