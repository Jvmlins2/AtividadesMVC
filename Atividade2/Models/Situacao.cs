using System;
using System.Collections.Generic;

namespace Atividade2.Models;

public partial class Situacao
{
    public int SituacaoID { get; set; }

    public string? Nome { get; set; }

    public virtual ICollection<Produto> Produtos { get; set; } = new List<Produto>();
}
