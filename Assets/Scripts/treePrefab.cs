using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class treePrefab : MonoBehaviour {
    MyTree tree;

    public GameObject locationText;
    public GameObject dateText;
    public GameObject valueText;
    public GameObject significanceText;

    public Color originalColor;
    public Color selectedColor;

    public bool selected = false;

    loadTrees setupManager;

    public void setup(loadTrees lr, MyTree t, GameObject lt, GameObject dt, GameObject vt, GameObject st)
    {
        this.tree = t;

        //Move into position
        this.transform.position = new Vector3(t.X + 30f, t.Y, t.Z - 16f);
        
        //Set the label to be the Location
        this.GetComponentInChildren<TextMesh>().text = t.Location;

        //Set to original color
        this.GetComponent<Renderer>().material.color = originalColor;

        this.locationText = lt;
        this.dateText = dt;
        this.valueText = vt;
        this.significanceText = st;

        this.setupManager = lr;

        

    }

    public void revertColor()
    {
        this.GetComponent<Renderer>().material.color = originalColor;
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButton(0))
        {
            foreach(GameObject r in this.setupManager.spawnedTreesList)
            {
                if (r.GetComponent<treePrefab>().selected)
                {
					r.GetComponent<treePrefab>().revertColor();
					r.GetComponent<treePrefab>().selected = false;
                }
            }

            //Set all other objects to default color.
            Debug.Log("Mouse Click: " + tree.id.ToString());
            

            originalColor = this.GetComponent<Renderer>().material.color;
            this.GetComponent<Renderer>().material.color = selectedColor;

            //Set Panel Text
            locationText.GetComponent<Text>().text = "Location: " + tree.Location;
            dateText.GetComponent<Text>().text = "Date of Reading: " + tree.WhenReadingRecorded;
			valueText.GetComponent<Text>().text = "Ecological Value: " + tree.EcologicalValue;
			significanceText.GetComponent<Text>().text = "Historical Significance: " + tree.HistoricalSignificance.ToString();

            this.selected = true;
        }
    }


}
