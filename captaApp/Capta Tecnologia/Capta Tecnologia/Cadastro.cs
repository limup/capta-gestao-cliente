using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Capta_Tecnologia.Models;
using Capta_Tecnologia.Global;
using Caelum.Stella.CSharp.Validation;

namespace Capta_Tecnologia
{
    public partial class frmCadastroCliente : Form
    {
        public frmCapta frmCaptaReferencia = null; 

        private Cliente _cliente = new Cliente();
        private List<Dominio> _dominios = new List<Dominio>();

        private Global.Global.Metodo _metodo = new Global.Global.Metodo();

        public frmCadastroCliente(Cliente cliente, Global.Global.Metodo metodo)
        {
            if (cliente != null)
            {
                _cliente = cliente;
                _metodo = metodo;
            }

            InitializeComponent();
            InitializaFilds();
        }

        private void InitializaFilds()
        {
            if (_metodo.Equals(Global.Global.Metodo.Atualizar))
            {
                txtNome.Text = _cliente.Nome;
                txtCpf.Text = _cliente.Cpf.ToString();

                cmbSexo.SelectedIndex = (int)Enum.Parse(typeof(Global.Global.Sexo), _cliente.Sexo);
                cmbTipo.SelectedIndex = (int)Enum.Parse(typeof(Global.Global.Tipo), _cliente.tbDominios.First().Tipo.ToString());
                
                if (_cliente.tbDominios.First().Situacao)
                {
                    cmbSituacao.SelectedIndex = 1;
                }
                else
                {
                    cmbSituacao.SelectedIndex = 0;
                }

            }
        }

        private async void btnCadastrarCliente_Click(object sender, EventArgs e)
        {
            //Valida campos
            if (ValidaCPF(txtCpf.Text).Equals(false))
                return;

            if (txtCpf.Text.Equals(string.Empty))
            {
                MessageBox.Show("Campo CPF vazio!");
                return;
            }

            if (txtNome.Text.Equals(string.Empty))
            {
                MessageBox.Show("Campo Nome vazio!");
                return;
            }

            if (cmbSexo.SelectedIndex == -1)
            {
                MessageBox.Show("Combo Sexo vazio!");
                return;
            }

            if (cmbTipo.SelectedIndex == -1)
            {
                MessageBox.Show("Combo Tipo vazio!");
                return;
            }

            if (cmbSituacao.SelectedIndex == -1)
            {
                MessageBox.Show("Combo Situação vazio!");
                return;
            }

            var sexo = Convert.ToString((Global.Global.Sexo)cmbSexo.SelectedIndex);
            var tipo = Convert.ToString((Global.Global.Tipo)cmbTipo.SelectedIndex);
            var situacao = Convert.ToBoolean((Global.Global.Situacao)cmbSituacao.SelectedIndex);

            _dominios.Add(new Dominio(0, tipo.ToString(), situacao));

            _cliente.Nome = txtNome.Text;
            _cliente.Cpf = Convert.ToInt64(txtCpf.Text);
            _cliente.Sexo = sexo;
            _cliente.tbDominios = _dominios;
            

            var json = JsonConvert.SerializeObject(_cliente);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var metodo = _metodo.ToString();
            var result = String.Empty;
            HttpResponseMessage response = null;

            using (var client = new HttpClient())
            {
                try
                {

                    if (_metodo.Equals(Global.Global.Metodo.Cadastrar))
                    {
                        response = await client.PostAsync(ConfigurationManager.AppSettings["UrlBase"] + metodo, data);
                    }
                    else if(_metodo.Equals(Global.Global.Metodo.Atualizar))
                    {
                        response = await client.PutAsync(ConfigurationManager.AppSettings["UrlBase"] + metodo, data);
                    }

                    if (response.IsSuccessStatusCode)
                    {
                        result = await response.Content.ReadAsStringAsync();
                        MessageBox.Show(result);

                        //Atualiza Tabela
                        frmCaptaReferencia.lstvCLientes.Clear();
                        frmCaptaReferencia.carregaTabelaClientes();

                        this.Close();
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

        public Boolean ValidaCPF(string cpf)
        {

            try
            {
                //Validação CPF
                new CPFValidator().AssertValid(cpf);
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("Método: {0}, Erro: {1}", "validaCPF", ex.Message));
                MessageBox.Show("CPF inválido!");
                return false;
            }
        }

        private void txtCpf_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtCpf.Text, "[^0-9]"))
            {
                MessageBox.Show("Somente números!");
                txtCpf.Text = txtCpf.Text.Remove(txtCpf.Text.Length - 1);
            }
        }

        private void frmCadastroCliente_Load(object sender, EventArgs e)
        {

        }
    }
}
