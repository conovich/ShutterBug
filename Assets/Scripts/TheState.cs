﻿using UnityEngine;
using System.Collections;

public class TheState: MonoBehaviour {
	
	public static TheState _MyState;
	
	private TheState() {}
	
	public static TheState Instance{
		get{
			if (_MyState == null){
				_MyState = new TheState();	
			}
			return _MyState;
		}
	}
	
	void Start () {
	
	}
	
	void Update () {
	
	}
}
