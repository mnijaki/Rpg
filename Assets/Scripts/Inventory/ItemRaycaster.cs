using UnityEngine;

public class ItemRaycaster : ItemComponent
{
	#region Serialized fields

	/// <summary>
	///   Delay of item usage (in seconds).
	/// </summary>
	[SerializeField]
	[Range(0.0F,5.0F)]
	[Tooltip("Delay of item usage (in seconds)")]
	private float _delay = 0.1F;
	
	/// <summary>
	///   Raycast range. 
	/// </summary>
	[SerializeField]
	[Range(1.0F,100.0F)]
	[Tooltip("Raycast range")]
	private float _range = 10.0F;
	
	#endregion
	
	#region Protected and private fields
	
	/// <summary>
	///   Collection of raycast hit results.
	/// </summary>
	private readonly RaycastHit[] _results = new RaycastHit[100];

	/// <summary>
	///   Layer mask used in raycasting. 
	/// </summary>
	private static int _layerMask;

	/// <summary>
	///   Number of raycast hits.
	/// </summary>
	private int _hits;

	/// <summary>
	///   Position of the ray.
	/// </summary>
	private static readonly Vector2 _rayPosition = Vector2.one / 2;
	
	/// <summary>
	///   Empty raycast hit.
	/// </summary>
	private static readonly RaycastHit _emptyHit = new RaycastHit();

	#endregion
	
	#region Public methods
	
	/// <summary>
	///   Use item.
	/// </summary>
	public override void Use()
	{
		_nextUseTime = Time.time + _delay;

		// MN:TO_DO: not optimised?
		Ray ray = Camera.main.ViewportPointToRay(_rayPosition);
		// RaycastNonAlloc does not sort result by distance. 
		_hits = Physics.RaycastNonAlloc(ray, _results, _range, _layerMask, QueryTriggerInteraction.Collide);
		
		RaycastHit nearest = GetNearestTransform();
		if(nearest.transform == null)
		{
			return;
		}

		Transform hitCubeTrans = GameObject.CreatePrimitive(PrimitiveType.Cube).transform;
		hitCubeTrans.localScale = new Vector3(0.1F, 0.1F, 0.1F);
		hitCubeTrans.position = nearest.point;
	}

	/// <summary>
	///   Get nearest transform from results of raycasting.
	/// </summary>
	/// <returns>Nearest transform from results of raycasting</returns>
	private RaycastHit GetNearestTransform()
	{
		RaycastHit nearest = _emptyHit;
		double nearestDistance = double.MaxValue;

		for(int i = 0; i < _hits; i++)
		{
			float distance = Vector3.Distance(transform.position, _results[i].point);
			if(distance >= nearestDistance)
			{
				continue;
			}

			nearest = _results[i];
			nearestDistance = distance;
		}
		
		return nearest;
	}

	#endregion
	
	#region Protected and private methods

	/// <summary>
	///   Awake.
	/// </summary>
	private void Awake()
	{
		// MN:TO_DO: layer mask cannot can be obtained only during initialization of object or by serialization.
		_layerMask = LayerMask.GetMask("Default");
	}

	#endregion
}