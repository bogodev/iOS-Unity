using System;
using System.IO;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Helpers
{
	public static string NameOf(Action callback)
	{
		return callback.Method.Name;
	}

	public static ServerData LoadDataFromResources (string fileName)
	{
		ServerData serverData = new ServerData ();
		TextAsset data = (TextAsset)Resources.Load(fileName, typeof(TextAsset));
		StringReader reader = new StringReader(data.text);

		string line; 
		List<string> lines = new List<string> ();
		while ((line = reader.ReadLine()) != null) 
			lines.Add(line);

		serverData.ObjectsReaded = lines;
		serverData.allInfo = reader.ReadToEnd();
		reader.Close();
		
		return serverData;
	}

	public static string GetTypeByInitial(string initial)
	{
		if (initial.ToLower () == "m")
			return CelestialType.Meteor.ToString ();
		else if (initial.ToLower () == "c")
			return CelestialType.Comet.ToString ();

		return CelestialType.Other.ToString ();
	}

	public static CelestialType GetTypeByName( string name )
	{
		if (name.ToLower () == CelestialType.Meteor.ToString ().ToLower ())
				return CelestialType.Meteor;
		else if (name.ToLower () == CelestialType.Comet.ToString ().ToLower ())
				return CelestialType.Comet;
		return CelestialType.Other;
	}
}