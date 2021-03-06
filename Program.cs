using System;

namespace videos.catalog
{
    class Program
    {
        static RepositorioSeries series = new RepositorioSeries();
        static RepositorioFilmes filmes = new RepositorioFilmes();

        static void Main(string[] args)
        {
            string opcaoUsuario = obterOpcaoUsuario("P");

            while(opcaoUsuario.ToUpper() != "X")
            {
                if(opcaoUsuario == "1")
                {
                    opcaoUsuario = obterOpcaoUsuario("S");

                    while(opcaoUsuario != "V")
                    {
                        switch(opcaoUsuario)
                        {
                            case "1":
                                listarSeries();
                                break;
                            case "2":
                                inserirSerie();
                                break;
                            case "3":
                                atualizarSerie();
                                break;
                            case "4":
                                excluirSerie();
                                break;
                            case "5":
                                visualizarSerie();
                                break;
                            case "C":
                                Console.Clear();
                                break;

                            default:
                                Console.WriteLine();
                                Console.WriteLine("Opção inválida. Informe um dos itens do menu.");
                                break;
                        } 

                        opcaoUsuario = obterOpcaoUsuario("S");               
                    }
                }
                else if(opcaoUsuario == "2")
                {
                    opcaoUsuario = obterOpcaoUsuario("F");

                    while(opcaoUsuario != "V")
                    {
                        switch(opcaoUsuario)
                        {
                            case "1":
                                listarFilmes();
                                break;
                            case "2":
                                inserirFilme();
                                break;
                            case "3":
                                atualizarFilme();
                                break;
                            case "4":
                                excluirFilme();
                                break;
                            case "5":
                                visualizarFilme();
                                break;
                            case "C":
                                Console.Clear();
                                break;

                            default:
                                Console.WriteLine();
                                Console.WriteLine("Opção inválida. Informe um dos itens do menu.");
                                break;
                        }
                        
                        opcaoUsuario = obterOpcaoUsuario("F");
                    }
                }
                else if(opcaoUsuario == "C")
                {
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Opção inválida. Informe um dos itens do menu.");
                } 

                opcaoUsuario = obterOpcaoUsuario("P");
            }

            Console.WriteLine();
            Console.WriteLine("Catálogo Fechado.");
            Console.WriteLine();
        }

        //===============================================================================
        // Métodos para manipulação dos menus de acesso
        //===============================================================================
        private static string obterOpcaoUsuario(string menuTipo)
        {
            switch(menuTipo)
            {
                case "P":
                    menuPrincipal();
                    break;
                case "S":
                    menuSeries();
                    break;
                case "F":
                    menuFilmes();
                    break;
                
                 default:
                    throw new ArgumentOutOfRangeException();
            }

            string opcaoUsuario = Console.ReadLine().ToUpper();

            return opcaoUsuario;
        }

        private static void menuPrincipal()
        {
            Console.WriteLine();
            Console.WriteLine("CATÁLOGO DE VÍDEOS");
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1 - Séries");
            Console.WriteLine("2 - Filmes");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();
        }

        private static void menuSeries()
        {
            Console.WriteLine();
            Console.WriteLine("CATÁLOGO DE SÉRIES");
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("V - Voltar");
            Console.WriteLine();
        }

        private static void menuFilmes()
        {
            Console.WriteLine();
            Console.WriteLine("CATÁLOGO DE FILMES");
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1 - Listar filmes");
            Console.WriteLine("2 - Inserir filme");
            Console.WriteLine("3 - Atualizar filme");
            Console.WriteLine("4 - Excluir filme");
            Console.WriteLine("5 - Visualizar filme");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("V - Voltar");
            Console.WriteLine();
        }

        //===============================================================================
        // Métodos para gestão de séries
        //===============================================================================

        private static void listarSeries()
        {
            Console.WriteLine();
            Console.WriteLine("Lista de Séries");

            var lista = series.listar();

            if(lista.Count == 0)
            {
                Console.WriteLine("Não existem séries cadastradas.");
                return; 
            }

            foreach(var serie in lista)
            {
                var excluido = serie.retornarExclusao();

                Console.WriteLine("#ID {0}: {1} {2}", serie.retornarId(), serie.retornarTitulo(), (excluido ? "(Registro Excluído)" : ""));
            }
        }

        private static Serie preencherSerie(int idSerie=-1)
        {
            try{
                Console.WriteLine("Título:");
                string titulo = Console.ReadLine();

                Console.WriteLine("Sinopse:");
                string sinopse = Console.ReadLine();

                Console.WriteLine("Gênero:");
                foreach(int i in Enum.GetValues(typeof(Genero)))
                {
                    Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
                }
                int genero = int.Parse(Console.ReadLine());
                while(!Enum.IsDefined(typeof(Genero), genero))
                {
                    Console.WriteLine();
                    Console.WriteLine("{0} não é um gênero valido. Informe uma opção da lista.", genero);
                    genero = int.Parse(Console.ReadLine());
                }

                Console.WriteLine("Canal:");
                foreach(int i in Enum.GetValues(typeof(Canal)))
                {
                    Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Canal), i));
                }
                int canal = int.Parse(Console.ReadLine());
                while(!Enum.IsDefined(typeof(Canal), canal))
                {
                    Console.WriteLine();
                    Console.WriteLine("{0} não é um canal valido. Informe uma opção da lista.", canal);
                    canal = int.Parse(Console.ReadLine());
                }

                Console.WriteLine("Status:");
                foreach(int i in Enum.GetValues(typeof(SerieStatus)))
                {
                    Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(SerieStatus), i));
                }
                int status = int.Parse(Console.ReadLine());
                while(!Enum.IsDefined(typeof(SerieStatus), status))
                {
                    Console.WriteLine();
                    Console.WriteLine("{0} não é um status valido. Informe uma opção da lista.", status);
                    status = int.Parse(Console.ReadLine());
                }

                Console.WriteLine("Ano Início:");
                int inicio = int.Parse(Console.ReadLine());

                Console.WriteLine("Ano Fim: (informe '0' se série ainda estiver em andamento)");
                int fim = int.Parse(Console.ReadLine());

                Serie registro = new Serie(id: (idSerie < 0)? series.proximoId() : idSerie,
                                           genero: (Genero)genero,
                                           canal: (Canal)canal,
                                           status: (SerieStatus)status,
                                           titulo: titulo,
                                           sinopse: sinopse,
                                           anoInicio: inicio,
                                           anoFim: fim);

                return registro;
            }
            catch(FormatException){
                Console.WriteLine();
                Console.WriteLine("Entrada inválida. Preenchimento cancelado.");

                return null;
            }
        }

        private static void inserirSerie()
        {
            Console.WriteLine();
            Console.WriteLine("Cadastro de Série");

            Serie insercao = preencherSerie();

            series.inserir(insercao);
        }

        private static void atualizarSerie()
        {
            Console.WriteLine();
            Console.WriteLine("Atualização de Série");
            Console.WriteLine("Informe o ID da série que deseja atualizar");

            try{
                int idSerie = int.Parse(Console.ReadLine());

                if(series.verificaId(idSerie))
                {
                    Serie atualizacao = preencherSerie(idSerie);

                    series.atualizar(idSerie, atualizacao);
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("ID não encontrado.");
                }
            }
            catch(FormatException){
                Console.WriteLine();
                Console.WriteLine("Entrada inválida.");
            }
        }

        private static void excluirSerie()
        {
            Console.WriteLine();
            Console.WriteLine("Exclusão de Série");
            Console.WriteLine("Informe o ID da série que deseja excluir");

            try{
                int idSerie = int.Parse(Console.ReadLine());

                if(series.verificaId(idSerie))
                {
                    Console.WriteLine();
                    Console.WriteLine("Confirma exclusão do registro? (Digite 's' para confirmar. Para cancelar, pressione qualquer outra tecla.)");
                    string confirma = Console.ReadLine().ToUpper();

                    if(confirma == "S")
                    {
                        series.excluir(idSerie);

                        Console.WriteLine();
                        Console.WriteLine("Registro excluído.");
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Exclusão cancelada.");
                    }
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("ID não encontrado.");
                }
            }
            catch(FormatException){
                Console.WriteLine();
                Console.WriteLine("Entrada inválida.");
            }
        }

        private static void visualizarSerie()
        {
            Console.WriteLine();
            Console.WriteLine("Visualização de Série");
            Console.WriteLine("Informe o ID da série que deseja visualizar");

            try{
                int idSerie = int.Parse(Console.ReadLine());

                if(series.verificaId(idSerie))
                {
                    var serie = series.retornarPorId(idSerie);

                    Console.WriteLine();
                    Console.WriteLine(serie);
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("ID não encontrado.");
                }
            }
            catch(FormatException){
                Console.WriteLine();
                Console.WriteLine("Entrada inválida.");
            }
        }

        //===============================================================================
        // Métodos para gestão de filmes
        //===============================================================================

        private static void listarFilmes()
        {
            Console.WriteLine();
            Console.WriteLine("Lista de Filmes");

            var lista = filmes.listar();

            if(lista.Count == 0)
            {
                Console.WriteLine("Não existem filmes cadastrados.");
                return; 
            }

            foreach(var filme in lista)
            {
                var excluido = filme.retornarExclusao();

                Console.WriteLine("#ID {0}: {1} {2}", filme.retornarId(), filme.retornarTitulo(), (excluido ? "(Registro Excluído)" : ""));
            }
        }

        private static Filme preencherFilme(int idFilme=-1)
        {
            try{
                Console.WriteLine("Título:");
                string titulo = Console.ReadLine();

                Console.WriteLine("Sinopse:");
                string sinopse = Console.ReadLine();

                Console.WriteLine("Gênero:");
                foreach(int i in Enum.GetValues(typeof(Genero)))
                {
                    Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
                }
                int genero = int.Parse(Console.ReadLine());
                while(!Enum.IsDefined(typeof(Genero), genero))
                {
                    Console.WriteLine();
                    Console.WriteLine("{0} não é um gênero valido. Informe uma opção da lista.", genero);
                    genero = int.Parse(Console.ReadLine());
                }

                Console.WriteLine("Direção:");
                string direcao = Console.ReadLine();

                Console.WriteLine("Duração: (em minutos)");
                int duracao = int.Parse(Console.ReadLine());

                Console.WriteLine("Ano:");
                int ano = int.Parse(Console.ReadLine());

                Filme registro = new Filme(id: (idFilme < 0)? filmes.proximoId() : idFilme,
                                           genero: (Genero)genero,
                                           titulo: titulo,
                                           sinopse: sinopse,
                                           direcao: direcao,
                                           duracao: duracao,
                                           ano: ano);

                return registro;
            }
            catch(FormatException){
                Console.WriteLine();
                Console.WriteLine("Entrada inválida. Preenchimento cancelado.");

                return null;
            }
        }

        private static void inserirFilme()
        {
            Console.WriteLine();
            Console.WriteLine("Cadastro de Filme");

            Filme insercao = preencherFilme();

            filmes.inserir(insercao);
        }

        private static void atualizarFilme()
        {
            Console.WriteLine();
            Console.WriteLine("Atualização de Filme");
            Console.WriteLine("Informe o ID do filme que deseja atualizar");

            try{
                int idFilme = int.Parse(Console.ReadLine());

                if(filmes.verificaId(idFilme))
                {
                    Filme atualizacao = preencherFilme(idFilme);

                    filmes.atualizar(idFilme, atualizacao);
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("ID não encontrado.");
                }
            }
            catch(FormatException){
                Console.WriteLine();
                Console.WriteLine("Entrada inválida.");
            }
        }

        private static void excluirFilme()
        {
            Console.WriteLine();
            Console.WriteLine("Exclusão de Filme");
            Console.WriteLine("Informe o ID do filme que deseja excluir");

            try{
                int idFilme = int.Parse(Console.ReadLine());

                if(filmes.verificaId(idFilme)){
                    Console.WriteLine();
                    Console.WriteLine("Confirma exclusão do registro? (Digite 's' para confirmar. Para cancelar, pressione qualquer outra tecla.)");
                    string confirma = Console.ReadLine().ToUpper();

                    if(confirma == "S")
                    {
                        filmes.excluir(idFilme);

                        Console.WriteLine();
                        Console.WriteLine("Registro excluído.");
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Exclusão cancelada.");
                    }
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("ID não encontrado.");
                }
            }
            catch(FormatException){
                Console.WriteLine();
                Console.WriteLine("Entrada inválida.");
            }
        }

        private static void visualizarFilme()
        {
            Console.WriteLine();
            Console.WriteLine("Visualização de Filme");
            Console.WriteLine("Informe o ID do filme que deseja visualizar");

            try{
                int idFilme = int.Parse(Console.ReadLine());

                if(filmes.verificaId(idFilme))
                {
                    var filme = filmes.retornarPorId(idFilme);

                    Console.WriteLine();
                    Console.WriteLine(filme);
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("ID não encontrado.");
                }
            }
            catch(FormatException){
                Console.WriteLine();
                Console.WriteLine("Entrada inválida.");
            }
        }
    }
}
