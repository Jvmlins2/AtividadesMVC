using System;
using System.Collections.Generic;

namespace AtividadeBiblioteca.Models;

public partial class Livro
{
    public int LivroID { get; set; }

    public string? Nome { get; set; }

    public string? Autor { get; set; }

    public string? Descricao { get; set; }

    public DateTime? DataPublicacao { get; set; }

    public byte[]? Imagem { get; set; }

    public Guid? UsuarioID { get; set; }

    public virtual Usuario? Usuario { get; set; }
}
