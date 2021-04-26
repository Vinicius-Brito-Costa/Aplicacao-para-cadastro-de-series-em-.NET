using System;
using AplicativoSeries.Classes;
namespace AplicativoSeries
{
    class Program : LogHelper
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            bool repetir = true;
            while (repetir)
            {
                switch (ObterOpcaoUsuario())
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    case "X":
                        repetir = false;
                        break;
                    default:
                        Console.WriteLine("Opção invalida.");
                        break;
                }
            }
        }

        private static void VisualizarSerie()
        {
            ListarSeries();
            Series serie = repositorio.RetornaPorId(InputInt("Digite o id da serie: "));
            if(serie.RetornaExcluido()){
                Log("Nenhuma serie encontrada.");
            }
            else{
                Log(serie.Informacoes());
            }
        }

        private static void ExcluirSerie()
        {
            ListarSeries();
            repositorio.Excluir(InputInt("Digite o id da serie: "));
        }

        private static void AtualizarSerie()
        {
            ListarSeries();
            int id = InputInt("Digite o id da serie: ");
            repositorio.Atualiza(id, GerarSerie(false, id));
        }

        private static void InserirSerie()
        {
            repositorio.Insere(GerarSerie());
        }

        private static void ListarSeries()
        {
            var lista = repositorio.Lista();
            if(lista.Count == 0){
                Log("Nenhuma série cadastrada.");
            }
            lista.ForEach(serie =>{
                bool serieNaoExcluida = !serie.RetornaExcluido();
                if(serieNaoExcluida){
                    Log($"ID: {serie.RetornaId()} | Nome: {serie.RetornaTitulo()}");
                }
            });
        }
        private static Series GerarSerie(bool notAtt = true, int attId = 0)
        {
            int id = notAtt ? repositorio.ProximoId() : attId;
            string titulo = Input("Digite o titulo: ");
            Genero genero = ObterGenero();
            string descricao = Input("Digite a descricão: ");
            int ano = InputInt("Digite o ano: ");
            Series serie = new Series(id, genero, titulo, descricao, ano);
            return serie;
        }
        private static Genero ObterGenero()
        {
            string[] listaGenero = { "1 - Ação", "2 - Drama", "3 - Comedia", "4 - Terror", "5 - Documentario" };
            bool repetir = true;
            Genero opcao = Genero.Acao;
            while (repetir)
            {
                Display(listaGenero);
                switch (Input("Escolha o genero: "))
                {
                    case "1":
                        opcao = Genero.Acao;
                        repetir = false;
                        break;
                    case "2":
                        opcao = Genero.Drama;
                        repetir = false;
                        break;
                    case "3":
                        opcao = Genero.Comedia;
                        repetir = false;
                        break;
                    case "4":
                        opcao = Genero.Terror;
                        repetir = false;
                        break;
                    case "5":
                        opcao = Genero.Documentario;
                        repetir = false;
                        break;
                    default:
                        Log("A opção não é valida.");
                        break;
                }
            }
            return opcao;
        }

        private static string ObterOpcaoUsuario()
        {
            Log("");
            Log("Dev Séries a seu dispor!");
            Log("Informe a opção desejada:");
            Log("1 - Listar séries");
            Log("2 - Inserir nova série");
            Log("3 - Atualizar série");
            Log("4 - Excluir série");
            Log("5 - Visualizar série");
            Log("C - Limpar tela");
            Log("X - Sair");
            Log("");

            string opcaoUsuario = Input("Digite sua escolha: ").ToUpper();
            Log("");
            return opcaoUsuario;
        }
        private static int InputInt(string text){
            int valor = 0;
            bool repetir = true;
            while(repetir){
                bool result = Int32.TryParse(Input(text), out valor);
                if(result){
                    repetir = false;
                }
            }
            return valor;

        }
    }
}
