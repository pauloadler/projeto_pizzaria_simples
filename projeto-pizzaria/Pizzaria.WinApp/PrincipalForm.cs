using Pizzaria.WinApp.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Pizzaria.WinApp
{
    public partial class PrincipalForm : Form
    {
        private IGerenciadorFormulario _gerenciador;

        public PrincipalForm()
        {
            InitializeComponent();
           
        }

        private void CarregarCadastro(IGerenciadorFormulario gerenciador, string selecionado)
        {
            _gerenciador = gerenciador;

            UserControl listagem = _gerenciador.PegarControle();
            _gerenciador.CarregarListagem();

            EstadoBotoes estadoBotoes = _gerenciador.ObtemEstadoBotoes();
            TituloBotoes tituloBotoes = _gerenciador.ObtemTituloBotoes(selecionado);
            ModificarEstadoBotoes(estadoBotoes);
            ModificarTituloBotoes(tituloBotoes);

            listagem.Dock = DockStyle.Fill;

            panelControl.Controls.Clear();
            _gerenciador.LimparItemSelecionado();

            panelControl.Controls.Add(listagem);
        }

        private void ModificarEstadoBotoes(EstadoBotoes estadoBotoes)
        {
            ToolStripbtnGravar.Enabled = estadoBotoes.Gravar;
            ToolStripbtnEditar.Enabled = estadoBotoes.Editar;
            ToolStripbtnExcluir.Enabled = estadoBotoes.Excluir;
        }

        private void ModificarTituloBotoes(TituloBotoes tituloBotoes)
        {
            ToolStripbtnGravar.Text = tituloBotoes.Gravar;
            ToolStripbtnEditar.Text = tituloBotoes.Editar;
            ToolStripbtnExcluir.Text = tituloBotoes.Excluir;
        }


        private void ToolStripbtnGravar_Click(object sender, EventArgs e)
        {
            try
            {
                _gerenciador.Gravar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ToolStripbtnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                _gerenciador.Editar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ToolStripbtnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                _gerenciador.ItemSelecionado();
                var message = MessageBox.Show("Deseja excluir esse registro?", "Atenção!", MessageBoxButtons.YesNo);

                if (message == DialogResult.Yes)
                {
                    _gerenciador.Excluir();
                    MessageBox.Show("Registro deletado com sucesso!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PrincipalForm_Load(object sender, EventArgs e)
        {

        }
    }
}
