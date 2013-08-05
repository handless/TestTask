using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace TestTask
{
    public class Configuration
    {

        // Класс для парсинга хмл и возвращаем данные

        public void ChangeConnectionString( string someString )
        { 
      
            //брать не из текстбокса а из хмл файла.

    //        <div>
    //    Connection name:<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><br />
    //    Connection string:<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox><br />
    //    Provider name:<asp:TextBox ID="TextBox3" runat="server">System.Data.SqlClient</asp:TextBox><br />
    //    <asp:Button ID="Button1" runat="server" Text="Button"
    //        onclick="Button1_Click1" />
    //</div>

            var configuration = WebConfigurationManager.OpenWebConfiguration("~");
         var section = (ConnectionStringsSection)configuration.GetSection("connectionStrings");
        //section.ConnectionStrings.Add(
           // new ConnectionStringSettings(TextBox1.Text, TextBox2.Text, TextBox3.Text)
           // );
        configuration.Save();

            
        }
    }
}