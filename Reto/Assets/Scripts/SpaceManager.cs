using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpaceManager : MonoBehaviour 
{
	[SerializeField]
	private GameObject celestialBodyPrefab;
	[SerializeField]
	private float updateRateTime;
	[SerializeField]
	private List<CelestialBody> celestialBodies;
	private List<CelestialReading> celestialReading;

	private float nowTime;
	private float currentTime = 0;

	private bool canStartReaded = false;
	public Radar radar;

	private void Start ()
	{
		radar = new Radar ();
		radar.Initialize (this);
		CreateBodies ();
		canStartReaded = true;
	}

	private void CreateBodies ()
	{
		celestialBodies = new List<CelestialBody> ();
		celestialReading = radar.GetCurrentReading ();
		if (celestialBodies.Count < celestialReading.Count) 
		{
			foreach(CelestialReading celestialData in celestialReading)
				celestialBodies.Add(CreateCelestialBody (celestialData));
		}
	}

	private CelestialBody CreateCelestialBody (CelestialReading celestialData)
	{
		GameObject celestialObject = Instantiate (celestialBodyPrefab) as GameObject;
		CelestialBody currentCelestialBody = celestialObject.GetComponent<CelestialBody> ();
		currentCelestialBody.currentPosition = celestialData.positionInfo;
		currentCelestialBody.CelestialType = celestialData.celestialType;
		currentCelestialBody.ID = celestialData.ID;
		currentCelestialBody.totalTime = updateRateTime;
		celestialObject.name = celestialData.celestialType.ToString () + " - " + celestialData.ID;
	
		return currentCelestialBody;
	}

	private void Update ()
	{
		if (!canStartReaded)
			return;

		if (CanMoveObjects ()) 
			MoveCelestialsBodies ();
	}

	private bool CanMoveObjects ()
	{
		currentTime += Time.deltaTime;
		if (currentTime >= updateRateTime)
		{
			currentTime = 0;
			return true;
		}
		return false;
	}

	private void MoveCelestialsBodies ()
	{
		celestialReading = radar.GetCurrentReading ();

		foreach (CelestialBody celestialBody in celestialBodies) 
			ApplyReadingToObject ( celestialBody );

		radar.NextReading ();
	}

	private void ApplyReadingToObject (CelestialBody celestialBody)
	{
		foreach (CelestialReading currentReading in celestialReading) 
		{
			if(currentReading.ID == celestialBody.ID)
				celestialBody.CurrentPosition = currentReading.positionInfo;
		}
	}
}