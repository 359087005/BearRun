/****************************************************
    文件：RoadChange.cs
	作者：ICE
    邮箱: 359087005@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using UnityEngine;

public class RoadChange : MonoBehaviour
{
    GameObject roadNow;
    GameObject roadNext;

    GameObject parent;

    private void Start()
    {
        if (parent == null)
        {
            parent = new GameObject("RoadParent");
            parent.transform.position = Vector3.zero;
        }
        roadNow = Game.Instance.objectPool.Spawn("Pattern_1", parent.transform);
        roadNext = Game.Instance.objectPool.Spawn("Pattern_2", parent.transform);
        roadNext.transform.position += new Vector3(0, 0, 160);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == Consts.TAG_Road)
        {
            //对象池回收
            Game.Instance.objectPool.UnSpawn(other.gameObject);

            //创建新的
            SpawnNewRoad();
        }
    }

    void SpawnNewRoad()
    {
        int i = Random.Range(1,5);

        //生成新的游戏对象
        roadNow = roadNext;
        roadNext = Game.Instance.objectPool.Spawn("Pattern_" + i, parent.transform);
        roadNext.transform.position = roadNow.transform.position + new Vector3(0, 0, 160);
    }
}