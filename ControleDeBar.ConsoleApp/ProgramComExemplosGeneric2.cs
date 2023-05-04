namespace ControleDeBar.ConsoleApp
{
    internal class ProgramComExemplosGeneric2
    {
        static void Main(string[] args)
        {
            Cachorro cachorroMacho = new Cachorro();
            Cachorro cachorroFemea = new Cachorro();

            Cachorro filhoteCachorro = Cruzar(cachorroMacho, cachorroFemea);

            Gato gatoMacho = new Gato(); 
            Gato gatoFemea = new Gato();

            Gato filhoteGato = Cruzar(gatoMacho, gatoFemea);
        }

        private static T Cruzar<T>(T macho, T femea) where T : Animal, new()
        {
            T animal = new T();

            animal.pai = macho;
            animal.mae = femea;

            return animal;
        }

        private static Gato CruzarGatos(Gato gatoMacho, Gato gatoFemea)
        {
            Gato gato = new Gato();
            gato.pai = gatoMacho;
            gato.mae = gatoFemea;

            return gato;                 
        }

        private static Cachorro CruzarCachorros(Cachorro cachorroMacho, Cachorro cachorroFemea)
        {
            Cachorro cachorro = new Cachorro();
            cachorro.pai = cachorroMacho;
            cachorro.mae = cachorroFemea;

            return cachorro;
        }

    }

    public class Animal
    {
        public Animal pai;
        public Animal mae;
    }

    public class Cachorro : Animal
    {
       
    }

    public class Gato : Animal
    {
       
    }

}
