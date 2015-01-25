using UnityEngine;
using System.Collections;

public class MoveAlongTarget : MonoBehaviour
{

    public GameObject Target;
    private float LerpValue = 0.25f;

    // Use this for initialization
    void Start()
    {

    }

    public void SetTarget(GameObject newTarget)
    {
        if (newTarget != null)
            Target = newTarget;
    }

    // Update is called once per frame
    void Update()
    {
        if (Target != null)
        {
            Vector3 movement = Vector3.Lerp(transform.position, Target.transform.position, LerpValue * Time.deltaTime);
            transform.position = new Vector3(movement.x, transform.position.y, transform.position.z);
        }
    }
}
