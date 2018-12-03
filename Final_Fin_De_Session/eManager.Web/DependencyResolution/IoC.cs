using eManager.Domain;
using eManager.Web.Infrastrucre;
using StructureMap;
namespace eManager.Web {
    public static class IoC {
        public static IContainer Initialize() {
            ObjectFactory.Initialize(x =>
                        {
                            x.Scan(scan =>
                                    {
                                        scan.TheCallingAssembly();
                                        scan.WithDefaultConventions();
                                    });
                           x.For<IDepartmentDataSource>().HttpContextScoped().Use<DepartmentDB>();
                        });
            return ObjectFactory.Container;
        }
    }
}