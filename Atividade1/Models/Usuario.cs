using System;
using System.Collections.Generic;

namespace AtividadeBiblioteca.Models;

public partial class Usuario
{
    public Guid UsuarioID { get; set; }

    public string? Nome { get; set; }

    public string? Email { get; set; }

    public byte[] Senha { get; set; } = null!;

    public virtual ICollection<Livro> Livros { get; set; } = new List<Livro>();
}
