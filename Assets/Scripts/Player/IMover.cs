/// <summary>
///   Mover interface.
/// </summary>
public interface IMover
{
	#region Public fields
	
	/// <summary>
	///   Type of mover.
	/// </summary>
	MoverType MoverType { get; }
	
	#endregion
	
	#region Public methods
	
	/// <summary>
	///   Tick (called once per update frame).
	/// </summary>
	void Tick();
	
	#endregion
}