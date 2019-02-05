using System.Data;
using System;
using System.Data.SqlClient;
using System.Web;

namespace Ex1
{
    public class conexao
    {
        private SqlConnection con = new SqlConnection();
        private SqlDataAdapter dap = new SqlDataAdapter();
        private SqlDataReader dataReaderMy;
        private SqlCommand com;
        
        private DataTable dat = new DataTable();
        

        public void ConexaoSql()
        {
            string sistemaTeste;

            sistemaTeste = "s";

            if (sistemaTeste == "s")
            {

            }
            else
            {

            }
            conectar();
        }

        public bool conectar()
        {
            if ((con.State == ConnectionState.Broken) || (con.State == ConnectionState.Closed))
            {
                try
                {
                    this.con.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + HttpContext.Current.Server.MapPath(".") + "\\App_Data\\octo.mdf;Integrated Security=True";
                    this.con.Open();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
                return true;
        }

        public void fechar()
        {
            if ((con.State == ConnectionState.Open) || (con.State == ConnectionState.Executing) || (con.State == ConnectionState.Fetching))
            {
                con.Close();
                con.Dispose();
                con = null;
            }
        }

        public SqlDataReader myDataReader(string sql)
        {
            try
            {
                this.conectar();
                this.com = new SqlCommand(sql, con);
                this.dataReaderMy = com.ExecuteReader();
                return this.dataReaderMy;
            }
            catch (Exception e)
            {
                return this.dataReaderMy;
            }
        }

        public void myComandoSemRetorno(string sql)
        {
            try
            {
                this.conectar();
                this.com = new SqlCommand(sql, con);
                this.com.ExecuteNonQuery();
            }
            catch
            {

            }
        }

        public bool myComandoRetornoLogico(string sql)
        {
            try
            {
                this.conectar();
                this.com = new SqlCommand(sql, con);
                this.com.ExecuteNonQuery();
                return true;
            }
            catch (Exception a)
            {
                return false;
            }
        }

        public DataTable myDataTable()
        {
            string[] dados = new string[7];

            try
            {
                string sql = "select c.id, c.nome as Nome, c.documento as Documento, e.endereco as Endereço, e.tipo as 'Tipo End.', t.numero as Telefone, t.tipo as 'Tipo Tel.' from clientes c " +
                    " inner join telefone t on t.id = c.id " +
                    " inner join endereco e on e.id = c.id ";
                this.conectar();
                this.com = new SqlCommand(sql, con);
                this.com.CommandType = CommandType.Text;
                this.com.CommandText = sql;
                dap.SelectCommand = this.com;
                dap.Fill(dat);
                dap.Dispose();
                return dat;
            }
            catch (Exception e)
            {
                return dat;
            }
            
        }

        public DataTable myDataTable(string sql)
        {
            try
            {
                this.conectar();
                this.com = new SqlCommand(sql, con);
                this.com.CommandType = CommandType.Text;
                this.com.CommandText = sql;
                dap.SelectCommand = this.com;
                dap.Fill(dat);
                dap.Dispose();
                return dat;
            }
            catch
            {
                return dat;
            }
        }
    }
}
