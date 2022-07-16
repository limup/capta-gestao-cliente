using Capta_Tecnologia.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capta_Tecnologia
{
    public partial class frmCapta : Form
    {
        List<Cliente> clientes = new List<Cliente>();

        public frmCapta()
        {
            InitializeComponent();
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            frmCadastroCliente frm = new frmCadastroCliente(null, Global.Global.Metodo.Cadastrar);

            try
            {
                frm.Show();
                frm.frmCaptaReferencia = this;
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("Evento: {0}, Erro: {1}", "btnCliente_Click", ex.Message));
                MessageBox.Show("Erro interno do aplicativo, contatar desenvolvedor.");
            }
        }

        private void lstvCLientes_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            using (var client = new HttpClient())
            {
                try
                {
                    //var response = client.GetStringAsync(ConfigurationManager.AppSettings["UrlBase"]);
                    
                }
                catch (Exception ex)
                {

                    throw;
                }

                
            }
        }

        private void frmCapta_Load(object sender, EventArgs e)
        {
            carregaTabelaClientes();
        }

        public async void carregaTabelaClientes()
        {
            var metodo = Global.Global.Metodo.Listar.ToString();
            var result = String.Empty;

            using (var client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync(ConfigurationManager.AppSettings["UrlBase"] + metodo);

                    if (response.IsSuccessStatusCode)
                    {
                        result = await response.Content.ReadAsStringAsync();

                        clientes = JsonConvert.DeserializeObject<List<Cliente>>(result);

                        //Preenche ListView
                        lstvCLientes.View = View.Details;

                        lstvCLientes.Columns.Add("Id");
                        lstvCLientes.Columns.Add("Nome");
                        lstvCLientes.Columns.Add("CPF");
                        lstvCLientes.Columns.Add("Sexo");
                        lstvCLientes.Columns.Add("Tipo");
                        lstvCLientes.Columns.Add("Situação");

                        if (clientes == null)
                        {
                            return;
                        }

                        foreach (var item in clientes)
                        {
                            foreach (var dom in item.tbDominios)
                            {
                                lstvCLientes.Items.Add(new ListViewItem(new string[] {
                                item.Id.ToString(),
                                item.Nome,
                                item.Cpf.ToString(),
                                item.Sexo,
                                dom.Tipo,
                                dom.Situacao.ToString()
                            }));
                            }
                        }


                        lstvCLientes.GridLines = true;
                        lstvCLientes.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                        lstvCLientes.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                        lstvCLientes.Columns[0].Width = 0;

                        //MessageBox.Show(result);
                    }
                    else
                    {
                        result = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Erro: " + result);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(string.Format("Método: {0}, Erro: {1}", metodo, ex.Message));
                    MessageBox.Show("Erro interno do aplicativo, contatar desenvolvedor.");
                }
            }
        }

        private async void lstvCLientes_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                DialogResult r = MessageBox.Show("Deseja Excluir?", "Excluir ou Alterar", MessageBoxButtons.YesNoCancel);
                int id = Convert.ToInt32(lstvCLientes.Items[e.ItemIndex].SubItems[0].Text);

                if (r == DialogResult.Yes)
                {
                    var metodo = Global.Global.Metodo.Deletar.ToString();
                    var result = String.Empty;

                    using (var client = new HttpClient())
                    {
                        try
                        {
                            var response = await client.DeleteAsync(ConfigurationManager.AppSettings["UrlBase"] + metodo + String.Format("/{0}", id));

                            if (response.IsSuccessStatusCode)
                            {
                                result = await response.Content.ReadAsStringAsync();
                                MessageBox.Show(result);
                            }
                            else
                            {
                                result = await response.Content.ReadAsStringAsync();
                                MessageBox.Show("Erro: " + result);
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(string.Format("Método: {0}, Erro: {1}", metodo, ex.Message));
                            MessageBox.Show("Erro interno do aplicativo, contatar desenvolvedor.");
                        }
                        finally
                        {
                            lstvCLientes.Clear();
                            carregaTabelaClientes();
                        }
                    }
                }

                else
                {
                    //MessageBox.Show(e.ItemIndex.ToString());
                    Cliente cliente = clientes.Where(x => x.Id.Equals(id)).FirstOrDefault();

                    frmCadastroCliente frm = new frmCadastroCliente(cliente, Global.Global.Metodo.Atualizar);
                    frm.Show();
                    frm.frmCaptaReferencia = this;

                }
            }
        }
    }
}
