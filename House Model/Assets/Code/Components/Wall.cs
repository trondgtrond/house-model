using System;
using UnityEngine;

[ExecuteInEditMode]
public class Wall : MonoBehaviour
{
	public enum WallDirection
	{
		NorthSouth,
		EastWest
	}

	[SerializeField]
	private WallDirection wallDirection;

	[SerializeField]
	private float length;

	[SerializeField]
	private float height;
	
	[SerializeField]
	private float width;
	
	private void Update()
	{
		Vector3 size;
		if(wallDirection == WallDirection.EastWest)
		{
			size = new Vector3(length, height, width);	
		}else if (wallDirection == WallDirection.NorthSouth)
		{
			size = new Vector3(width, height, length);
		}
		else
		{
			throw new ArgumentException("Unknown wall direction");
		}

		if (transform.localScale != size)
		{
			transform.localScale = size;
			transform.localPosition = new Vector3(transform.localPosition.x, transform.localScale.y / 2,
				transform.localPosition.z);
		}
	}
}
