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
        //public List<Employees> Employeess
        //{
        //    get
        //    {
        //    ////получение ключа для поиска во ViewState
        //    //   //В принципе этот ключ и не нужен.. он лишь обеспечивает "поиск на определенной странице" 
        //    //    var str = hfEmployeesViewState.Value;
        //    //   // var str = "das"; //если так написать тоже будет работать
        //    //    if (string.IsNullOrEmpty(str))
        //    //    {
        //    //        hfEmployeesViewState.Value = string.Format("Employees_{0}", Guid.NewGuid());
        //    //        str = hfEmployeesViewState.Value;
        //    //    }

        //    //    if (ViewState[str]== null || !(ViewState[str] is List<Employees>))
        //    //    {
        //    //        var employees = new List<Employees>
        //    //                            {
        //    //                                new Employees{Id = 1 , LastName = "Puscha", FirstName="Ivan"},
        //    //                                new Employees{Id = 2 , LastName = "Bevza", FirstName="Julia"}
        //    //                            };
        //    //        ViewState[str] = employees;
        //    //        return employees;
        //    //    }
        //    //    return ViewState[str] as List<Employees>;
        //    }
        //    set
        //    {
        //        var str = hfEmployeesViewState.Value;
        //        if (string.IsNullOrEmpty(str))
        //        {
        //            hfEmployeesViewState.Value = string.Format("Employees_{0}",Guid.NewGuid());
        //            str = hfEmployeesViewState.Value;
        //        }
        //        ViewState[str] = value;
        //    }
        //}

        #region события
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UpdateGrid();
            }

        }

        protected void Page_Init(object sender, EventArgs e)
        {
            gridView.DataSource = container.EmployeesSet.Where(q => q.Id > 0).ToList();
        }

        
        #endregion

        private void UpdateGrid()
        {
           // gridView.DataSourceID = "ods";
            gridView.DataSource = container.EmployeesSet.Where(x => x.Id > 0).ToList();
           // gridView.DataSourceID = string.Empty;
            gridView.DataBind();
            
        }

        //Не работает
        protected void gvPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
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
                container.SaveChanges();
                gridView.EditIndex = -1;
                UpdateGrid();

            }
            //int id;
            //if (int.TryParse(string.Format("{0}",e.Keys["Id"]), out id))
            //{
            //    Employeess.Where(x => x.Id == id).ToList().ForEach(x =>
            //        {
            //            x.FirstName = string.Format("{0}", e.NewValues["FirstName"]);
            //            x.LastName = string.Format("{0}", e.NewValues["LastName"]);
            //        });
            //    gv.EditIndex = -1;
            //    UpdateGrid();
            //}
        }

        private string ConvertSortDirectionToSql(SortDirection sortDirection)
        {
            string newSortDirection = String.Empty;

            switch (sortDirection)
            { 
                case SortDirection.Ascending:
                    newSortDirection = "ASC";
                    break;
                case SortDirection.Descending:
                    newSortDirection = "DESC";
                    break;
                
            }

            return newSortDirection;
        }

        public IEnumerable<Employees> GetEmployees(int id, string employeesFilter, string modelFilter, int maximumRows, int startRowIndex, string sort)
        {
            IEnumerable<Employees> temp = container.EmployeesSet.Where(x => x.Id > 0);

            if(sort.Contains("DESC"))
            {
                if(sort.Contains("Salary")) temp = temp.OrderByDescending(x=>x.Salary);

            }
            else 
            {
                if (sort.Contains("Salary")) temp = temp.OrderBy(x=>x.Salary);
            }
            return temp;
        
        }

        //private string f = "";
        //private SortDirection d = SortDirection.Ascending;
        //private void GridViewSortDirection(GridView g, GridViewSortEventArgs e, out SortDirection sortDirection, out string field)
        //{
        //    field = e.SortExpression;
        //    sortDirection = e.SortDirection;

        //    if (g.Attributes["CurrentSortField"] != null && g.Attributes["CurrentSortDir"] != null)
        //    {
        //        if (field == g.Attributes["CurrentSortField"])
        //        {
        //            sortDirection = SortDirection.Descending;
        //            if (g.Attributes["CurrentSortDir"] == "ASC")
        //            {
        //                sortDirection = SortDirection.Ascending;
        //            }
        //        }
        //        g.Attributes["CurrentSortField"] = field;
        //        g.Attributes["CurrentSortDir"] = (sortDirection == SortDirection.Ascending ? "DESC" : "ASC");
        //    }
        //}

        protected void GvSorting(object sender, GridViewSortEventArgs e)
        {
           
            if (sortDirection.Value == "Ascending")
            {
                sortDirection.Value = "Descending";
            }
            else
            {
                sortDirection.Value = "Ascending";
            }
         

            IEnumerable<Employees> temp = container.EmployeesSet.Where(x => x.Id > 0);
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

           // //gridView.DataSource = container.EmployeesSet.Where(q => q.Id > 3).ToList();
           // var Test = gridView.DataSource;

           // //gridView.DataBind();
           // //gridView.DataSourceID = "ods";
           //// Console.WriteLine(gridView.DataSource);
           // DataTable dataTable = (DataTable)Test ;

           // if (dataTable != null)
           // {
           //     DataView dataView = new DataView(dataTable);
           //     dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);

           //     gridView.DataSource = dataView;
           //     gridView.DataBind();
           // }
        }
        protected void Edit(object sender, GridViewEditEventArgs e)
        {
            gridView.EditIndex = e.NewEditIndex;
            
            UpdateGrid();
        }

        protected void GvCanceling(object sender, GridViewCancelEditEventArgs e)
        {
            gridView.EditIndex = -1;
            UpdateGrid();
        }
    }
}