﻿using ControleDeBar.ConsoleApp.Compartilhado;

namespace ControleDeBar.ConsoleApp.ModuloGarcom
{
    public class RepositorioGarcom : RepositorioBase<Garcom>
    {
        public RepositorioGarcom(List<Garcom> listaGarcom)
        {
            this.listaRegistros = listaGarcom;
        }
    }
}
