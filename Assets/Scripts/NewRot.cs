using UnityEngine;
using System.Collections;

public class NewRot : MonoBehaviour {
	void Update (){
		transform.Rotate (new Vector3 (363, -342, 354) * Time.deltaTime * 0.4F);
	}
}
