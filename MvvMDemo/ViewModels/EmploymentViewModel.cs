using MvvMDemo.Helpers;
using MvvMDemo.Models;
using MvvMDemo.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvMDemo.ViewModels
{
    class EmploymentViewModel : BaseINotify
    {
        EmployeeService ObjEmployeeService;

        public EmploymentViewModel()
        {
            ObjEmployeeService = new EmployeeService();
            LoadData();
            CurrentEmployee = new Employee();
            saveCommand = new RelayCommand(Save);
            searchCommand = new RelayCommand(Search);
            updateCommand = new RelayCommand(Update);
            deleteCommand = new RelayCommand(Delete);
        }

        private ObservableCollection<Employee> employeesList;

        public ObservableCollection<Employee> EmployeeList
        {
            get { return employeesList; }
            set { employeesList = value; OnPropertyChange("EmployeeList"); }
        }

        public void LoadData()
        {
            EmployeeList = new ObservableCollection<Employee>(ObjEmployeeService.GetEmployees());
        }

        private Employee currentEmployee;

        public Employee CurrentEmployee
        {
            get { return currentEmployee; }
            set { currentEmployee = value; OnPropertyChange("CurrentEmployee"); }
        }

        private String message;

        public String Message
        {
            get { return message; }
            set { message = value; OnPropertyChange("Message"); }
        }

        #region Save Command
        private RelayCommand saveCommand;

        public RelayCommand SaveCommand
        {
            get { return saveCommand; }
        }
        public void Save()
        {

            try
            {
               var res = ObjEmployeeService.AddEmployee(CurrentEmployee);
                LoadData();
                if (res)
                {
                    Message = "Employee added succesfully";
                }
                else
                {
                    Message = "Failed to add Employee to system.";
                }
            }
            catch (Exception ex)
            {

                Message = ex.Message;
            }
        }
        #endregion

        #region Search Command
        private RelayCommand searchCommand;

        public RelayCommand SearchCommand
        {
            get { return searchCommand; }
          
        }

        public void Search()
        {
            var res = ObjEmployeeService.GetEmployee(CurrentEmployee.ID);
            if (res != null)
            {
                CurrentEmployee = res;
            }
            else
            {
                Message = "Employee not found";
            }
        }
        #endregion

        #region Update Command
        private RelayCommand updateCommand;

        public RelayCommand UpdateCommand
        {
            get { return updateCommand; }
         
        }

        public void Update()
        {
            var res = ObjEmployeeService.UpdateEmployee(CurrentEmployee);
            if (res)
            {
                Message = "Employee has been Updated";
                LoadData();
            }
            else
            {
                Message = "Failed to update Employee";
            }
        }
        #endregion

        #region Delete Command

        private RelayCommand deleteCommand;

        public RelayCommand DeleteCommand
        {
            get { return deleteCommand; }
           
        }

        public void Delete()
        {
            bool res = ObjEmployeeService.DeleteEmployee(CurrentEmployee.ID);
            if (res)
            {
                Message = "Employee has been deleted";
                LoadData();
            }
            else
            {
                Message = "Failed to delete Employee";
            }
        }

        #endregion
    }
}
