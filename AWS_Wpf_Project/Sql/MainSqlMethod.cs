using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using AWS_Wpf_Project.Interface;
using AWS_Wpf_Project.Services;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWS_Wpf_Project.Sql
{
    public class MainSqlMethod
    {
        /// <summary>
        /// Сервис для отображения сообщений.
        /// </summary>
        public IMessagable MessageService { get; set; }

        public MainSqlMethod()
        {
            MessageService = new StandartMessageService();
        }

        public MainSqlMethod(IMessagable messageService)
        {
            this.MessageService = messageService;
        }

        public DataTable LoadData(string sqlRequest)
        {
            using (SqlConnection conn = new SqlConnection(Connection.MainConnection.MainConn))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        string commandText = sqlRequest;
                        cmd.CommandText = commandText;

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);

                        return ds.Tables[0];
                    }
                }
                catch (Exception ex)
                {
                    MessageService.ShowErrorMessage("Sql error on LoadData", ex.Message);
                    return null;
                }
            }
        }
    }
}
