using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class RTSResourceManager : MonoBehaviour
{
    List<RTSResource> rtsResources = new List<RTSResource>();

    [SerializeField] string resName;
    [SerializeField] int cost;
    [SerializeField] float incomeSpeed;
    [SerializeField] bool showResources = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #region Editor
    #if UNITY_EDITOR
    [CustomEditor(typeof(RTSResourceManager))]
    public class ResourceManagerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            RTSResourceManager resourceManager = (RTSResourceManager)target;

            DrawDetails(resourceManager);

            EditorGUILayout.Space();
            resourceManager.showResources = EditorGUILayout.Foldout(resourceManager.showResources, "Resources", true);

            if (resourceManager.showResources)
            {
                EditorGUI.indentLevel++;
                List<RTSResource> resources = resourceManager.rtsResources;
                int size = Mathf.Max(0, EditorGUILayout.IntField("Size", resources.Count));

                while (size > resources.Count)
                {
                    resources.Add(new RTSResource());
                }

                while (size < resources.Count)
                {
                    resources.RemoveAt(resources.Count - 1);
                }

                for (int i = 0; i < resources.Count; i++)
                {
                    resources[i] = (RTSResource)EditorGUILayout.ObjectField("Element " + i, resources[i], typeof(RTSResource), false);
                    EditorGUILayout.LabelField("Resource Name", GUILayout.MaxWidth(120)); 
                    //resources[i].resourceName = EditorGUILayout.TextField(resources[i].resourceName);
                }
                EditorGUI.indentLevel--;
            }
        }

        private static void DrawDetails(RTSResourceManager rtsResourceManager)
        {
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Details");
            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.LabelField("Name", GUILayout.MaxWidth(50));
            rtsResourceManager.resName = EditorGUILayout.TextField(rtsResourceManager.resName);

            EditorGUILayout.LabelField("Cost", GUILayout.MaxWidth(50));
            rtsResourceManager.cost = EditorGUILayout.IntField(rtsResourceManager.cost);

            EditorGUILayout.LabelField("Income", GUILayout.MaxWidth(75));
            rtsResourceManager.incomeSpeed = EditorGUILayout.FloatField(rtsResourceManager.incomeSpeed);

            EditorGUILayout.EndHorizontal();
        }
    }
    #endif
    #endregion
}
