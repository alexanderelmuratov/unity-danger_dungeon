using System.Collections;
using System.Linq;
using UnityEngine;

public class EntitySpawner : MonoBehaviour
{
    private void Awake()
    {
        var playerData = Context.Instance.DataSystem.EntityData.FirstOrDefault(e => e.name == "Player");
        Instantiate(playerData.prefab, playerData.position, Quaternion.identity);

        var spawnData = Context.Instance.DataSystem.SpawnData;

        foreach (var data in spawnData)
        {
            StartCoroutine(SpawnEnemy(data));
        }
    }

    private IEnumerator SpawnEnemy(SpawnData spawnData)
    {
        var entityData = Context.Instance.DataSystem.EntityData;

        foreach (var data in entityData)
        {
            if (data.name == spawnData.name)
            {
                Instantiate(data.prefab, data.position, Quaternion.identity);
                yield return new WaitForSeconds(spawnData.delay);
            }
        }
    }
}
