﻿using System.Collections;
using System.Collections.Generic;

namespace ControleDeBar.ConsoleApp
{
    internal class ProgramComExemplosGeneric1
    {
        static void Main2(string[] args)
        {
            Laranja laranja = new Laranja();
            laranja.tipoLaranja = TipoLaranja.Bahia;
            laranja.cor = CorFrutas.Amarelo;

            Limao limao = new Limao();
            limao.tipoLimao = TipoLimao.Cravo;
            limao.cor = CorFrutas.Laranjado;

            Maca maca = new Maca();
            maca.cor = CorFrutas.Vermelho;

            Caixa<Laranja> caixaDeLaranja = new Caixa<Laranja>();

            caixaDeLaranja.Guardar(laranja);

            Caixa<Limao> caixaDeLimaoo = new Caixa<Limao>();

            caixaDeLimaoo.Guardar(limao);
            caixaDeLimaoo.Guardar(limao);
            caixaDeLimaoo.Guardar(limao);
            caixaDeLimaoo.Guardar(limao);

            Caixa<Maca> caixaMaca = new Caixa<Maca>();
            caixaMaca.Guardar(maca);

            Laranja laranjaSelecionada = caixaDeLaranja.PegarUmaFrutaAleatoria();
            laranjaSelecionada.tipoLaranja = TipoLaranja.Umbigo;

            Limao limaoSelecionado = caixaDeLimaoo.PegarUmaFrutaAleatoria();
             
            ConsoleColor corTeste = Teste();

            switch (corTeste)
            {
                case ConsoleColor.Black:
                    break;
                case ConsoleColor.DarkBlue:
                    break;
                case ConsoleColor.DarkGreen:
                    break;
                case ConsoleColor.DarkCyan:
                    break;
                case ConsoleColor.DarkRed:
                    break;
                case ConsoleColor.DarkMagenta:
                    break;
                case ConsoleColor.DarkYellow:
                    break;
                case ConsoleColor.Gray:
                    break;
                case ConsoleColor.DarkGray:
                    break;
                case ConsoleColor.Blue:
                    break;
                case ConsoleColor.Green:
                    break;
                case ConsoleColor.Cyan:
                    break;
                case ConsoleColor.Red:
                    break;
                case ConsoleColor.Magenta:
                    break;
                case ConsoleColor.Yellow:
                    break;
                case ConsoleColor.White:
                    break;
            }
        }

        private static ConsoleColor Teste()
        {
            throw new NotImplementedException();
        }

        public class Caixa<T>
    {        
        List<T> frutas = new List<T>();

        public void Guardar(T fruta)
        {
            frutas.Add(fruta);
        }

        public T PegarUmaFrutaAleatoria()
        {
            int indice = new Random().Next(0, frutas.Count);

            return frutas[indice];
        }
    }    
    
    public class Fruta
    {
        public string nome;
        public int peso;
        public CorFrutas cor;
    }

    public enum CorFrutas
    {
        Amarelo, Vermelho, Verde, Laranjado
    }

    public class Laranja : Fruta
    {
        public TipoLaranja tipoLaranja;
    }

    public enum TipoLaranja
    {
        Bahia, Lima, Umbigo
    }

    public class Limao : Fruta
    {
        public TipoLimao tipoLimao;
    }

    public enum TipoLimao
    {
        Taiti, Cravo, Siciliano
    }

    public class Maca : Fruta
    {

    }


    }
}