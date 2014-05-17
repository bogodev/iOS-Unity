using System;
using UnityEngine;
using System.Collections;

public class ServerInfoData : IDataParser
{
	private string url;
	private string textInfo;
	public void Load (MonoBehaviour caller)
	{
		caller.StartCoroutine (GetInformation ());
	}

	private IEnumerator GetInformation ()
	{
		WWW service = new WWW (url);
		yield return service;
		textInfo = service.text;
	}

	public string ParseToJSON ()
	{
		return "";
	}

	public ArrayList DecodeJSON ()
	{
		return null;
	}
}