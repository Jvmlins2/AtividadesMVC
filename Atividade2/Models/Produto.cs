using System;
using System.Collections.Generic;

namespace Atividade2.Models;

public partial class Produto
{
    public int ProdutoID { get; set; }

    public string? Nome { get; set; }

    public int? Quantidade { get; set; }

    public int? SituacaoID { get; set; }

    public virtual Situacao? Situacao { get; set; }
}
