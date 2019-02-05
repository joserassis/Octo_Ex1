﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Ex1
{
    public partial class Main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                dataTable();
        }

        private void dataTable()
        {
            conexao a = new conexao();
            dt.AutoGenerateEditButton = true;
            dt.AutoGenerateDeleteButton = true;
            dt.DataSource = a.myDataTable();
            dt.DataBind();
        }
              
        protected void dt_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = e.RowIndex;
            id = dt.Rows[index].Cells[1].Text;

            string query = "delete Endereco where id = " + id + "; " +
                    " delete Telefone where id=" + id + ";" +
                    " delete clientes where id=" + id;

            conexao con = new conexao();
            bool ok = con.myComandoRetornoLogico(query);
            Response.Redirect(Request.RawUrl);
        }

        string id;
        protected void dt_RowEditing(object sender, GridViewEditEventArgs e)
        {            
            int index = e.NewEditIndex;
            id = dt.Rows[index].Cells[1].Text;
            ConfigurationManager.AppSettings["idCliente"] = id;
            string tDoc, nDoc;
            conexao a = new conexao();
            string query = "select c.nome, c.documento, c.tipodoc, t.numero, t.tipo, e.endereco, e.tipo from clientes c" +
            " inner join Telefone t on t.id = c.id" +
            " inner join Endereco e on e.id = c.id where c.id = " + id;

            SqlDataReader dr = a.myDataReader(query);
            if (dr.HasRows)
                while (dr.Read())
                {
                    nome.Value = dr[0].ToString();
                    tDoc = dr[2].ToString();
                    nDoc = dr[1].ToString();
                    if (tDoc == "CPF")
                    { cpf.Value = nDoc; radio1.Checked = true; }
                    else
                    { cnpj.Value = nDoc; radio2.Checked = true; }

                    tipotel.Value = dr[4].ToString();
                    tel.Value = dr[3].ToString();
                    end.Value = dr[5].ToString();
                    tipoend.Value = dr[6].ToString();
                }

            //foreach (Control c in dt.Rows[e.NewEditIndex].Controls)
            //{
            //    if (c is DataControlFieldCell)
            //        (c as DataControlFieldCell).Enabled = false;
            //}
            btnCancel.Visible = true;
            //Response.Redirect(Request.RawUrl);
            dt.Enabled = false;
        }

        protected void Cancel(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void Save(object sender, EventArgs e)
        {
            Cliente c = new Cliente();
            c.nome = nome.Value.ToString();
            c.tipoDoc = radio1.Checked ? "CPF" : "CNPJ";
            c.doc = radio1.Checked ? cpf.Value.ToString() : cnpj.Value.ToString();
            c.tipoTel = tipotel.Value.ToString();
            c.tel = tel.Value.ToString();
            c.tipoEnd = tipoend.Value.ToString();
            c.end = end.Value.ToString();

            if (string.IsNullOrEmpty(ConfigurationManager.AppSettings["idCliente"]))
            {
                string query = "insert into clientes values ('" + c.nome + "', '" + c.doc + "', '" + c.tipoDoc + "'); declare @a int; set @a = scope_identity(); " +
                    " insert into Endereco values (@a, '" + c.end + "', '" + c.tipoEnd + "');" +
                    " insert into Telefone values (@a, '" + c.tel + "', '" + c.tipoTel + "')";

                conexao con = new conexao();
                bool ok = con.myComandoRetornoLogico(query);
            }
            else
            {                
                id = ConfigurationManager.AppSettings["idCliente"];
                string query = "update clientes set nome ='" + c.nome + "', documento = '" + c.doc + "', tipodoc = '" + c.tipoDoc + "' where id = " + id + "; " +
                    " update Endereco set endereco ='" + c.end + "', tipo='" + c.tipoEnd + "' where id=" + id + ";" +
                    " update Telefone set numero ='" + c.tel + "', tipo='" + c.tipoTel + "' where id=" + id;

                conexao con = new conexao();
                bool ok = con.myComandoRetornoLogico(query);
            }

            ConfigurationManager.AppSettings["idCliente"] = "";

            btnCancel.Visible = false;
            Response.Redirect(Request.RawUrl);
        }

        public class Cliente
        {
            public string nome { get; set; }
            public string doc { get; set; }
            public string tipoDoc { get; set; }
            public string tel { get; set; }
            public string tipoTel { get; set; }
            public string end { get; set; }
            public string tipoEnd { get; set; }
        }

        protected void dt_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dt.PageIndex = e.NewPageIndex;

            //rebind your gridview - GetSource(),Datasource of your GirdView
            dataTable();
        }

        protected void dt_PageIndexChanged(object sender, EventArgs e)
        {

        }
    }
}