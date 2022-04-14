using DevExpress.ExpressApp.Design;
using DevExpress.ExpressApp.EF.DesignTime;
using DevExpress.ExpressApp.EF.Updating;
using System;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using XAFDemoOne.Module.BusinessObjects.Marketing;

namespace XAFDemoOne.Module.BusinessObjects
{
    public class XAFDemoOneContextInitializer : DbContextTypesInfoInitializerBase {
		protected override DbContext CreateDbContext() {
			DbContextInfo contextInfo = new DbContextInfo(typeof(XAFDemoOneDbContext), new DbProviderInfo(providerInvariantName: "System.Data.SqlClient", providerManifestToken: "2008"));
            return contextInfo.CreateInstance();
		}
	}
	[TypesInfoInitializer(typeof(XAFDemoOneContextInitializer))]
	public class XAFDemoOneDbContext : DbContext {
		public XAFDemoOneDbContext(String connectionString)
			: base(connectionString) {
		}
		public XAFDemoOneDbContext(DbConnection connection)
			: base(connection, false) {
		}
		public XAFDemoOneDbContext() {
		}
		public DbSet<ModuleInfo> ModulesInfo { get; set; }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Testimonial> Testimonial { get; set; }
	}
}
