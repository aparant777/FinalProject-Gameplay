using UnityEngine;
using System.Collections;

public class MouseManager : MonoBehaviour {

	public Rigidbody2D grabbedObject = null;
	public float dragSpeed;
	public LineRenderer draggedLine;
	public SpringJoint2D springJoint;
	//we need to use reference for the rigidbody to grab the rigidbody object.
	
	void Update () {

		if(Input.GetMouseButtonDown(0)){

			Vector3 mousePosition3D = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			/* see, we need to convert the screen coordinates to world coordinates.
			 * Look the world coordinates are restricted in the box or the viewport of the camera,
			 * whereas the screencoordinates are dependent on the scene of the screen.
			 *
			 *So, a function is available, which converts the screen coordinates to world 
			 *coordinates of the game view. 
			 We need to convert the mouse coordinates from screen to world */
			Vector2 mousePosition2DConverted =  new Vector2(mousePosition3D.x, mousePosition3D.y);
			//for raycast we need only vector2
			Vector2 direction = Vector2.zero;
			//so we got the position of the mouse.
			//now we need to raycast it.

			RaycastHit2D hit = Physics2D.Raycast(mousePosition2DConverted, direction);
			//we raycast it from the origin that is the mouse position and in 
			//the zero direction(still confused about the zero direction);

			Debug.Log(mousePosition2DConverted);

			if(hit != null && hit.collider != null && hit.collider.tag != "Immovable"){
				//that means we hit something
				//that means we hit a collider which has a rigidbody
				//also we do not want to move the main platform which is tagged as main platform
				grabbedObject =  hit.rigidbody;
				draggedLine.enabled = true;
				Debug.Log(grabbedObject.name);	//gets the name of the rigidbody.
				springJoint = grabbedObject.gameObject.AddComponent<SpringJoint2D>();
				//now i have added the spring joint to the object which i am grabbing.
				springJoint.enableCollision = true;
				//so that the grabbed object can collide with other objects
				springJoint.distance = 0.015f;
				springJoint.dampingRatio = 10;
				springJoint.frequency = 1.0f;
				//springJoint.anchor = new Vector2(hit.transform.position.x,hit.transform.position.y);
				/*the above statement commented will not work since the points are in the 
				 * world coordinate systemm, we will need to convert the points in the 
				 * global coordinate system*/

				//world->local
				Vector3 convertedPositionInLocalSpace = grabbedObject.transform.InverseTransformPoint(hit.point);
				springJoint.anchor = convertedPositionInLocalSpace;
				//the above converts the point in local space from global space

			} else{
					Debug.Log("oohh !! We missed");
			}
		}

		//if we let go our finger

		//if(Input.touchCount < 1 && grabbedObject != null)

#if(UNITY_ANDROID)

#endif
		if(Input.GetMouseButtonUp(0) && grabbedObject != null){
			grabbedObject.gravityScale = 1;
			grabbedObject = null;
			draggedLine.enabled = false;
			Destroy(springJoint);
			springJoint = null;
		}


		if(springJoint != null){
			Vector3 mousePosition3D = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector2 mousePosition2DConverted =  new Vector2(mousePosition3D.x, mousePosition3D.y);

			springJoint.connectedAnchor = mousePosition3D;
		}
	}

	void FixedUpdate(){
		//now since the grabbed object is physics object, we will move it in FixedUpdate()

		if(grabbedObject != null){
			/* but we need to again convert the screen to world coordinates*/

			Vector3 mousePosition3d = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector2 mousePosition2d = new Vector2(mousePosition3d.x, mousePosition3d.y);

			//ok we got the mouse position, so lets move it

			Vector2 direction = mousePosition2d - grabbedObject.position;
			direction *= dragSpeed;

			//grabbedObject.velocity = direction;

			//draggedLine.SetPosition(0,new Vector3(grabbedObject.position.x,grabbedObject.position.y, -1f));
			/* the 0 in the first parameter indicates the staring position of line, 
				 * which incicates the line is originating from the grabbedObjects position */
			//draggedLine.SetPosition(1,new Vector3(mousePosition2d.x,mousePosition2d.y,0f));
			/*the 1 indicates the end position.
			 * we can add more numbers to the index, thus indicating more number 
			 * of lines joiing the linerenderer, */

		}
	}
	//the LateUpdate() runs after the physics, update and all the methods,

	void LateUpdate(){
		if(grabbedObject != null){
			//convert the local space to world space to draw the line
			Vector2 localToWorld=grabbedObject.transform.TransformPoint(springJoint.anchor.x,springJoint.anchor.y,0f);
			//need to convert
			draggedLine.SetPosition(0,new Vector3(localToWorld.x,localToWorld.y, -1f));
			draggedLine.SetPosition(1,new Vector3(springJoint.connectedAnchor.x,springJoint.connectedAnchor.y,0f));
		}
	}
}
	