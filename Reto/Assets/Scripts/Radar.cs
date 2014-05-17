using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Radar
{
	private int currentRead = 0;
	private IDataParser dataParser;
	private List<CelestialReading> currentCelestialReading;
	private string readingsText;
	private ArrayList readings;

	public void Initialize (MonoBehaviour caller)
	{
		dataParser = new LocalData ();
		dataParser.Load (caller);
		readingsText = dataParser.ParseToJSON ();
		readings = dataParser.DecodeJSON ();
	}

	public List<CelestialReading> GetCurrentReading ()
	{
		currentCelestialReading = new List<CelestialReading> ();
		ArrayList currentReadingInfo = readings[currentRead] as ArrayList;
		int index = 0;
		foreach (Hashtable information in currentReadingInfo) 
		{
			currentCelestialReading.Add (ToCelestialReading (information,index));
			index++;
		}
		return currentCelestialReading;
	}

	public void NextReading ()
	{
		if(currentRead < readings.Count-1)
			currentRead++;
	}

	public CelestialReading ToCelestialReading( Hashtable info , int index)
	{
		CelestialReading celestialReading = new CelestialReading (info,index);
		return celestialReading;
	}
}