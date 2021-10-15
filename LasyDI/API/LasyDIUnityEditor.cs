using UnityEngine;
using UnityEditor;

namespace LasyDI.API
{
    internal sealed class LasyDIUnityEditor
    {
        [MenuItem("GameObject/LasyDI/SceneContext", false, 0)]
        public static void CreateSceneContext()
        {
            var sceneContext = Object.FindObjectOfType<SceneContext>();

            if (sceneContext == default)
            {
                sceneContext = new GameObject().AddComponent<SceneContext>();
            }

            Selection.activeObject = sceneContext;
        }
        [MenuItem("LasyDI/ProjectContext", false, 0)]
        public static void FindProjectContext()
        {
            var projectContext = Resources.Load<ProjectContext>(nameof(ProjectContext));

            if (projectContext == default)
            {
                projectContext = new GameObject().AddComponent<ProjectContext>();
                PrefabUtility.SaveAsPrefabAsset(projectContext.gameObject, $"Assets/LasyDI/Resources/{nameof(ProjectContext)}.prefab");
                Object.DestroyImmediate(projectContext.gameObject);
                FindProjectContext();
                return;
            }

            Selection.activeObject = projectContext;
        }
    }
}
