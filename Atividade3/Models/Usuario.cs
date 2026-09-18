using System;
using System.Collections.Generic;

namespace Atividade3.Models;

public partial class Usuario
{
    public Guid UsuarioID { get; set; }

    public string? Nome { get; set; }

    public string? Email { get; set; }

    public byte[] Senha { get; set; } = null!;
}
