using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Reflection;

public class PoolableSettings
{
    public Vector3 Position;
    public Quaternion Rotation;

    public PoolableSettings()
    {

    }

    public PoolableSettings(Vector3 position, Quaternion rotation)
    {
        Position = position;
        Rotation = rotation;
    }

    //public PoolableSettings(object parameters)
    //{
    //    //Type myType = parameters.GetType();
    //    //IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());

    //    //foreach (PropertyInfo prop in props)
    //    //{
    //    //    object propValue = prop.GetValue(parameters, null);
    //    //}
    //    PoolableSettings returnSettings = new PoolableSettings();
    //    //returnSettings.Position = (Vector3)parameters.GetType().GetProperty("Position").GetValue(parameters, null);
    //    //returnSettings.Rotation = Rotation = (Quaternion)parameters.GetType().GetProperty("Rotation").GetValue(parameters, null);
    //    //return 
    //}
}
