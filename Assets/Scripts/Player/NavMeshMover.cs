using UnityEngine;
using UnityEngine.AI;

/// <summary>
///   Mover of object on navigation mesh.
/// </summary>
public class NavMeshMover : IMover
{
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
	public NavMeshMover(Player player)
	{
		_player = player;
		
		_navMeshAgent = _player.GetComponent<NavMeshAgent>();
		_navMeshAgent.enabled = true;
	}
	
	/// <summary>
	///   Tick.
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