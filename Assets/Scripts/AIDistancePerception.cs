using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AIDistancePerception : AIPerception
{
    public override GameObject[] getGameObjects()
    {
		List<GameObject> result = new List<GameObject>();

		Collider[] colliders = Physics.OverlapSphere(transform.position, distance);
		foreach (Collider collider in colliders)
		{
			//ensure that you are not perceiving yourself
			if (collider.gameObject == gameObject) continue;
			if (tagName == "" || collider.CompareTag(tagName))
			{
				// calculate angle from transform forward vector to direction of game object
				Vector3 direction = (collider.transform.position - transform.position).normalized;
				float angle = Vector3.Angle(transform.forward, direction);
				// if angle is no more than max angle, add game object
				if (angle <= maxAngle)
				{
					result.Add(collider.gameObject);
				}
			}
		}

		return result.ToArray();
	}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
