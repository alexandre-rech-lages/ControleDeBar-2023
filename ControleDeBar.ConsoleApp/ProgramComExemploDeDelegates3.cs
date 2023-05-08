using System.Collections;

namespace ControleDeBar.ConsoleApp
{
    public class ProgramComExemploDeDelegates3
    {
        static void Main(string[] args)
        {
            //listas, herança, polimorfismo, generic, listas genéricas e delegate

            Aluno aluno01 = new Aluno(12, "Tiago");
            Aluno aluno02 = new Aluno(13, "João");
            Aluno aluno03 = new Aluno(2, "Arthur");
            Aluno aluno04 = new Aluno(5, "Camila");

            List<Aluno> alunos = new List<Aluno>();

            alunos.Add(aluno01);
            alunos.Add(aluno02);
            alunos.Add(aluno03);
            alunos.Add(aluno04);

            MostrarAlunos(alunos);

            ExcluirAluno(alunos);
        }

        private static void ExcluirAluno(List<Aluno> alunos)
        {
            Console.Write("Digite o nome do aluno para excluir: ");
            string nomeSelecionado = Console.ReadLine();

            //Predicate<Aluno> condicao = delegate(Aluno aluno) { 
            //    return aluno.id == idSelecionado;
            //};

            //expressão lambda
            Aluno aluno = alunos.Find(a => a.nome == nomeSelecionado);

            if (aluno != null)
            {
                alunos.Remove(aluno); 
            }

        }

        private static void MostrarAlunos(List<Aluno> alunos)
        {

            //métodos anônimos
            //Comparison<Aluno> condicao = delegate(Aluno x, Aluno y)
            //{                
            //    if (x.id > y.id)
            //        return 1;

            //    else if (x.id < y.id)
            //        return -1;

            //    else
            //        return 0;
            //}; 

            //expressão lambda


            alunos.Sort((x, y) => y.id.CompareTo(x.id));


            foreach (Aluno aluno in alunos)
            {
                Console.WriteLine(aluno.id + ", " + aluno.nome);
            }
        }
    }

    public class Aluno //: IComparable
    {
        public int id;
        public string nome;

        public Aluno(int id, string nome)
        {
            this.id = id;
            this.nome = nome;
        }

        //public int CompareTo(object? obj)
        //{
        //    Aluno a = (Aluno)obj;

        //    if (id > a.id)
        //        return 1;
        //    else if (id < a.id)
        //        return -1;
        //    else
        //        return 0;
        //}
    }
}
