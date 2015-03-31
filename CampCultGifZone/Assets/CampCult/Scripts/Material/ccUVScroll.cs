using UnityEngine;
using System.Collections;

public class ccUVScroll : MonoBehaviour {

	public Vector2 scrollPerSecond = Vector2.one;
	public string textureName = "_MainTex";

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector4 v = renderer.material.GetVector(textureName+"_ST");
		v.z+=scrollPerSecond.x*Time.deltaTime;
		v.w+=scrollPerSecond.y*Time.deltaTime;
		renderer.material.SetVector(textureName+"_ST",v);
		
	}
}
