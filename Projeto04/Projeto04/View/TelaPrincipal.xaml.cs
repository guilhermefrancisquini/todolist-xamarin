using Projeto04.Database;
using Projeto04.Model;
using Projeto04.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Projeto04.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TelaPrincipal : ContentPage
    {
        public  Tarefa TarefaEdicao { get; set; }
        public TelaPrincipal()
        {
            InitializeComponent();

            BindingContext = new TelaPrincipalViewModel();

            BtnAdd.Clicked += delegate 
            {
                if (TarefaEdicao == null)
                {
                    var tarefa = new Tarefa { Nome = Tarefa.Text, Finalizado = false };
                    new TarefasDataAccess().SalvarTarefa(tarefa);
                }
                else
                {
                    TarefaEdicao.Nome = Tarefa.Text;
                    new TarefasDataAccess().AtualizarTarefa(TarefaEdicao);
                    TarefaEdicao = null;

                }
                Tarefa.Text = "";

                BindingContext = new TelaPrincipalViewModel();
            };
        }

        public void ExcluirTarefa(object sender, EventArgs e)
        {
            var tarefa = (((MenuItem)sender).CommandParameter) as Tarefa;

            new TarefasDataAccess().ExcluirTarefa(tarefa);

            BindingContext = new TelaPrincipalViewModel();
        }

        public void EditarTarefa(object sender, EventArgs e)
        {
            var tarefa = (((MenuItem)sender).CommandParameter) as Tarefa;

            Tarefa.Text = tarefa.Nome;
            TarefaEdicao = tarefa;
        }
    }
}