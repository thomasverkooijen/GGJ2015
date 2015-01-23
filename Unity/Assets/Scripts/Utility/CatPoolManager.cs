//using UnityEngine;
//#if UNITY_EDITOR
//    using UnityEditor;
//#endif
//using System.Collections;
//using System.Collections.Generic;
//using Assets.Scripts.Entities;
//using Assets.Scripts.Utility;

//public class CatPoolManager : Singleton<CatPoolManager>, IPoolManager
//{

//    public int PoolSize { get { return 100; } }
//    //private List<IPoolableObject> _ActiveObjects;
//    //public List<IPoolableObject> ActiveObjects
//    //{
//    //    get
//    //    {
//    //        if (this._ActiveObjects == null)
//    //        {
//    //            this._ActiveObjects = new List<IPoolableObject>(PoolSize);
//    //            return this._ActiveObjects;
//    //        }
//    //        else
//    //        {
//    //            return this._ActiveObjects;
//    //        }
//    //    }
//    //    set
//    //    {
//    //        this._ActiveObjects = value;
//    //    }
//    //}

//    //public List<IPoolableObject> _InactiveObjects;
//    //public List<IPoolableObject> InactiveObjects
//    //{
//    //    get
//    //    {
//    //        if (this._InactiveObjects == null)
//    //        {
//    //            this._InactiveObjects = new List<IPoolableObject>(PoolSize);
//    //            return this._InactiveObjects;
//    //        }
//    //        return this._InactiveObjects;
//    //    }
//    //    set
//    //    {
//    //        this._InactiveObjects = value;
//    //    }
//    //}
//    public List<Cat> ActiveObjects, InactiveObjects;

//    IEnumerator SpawnObject(GameObject objectType, int index)
//    {
//        yield return new WaitForSeconds(((float)index)/10);
//        GameObject newObject = Instantiate(objectType) as GameObject;
//        newObject.name = objectType.GetType() + "_" + index;

//        Cat catScript = newObject.AddComponent<Cat>() as Cat;
//        catScript.Id = index;
//        CatSettings settings = new CatSettings { Bounciness = Settings.Instance.Bounciness, Stickiness = Settings.Instance.Stickiness, };
//        catScript.Configure(settings, true);
//        IPoolableObject newPoolableObject = (IPoolableObject)catScript;

//        IPoolableObject poolableInterface = newPoolableObject as IPoolableObject;
//        //Debug.Log("IPoolableObject: " + newPoolableObject);
//        PoolableSettings poolSettings = new PoolableSettings(Vector3.zero, Quaternion.identity);
//        poolableInterface.Deactivate(poolSettings);
//        InactiveObjects.Add(catScript);
//    }

//    private GameObject ObjectType;

//    public void PreloadObjects(GameObject objectType)
//    {
//        ActiveObjects = new List<Cat>();
//        InactiveObjects = new List<Cat>();
//        ObjectType = objectType;
//        for (int i = 0; i < PoolSize; i++)
//        {
//            StartCoroutine(SpawnObject(objectType, i));
//        }
//    }

//    void OnLevelWasLoaded(int level)
//    {
//        Dispose();
//        if (Application.loadedLevelName.Contains("level"))
//        {
//            for (int i = 0; i < PoolSize; i++)
//            {
//                StartCoroutine(SpawnObject(ObjectType, i / 10));
//            }
//        }
//    }

//    public Cat ActivateObject(PoolableSettings parameters)
//    {
//        if (InactiveObjects.Count > 0)
//        {
//            //IPoolableObject returnObject = InactiveObjects[0];
//            Cat returnObject = InactiveObjects[0];
//            ActiveObjects.Add(returnObject);
//            returnObject.Activate(parameters);
//            returnObject.GameObject.name = returnObject.ToString();
//            InactiveObjects.RemoveAt(0);
//            return returnObject;
//        }
//        else
//        {
//            return null;
//        }
//    }

//    public Cat DeactivateObject(GameObject target, PoolableSettings parameters)
//    {
//        Cat cat = ActiveObjects.Find(t => t.GameObject == target);
//        ActiveObjects.Remove(cat);
//        InactiveObjects.Add(cat);
//        cat.Deactivate(parameters);
//        cat.GameObject.name = (cat).ToString();
//        return cat;
//    }

//    public void DeactivateAllObjects(PoolableSettings parameters)
//    {
//        //foreach(Cat cat in ActiveObjects)
//        //{

//        //}
//        //return InactiveObjects;
//    }

//    //public IPoolableObject DeactivateObject(object parameters)
//    //{
//    //    //if (ActiveObjects.Count > 0)
//    //    //{
//    //    IPoolableObject returnObject = ActiveObjects[0];
//    //    ActiveObjects.RemoveAt(0);
//    //    InactiveObjects.Add(returnObject);
//    //    returnObject.Deactivate(new PoolableSettings(parameters));
//    //    return returnObject;
//    //    //}
//    //    //return null;
//    //}

//    void Dispose()
//    {
//        InactiveObjects = null;
//        //_InactiveObjects = null;
//        ActiveObjects = null;
//        ActiveObjects = new List<Cat>();
//        InactiveObjects = new List<Cat>();
//        //_ActiveObjects = null;
//    }
//}
