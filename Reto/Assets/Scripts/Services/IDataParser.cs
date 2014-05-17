using UnityEngine;
using System.Collections;

public interface IDataParser
{
	void Load (MonoBehaviour caller);
	string ParseToJSON ();
	ArrayList DecodeJSON ();
}