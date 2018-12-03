using Gestion_Des_Conges_2.Infrastructure;
using StructureMap;
namespace Gestion_Des_Conges_2 {
    public static class IoC {
        public static IContainer Initialize() {
            ObjectFactory.Initialize(x =>
                        {
                            x.Scan(scan =>
                                    {
                                        scan.TheCallingAssembly();
                                        scan.WithDefaultConventions();
                                    });
                          x.For<ILeaveManagementRepository>().HttpContextScoped().Use<LeaveManagementRepositoryDb>();
                        });
            return ObjectFactory.Container;
        }
    }
}