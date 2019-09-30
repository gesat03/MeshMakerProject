using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class CallPrefab : MonoBehaviour {

    public InputField OBJName;

    string ObjName = "Default";

    string localPath;

    GameObject Obj;

    public Button Save;
    public Button Create;
    public Button Load;
    public Button Delete;

    void Start ()
    {
        Save.interactable = false;
        Delete.interactable = false;
    }

    public void LoadOBJ()
    {

        if (AssetDatabase.LoadAssetAtPath(localPath, typeof(GameObject)))
        {
            //Instantiate from editor
            Obj = (GameObject)Instantiate(AssetDatabase.LoadAssetAtPath(localPath, typeof(GameObject)));
            Obj.name = ObjName;
            Debug.Log("Object loaded...");
            Save.interactable = true;
            Delete.interactable = true;
        }
        else
        {
            Debug.Log("Does Not Exist...");
        }
    }

    public void DeleteOBJ()
    {
        if (Obj != null)
        {
            Destroy(Obj);
            Debug.Log("Object deleted...");
            Save.interactable = false;
            Delete.interactable = false;
        }
    }

    public void CreateOBJ()
    {
        if (OBJName.text != "")
        {
            ObjName = OBJName.text;
            localPath = "Assets/Prefabs/Cubes/" + ObjName + ".prefab";

            Obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
            Obj.name = ObjName;
            Debug.Log("Object just created...");

            Save.interactable = true;
            Delete.interactable = true;
        }
        else
        {
            Debug.Log("Object already created or give another name");
        }
    }

    public void SaveOBJ()
    {
        if (Obj != null && !AssetDatabase.LoadAssetAtPath(localPath, typeof(GameObject)))
        {
            Object prefab = PrefabUtility.CreatePrefab(localPath, Obj);
            PrefabUtility.ReplacePrefab(Obj, prefab, ReplacePrefabOptions.ConnectToPrefab);
            Debug.Log("Object saved...");
        }
        else
        {
            Debug.Log("There is an issue to save...");
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
