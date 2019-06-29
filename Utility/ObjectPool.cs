using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{

	public static ObjectPool instance;

	[System.Serializable]
	public class PoolUnit
	{
		public GameObject prefab;
		public int size;
		public Transform parent;
	}

	bool isPoolMade;
	public bool isSingleton;
	public List<PoolUnit> Pool;
	public Dictionary<string, Stack<GameObject>> poolDictionary;

	public void MakeSingleton ()
	{
		if (isSingleton) {
			if (instance == null) {
				instance = this;
			}
		}
	}

	private void Awake ()
	{
		MakeSingleton ();
	}

	public bool IsPoolMade ()
	{
		return isPoolMade;

	}

	void Start ()
	{
		GeneratePool ();
	}

	public void GeneratePool ()
	{
		poolDictionary = new Dictionary<string, Stack<GameObject>> ();
		foreach (PoolUnit pool in Pool) {
			Stack<GameObject> objectPool = new Stack<GameObject> ();

			for (int i = 0; i < pool.size; i++) {
				GameObject obj;
				if (pool.parent == null) {
					obj = Instantiate (pool.prefab);
				} else {
					obj = Instantiate (pool.prefab, pool.parent);
				}
				obj.name = pool.prefab.name;
				//obj.transform.SetParent(transform, false);
				obj.SetActive (false);
				objectPool.Push (obj);
			}
			poolDictionary.Add (pool.prefab.name, objectPool);
		}

		isPoolMade = true;
	}

	public GameObject[] GetAllPoolObjectsFromName (string name)
	{
		return poolDictionary [name].ToArray ();
	}

	public int GetPoolObjectCount ()
	{

		return poolDictionary.Count;

	}

	public GameObject GetObjectFromPool (string name, Vector3 position, Quaternion rotation)
	{
		if (!isPoolMade) {
			return null;
		}

		GameObject spawnobj;

		if (!poolDictionary.ContainsKey (name)) {
			//Debug.LogError ("this key " + name + "doesnt exisaefowuhawfouhafoiht" + isPoolMade);
			return null;
		}
		Stack<GameObject> poolStackMeta;
		poolStackMeta = poolDictionary [name];

		if (poolStackMeta.Count == 0) {
			PoolUnit pu = GetSourcePoolObjectFromName (name);
			spawnobj = Instantiate (pu.prefab);
			spawnobj.name = name;
			spawnobj.transform.SetParent (pu.parent, false);

		} else {
			spawnobj = poolStackMeta.Pop ();
		}
		spawnobj.SetActive (true);
		spawnobj.transform.position = position;
		spawnobj.transform.rotation = rotation;


		return spawnobj;
	}

	public GameObject GetObjectFromPool(string name)
	{
		if (!isPoolMade) {
			return null;
		}

		if (!poolDictionary.ContainsKey (name))     {
			//Debug.LogError ("this key " + name + "doesnt exist f" + isPoolMade);
			return null;
		} else {
			Stack<GameObject> poolStackMeta;
			poolStackMeta = poolDictionary [name];
			GameObject spawnobj;
			if (poolStackMeta.Count == 0) {
				spawnobj = Instantiate (GetSourcePoolObjectFromName (name).prefab);
				spawnobj.name = name;
				spawnobj.transform.SetParent (GetSourcePoolObjectFromName (name).parent, false);

			} else {
				spawnobj = poolStackMeta.Pop ();
			}
			spawnobj.SetActive (true);
			return spawnobj;
		}
	}

	public void ReturnObjectToPool (GameObject objToReturn)
	{
		//Debug.LogError (objToReturn.name + "kuch");
		poolDictionary [objToReturn.name].Push (objToReturn);
        objToReturn.transform.parent = Pool[0].parent;

        objToReturn.SetActive (false);
	}

	public PoolUnit GetSourcePoolObjectFromName (string name)
	{
		for (int i = 0; i < Pool.Count; i++) {
			if (name == Pool [i].prefab.name) {
				return Pool [i];
			}
		}
		return null;
	}
}
