using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UVMapper : MonoBehaviour {

	public bool x;
	public bool y;
	public bool z;

	void Start()
	{
		Mesh mesh = GetComponent<MeshFilter>().mesh;
		Vector3[] vertices = mesh.vertices;
		Vector2[] uvs = new Vector2[vertices.Length];

		for (int i = 0; i < uvs.Length; i++)
		{
			if(x && y)
				uvs[i] = new Vector2(vertices[i].x, vertices[i].y);
			else if(x && z)
				uvs[i] = new Vector2(vertices[i].x, vertices[i].z);
			else if(y && z)
				uvs[i] = new Vector2(vertices[i].y, vertices[i].z);
		}
		mesh.uv = uvs;
	}

}
