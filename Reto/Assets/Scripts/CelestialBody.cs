using UnityEngine;
using System.Collections;

public class CelestialBody : MonoBehaviour 
{
	[SerializeField]
	private Material otherMaterial;
	[SerializeField]
	private Material meteorMaterial;
	[SerializeField]
	private Material cometMaterial;

	private float alpha;
	public float totalTime;
	private float currentTime;

	private Vector3 initPosition;
	private Vector3 targetPosition;

	public int ID;
	public Vector3 currentPosition;

	public Vector3 CurrentPosition {
		get {
			return currentPosition;
		}
		set 
		{
			Debug.Log("--- Calling the fucking new pos");
			currentPosition = value;
			initPosition = transform.localPosition;
			targetPosition = currentPosition;
			currentTime = 0;
		}
	}

	private CelestialType celestialType;
	private Transform myTransform;
	private MeshRenderer meshRenderer;


	public CelestialType CelestialType
	{
		get{ return celestialType;}
		set{ celestialType = value; }
	}

	private void SetColorByType ()
	{
		if (celestialType == CelestialType.Comet)
			meshRenderer.material = this.cometMaterial;
		else if (celestialType == CelestialType.Meteor)
			meshRenderer.material = this.meteorMaterial;
		else
			meshRenderer.material = this.otherMaterial;
	}

	private void Start ()
	{
		currentTime = 0;
		myTransform = transform;
		meshRenderer = myTransform.GetComponent<MeshRenderer> ();

		SetColorByType ();
	}

	private void Update () 
	{
		MoveObject ();
	}

	private void MoveObject ()
	{
		if (myTransform.localPosition != currentPosition) 
		{
			Debug.Log("problema 01 current time " + currentTime + " totaltime " + totalTime);
			currentTime += Time.deltaTime;
			if (currentTime >= totalTime)
			{
				Debug.Log("problema 0101");
				myTransform.localPosition = targetPosition;
			}
			else
			{
				Debug.Log("problema 0102");
				alpha = currentTime/totalTime;
				myTransform.localPosition = initPosition + (targetPosition-initPosition)*alpha;
			}
		}
		//myTransform.localPosition = currentPosition;
	}
}