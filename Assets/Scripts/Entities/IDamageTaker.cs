/// <summary>
///   Interface for damage taker.
/// </summary>
public interface IDamageTaker
{
	#region Public methods

	/// <summary>
	///   Take damage.
	/// </summary>
	/// <param name="val">Value of damage</param>
	void TakeDamage(int val);

	#endregion
}