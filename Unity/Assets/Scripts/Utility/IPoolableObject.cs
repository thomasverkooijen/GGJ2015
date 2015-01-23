using UnityEngine;
using System.Collections;

public interface IPoolableObject
{
    int Id { get; set; }
    GameObject GameObject { get; set; }

    void Activate(PoolableSettings parameters);
    void Deactivate(PoolableSettings parameters);
}