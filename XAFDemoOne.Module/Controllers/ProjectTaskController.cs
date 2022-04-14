using System;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using XAFDemoOne.Module.BusinessObjects.Planning;

namespace XAFDemoOne.Module.Controllers
{
    public class ProjectTaskController : ViewController
    {
        public ProjectTaskController()
        {
            TargetObjectType = typeof(ProjectTask);
            TargetViewType = ViewType.Any;
            SimpleAction markCompletedAction = new SimpleAction(
                this, "MarkCompleted",
                DevExpress.Persistent.Base.PredefinedCategory.RecordEdit)
            {
                TargetObjectsCriteria =
                    (CriteriaOperator.Parse("Status != ?", ProjectTaskStatus.Completed)).ToString(),
                ConfirmationMessage =
                            "Are you sure you want to mark the selected task(s) as 'Completed'?",
                ImageName = "State_Task_Completed"
            };
            markCompletedAction.Execute += (s, e) => {
                foreach (ProjectTask task in e.SelectedObjects)
                {
                    task.EndDate = DateTime.Now;
                    task.Status = ProjectTaskStatus.Completed;
                    View.ObjectSpace.SetModified(task);
                }
                View.ObjectSpace.CommitChanges();
                View.ObjectSpace.Refresh();
            };
        }
    }
}
