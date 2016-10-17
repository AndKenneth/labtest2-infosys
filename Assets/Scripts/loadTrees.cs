using UnityEngine;
using System.Collections.Generic;

public class loadTrees : MonoBehaviour {
    public GameObject treePrefab;

    public GameObject locationText;
    public GameObject dateText;
    public GameObject valueText;
    public GameObject significanceText;

    public List<GameObject> spawnedTreesList;


    // Use this for initialization
    void Start () {
		List<MyTree> trees = Request.getTrees();
        foreach(MyTree t in trees){
            GameObject newTree = Instantiate(treePrefab);
			newTree.GetComponentInChildren<treePrefab>().setup(this, t, locationText, dateText, valueText, significanceText);
            spawnedTreesList.Add(newTree);
        }
	}

	
	// Update is called once per frame
	void Update () {
	
	}
}
