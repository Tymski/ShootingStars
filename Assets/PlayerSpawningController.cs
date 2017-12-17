using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerSpawningController : MonoBehaviour
{
    private static PlayerSpawningController _instance;

    [SerializeField]
    private Transform[] _spawns;

    [SerializeField]
    private float _cooldownTime;

    private List<int> Cooldown;

    public void Awake()
    {
        _instance = this;

        Cooldown = new List<int>();
    }

    public static Vector3 GetSpawningPoint()
    {
        var rand = 0;
        do
        {
             rand = Random.Range(0, _instance._spawns.Length);
        } while (_instance.Cooldown.Contains(rand));

        return _instance._spawns[rand].position;
    }

    public static Vector3 GetSpawningPoint(int id)
    {
        return _instance._spawns[id].position;
    }

    private IEnumerator CooldownSpawn(int id)
    {
        Cooldown.Add(id);

        yield return new WaitForSeconds(_cooldownTime);

        Cooldown.Remove(id);
    }


}
