using UnityEngine;
using Unity.Entities;

public class RandomRotator : MonoBehaviour
{
    public float speed;

    class RotatorSystem : ComponentSystem
    {
        [System.Serializable]
        struct Components
        {
            public RandomRotator rotator;
            public Transform transform;
        }

        protected override void OnStartRunning()
        {
            foreach (var entities in GetEntities<Components>())
            {
                entities.rotator.speed = Random.Range(0f, 25f);
            }
        }

        protected override void OnUpdate()
        {
            float deltaTime = Time.deltaTime;

            foreach (var entities in GetEntities<Components>())
            {
                entities.transform.Rotate(entities.rotator.speed * deltaTime, entities.rotator.speed * deltaTime, entities.rotator.speed * deltaTime);
            }
        }
    }
}