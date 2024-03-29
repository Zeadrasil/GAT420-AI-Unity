using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAgentSpawner : MonoBehaviour
{
	[SerializeField] AIAgent[] agents;
	[SerializeField] LayerMask layerMask;
	[SerializeField] float spawnsPerSecond;
	private float cooldown = 0;
	int index = 0;

	void Update()
	{

		//press tab to switch agent to spawn
		if (Input.GetKeyDown(KeyCode.Tab)) index = (++index % agents.Length);

		//click to spawn or hold left control and mouse button to spawn multiple
		if (Input.GetMouseButtonDown(0) || (Input.GetMouseButton(0) && Input.GetKey(KeyCode.LeftControl)))
		{
			if (cooldown <= 0 || Input.GetMouseButtonDown(0))
			{
				cooldown += 1 / spawnsPerSecond;
				//get ray from camera to screen position
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				//raycast and see if it hits an object with layer
				if (Physics.Raycast(ray, out RaycastHit hitInfo, 100, layerMask))
				{
					//spawn agent at hit point with random rotation
					Instantiate(agents[index], hitInfo.point, Quaternion.AngleAxis(Random.Range(0, 360), Vector3.up));
				}
			}
			else
			{
				cooldown -= Time.deltaTime;
			}
		}
	}
}
