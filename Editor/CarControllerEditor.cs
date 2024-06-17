using UnityEngine;
using static Codice.Client.BaseCommands.Import.Commit;
using System.Drawing;

using Unity.VisualScripting;
using System;


#if UNITY_EDITOR
using UnityEditor;
public class CarControllerEditor : EditorWindow
{
    enum wheelState {
        FRONT_RIGHT, FRONT_LEFT,REAR_RIGHT, REAR_LEFT
    }
    private GameObject currentVehicle;
    [MenuItem("TeamflyerStudio/CarController/VehicleWizard")]
    public static void ShowWindow() {
        GetWindow<CarControllerEditor>("VehicleWizard").Show();
    }

    private void OnGUI() {
        GUILayout.Space(10);
        GUILayout.BeginHorizontal();
        GUILayout.Label("Vehicle Model : ");
        currentVehicle = EditorGUILayout.ObjectField(currentVehicle, typeof(GameObject), true) as GameObject;
        GUILayout.EndHorizontal();
        GUILayout.Space(20);
        GUILayout.Label("Create COM:", EditorStyles.boldLabel);

        if(GUILayout.Button("Create COM",GUILayout.ExpandWidth(true),GUILayout.Height(20))) {
            createCOM(currentVehicle);
        }
        
        
        GUILayout.Label("Create Wheel Collider : ");
        if (GUILayout.Button("Front Right", GUILayout.ExpandWidth(true), GUILayout.Height(20))) {
            wheelCollider("FR");
        }
    }

    private void createCOM(GameObject go) {
        if(go == null) {
            EditorUtility.DisplayDialog("Error", "Attach the gameobject in the vehicle field","Ok");
        } else {
            if (GameObject.Find("COM")==true) {
                EditorUtility.DisplayDialog("Error", "COM is already created", "Ok");
            } else {
                GameObject COM = new GameObject("COM");
                COM.transform.SetParent(go.transform,false);
            }
        }

    }

    private void wheelCollider(string name) {
        
        GameObject selectedWheel = Selection.activeGameObject;
        
        if (selectedWheel != null) {
            GameObject wheelColliderObj = GameObject.Find("WheelColliders");
            if (wheelColliderObj != null) {
                CreateCollider(wheelColliderObj,selectedWheel,name);
            } else {
                GameObject wCollider = new GameObject("WheelColliders");
                wCollider.transform.SetParent(currentVehicle.transform,false);
                CreateCollider(wCollider, selectedWheel, name);
            }
        }
    }

    private void CreateCollider(GameObject wheelColliderObj,GameObject selectedObject,string name) {
        if(wheelColliderObj&&selectedObject!=null) {
            GameObject wheelCollider = new GameObject(name);
            wheelCollider.transform.SetParent(wheelColliderObj.transform, false);
            WheelCollider wheel=wheelCollider.AddComponent<WheelCollider>();
            wheel.radius = CalculateRadius(selectedObject);
            //wheelColliderObj.transform.localPosition=selectedObject.transform.localPosition;
        }
    }

    private float CalculateRadius(GameObject wheelMesh) {
        MeshFilter wheelMeshFilter = wheelMesh.GetComponent<MeshFilter>(); 
        if (wheelMeshFilter == null) {
            Debug.LogWarning("No MeshFilter assigned.");
            return 0f;
        }

        Mesh mesh = wheelMeshFilter.sharedMesh;
        if (mesh == null) {
            Debug.LogWarning("No mesh assigned to the MeshFilter.");
            return 0f;
        }

        Bounds bounds = mesh.bounds;
        float radius = Mathf.Max(bounds.extents.x, bounds.extents.y, bounds.extents.z);
        return radius;
    }
}
#endif