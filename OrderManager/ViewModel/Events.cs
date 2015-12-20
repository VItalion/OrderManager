using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.ViewModel
{
    public static class Events          //Статический прокси всех созданных событий
    {
        #region ProjectEvents
        public static event Action OnProjectChange;
        public static event Action<Model.Project> OnSelectProject;
        public static event Action OnAddProject;
        public static event Action<Model.Project> OnDeleteProject;
        public static event Action OnProjectCancelChange;
        public static event Action OnProjectSaveChange;
        public static event Action OnShowProjectInformation;
        public static event Action<Model.Task> OnCreateTask;

        public static event Action OnCreateProjectTab;
        #endregion

        #region ExecutorEvents
        public static event Action OnPersonChange;
        public static event Action<string> OnPhotoCahnge;
        public static event Action<Model.Executor> OnExecutorSaveCahnge;
        public static event Action OnExecutorCancelChange;
        public static event Action<Model.Executor> OnCreateExecutor;
        public static event Action<Model.Executor> OnDeleteExecutor;
        public static event Action<Model.Executor> OnSelectExecutor;
        public static event Action OnShowExecutorInformation;

        public static event Action OnCreatePersonTab;
        #endregion

        #region CustomerEvents
        public static event Action<Model.Customer> OnSelectCustomer;
        public static event Action<Model.Customer> OnCreateCustomer;
        public static event Action<Model.Customer> OnDeleteCustomer;
        public static event Action<Model.Customer> OnSaveChangeCustomer;
        public static event Action OnCancelChangeCustomer;
        public static event Action OnShowCustomerInformation;
        #endregion

        #region Projects
        public static void ProjectChange()
        {
            if (OnProjectChange != null)
                OnProjectChange();
        }
        public static void AddProject()
        {
            if (OnAddProject != null)
                OnAddProject();
        }
        public static void SelectProject(Model.Project project)
        {
            if (OnSelectProject != null)
                OnSelectProject(project);
            Behaviors.ProjectControl.DataSource.SelectedProject = project;
        }
        public static void DeleteProject(Model.Project project)
        {
            if (OnDeleteProject != null)
                OnDeleteProject(project);
        }
        public static void ProjectCancelChange()
        {
            if (OnProjectCancelChange != null)
                OnProjectCancelChange();
        }
        public static void ProjectSaveChage()
        {
            if (OnProjectSaveChange != null)
                OnProjectSaveChange();
        }        
        public static void ShowProjectInformation()
        {
            if (OnShowProjectInformation != null)
                OnShowProjectInformation();
        }
        public static void CreateTask(Model.Task task)
        {
            if (OnCreateTask != null)
                OnCreateTask(task);
        }

        public static void CreteProjectTab()
        {
            if (OnCreateProjectTab != null)
                OnCreateProjectTab();
        }
        #endregion

        #region Executors
        public static void PhotoCahnge(string path)
        {
            if (OnPhotoCahnge != null)
                OnPhotoCahnge(path);
        }
        public static void PersonChange()
        {
            if (OnPersonChange != null)
                OnPersonChange();
        }
        public static void ExecutorSaveChange(Model.Executor executor)
        {
            if (OnExecutorSaveCahnge != null)
                OnExecutorSaveCahnge(executor);
        }
        public static void ExecutorCancelChange()
        {
            if (OnExecutorCancelChange != null)
                OnExecutorCancelChange();
        }
        public static void CreateExecutor(Model.Executor executor)
        {
            if (OnCreateExecutor != null)
                OnCreateExecutor(executor);
        }
        public static void DeleteExecutor(Model.Executor executor)
        {
            if (OnDeleteExecutor != null)
                OnDeleteExecutor(executor);
        }
        public static void SelectExecutor(Model.Executor executor)
        {
            if (OnSelectExecutor != null)
                OnSelectExecutor(executor);

            Behaviors.ExecutorTab.SelectedExecutor.Executor = new Model.Executor(executor);
        }
        public static void ShowExecutorInformation()
        {
            if (OnShowExecutorInformation != null)
                OnShowExecutorInformation();
        }

        public static void CreatePersonTab()
        {
            if (OnCreatePersonTab != null)
                OnCreatePersonTab();
        }
        #endregion

        #region Customers
        public static void SelectCustomer(Model.Customer customer)
        {
            if (OnSelectCustomer != null)
                OnSelectCustomer(customer);

            Behaviors.CustomerTab.SelectedCustomer.Customer = new Model.Customer(customer);
        }
        public static void CreateCustomer(Model.Customer customer)
        {
            if (OnCreateCustomer != null)
                OnCreateCustomer(customer);
        }
        public static void DeleteCustomer(Model.Customer customer)
        {
            if (OnDeleteCustomer != null)
                OnDeleteCustomer(customer);
        }
        public static void CustomerSaveChange(Model.Customer customer)
        {
            if (OnSaveChangeCustomer != null)
                OnSaveChangeCustomer(customer);
        }
        public static void CustomerCancelChange()
        {
            if (OnCancelChangeCustomer != null)
                OnCancelChangeCustomer();
        }
        public static void ShowCustomerInformation()
        {
            if (OnShowCustomerInformation != null)
                OnShowCustomerInformation();
        }
        #endregion
    }
}
