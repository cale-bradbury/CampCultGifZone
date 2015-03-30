using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ccCreateGroup : MonoBehaviour {

	public enum SpawnType{
		Linear,
		Random
	}

	public GameObject[] obj;
	public SpawnType spawnType;
	int lastSpawned = -1;
	public int count = 5;
	[HideInInspector]
	public List<GameObject> all = new List<GameObject>();

	// Use this for initialization
	protected void Start () {
		for(int i =0;i< count;i++){
			GameObject g = getNew();
			all.Add(g);
			g.transform.localPosition = place(i);
		}
	}

	virtual public Vector3 place(int i){
		return Vector3.zero;
	}

	public void refresh(){
		for(int i =0;i< all.Count;i++){
			all[i].transform.localPosition = place(i);
		}
	}

	protected void Update(){
		if(all.Count<count){
			for(int i =0;i< count;i++){
				if(all.Count-1<i){
					all.Add(getNew());
				}
				all[i].transform.localPosition = place(i);
			}
		}else if(all.Count>count){
			for(int i = all.Count-1;i>=0;i--){
				if(i>=count){
					Destroy(all[i]);
					all.RemoveAt(i);
				}else{
					all[i].transform.localPosition = place(i);
				}
			}
		}
	}

	public GameObject getNew(){
		GameObject g;
		if(spawnType == SpawnType.Linear ){
			lastSpawned++;
			lastSpawned%= obj.Length;
			g = Instantiate(obj[lastSpawned]) as GameObject;
		}else {
			g = Instantiate(obj[(int)Random.Range(0,obj.Length)]) as GameObject;
		}
		g.transform.parent = transform;
		return g;
	}
	
	public delegate void apply(GameObject obj, int index);
	
	//function should takea gameObject and an index
	public void applyToAll(apply func){
		for(int i =0;i< all.Count;i++){
			func(all[i] as GameObject,i);
		}
	}

	public GameObject at(int i){
		return all[i] as GameObject;
	}

	public int length(){
		return all.Count;
	}
}
