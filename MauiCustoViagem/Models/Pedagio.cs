﻿using SQLite;

namespace MauiCustoViagem.Models
{
    public class Pedagio
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Origem { get; set; }
        public string Destino { get; set; }
        public double Distancia { get; set; }
        public double Rendimento { get; set; }
        public double Preco { get; set; }

        //public double Custo { get => Quantidade * Preco; }
    }
}
