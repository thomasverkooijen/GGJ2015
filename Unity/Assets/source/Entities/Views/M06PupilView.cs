using UnityEngine;
using System.Collections;

public class M06PupilView : MonoBehaviour {

    public float TwitchTimerLowerBound = 0.1f;
    public float TwitchTimerUpperBound = 1.1f;

    public float TwitchSpeed = 0.25f;

    private float _twitchTimer;

    public Vector3 _startPosition;
    public Vector3 _targetPosition;

	void Start () {
        _startPosition = transform.localPosition;
        _twitchTimer = Random.Range(TwitchTimerLowerBound, TwitchTimerUpperBound);
        StartCoroutine(SelectNewTarget());
	}

    void Update()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, _targetPosition, TwitchSpeed);
    }

    IEnumerator SelectNewTarget()
    {
        _targetPosition = (Random.insideUnitSphere)/2 + _startPosition;
        _twitchTimer = Random.Range(TwitchTimerLowerBound, TwitchTimerUpperBound);
        yield return new WaitForSeconds(_twitchTimer);
        StartCoroutine(SelectNewTarget());
    }
}
