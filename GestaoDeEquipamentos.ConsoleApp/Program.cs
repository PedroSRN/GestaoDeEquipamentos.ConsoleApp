using System;

namespace GestaoDeEquipamentos.ConsoleApp
{
    internal class Program
    {
        static string opcao, opcaoChamados; //variavel global
        static int registro = 1000; //quantidades de produtos do array
        static int chamados = 1000; //quantidade de chamados do array

        static void Main(string[] args)
        {
            bool continuarNoMenu = true;

            #region Criação dos Arrays - EQUIPAMENTOS
            int[] idArray = new int[registro];
            string[] nomesEquipamentos = new string[registro];
            decimal[] precoEquipamentos = new decimal[registro];
            string[] numeroDeSerieEquipamento = new string[registro];
            string[] dataFabricacao = new string[registro];
            string[] fabricantes = new string[registro];
            #endregion

            #region Criação dos Arrays - CHAMADOS
            int[] idArrayChamado = new int[chamados];
            string[] tituloChamado = new string[chamados];
            string[] descricaoChamado = new string[chamados];
            string[] nomesEquipamentosChamados = new string[chamados]; //REFERENCIAR NOME EQUIPAMENTOS
            string[] dataAberturaChamado = new string[chamados];
            #endregion


            Menu();
            while (true)
            {
                continuarNoMenu = true;
                if (opcao == "1")
                {
                    RegistroDeEquipamentos(ref idArray, ref nomesEquipamentos, ref precoEquipamentos, ref numeroDeSerieEquipamento, ref dataFabricacao, ref fabricantes);
                }
                if (opcao == "2")
                {
                    VisualizarEquipamentos(idArray, nomesEquipamentos, numeroDeSerieEquipamento, fabricantes);
                    Menu();
                }
                if (opcao == "3")
                {
                    EditarEquipamentos(ref idArray, ref nomesEquipamentos, ref precoEquipamentos, ref numeroDeSerieEquipamento, ref dataFabricacao, ref fabricantes);
                }
                if (opcao == "4")
                {
                    ExcluirEquipamentos(ref idArray, ref nomesEquipamentos, ref precoEquipamentos, ref numeroDeSerieEquipamento, ref dataFabricacao, ref fabricantes, ref nomesEquipamentosChamados);
                }
                if (opcao == "5")
                {
                    MenuControleDeChamados();

                    while (continuarNoMenu)
                    {
                        if (opcaoChamados == "1")
                        {
                            RegistrarChamados(ref idArrayChamado, ref tituloChamado, ref descricaoChamado, ref nomesEquipamentosChamados, ref dataAberturaChamado, ref nomesEquipamentos/*ref nome*/);
                        }
                        if (opcaoChamados == "2")
                        {
                            VisualizarChamados(idArrayChamado, tituloChamado, nomesEquipamentosChamados, dataAberturaChamado);
                            MenuControleDeChamados();
                        }
                        if (opcaoChamados == "3")
                        {
                            EditarChamados(ref idArrayChamado, ref tituloChamado, ref descricaoChamado, ref nomesEquipamentosChamados, ref dataAberturaChamado, ref nomesEquipamentos);
                        }
                        if (opcaoChamados == "4")
                        {
                            ExcluirChamados(ref idArrayChamado, ref tituloChamado, ref descricaoChamado, ref nomesEquipamentosChamados, ref dataAberturaChamado, ref nomesEquipamentos);
                        }
                        if (opcaoChamados == "0")// opção voltar para o menu inicial
                        {
                            Console.ResetColor();
                            continuarNoMenu = false;
                            Menu();
                        }
                    }
                }
               

                if (opcao == "0")//opção sair do programa
                {
                    break;
                }
            }
        }

        #region Controle de equipamentos

        static void Menu()
        {                            //Menu 2.0
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Clear();
            Console.WriteLine("          Controle de Equipamentos");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine(" * 1 * Para Registrar um novo equipamento *");
            Console.WriteLine(" * 2 * Para Visualizar os equipamentos cadastrados *");
            Console.WriteLine(" * 3 * Para Editar um equipamento *");
            Console.WriteLine(" * 4 * Para Excluir um equipamento *");
            Console.WriteLine(" * 5 * Para - CONTROLE DE CHAMADOS *");
            Console.WriteLine(" * 0 * Para Sair do Programa *");
            Console.WriteLine("-------------------------------------------------");

            opcao = Console.ReadLine();

        }

        static void RegistroDeEquipamentos(ref int[] idArray, ref string[] nomesEquipamentos, ref decimal[] precoEquipamentos, ref string[] numeroDeSerieEquipamento, ref string[] dataFabricacao, ref string[] fabricantes)
        {
            int posicao = 0;
            string continuarRegistrando;
            int id = 0;
            

            for (posicao = 0; posicao < registro;)
            {
                idArray[posicao] = id;

                Console.ResetColor();
                Console.Clear();
                Console.Write("Digite o nome do equipamento: ");
                string nome = Console.ReadLine();
                nomesEquipamentos[posicao] =  nome;

                if (nome.Length < 6) //validação do tamanho do nome do produto
                {
                    Console.WriteLine();
                    Console.WriteLine("*Erro* Digite um nome que tenha mais de 6 caracteres");
                    Console.ReadLine();
                    break;
                }
                

                Console.Write("Digite o preço da aquisição: ");
                decimal preco = Convert.ToDecimal(Console.ReadLine());
                precoEquipamentos[posicao] = preco;

                Console.Write("Digite o numero de série do equipamento: ");
                string numeroSerie = (Console.ReadLine());
                numeroDeSerieEquipamento[posicao] = numeroSerie;

                Console.Write("Digite a data de fabricação (dia/mes/ano): ");
                string dataDefabricacao = Console.ReadLine();
                Convert.ToDateTime(dataDefabricacao);
                dataFabricacao[posicao] = dataDefabricacao; //Fazer validaçõs de data


                Console.Write("Digite o nome do fabricante: ");
                string fabricante = Console.ReadLine();
                fabricantes[posicao] = fabricante;


                Console.WriteLine();
                Console.WriteLine("Digite 1 para registrar outro produto");
                Console.WriteLine("Ou 2 para voltar para o menu");
                continuarRegistrando = Console.ReadLine();

                posicao++; //incrementa a posição
                id++;
                if (continuarRegistrando == "1")
                {
                    Console.WriteLine();
                    Console.WriteLine("Você registrou " + posicao + " equipamentos");
                    Console.ReadLine();
                    Console.WriteLine();
                    continue;
                }
                else if (continuarRegistrando == "2")
                {
                    Console.Clear();
                    Menu();
                    break;

                }
            }

        }

        static void VisualizarEquipamentos(int[] idArray, string[] nomesEquipamentos, string[] numeroDeSerieEquipamento, string[] fabricantes)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;

            for (int i = 0; i < nomesEquipamentos.Length; i++)
            {
                if (nomesEquipamentos[i] != null)
                {
                    Console.WriteLine("Id: " + idArray[i]);
                    Console.WriteLine("Nome: " + nomesEquipamentos[i]);
                    Console.WriteLine("Numero de série: " + numeroDeSerieEquipamento[i]);
                    Console.WriteLine("Fabricante: " + fabricantes[i]);
                    Console.WriteLine("*************************");
                    Console.WriteLine();
                    break;
                }
                if (nomesEquipamentos[i] == null)
                {
                    Console.WriteLine("Você não cadastrou nenhum equipamento - você voltará ao menu para cadastrar um equipamento");
                    Console.ReadLine();
                    Menu();
                    break;
                }
            }

            Console.ResetColor();
            Console.ReadLine();
            Console.Clear();

            //Menu();

        }

        static void EditarEquipamentos(ref int[] idArray, ref string[] nomesEquipamentos, ref decimal[] precoEquipamentos, ref string[] numeroDeSerieEquipamento, ref string[] dataFabricacao, ref string[] fabricantes)
        {
            int equipamentoEditado;

            VisualizarEquipamentos(idArray, nomesEquipamentos, numeroDeSerieEquipamento, fabricantes);
            Console.Clear();
            Console.ResetColor();



            bool continuar = true;
            while (continuar)// WHILE para repitir até o usuário digitar opção valida 
            {
                Console.Clear();
                Console.Write("Digite o Id do equipamento que deseja editar: ");
                equipamentoEditado = Convert.ToInt32(Console.ReadLine());

                int i = equipamentoEditado;
                for (i = equipamentoEditado; i == idArray[i]; i++) // FOR que verifica se o numero do item passado é verdadeiro
                {
                    if (equipamentoEditado == idArray[i] && nomesEquipamentos != null)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine();
                        Console.WriteLine("Digite os novos dados do equipamento");
                        Console.ResetColor();
                        Console.WriteLine();
                        Console.Write("Digite o nome do equipamento: ");
                        string nome = Console.ReadLine();

                        nomesEquipamentos[i] = nome;

                        if (nome.Length < 6) // validação do tamanho do nome do produto
                        {
                            Console.WriteLine();
                            Console.WriteLine("*Erro* Digite um nome que tenha mais de 6 caracteres");
                            Console.ReadLine();
                            break;
                        }

                        Console.Write("Digite o preço da aquisição: ");
                        decimal preco = Convert.ToDecimal(Console.ReadLine());
                        precoEquipamentos[i] = preco;

                        Console.Write("Digite o numero de série do equipamento: ");
                        string numeroSerie = (Console.ReadLine());
                        numeroDeSerieEquipamento[i] = numeroSerie;

                        Console.Write("Digite a data de fabricação (dia/mes/ano): ");
                        string dataDefabricacao = Console.ReadLine();
                        Convert.ToDateTime(dataDefabricacao);
                        dataFabricacao[i] = dataDefabricacao; // Fazer validaçõs de data


                        Console.Write("Digite o nome do fabricante: ");
                        string fabricante = Console.ReadLine();
                        fabricantes[i] = fabricante;

                        Console.ReadLine();

                        continuar = false;
                    }
                }

                for (i = equipamentoEditado; i != idArray[i]; i++) // validação objeto existente 
                {
                    if (i != idArray[i])
                    {
                        Console.WriteLine();
                        Console.WriteLine("O objeto que foi selecionado para edição não existe selecione um objeto valido");
                        Console.WriteLine();
                        Console.ReadLine();
                        break;

                    }
                }
            }

            Console.Clear();
            Menu();
        }

        static void ExcluirEquipamentos(ref int[] idArray, ref string[] nomesEquipamentos, ref decimal[] precoEquipamentos, ref string[] numeroDeSerieEquipamento, ref string[] dataFabricacao, ref string[] fabricantes, ref string[] nomesEquipamentosChamados)
        {
            int excluirEquipamentos;

            VisualizarEquipamentos(idArray, nomesEquipamentos, numeroDeSerieEquipamento, fabricantes);

            bool continuar = true;

            while (continuar) // WHILE para repitir até o usuário digitar opção valida 
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("Digite o Id do equipamento que deseja excluir: ");
                Console.ResetColor();
                excluirEquipamentos = Convert.ToInt32(Console.ReadLine());

                //nova sequencia de arrays removendo uma posição para remover item
                int[] novoArrayIdArray = new int[idArray.Length - 1];
                string[] novoArrayNomeEquipamento = new string[nomesEquipamentos.Length - 1];
                decimal[] novoArrayPrecoEquipamentos = new decimal[precoEquipamentos.Length - 1];
                string[] novoArrayNumeroDeSerieEquipamento = new string[numeroDeSerieEquipamento.Length - 1];
                string[] novoArrayDataFabricacao = new string[dataFabricacao.Length - 1];
                string[] novoArrayFabricantes = new string[fabricantes.Length - 1];
                int j = 0;


                   for(/*int i =0; nomesEquipamentos[i] == nomesEquipamentosChamados[i];i++*/ int i = excluirEquipamentos; i == idArray[i]; i++) 
                   {
                        if (nomesEquipamentos[i] == nomesEquipamentosChamados[i])
                        {
                            Console.WriteLine("O equipamento não pode ser excluido pois foi vinculado a um chamado");
                            Console.ReadLine();
                            continuar = false;
                            break;

                        }

                        if (nomesEquipamentos[i] != nomesEquipamentosChamados[i])
                        {
                            for (i = excluirEquipamentos; i == idArray[i]; i++)// FOR que verifica se o numero do item passado é verdadeiro
                            {


                                if (idArray[i] != excluirEquipamentos)
                                {
                                    novoArrayIdArray[j] = idArray[i];
                                    novoArrayNomeEquipamento[j] = nomesEquipamentos[i];
                                    novoArrayPrecoEquipamentos[j] = precoEquipamentos[i];
                                    novoArrayNumeroDeSerieEquipamento[j] = numeroDeSerieEquipamento[i];
                                    novoArrayDataFabricacao[j] = dataFabricacao[i];
                                    novoArrayFabricantes[j] = fabricantes[i];
                                    j++;
                                }
                                continuar = false;
                            }
                                idArray = novoArrayIdArray;
                                nomesEquipamentos = novoArrayNomeEquipamento;
                                precoEquipamentos = novoArrayPrecoEquipamentos;
                                numeroDeSerieEquipamento = novoArrayNumeroDeSerieEquipamento;
                                dataFabricacao = novoArrayDataFabricacao;
                                fabricantes = novoArrayFabricantes;


                        }
                   }


               

               
                for (int i = excluirEquipamentos; i != idArray[i]; i++) //validação objeto existente 
                {
                    if (i != idArray[i])
                    {
                        Console.WriteLine();
                        Console.WriteLine("O objeto que foi selecionado para edição não existe selecione um objeto valido");
                        Console.WriteLine();
                        Console.ReadLine();
                        break;

                    }
                }
            }
            Console.Clear();
            Menu();
        }

        #endregion


        #region Controle de chamados
        static void MenuControleDeChamados()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Clear();
            Console.WriteLine("          Controle de Chamados");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine(" * 1 * Para Registrar um novo Chamado *");
            Console.WriteLine(" * 2 * Para Visualizar os Chamados Cadastrados *");
            Console.WriteLine(" * 3 * Para Editar um Chamado *");
            Console.WriteLine(" * 4 * Para Excluir um Chamado *");
            Console.WriteLine(" * 0 * Para Sair para o menu de equipamentos *");
            Console.WriteLine("-------------------------------------------------");

            opcaoChamados = Console.ReadLine();
        }

        static void RegistrarChamados(ref int[] idArrayChamado, ref string[] tituloChamado, ref string[] descricaoChamado, ref string[] nomesEquipamentosChamados, ref string[] dataAberturaChamado, ref string[] nomesEquipamentos)
        {
           
            int posicaoChamado = 0;
            string continuarRegistrandoChamados;
            int idChamado = 0;

            for (posicaoChamado = 0; posicaoChamado < chamados;)
            {
                idArrayChamado[posicaoChamado] = idChamado;

                Console.ResetColor();
                Console.Clear();
                Console.Write("Digite o titulo do chamado: ");
                string titulo = Console.ReadLine();
                tituloChamado[posicaoChamado] = titulo;

                Console.Write("Digite a descrição do chamado: ");
                string descricao = Console.ReadLine();
                descricaoChamado[posicaoChamado] = descricao;

                Console.Write("Digite o nome do equipamento: ");
                string nomeEquipamentoChamado = Console.ReadLine();

                //if (nomeEquipamentoChamado != nomesEquipamentos.)// validar equipamento existente
                //{
                //    Console.WriteLine("O equipamento não existe Digite o nome de um equipamento existente na lista");
                //    Console.ReadLine();
                //    break;
                //}

                //else if (nomeEquipamentoChamado == nomesEquipamentos[nome])
               // {
                    nomesEquipamentosChamados[posicaoChamado] = nomeEquipamentoChamado;
                // continue;
                //}

                Console.Write("Digite a data de abertura do chamado (dia/mes/ano): ");
                string dataDeAbertura = Console.ReadLine();
                Convert.ToDateTime(dataDeAbertura);
                dataAberturaChamado[posicaoChamado] = dataDeAbertura; //Fazer validaçõs de data

                Console.WriteLine();
                Console.WriteLine("Digite 1 para registrar outro chamado");
                Console.WriteLine("Ou 2 para voltar para o menu de chamados");

                continuarRegistrandoChamados = Console.ReadLine();
                posicaoChamado++; //incrementa a posição
                idChamado++;

                if (continuarRegistrandoChamados == "1")
                {
                    Console.WriteLine();
                    Console.WriteLine("Você registrou " + posicaoChamado + " Chamados");
                    Console.ReadLine();
                    Console.WriteLine();
                    continue;
                }
                else if (continuarRegistrandoChamados == "2")
                {
                    Console.Clear();
                    MenuControleDeChamados(); 
                    break;
                }
            }
        }

       static void VisualizarChamados( int[] idArrayChamado,  string[] tituloChamado,  string[] nomesEquipamentosChamados,  string[] dataAberturaChamado)
       {
                
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;

            for (int i = 0; i < tituloChamado.Length; i++)
            {
               

                if (tituloChamado[i] != null)
                {
                    Console.WriteLine("Id Chamado: " + idArrayChamado[i]);
                    Console.WriteLine("Titulo: " + tituloChamado[i]);
                    Console.WriteLine("Equipamento: " + nomesEquipamentosChamados[i]);
                    Console.WriteLine("Data de Abertura Do Chamado: " + dataAberturaChamado[i]);

                    string strDataAbertura = dataAberturaChamado[i];
                    DateTime dataAbertura = Convert.ToDateTime(strDataAbertura);
                    TimeSpan diferenca = DateTime.Today - dataAbertura;
                    double dias = diferenca.TotalDays;
                    Console.WriteLine("Dias em aberto: " + dias);
                    Console.WriteLine("*************************");
                    Console.WriteLine();
                    break;
                }
                if(tituloChamado[i] == null)
                {
                    Console.WriteLine("Você não cadastrou nenhum equipamento - você voltará ao menu para cadastrar um equipamento");
                    Console.ReadLine();
                    Menu();
                    break;
                }
            }

            Console.ResetColor();
            Console.ReadLine();
            Console.Clear();
       }

        static void EditarChamados(ref int[] idArrayChamado, ref string[] tituloChamado, ref string[] descricaoChamado, ref string[] nomesEquipamentosChamados, ref string[] dataAberturaChamado, ref string[] nomesEquipamentos)
        {
            int chamadoEditado;

            VisualizarChamados(idArrayChamado, tituloChamado, nomesEquipamentosChamados, dataAberturaChamado);
            Console.Clear();
            Console.ResetColor();

            bool continuar = true;
            while (continuar)// WHILE para repitir até o usuário digitar opção valida 
            {
                Console.Clear();
                Console.Write("Digite o Id do Chamado que deseja editar: ");
                chamadoEditado = Convert.ToInt32(Console.ReadLine());

                int i = chamadoEditado;
                for (i = chamadoEditado; i == idArrayChamado[i]; i++) // FOR que verifica se o numero do item passado é verdadeiro
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine();
                    Console.WriteLine("Digite os novos dados do chamado");
                    Console.ResetColor();
                    Console.WriteLine();
                    Console.Write("Digite o titulo do chamado: ");
                    string titulo = Console.ReadLine();
                    tituloChamado[i] = titulo;

                    Console.Write("Digite a descrição do chamado: ");
                    string descricao = Console.ReadLine();
                    descricaoChamado[i] = descricao;

                    Console.Write("Digite o nome do equipamento: ");
                    string nomeEquipamentoChamado = Console.ReadLine();

                    //if (nomeEquipamentoChamado != nomesEquipamentos.)// validar equipamento existente
                    //{
                    //    Console.WriteLine("O equipamento não existe Digite o nome de um equipamento existente na lista");
                    //    Console.ReadLine();
                    //    break;
                    //}

                    //else if (nomeEquipamentoChamado == nomesEquipamentos[nome])
                    // {
                    nomesEquipamentosChamados[i] = nomeEquipamentoChamado;
                    // continue;
                    //}

                    Console.Write("Digite a data de abertura do chamado (dia/mes/ano): ");
                    string dataDeAbertura = Console.ReadLine();
                    Convert.ToDateTime(dataDeAbertura);
                    dataAberturaChamado[i] = dataDeAbertura; //Fazer validaçõs de data

                    Console.ReadLine();

                    continuar = false;
                    MenuControleDeChamados();
                }

                for (i = chamadoEditado; i != idArrayChamado[i]; i++) // validação objeto existente 
                {
                    if (i != idArrayChamado[i])
                    {
                        Console.WriteLine();
                        Console.WriteLine("O Chamado que foi selecionado para edição não existe selecione um chamado valido");
                        Console.WriteLine();
                        Console.ReadLine();
                        break;

                    }
                }
            }
        }

        static void ExcluirChamados(ref int[] idArrayChamado, ref string[] tituloChamado, ref string[] descricaoChamado, ref string[] nomesEquipamentosChamados, ref string[] dataAberturaChamado, ref string[] nomesEquipamentos)
        {
            int excluirChamados;
            
            VisualizarChamados(idArrayChamado, tituloChamado, nomesEquipamentosChamados, dataAberturaChamado);
            Console.Clear();
            Console.ResetColor();

            bool continuar = true;

            while (continuar) // WHILE para repitir até o usuário digitar opção valida 
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("Digite o Id do chamado que deseja excluir: ");
                Console.ResetColor();
                excluirChamados = Convert.ToInt32(Console.ReadLine());

                //nova sequencia de arrays removendo uma posição para remover item
                int[] novoArrayIdArrayChamado = new int[idArrayChamado.Length - 1];
                string[] novoArrayTituloChamado = new string[tituloChamado.Length - 1];
                string[] novoArrayNomesEquipamentosChamados = new string[nomesEquipamentosChamados.Length - 1];
                string[] novoArrayDataAberturaChamado = new string[dataAberturaChamado.Length - 1];
               

                int j = 0;
               
                for (int i = excluirChamados; i == idArrayChamado[i]; i++)// FOR que verifica se o numero do item passado é verdadeiro
                {
                    if (idArrayChamado[i] != excluirChamados)
                    {
                        novoArrayIdArrayChamado[j] = idArrayChamado[i];
                        novoArrayTituloChamado[j] = tituloChamado[i];
                        novoArrayNomesEquipamentosChamados[j] = nomesEquipamentosChamados[i];
                        novoArrayDataAberturaChamado[j] = dataAberturaChamado[i];
                       
                        j++;
                    }
                    continuar = false;
                }

                idArrayChamado = novoArrayIdArrayChamado;
                tituloChamado = novoArrayTituloChamado;
                nomesEquipamentosChamados = novoArrayNomesEquipamentosChamados;
                dataAberturaChamado = novoArrayDataAberturaChamado;
               

                for (int i = excluirChamados; i != idArrayChamado[i]; i++) //validação objeto existente 
                {
                    if (i != idArrayChamado[i])
                    {
                        Console.WriteLine();
                        Console.WriteLine("O Chamado que foi selecionado para edição não existe selecione um chamado valido");
                        Console.WriteLine();
                        Console.ReadLine();
                        break;

                    }
                }
            }
            Console.Clear();
            MenuControleDeChamados();


        }



        #endregion
    }
}
   
