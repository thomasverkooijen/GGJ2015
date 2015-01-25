using UnityEngine;
using System.Collections;

public class SelectRandomSpriteOnLoad : MonoBehaviour {

    public Sprite[] AvailableSprites;

	// Use this for initialization
	void Start () {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = AvailableSprites[Random.Range(0, AvailableSprites.Length)];
	}
}
