using UnityEngine;

namespace Code.Extensions
{
    public static class Vector3Extensions
    {
        public static Vector3 GetMouseWorldPosition(this Vector3 mousePosition, float z)
        {
            mousePosition.z = z;
            
            return Camera.main.ScreenToWorldPoint(mousePosition);
        }
    }
}