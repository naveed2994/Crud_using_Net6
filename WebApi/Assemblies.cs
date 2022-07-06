using System.Reflection;

namespace WebApi
{
    public class Assemblies
    {
        public static Assembly[] Get()
        {
            return new Assembly[] { typeof(Domain.IMarker).Assembly, typeof(WebApi.IMarker).Assembly, typeof(Presistance.IMarker).Assembly, typeof(UI.IMarker).Assembly };
        }
    }
}