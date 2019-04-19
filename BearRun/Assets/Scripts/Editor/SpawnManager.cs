/****************************************************
    文件：SpawnManager.cs
	作者：ICE
    邮箱: 359087005@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using UnityEditor;
using UnityEngine;

public class SpawnManager : EditorWindow 
{
    [MenuItem("Tool/Click Me!")]
    static void PatternSystem()
    {
        GameObject spawnManager = GameObject.Find("PatternManager");
        if (spawnManager != null)
        {
            PatternManager patternManager =
                 spawnManager.GetComponent<PatternManager>();
            if (Selection.gameObjects.Length == 1)
            {
                var item = Selection.gameObjects[0].transform.Find("Items");
                if (item != null)
                {
                    Pattern ptn = new Pattern();
                    foreach (var child in item)
                    {
                        Transform childTrans = child as Transform;
                        if (childTrans != null)
                        {
                            var prefab = UnityEditor.PrefabUtility.GetPrefabParent(childTrans.gameObject);
                            if (prefab != null)
                            {
                                PatternItem pIm = new PatternItem()
                                {
                                    pos = childTrans.transform.localPosition,
                                prefabName  = prefab.name
                                };
                                ptn.patternItemList.Add(pIm);
                            }
                        }
                    }
                    patternManager.patternList.Add(ptn);
                }
            }
        }
    }
}