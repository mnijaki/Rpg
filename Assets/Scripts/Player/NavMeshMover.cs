using UnityEngine;
using UnityEngine.AI;

/// <summary>
///   Mover of object on navigation mesh.
/// </summary>
public class NavMeshMover : IMover
{
	#region Public fields
	
	/// <summary>
	///   Type of mover.
	/// </summary>
	public MoverType MoverType { get; }
	
	#endregion
	
	#region Protected and private fields
	
	/// <summary>
	///  Player.
	/// </summary>
	private readonly Player _player;
	
	/// <summary>
	///   Navigation mesh agent.
	/// </summary>
	private readonly NavMeshAgent _navMeshAgent;

	#endregion
	
	#region Public mentods
	
	/// <summary>
	///   Constructor.
	/// </summary>
	/// <param name="player">Player to move</param>
	/// <param name="moverType">Type of mover</param>
	public NavMeshMover(Player player, MoverType moverType)
	{
		_player = player;
		MoverType = moverType;
		
		_navMeshAgent = _player.GetComponent<NavMeshAgent>();
		_navMeshAgent.enabled = true;
	}
	
	/// <summary>
	///   Tick (called once per update frame).
	/// </summary>
	public void Tick()
	{
		if(Input.GetMouseButtonDown(0))
		{
			if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hitInfo))
			{
				_navMeshAgent.SetDestination(hitInfo.point);
			}
		}
	}
	
	#endregion
}