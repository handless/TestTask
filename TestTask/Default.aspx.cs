using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Serialization;

namespace TestTask
{
    public partial class Default : System.Web.UI.Page
    {
       

        public TestDBContainer container = new TestDBContainer();
       

        #region события
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                UpdateGrid(0);
            }
           

        }
        protected void DropDownList_SelectedValue(object sender, EventArgs e)
        {
           
            string selectedJob = DropDownList.SelectedValue;
            int jobId = container.JobsSet.Where(x => x.JobsName == selectedJob).FirstOrDefault().Id;
            UpdateGrid(jobId);
        }

       

        protected void Page_Init(object sender, EventArgs e)
        {
            //string selectedJob = DropDownList.SelectedValue;
            //int jobId = container.JobsSet.Where(x => x.JobsName == selectedJob).FirstOrDefault().Id;

            //if (jobId == 0)
            //{
            //    gridView.DataSource = container.EmployeesSet.Where(x => x.JobsId == 1).ToList();
            //    // gridView.DataSourceID = string.Empty;
            //    gridView.DataBind();
            //}
            //else
            //{
            //    gridView.DataSource = container.EmployeesSet.Where(q => q.JobsId == jobId).ToList();
            //    gridView.DataBind();
            //}

        }


      
        #endregion
        private void UpdateGrid(int JobId)
        {
            if (JobId == 0)
            {
                gridView.DataSource = container.EmployeesSet.Where(x => x.JobsId == 1).ToList();
                // gridView.DataSourceID = string.Empty;
                gridView.DataBind();
            }
            else
            {
                gridView.DataSource = container.EmployeesSet.Where(q => q.JobsId == JobId).ToList();
                gridView.DataBind();
            }
        }
       

        //Не работает
        protected void gvPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            
                string selectedJob = DropDownList.SelectedValue;
                int jobId = container.JobsSet.Where(x => x.JobsName == selectedJob).FirstOrDefault().Id;
                UpdateGrid(jobId);
            

            gridView.PageIndex = e.NewPageIndex;
            
            gridView.DataBind();
        }


        protected void GvUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id;
            if (int.TryParse(string.Format("{0}", e.Keys["Id"]), out id))
            {
                container.EmployeesSet.Where(x => x.Id == id).ToList().ForEach(x =>
                    {
                        x.Salary = Convert.ToDouble(string.Format("{0}", e.NewValues["Salary"]).Replace(".", ","));
                    });
                string selectedJob = DropDownList.SelectedValue;
                int jobId = container.JobsSet.Where(x => x.JobsName == selectedJob).FirstOrDefault().Id;
               
                container.SaveChanges();
                gridView.EditIndex = -1;
                UpdateGrid(jobId);

            }
         
        }

        
        protected void GvSorting(object sender, GridViewSortEventArgs e)
        {
           
            //Переписать в метод Flip
            if (sortDirection.Value == "Ascending")
            {
                sortDirection.Value = "Descending";
            }
            else
            {
                sortDirection.Value = "Ascending";
            }

            IEnumerable<Employees> temp;
            string selectedJob = DropDownList.SelectedValue;
            int jobId = container.JobsSet.Where(x => x.JobsName == selectedJob).FirstOrDefault().Id;
            temp = container.EmployeesSet.Where(q => q.JobsId == jobId).ToList();
            gridView.DataBind();

            if (sortDirection.Value == "Descending")
            {
                if (e.SortExpression.Contains("LastName")) temp = temp.OrderByDescending(x => x.LastName);
                if (e.SortExpression.Contains("Salary")) temp = temp.OrderByDescending(x => x.Salary);
                sortDirection.Value = SortDirection.Descending.ToString();
            }
            else
            {
                if (e.SortExpression.Contains("LastName")) temp = temp.OrderBy(x => x.LastName);
                if (e.SortExpression.Contains("Salary")) temp = temp.OrderBy(x => x.Salary);
                sortDirection.Value = SortDirection.Ascending.ToString();
            }

            gridView.DataSource = temp.ToList();
            gridView.DataBind();

          
        }
        protected void Edit(object sender, GridViewEditEventArgs e)
        {
            gridView.EditIndex = e.NewEditIndex;
            string selectedJob = DropDownList.SelectedValue;
            int jobId = container.JobsSet.Where(x => x.JobsName == selectedJob).FirstOrDefault().Id;
               
            UpdateGrid(jobId);
        }

        protected void GvCanceling(object sender, GridViewCancelEditEventArgs e)
        {
            gridView.EditIndex = -1;
            string selectedJob = DropDownList.SelectedValue;
            int jobId = container.JobsSet.Where(x => x.JobsName == selectedJob).FirstOrDefault().Id;
               
            UpdateGrid(jobId);
        }

        
    }
}