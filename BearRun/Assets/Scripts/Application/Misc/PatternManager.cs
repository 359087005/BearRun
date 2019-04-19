/****************************************************
    文件：PatternManager.cs
	作者：ICE
    邮箱: 359087005@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using System.Collections.Generic;
using UnityEngine;
using System;

public class PatternManager : MonoSingleton<PatternManager> 
{
    public List<Pattern> patternList = new List<Pattern>(); 

}
[Serializable]
public class PatternItem
{
    public string prefabName;
    public Vector3 pos;
}
[Serializable]
public class Pattern
{
    public List<PatternItem> patternItemList = new List<PatternItem>();
}