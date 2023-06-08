using SQLite;

namespace Models.TbModels;

[Table("tbusuario")]
public class UsuarioModel
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }
    [Column("nome")]
    public string Nome { get; set; }
    [Column("cpf")]
    public string Cpf { get; set; }
    [Column("email")]
    public string Email { get; set; }
    [Column("senha")]
    public string Senha { get; set; }
}
