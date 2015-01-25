using UnityEngine;
using System.Collections;

public class UpdateFinishedCounter : MonoBehaviour {

    private UILabel UILabel;

    void Start()
    {
        UILabel = GetComponent<UILabel>();
    }

	// Update is called once per frame
	void Update () {
        UILabel.text = "Finished: " + GameProgressTracker.FinishedObjects;
	}
}