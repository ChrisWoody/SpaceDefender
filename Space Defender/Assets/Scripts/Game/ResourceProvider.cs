using System.ComponentModel;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.Assertions;

namespace Assets.Scripts.Game
{
    // Nice to have. Have this instansiate the objects (instead of doing it everywhere else in code). Maybe have an enum of resources.

    public class ResourceProvider : MonoBehaviour
    {
        void Awake()
        {
            Assert.IsTrue(FindObjectsOfType<ResourceProvider>().Count() == 1,
                "Scene can only have 1 ResourceProvider");

            var resourcesProps = typeof(ResourceProvider).GetProperties(BindingFlags.Static | BindingFlags.Public).Where(x => x.PropertyType == typeof(Transform));
            foreach (var property in resourcesProps)
            {
                var attrib = property.GetCustomAttributes(typeof(DescriptionAttribute), false).Single();
                var path = ((DescriptionAttribute)attrib).Description;
                property.SetValue(property, Resources.Load<Transform>(path), null);
            }
        }

        [Description("Player/Weapons/Laser")]
        public static Transform Laser { get; private set; }

        [Description("Player/Weapons/LaserExplosion")]
        public static Transform LaserExplosion { get; private set; }
    }
}
