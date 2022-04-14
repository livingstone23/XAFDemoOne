using System;
using System.Linq;
using DevExpress.ExpressApp;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Updating;
using DevExpress.Xpo;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.BaseImpl;
using XAFDemoOne.Module.BusinessObjects.Marketing;
using XAFDemoOne.Module.BusinessObjects.Planning;

namespace XAFDemoOne.Module.DatabaseUpdate {
    // For more typical usage scenarios, be sure to check out https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.Updating.ModuleUpdater
    public class Updater : ModuleUpdater {
        public Updater(IObjectSpace objectSpace, Version currentDBVersion) :
            base(objectSpace, currentDBVersion) {
        }
        public override void UpdateDatabaseAfterUpdateSchema()
        {
            base.UpdateDatabaseAfterUpdateSchema();
            if (ObjectSpace.CanInstantiate(typeof(Person)))
            {
                Person person = ObjectSpace.FirstOrDefault<Person>(p => p.FirstName == "John" && p.LastName == "Nilsen");
                if (person == null)
                {
                    person = ObjectSpace.CreateObject<Person>();
                    person.FirstName = "John";
                    person.LastName = "Nilsen";
                }
            }
            if (ObjectSpace.CanInstantiate(typeof(ProjectTask)))
            {
                ProjectTask task = ObjectSpace.FirstOrDefault<ProjectTask>(t => t.Subject == "TODO: Conditional UI Customization");
                if (task == null)
                {
                    task = ObjectSpace.CreateObject<ProjectTask>();
                    task.Subject = "TODO: Conditional UI Customization";
                    task.Status = ProjectTaskStatus.InProgress;
                    task.AssignedTo = ObjectSpace.FirstOrDefault<Person>(p => p.FirstName == "John" && p.LastName == "Nilsen");
                    task.StartDate = new DateTime(2019, 1, 30);
                    task.Notes = "OVERVIEW: http://www.devexpress.com/Products/NET/Application_Framework/features_appearance.xml";
                }
            }
            if (ObjectSpace.CanInstantiate(typeof(Project)))
            {
                Project project = ObjectSpace.FirstOrDefault<Project>(p => p.Name == "DevExpress XAF Features Overview");
                if (project == null)
                {
                    project = ObjectSpace.CreateObject<Project>();
                    project.Name = "DevExpress XAF Features Overview";
                    project.Manager = ObjectSpace.FirstOrDefault<Person>(p => p.FirstName == "John" && p.LastName == "Nilsen");
                    project.Tasks.Add(ObjectSpace.FirstOrDefault<ProjectTask>(t => t.Subject == "TODO: Conditional UI Customization"));
                }
            }
            if (ObjectSpace.CanInstantiate(typeof(Customer)))
            {
                Customer customer = ObjectSpace.FirstOrDefault<Customer>(c => c.FirstName == "Ann" && c.LastName == "Devon");
                if (customer == null)
                {
                    customer = ObjectSpace.CreateObject<Customer>();
                    customer.FirstName = "Ann";
                    customer.LastName = "Devon";
                    customer.Company = "Eastern Connection";
                }
            }
            ObjectSpace.CommitChanges();
        }



        public override void UpdateDatabaseBeforeUpdateSchema() {
            base.UpdateDatabaseBeforeUpdateSchema();
            //if(CurrentDBVersion < new Version("1.1.0.0") && CurrentDBVersion > new Version("0.0.0.0")) {
            //    RenameColumn("DomainObject1Table", "OldColumnName", "NewColumnName");
            //}
        }
    }
}
