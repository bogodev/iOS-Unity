using System;
using UnityEngine;
using System.Collections;

public class LocalData : IDataParser
{
	private ServerData data;
	private string [] lines;
	private ArrayList dataList;
	private string jsonInfo;

	public void Load (MonoBehaviour caller)
	{
		data = Helpers.LoadDataFromResources ("data");
	}

	public ArrayList DecodeJSON ()
	{
		return MiniJSON.jsonDecode (jsonInfo) as ArrayList;
	}

	public string ParseToJSON ()
	{
		dataList = new ArrayList ();
		foreach (string eachRead in data.ObjectsReaded)
			dataList.Add(GetObjects (eachRead));
		jsonInfo = MiniJSON.jsonEncode (dataList);
		return jsonInfo;
	}

	private ArrayList GetObjects (string objects)
	{
		string [] objectsData = objects.Split( new char[]{';'} );
		ArrayList dataInfo = new ArrayList ();
		for (int i = 0 ; i < objectsData.Length ; i++) 
		{
			string currrentCelestialBody = objectsData[i];
			if(i != 0 )
				dataInfo.Add(ParserCelestialBody (currrentCelestialBody));
		}
		return dataInfo;
	}

	private Hashtable ParserCelestialBody(string celestialBodyData)
	{
		string [] data = celestialBodyData.Split (new char[]{','});
		Hashtable info = new Hashtable ();
		info["type"] = Helpers.GetTypeByInitial (data [0]);
		info ["x"] = data [1];
		info ["y"] = data [2];
		info ["z"] = data [3];
		return info;
	}
}