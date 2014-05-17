using UnityEngine;
using System.Collections;

public enum CelestialType
{
	Meteor = 0,
	Comet = 1,
	Other = 2
}

public class CelestialReading
{
	public int ID;
	public Vector3 positionInfo;
	public CelestialType celestialType;
	public CelestialReading (Hashtable data,int index)
	{
		ID = index;
		float x = ExtractPosition ("x", data);
		float y = ExtractPosition ("y", data);
		float z = ExtractPosition ("z", data);

		positionInfo = new Vector3 (x, y, z);
		celestialType = Helpers.GetTypeByName (data ["type"].ToString ());
	}

	private float ExtractPosition ( string position, Hashtable data)
	{
		string currentPosition = data [position].ToString ();
		float currentDataPosition = float.Parse (currentPosition) / 100000F;
		return currentDataPosition;
	}
	public override string ToString ()
	{
		return string.Format ("[CelestialReading] position:{0}",positionInfo);
	}
}