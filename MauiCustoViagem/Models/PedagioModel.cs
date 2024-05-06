using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiCustoViagem.Models
{
    public class PedagioModel
    {
        public int Id { get; set; }
        public string Local {  get; set; }
        public double Valor {  get; set; }
        public int IdViagem { get; set; }
    }
}
