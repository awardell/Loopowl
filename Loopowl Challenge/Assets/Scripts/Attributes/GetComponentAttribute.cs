using System;
using UnityEngine;

public class GetComponentAttribute : PropertyAttribute
{
	public Type type;
	public bool readOnly;
	public GetComponentAttribute(Type type, bool readOnly = false)
	{
		this.type = type;
		this.readOnly = readOnly;
	}
}
