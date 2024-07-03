using UnityEngine;

namespace Code.Extensions
{
    public static class TransformExtensions
    {
        public static void Replace(this Transform transform, Transform other, Vector3 position)
        {
            transform.position = other.position;
            other.position = position;
        }
    }
}