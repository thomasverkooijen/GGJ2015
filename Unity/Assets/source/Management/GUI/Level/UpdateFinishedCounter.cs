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
        UILabel.text = "Sentient robots remaining: " + (GameManager.ActiveEntities.FindAll(go => go.GetComponent<PlayerController>() != null).Count-1).ToString();
	}
}