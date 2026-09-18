using System;
using System.Collections.Generic;

namespace Atividade3.Models;

public partial class Alimento
{
    public int AlimentoID { get; set; }

    public string? Nome { get; set; }

    public double? Preco { get; set; }

    public string? Descricao { get; set; }
}
